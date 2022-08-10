import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Toaster } from 'ngx-toast-notifications';
import { UserserviceService } from '../service/userservice.service';


@Component({
  selector: 'app-createprofile',
  templateUrl: './createprofile.component.html',
  styleUrls: ['./createprofile.component.css']
})
export class CreateprofileComponent implements OnInit {
  error: string;

  constructor(private service:UserserviceService,private route: ActivatedRoute,private toaster: Toaster) { }
  userId:number=0;
  profileDetails:any;
  profileId:number=0;
  ngOnInit(): void {
    
  }
  createProfile()
  {
    const profile={
      userId:this.profileDetails.userid,
      profileId:0,
      profileStatusId:2

    }
    this.service.createProfile(profile).subscribe( {
      next: (data) => { },
      error: (error) => { this.error = error.error.message },
     
    });

  }

}
