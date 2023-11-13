import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Session } from 'inspector';

@Component({
  selector: 'app-destination-master',
  templateUrl: './destination-master.component.html',
  styleUrls: ['./destination-master.component.css']
})
export class DestinationMasterComponent implements OnInit {

  Createdby: string = "";
  CreatedOn: string = "";
  Updatedby: string = "";
  UpdatedOn: string = "";
  action: string = 'create';
  isEdit = false;

  constructor(private route:ActivatedRoute,
    private router: Router){}

  ngOnInit(): void {
    this.Createdby = "Andria Dsouza";
    this.CreatedOn = "09/05/2023";
    this.Updatedby = "Andria Dsouza";
    this.UpdatedOn = "09/05/2023";
    // this.viewAll = sessionStorage.getItem('viewAll') != undefined ? (sessionStorage.getItem('viewAll') == 'true' ? true : false) : this.viewAll;
    this.action = this.route.snapshot.params['action'];
    if(this.action == 'edit')
      this.isEdit = true;
    else
      this.isEdit = false;
  }

  back() {
    // this.viewAll = true;
    // sessionStorage.setItem('viewAll', 'true') 
    this.router.navigate(['destination-master-view'])
  }
}
