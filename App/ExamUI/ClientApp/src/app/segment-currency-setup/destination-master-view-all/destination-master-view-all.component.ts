import { SelectionModel } from '@angular/cdk/collections';
import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Session } from 'inspector';
import { first } from 'rxjs';
import { DestinationMasterData } from 'src/app/models/destination-master-model';
import { ContentService } from 'src/app/services/content.service';
import { DestinationMasterService } from 'src/app/services/destination-master.service';

const COLUMNS_SCHEMA = [
  {
    key: "id",
    type: "text"
  },
  {
    key: "destinationName",
    type: "text",
    label: "Destination"
  },
  {
    key: "destinationCode",
    type: "text",
    label: "Destination Code"
  },
  {
    key: "countryDetailsID",
    type: "text",
    label: "Country"
  },
  {
    key: "segment",
    type: "text",
    label: "Segment"
  },
  {
    key: "action",
    type: "text",
    label: "Action"
  },
  {
    key: "isActive",
    type: "text",
    label: "Status"
  }
]

@Component({
  selector: 'app-destination-master-view-all',
  templateUrl: './destination-master-view-all.component.html',
  styleUrls: ['./destination-master-view-all.component.css']
})
export class DestinationMasterViewAllComponent implements OnInit {
 
  Updatedby = 'Andria Dsouza';
  UpdatedOn = '09/05/2023';
  countries: any;
  searchText = '';
  country = '';
  // isEdit = false;
  displayedColumns: string[] = COLUMNS_SCHEMA.map(col => col.key);
  
  destinationMasterList: DestinationMasterData[] = [];
  dataSource: MatTableDataSource<DestinationMasterData>;
  message: string | undefined;
  loading: boolean | undefined;
  pageSize = 5;

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort)
  sort!: MatSort;

  selection = new SelectionModel<any>(true, []);
  // selection:any = [];
  selectionAmount = 0;
  
  constructor(private readonly changeDetectorRef: ChangeDetectorRef, 
    private destinationMasterService: DestinationMasterService,
    private contentService: ContentService,
    private router: Router
    ) { 
      this.dataSource = new MatTableDataSource(this.destinationMasterList);
    }

  ngOnInit(): void {
    // this.contentService.getAllCountries()
    // .pipe(first())
    // .subscribe({
    //   next: (response: any) => {
    //     console.log('countries: ', response);
    //     this.countries = response;
    //   },
    //   error: error => {
    //     this.message = "Failed!"
    //     this.loading = false;
    //   }
    // });
    this.destinationMasterList = [];
    this.countries = [
      { value: 'Select Country', viewValue: 'Select Country' },
      { value: 'Afghanistan', viewValue: 'Afghanistan' },
      { value: 'Albania', viewValue: 'Albania' },
      { value: 'Algeria', viewValue: 'Algeria' }
    ];
    this.destinationMasterService.getAllDestinations()
    .pipe(first())
    .subscribe({
      next: (response: any) => {
        // console.log('destinations: ', response);
        this.destinationMasterList = response;
        this.dataSource = new MatTableDataSource(this.destinationMasterList);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
        this.changeDetectorRef.detectChanges();
      },
      error: error => {
        this.message = "Failed!"
        this.loading = false;
      }
    });
  }

  edit(row: any) {
    sessionStorage.setItem('destinationMasterToEdit', JSON.stringify(row));
    this.router.navigate(['/destination-master', {queryParams: {action: 'edit'}}])
    
  }

  delete() {
    // data to delete
    console.log('to delete data: ', this.selection.selected);
    this.selection.selected.forEach((obj,index) => {
      this.destinationMasterService.deleteDestination(obj.id)
      .pipe(first())
      .subscribe({
        next: (response: any) => {
          console.log('deleted id: ', obj.id);
          this.destinationMasterList = this.destinationMasterList.filter((item, innerIndex) => innerIndex !== index);
          this.dataSource =  new MatTableDataSource(this.destinationMasterList); 
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;
          
          this.selectionAmount -= 1;
          this.changeDetectorRef.detectChanges();
        },
        error: error => {
          this.message = "Failed!"
          this.loading = false;
          return;
        }
      });
    });
    this.selection.clear();
  }

  /** Whether the number of selected elements matches the total number of rows. */
isAllSelected() {
  const numSelected = this.selection.selected.length;
  const numRows = this.dataSource.data.length;
  return numSelected == numRows;
}

/** Selects all rows if they are not all selected; otherwise clear selection. */
toggleAllRows() {
  this.isAllSelected() ?
      this.selection.clear() :
      this.dataSource.data.forEach(row => this.selection.select(row));
      this.selectionAmount = this.selection.selected.length;
}

  // selectRows() {
  //   for (let index = 0; index < this.pageSize; index++) {
  //     this.selection.select(this.dataSource.data[index]);
  //     this.selectionAmount = this.selection.selected.length;
  //   }
  // }

  onRowSelection (event: any, row: any) {
    event ? this.selection.toggle(row) : null
    if(this.selection.isSelected(row)) {
      this.selectionAmount += 1;
    } else {
      this.selectionAmount -= 1;
    }
  }

}
