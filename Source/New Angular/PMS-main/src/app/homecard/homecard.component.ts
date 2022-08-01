import { Component, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { Toaster } from 'ngx-toast-notifications';


@Component({
  selector: 'app-homecard',
  templateUrl: './homecard.component.html',
  styleUrls: ['./homecard.component.css']
})
export class HomecardComponent implements OnInit {

  constructor(private service: UserserviceService,private toaster:Toaster) { }
  filterDetails:any;
  page:number=1;
  filter:any={
    designationId:0,
    domainId:0,
    technologyId:0,
    collegeId:0,
    maxExp:0,
    minExp:0,
    profileStatusId:0,
    username:''
  }
  ngOnInit(): void {
    this.getProfileByFilters();
  }
  getProfileByFilters()
  {
    console.warn(this.filter);
    this.service.getProfileByFilters(this.filter).subscribe((data:any)=>
    {
      this.filterDetails=data;
      console.warn(this.filterDetails);
    });
  }
  editToUpdate(){
    this.toaster.open({ text: 'Request to update sent successfully via mail', position: 'top-center', type: 'success' })
  }

}
