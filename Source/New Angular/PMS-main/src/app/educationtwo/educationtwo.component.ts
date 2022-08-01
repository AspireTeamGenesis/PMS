import { Component, OnInit, ViewChild } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { FormGroup,FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { College } from 'Models/college';
import { EducationcardComponent } from '../educationcard/educationcard.component';

@Component({
  selector: 'app-educationtwo',
  templateUrl: './educationtwo.component.html',
  styleUrls: ['./educationtwo.component.css']
})
export class EducationtwoComponent implements OnInit {

  selectedYear: number=0;
  years: number[] = [];

  constructor(private FB: FormBuilder,private service: UserserviceService,private http: HttpClient) {
    this.selectedYear = new Date().getFullYear();
  for (let year = this.selectedYear; year >= 2000; year--) {
    this.years.push(year);
  }
    }


  collegeValue:College[]=[];
  college:number=0;
  educationDetails:any;

  // _college='';
  // college:any[]=[];
  // collegeDetails:any;
  
  user = {
    educationId: 0,
    profileId: 11,
    degree: '',
    course: '',
    collegeId:0,
    starting: 0,
    ending: 0,
    percentage: 0,
  }
  ngOnInit(): void {
    this.getCollege();
    // this.getEducationDetails(this.user.educationId);

  }
  
  getCollege()
  {
    this.service.getCollege().subscribe((data:any)=>
    {
      this.collegeValue=data;
    });
  }
  educationSubmit()
  {
    console.log("hi how");
    console.warn(this.user);
    this.service.addEducation(this.user).subscribe();//data=>this.user.push(data)    
  }

}
