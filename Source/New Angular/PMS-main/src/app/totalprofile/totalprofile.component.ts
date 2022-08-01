import { Component, Input, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { FormGroup,FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Toaster } from 'ngx-toast-notifications';
@Component({
  selector: 'app-totalprofile',
  templateUrl: './totalprofile.component.html',
  styleUrls: ['./totalprofile.component.css']
})
export class TotalprofileComponent implements OnInit {
  profileIdDetails:any;

  totalLength:any;
  page:number=1;
  achievementDetails:any;
  profileId:number;
  totalProfiles:any;
  constructor(private FB: FormBuilder,private service: UserserviceService,private http: HttpClient,private toaster: Toaster) { }

  ngOnInit(): void {
    this.getProfileBytotalStatus();
  }
  getProfileBytotalStatus()
  {
    this.service.getProfileBytotalStatus().subscribe({
      next:(data:any)=>{this.totalProfiles=data
        }
  })
  }
  editToUpdate(){
    this.toaster.open({ text: 'Request to update sent successfully via mail', position: 'top-center', type: 'success' })
  }
  

}
