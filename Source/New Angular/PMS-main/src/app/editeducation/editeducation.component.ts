import { Component, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { FormGroup,FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { College } from 'Models/college';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Toast, Toaster } from 'ngx-toast-notifications';


@Component({
  selector: 'app-editeducation',
  templateUrl: './editeducation.component.html',
  styleUrls: ['./editeducation.component.css']
})
export class EditeducationComponent implements OnInit {
  selectedYear: number=0;
  years: number[] = [];
  educationForm:FormGroup;
  formSubmitted: boolean = false;
  error: any;

  constructor(private FB: FormBuilder, private service: UserserviceService, private http: HttpClient, private route: ActivatedRoute,private toaster:Toaster) {
    this.selectedYear = new Date().getFullYear();
  for (let year = this.selectedYear; year >= 1990; year--) {
    this.years.push(year);
  }
    }
    profileId:number;
    // educationId=0;
    collegeValue:any;
  college:number=0;
  educationDetails:any;
  profileIdDetails:any;
  educationid:number=0;
  showMe: boolean = false;
  foot:boolean = true;

  user:any;
  
  ngOnInit(): void {
    this.educationForm=this.FB.group({
      Degree: ['', [Validators.required,Validators.minLength(2),Validators.maxLength(38),Validators.pattern("^[A-Za-z]+$")]],
      Course: ['', [Validators.required,Validators.minLength(2),Validators.maxLength(50),Validators.pattern("^[A-Za-z ]+$")]],
      College: ['', [Validators.required]],
      From: ['', [Validators.required]],
      To: ['', [Validators.required]],
      Percentage : ['', [Validators.required,Validators.minLength(1),Validators.maxLength(3),Validators.pattern("([1-9]|[1-9][0-9]|100)")]],

      });
    this.route.params.subscribe(params => {
      this.educationid = params['educationid'];
      console.log('Education id : ' + this.educationid);
    })
    this.getCollege();
    console.log('Hello : '+this.educationid);
    this.getEducationDetails(this.educationid);
    this.getProfileIdByUserId();

  }
  getCollege()
  {
    this.service.getCollege().subscribe((data:any)=>
    {
      this.collegeValue=data;
    });
  }

  getProfileIdByUserId()
  {
    this.service.getProfileIdByUserId().subscribe({
        next:(data:any)=>{this.profileIdDetails=data,
        this.profileId=this.profileIdDetails.profileId,
        console.warn(this.profileId),
        console.log(this.profileIdDetails)
        }
  
    })
  }

   getEducationDetails(educationId:number)
  {
    console.log(educationId);
    this.service.getEducationDetails(educationId).subscribe( (data)=>{
      this.user=data;
      console.log(this.user)});
      this.collegeValue=this.user.collegeid;
    }
    updateEducation()
    {
      const education = {
        educationId: this.educationid,
        profileId: this.profileId,
        degree: this.user.degree,
        course: this.user.course,
        collegeId:this.user.collegeid,
        starting: this.user.starting,
        ending: this.user.ending,
        percentage: this.user.percentage,
      }
        console.log("update");
        console.log(education);
        this.service.updateEducation(education).subscribe({
          error: (error) => { this.error = error.error.message },
          complete: () => {
            this.toaster.open({ text: 'Education updated successfully', position: 'top-center', type: 'success' });
          }
        });
    
      }
      toogletag()

  {

    this.showMe=!this.showMe;

  }
  footer()

  {

    this.foot=!this.foot;

    if(this.foot==false){this.foot=true};

   

  }

    }
