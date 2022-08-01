import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Hrprofile } from 'Models/hrprofile';
import { UserserviceService } from '../service/userservice.service';

@Component({
  selector: 'app-my-info',
  templateUrl: './my-info.component.html',
  styleUrls: ['./my-info.component.css']
})
export class MyInfoComponent implements OnInit {

  userId:any;
  // data:any;
  profileDetails={
    username:'',
    name:'',
    email:'',
    designation:'',
    organisation:'',
    gender:''
  };

  constructor(private service:UserserviceService,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.userId = params['userId'];
      console.log('User id : '+this.userId);
    })
    if(this.userId==undefined)
    this.getUserProfile();
    else
    this.getUserDetails(this.userId);

  }

  // public data:Hrprofile[]=[
    
  // ];
  getUserDetails(userId:number)
  {
    this.service.getUserDetails(userId).subscribe( {
      next:(data:any)=>this.profileDetails=data
    })
  }
  getUserProfile(){
    this.service.getUserProfile().subscribe( {
      next:(data:any)=>this.profileDetails=data
    })
  }
}
