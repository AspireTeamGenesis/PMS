import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { AuthenticationService } from '../service/authentication.service';
import { UserserviceService } from '../service/userservice.service';
import { Router } from '@angular/router';
import { animate, animateChild, query, style, transition, trigger } from '@angular/animations';
@Component({
  selector: 'app-hrsidebar',
  templateUrl: './hrsidebar.component.html',
  styleUrls: ['./hrsidebar.component.css'],
  animations: [

    trigger('ngIfAnimation', [
      transition(':enter, :leave', [
        query('@*', animateChild())
      ])

    ]),
    trigger('easeInOut', [

      transition('void => *', [
        style({
          opacity: 0
        }),
        animate("500ms ease-in", style({
          opacity: 1
        }))
      ]),
      transition('* => void', [
        style({
          opacity: 1
        }),
        animate("500ms ease-in", style({
          opacity: 0
        }))

      ])
    ])
  ]

})
export class HrsidebarComponent implements OnInit {

  profileId:any;
  userId:number;
  profileDetails:any;
  profileIdDetails:any;
  constructor(private service:UserserviceService,private route: ActivatedRoute,private servicer:AuthenticationService,private router: Router) { }
  ngOnInit(): void {
    this.getUserProfile();
    // this.getProfileIdByUserId();
  }
  getUserProfile(){
    this.service.getUserProfile().subscribe( {
      next:(data)=>{this.profileDetails=data,
      console.log(this.profileDetails)}
      
    })
    console.log(this.profileDetails.userId);
  }
  getProfileIdByUserId(){
    this.service.getProfileIdByUserId().subscribe((data)=>{
      this.profileIdDetails=data;
      this.profileId=this.profileIdDetails.profileId;
      console.log('professor '+this.profileId);
      if(this.profileId==0)
    {
        this.router.navigateByUrl("/createprofile");
    }
    else
    {
        this.router.navigateByUrl("/viewprofile");

    }
      


    })
    // console.log('prof '+this.profileId);
    // if(this.profileId==undefined)
    // {
    //     this.router.navigateByUrl("/createprofile");
    // }
    // else
    // {
    //     this.router.navigateByUrl("/viewprofile");

    // }
   
  }

//   {this.profileIdDetails=data;
//     console.log("Chitru"),
//   console.log(this.profileIdDetails),
//     console.log(this.profileIdDetails.profileId),
//       if(this.profileIdDetails.profileId == 0)
//       {
//         this.router.navigateByUrl("/createprofile");
//       }
//       else
//       {
//         this.router.navigateByUrl("/viewprofile");
//       }
//     }
  
// })
// console.log(this.profileIdDetails.profileid);
  
  logout()
  {
    this.servicer.ClearToken();
  }
  isShowDivIf = false;
  toggleSidebar() {
    this.isShowDivIf = !this.isShowDivIf;
  }


}
