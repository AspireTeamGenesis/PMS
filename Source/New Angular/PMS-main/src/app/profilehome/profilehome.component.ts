import { Component, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';


@Component({
  selector: 'app-profilehome',
  templateUrl: './profilehome.component.html',
  styleUrls: ['./profilehome.component.css']
})
export class ProfilehomeComponent implements OnInit {
  showMe: boolean = true;
  showMe1: boolean = false;

  dashboard:any;
  designationValue:any;
  domainValue:any;
  technologyValue:any;
  collegeValue:any;
  profileValue:any;
  filterValue:any;
  experience: number[] = [];
  // username:any;


  constructor(private service: UserserviceService) {
    for (let exp = 1 ; exp < 20; exp++) {
      this.experience.push(exp);
    }
   }

  filter:any={
    designationId:0,
    domainId:0,
    technologyId:0,
    collegeId:0,
    profileStatusId:0,
    username:''
  }

  ngOnInit(): void {
    this.dashboardcount();
    this.getDesignation();
    this.getDomain();
    this.getTechnology();
    this.getCollege();
    this.getProfileStatus();
  }
  dashboardcount()
  {
    this.service.dashboardcount().subscribe((data) => {
      this.dashboard = data;
    })
  }

  getDesignation()
  {
    this.service.getDesignation().subscribe((data:any)=>
    {
      this.designationValue=data;
    });

  }

  getDomain()
  {
    this.service.getDomain().subscribe((data:any)=>
    {
      this.domainValue=data;
    });

  }

  getTechnology()
  {
    this.service.getTechnology().subscribe((data:any)=>
    {
      this.technologyValue=data;
    });

  }

  getCollege()
  {
    this.service.getCollege().subscribe((data:any)=>
    {
      this.collegeValue=data;
    });

  }

  getProfileStatus()
  {
    this.service.getProfileStatus().subscribe((data:any)=>
    {
      this.profileValue=data;
    });

  }

  getProfileByFilters()
  {
    this.service.getProfileByFilters(this.filter).subscribe((data:any)=>
    {
      this.filterValue=data;
    });
  }

  toogletag()
  {
    !this.showMe==this.showMe;
    if(this.showMe==true){this.showMe=false};
  }

  toogletag1()
  {
    this.showMe1=!this.showMe1;
  }

}
