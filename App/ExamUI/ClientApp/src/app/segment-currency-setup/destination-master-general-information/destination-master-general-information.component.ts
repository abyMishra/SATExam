import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
// import { MatTableDataSource } from '@angular/material/table'
import { first } from 'rxjs';
import { DestinationMasterData } from '../../models/destination-master-model';
import { DestinationMasterService } from '../../services/destination-master.service';
import { ContentService } from 'src/app/services/content.service';
import { Router } from '@angular/router';
import { ConfirmDialogComponent, ConfirmDialogModel } from '../../confirm-dialog/confirm-dialog.component';
import { MatDialog } from '@angular/material/dialog';


const COLUMNS_SCHEMA = [
  {
    key: "id",
    type: "text"
  },
  {
    key: "ageDetails",
    type: "text",
    label: "Age Details"
  },
  {
    key: "type",
    type: "text",
    label: "Type"
  },
  {
    key: "currency",
    type: "text",
    label: "Currency"
  },
  {
    key: "delete",
    type: "text",
    label: "Delete"
  }
]

@Component({
  selector: 'app-destination-master-general-information',
  templateUrl: './destination-master-general-information.component.html',
  styleUrls: ['./destination-master-general-information.component.css']
})
export class DestinationMasterGeneralInformationComponent implements OnInit {
  countries: any;
  numberList: any;
  currencies: any;
  destinationGeneralInformationForm!: FormGroup;
  taxDetailsFormGroup!: FormGroup;
  destinationTaxInformation: any = [];
  isEdit = false;
  

  destinationMasterData: DestinationMasterData = {
    Id: undefined,
    countryDetailsID: '',
    destinationName: '',
    destinationCode: '',
    destinationDescription: '',
    taxDetails: [],
    isActive: false,
    location: {
      longitude: '',
      latitude: '',
      radius: '',
      area: '',
      population: 0
    },
    destinationImage: [],
    airport: [],
    district: [],
    thingsToDo: {
      urlSlug: '',
      pageURL: '',
      canonicalURL: '',
      imageURL: '',
      subText: '',
      description: ''
    },
    thingsToSee: {
      urlSlug: '',
      pageURL: '',
      canonicalURL: '',
      imageURL: '',
      subText: '',
      description: ''
    },
    auditDetails: {
      created_by: '',
      created_date: '',
      updated_by: '',
      updated_date: ''
    },
    cultureInfo: {
      country: '',
      cultureName: '',
      writingSystem: '',
      timeZone: '',
      format: ''
    },
    highLights: {
      description: '',
      isActive: false
    }
  };

  displayedColumns: string[] = COLUMNS_SCHEMA.map(col => col.key);
  dataSource = this.destinationTaxInformation;
  columnsSchema: any = COLUMNS_SCHEMA;

  country!: FormControl;
  destinationName!: FormControl;
  destinationCode!: FormControl;
  destinationDescription!: FormControl;

  latitude!: FormControl;
  longitude!: FormControl;
  radius!: FormControl;
  status!: FormControl;
  formSubmitted = false;
  message: string | undefined;
  loading: boolean | undefined;
  result: any;

  constructor(private fb: FormBuilder, 
              private readonly changeDetectorRef: ChangeDetectorRef, 
              private destinationMasterService: DestinationMasterService,
              private contentService: ContentService,
              private router: Router,
              public dialog: MatDialog
              ) { }
  ngOnInit(): void {
    this.countries = [
      { value: 'Select Country', viewValue: 'Select Country' },
      { value: 'Afghanistan', viewValue: 'Afghanistan' },
      { value: 'Albania', viewValue: 'Albania' },
      { value: 'Algeria', viewValue: 'Algeria' }
    ];
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
    this.numberList = new Array(100).fill(0).map((x, i) => i + 1);
    this.contentService.getAllCurrencies()
    .pipe(first())
    .subscribe({
      next: (response: any) => {
        this.currencies = response;
      },
      error: error => {
        this.message = "Failed!"
        this.loading = false;
      }
    });


    this.addRow();

    this.destinationGeneralInformationForm = this.fb.group({
      country: new FormControl('', [Validators.required]),
      destinationName: new FormControl('', [Validators.required]),
      destinationCode: new FormControl(''),
      destinationDescription: new FormControl(''),
      taxDetailsFormGroup: this.taxDetailsFormGroup,
      latitude: new FormControl(''),
      longitude: new FormControl(''),
      radius: new FormControl(''),
      status: new FormControl(''),
    });


      this.destinationMasterData = sessionStorage.destinationMasterToEdit != undefined ? JSON.parse(sessionStorage.destinationMasterToEdit) : this.destinationMasterData;
      console.log(this.destinationMasterData)
      if(this.destinationMasterData.destinationName != '') {
        this.isEdit = true;
        this.destinationGeneralInformationForm.controls['country'].setValue(this.destinationMasterData.countryDetailsID);
        this.destinationGeneralInformationForm.controls['destinationName'].setValue(this.destinationMasterData.destinationName);
        this.destinationGeneralInformationForm.controls['destinationCode'].setValue(this.destinationMasterData.destinationCode);
        this.destinationGeneralInformationForm.controls['destinationDescription'].setValue(this.destinationMasterData.destinationDescription);
        this.destinationGeneralInformationForm.controls['longitude'].setValue(this.destinationMasterData.location.longitude);
        this.destinationGeneralInformationForm.controls['latitude'].setValue(this.destinationMasterData.location.latitude);
        this.destinationGeneralInformationForm.controls['radius'].setValue(this.destinationMasterData.location.area);
        this.destinationGeneralInformationForm.controls['taxDetailsFormGroup'].setValue({taxDetailsArray: this.destinationMasterData.taxDetails});
        this.destinationGeneralInformationForm.controls['status'].setValue(this.destinationMasterData.isActive ? 'active' : 'inactive');
      
    }
  }

  submit() {

    this.formSubmitted = true;
    if (this.destinationGeneralInformationForm.valid) {
      this.destinationMasterData.countryDetailsID = this.destinationGeneralInformationForm.controls['country'].value;
      this.destinationMasterData.destinationName = this.destinationGeneralInformationForm.controls['destinationName'].value;
      this.destinationMasterData.destinationCode = this.destinationGeneralInformationForm.controls['destinationCode'].value;
      this.destinationMasterData.destinationDescription = this.destinationGeneralInformationForm.controls['destinationDescription'].value;
      this.destinationMasterData.location.longitude = this.destinationGeneralInformationForm.controls['longitude'].value;
      this.destinationMasterData.location.latitude = this.destinationGeneralInformationForm.controls['latitude'].value;
      this.destinationMasterData.location.area =this.destinationGeneralInformationForm.controls['radius'].value;
      this.destinationMasterData.taxDetails = this.destinationGeneralInformationForm.controls['taxDetailsFormGroup'].value['taxDetailsArray'];
      this.destinationMasterData.isActive = this.destinationGeneralInformationForm.controls['status'].value != undefined ? (this.destinationGeneralInformationForm.controls['status'].value == 'active' ? true : false ): false;
      if(!this.isEdit) {
        this.addGeneralInformation();
        this.router.navigate(['/destination-master-view'])
      } else {
        this.updateGeneralInformation();
        sessionStorage.removeItem('destinationMasterToEdit');
        this.router.navigate(['/destination-master-view'])
      }
    }
  }

  addGeneralInformation() {
    console.log('destinationMasterData: ', this.destinationMasterData);
    this.destinationMasterService.addDestinationMasterGeneralInformation(this.destinationMasterData)
      .pipe(first())
      .subscribe({
        next: (response: any) => {
          
          this.destinationMasterData = response;
          this.destinationMasterData.Id = response['id'];
          this.changeDetectorRef.detectChanges();
          this.isEdit = true;
        },
        error: error => {
          this.message = "Failed!"
          this.loading = false;
        }
      });
  }

  updateGeneralInformation() {
    console.log('destinationMasterData for update: ', this.destinationMasterData);
    this.destinationMasterService.updateGeneralInformation(this.destinationMasterData)
      .pipe(first())
      .subscribe({
        next: (response: any) => {
         
          this.destinationMasterData = response;
          this.changeDetectorRef.detectChanges();
          this.isEdit = true;
        },
        error: error => {
          this.message = "Failed!"
          this.loading = false;
        }
      });
  }

  addRow() {
    //console.log(this.dataSource.length);
    const newRow = { "id": this.dataSource.length, "ageDetails": "", "type": "", "currency": "", "delete": "" }

    if (this.taxDetailsFormGroup == undefined) {
      this.taxDetailsFormGroup = this.fb.group({
        taxDetailsArray: this.fb.array([
          this.fb.group({
            minAge: new FormControl(0),
            maxAge: new FormControl(0),
            taxType: new FormControl(''),
            country: new FormControl(''),
            taxRate: new FormControl(''),
            currencyDetails: new FormControl(''),
            // id: new FormControl('')
          })
        ])
      });
    } else {
      //const control = <FormArray>this.taxDetailsFormGroup.controls['taxDetailsArray'];
      this.taxDetailsArray.push(this.fb.group({
        minAge: new FormControl(0),
        maxAge: new FormControl(0),
        taxType: new FormControl(''),
        country: new FormControl(''),
        taxRate: new FormControl(''),
        currencyDetails: new FormControl(''),
        // id: new FormControl('')
      }));
    }

    this.dataSource = [...this.dataSource, newRow];
  }

  get taxDetailsArray(): FormArray {
    return this.taxDetailsFormGroup.get('taxDetailsArray') as FormArray;
  }

  removeRow(id: number) {
    const message = `Are you sure you want to delete this tax Information?`;
    const dialogData = new ConfirmDialogModel("Confirm Action", message);
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      maxWidth: "400px",
      data: dialogData
    });

    dialogRef.afterClosed().subscribe(dialogResult => {
      this.result = dialogResult;
      if(this.result) {
        this.deleteTaxInfo(id);
      }
    });
  }

  deleteTaxInfo(id: number) {
    const ObjTaxInfo = this.taxDetailsFormGroup.controls['taxDetailsArray'].value[id];
    console.log('ObjTaxInfo: ', ObjTaxInfo);
    const destinationId = this.destinationMasterData.id;
    console.log('destination ID: ', destinationId);
    if(destinationId != undefined) {
    this.destinationMasterService.deleteDestinationTaxInfo(destinationId, ObjTaxInfo)
      .pipe(first())
      .subscribe({
        next: (response: any) => {
          console.log('deleted obj: ', ObjTaxInfo);
          this.dataSource = this.dataSource.filter((u: { id: number; }) => u.id !== id);
          this.taxDetailsArray.removeAt(id);
          this.changeDetectorRef.detectChanges();
        },
        error: error => {
          this.message = "Failed!"
          this.loading = false;
          return;
        }
      });
    } else {

    }
   
  }
}
