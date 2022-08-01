import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../service/authentication.service';
import { UserserviceService } from '../service/userservice.service';
import { Router } from '@angular/router';
import { animate, animateChild, query, style, transition, trigger } from '@angular/animations';
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css'],
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

export class SidebarComponent implements OnInit {

  profileId: number;
  profileDetails = {
    username: ''
  };
  profileIdDetails: any;
  isShowDivIf = false;

  constructor(private service: UserserviceService, private servicer: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
    this.getUserProfile();
  }

  getUserProfile() {
    this.service.getUserProfile().subscribe({
      next: (data) => {
        this.profileDetails = data
      }
    })
  }

  getProfileIdByUserId()
  {
    console.log("1");
    this.service.getProfileIdByUserId().subscribe({
      next:(data)=> {
        this.profileIdDetails=data,
        console.log(this.profileIdDetails);
        this.profileId = this.profileIdDetails.profileId
        console.log(this.profileId);
        if (this.profileId == 0) {
          this.router.navigateByUrl("/createprofile");
        }
        else {
          this.router.navigateByUrl("/viewprofile");
        }
      }
    })
  }

  logout() {
    this.servicer.ClearToken();
  }

  toggleSidebar() {
    this.isShowDivIf = !this.isShowDivIf;
  }
}
