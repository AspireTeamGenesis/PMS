import { Component, Input, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { FormGroup,FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Toaster } from 'ngx-toast-notifications';
@Component({
  selector: 'app-filtercard',
  templateUrl: './filtercard.component.html',
  styleUrls: ['./filtercard.component.css']
})
export class FiltercardComponent implements OnInit {

  @Input() 
  public filterDetails:any[]=[]
  length:any;
  totalLength:any;
  profileId:number;
  page:number=1;
  educationDetails:any;
  profileIdDetails:any;
  arraylength:any;
  // profileId=7;
  // hello:100;
  constructor(private FB: FormBuilder,private service: UserserviceService,private http: HttpClient, private route : Router,private toaster: Toaster) { }
  
  ngOnInit(): void {
    
  }

  getProfileIdByUserId()
  {
    this.service.getProfileIdByUserId().subscribe({
        next:(data:any)=>{this.profileIdDetails=data,
        this.profileId=this.profileIdDetails.profileId,
        console.warn(this.profileId),
        console.log(this.profileIdDetails),
        this.getEducationByProfileId();  }
    })
  }
  
  getEducationByProfileId()
  {
    console.log('child called')
    this.service.getEducationByProfileId(this.profileId).subscribe((data)=>{
      this.educationDetails=data;
       this.totalLength=this.educationDetails.length;
       console.warn(this.educationDetails);
     })
  }

  cancelEducation(educationid:number)
  {
    this.service.cancelEducation(educationid).subscribe(()=>this.getEducationByProfileId());
  }
  editToUpdate(){
    this.toaster.open({ text: 'Request to update sent successfully via mail', position: 'top-center', type: 'success' })
  }

}
