import { Component, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';

@Component({
  selector: 'app-dashboard11',
  templateUrl: './dashboard11.component.html',
  styleUrls: ['./dashboard11.component.css']
})

export class Dashboard11Component implements OnInit {
    dashboard={
    TotalProfiles:0,
    ApprovedProfiles:0,
    RejectedProfiles:0,
    WaitingProfiles:0
  };
  constructor(private service: UserserviceService) {}

  ngOnInit(): void {
    this.dashboardcount();
  }

  dashboardcount()
  {
    this.service.dashboardcount().subscribe({
      next:(data)=>{
        this.dashboard=data
      }
    })
  }
}

