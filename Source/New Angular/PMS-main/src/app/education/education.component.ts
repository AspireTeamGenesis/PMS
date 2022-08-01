import { Component, OnInit, ViewChild } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { EducationcardComponent } from '../educationcard/educationcard.component';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { compileClassMetadata } from '@angular/compiler';
import { Toaster } from 'ngx-toast-notifications';


@Component({
  selector: 'app-education',
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.css']
})
export class EducationComponent implements OnInit {

  @ViewChild(EducationComponent) child: EducationcardComponent
  selectedYear: number = 0;
  years: number[] = [];
  error = ''
  constructor(private FB: FormBuilder, private service: UserserviceService, private http: HttpClient, private route: ActivatedRoute, private toaster: Toaster) {
    this.selectedYear = new Date().getFullYear();
    for (let year = this.selectedYear; year >= 1990; year--) {
      this.years.push(year);
    }
  }
  showMe: boolean = false;

  foot: boolean = true;

  collegeValue: any;
  college: number = 0;
  educationDetails: any;
  profileId: number = 0;
  profileDetails: any;
  profileIdDetails: any;
  user = {
    educationId: 0,
    profileId: 0,
    degree: '',
    course: '',
    collegeId: 0,
    starting: 0,
    ending: 0,
    percentage: 0,
  }
  ngOnInit(): void {
    this.getUserProfile;
    this.getCollege();
    this.getProfileIdByUserId();
    // this.getEducationDetails(this.user.educationId);

  }

  getUserProfile() {
    this.service.getUserProfile().subscribe({
      next: (data) => {
        this.profileDetails = data,
        console.log(this.profileDetails)
      }
    })
    console.log(this.profileDetails.userid);
  }

  getProfileIdByUserId() {
    this.service.getProfileIdByUserId().subscribe({
      next: (data: any) => {
        this.profileIdDetails = data,
        this.profileId = this.profileIdDetails.profileId,
        console.warn(this.profileId),
        console.log(this.profileIdDetails)
      }

    })
  }

  getCollege() {
    this.service.getCollege().subscribe({
      next: (data) => {
        this.collegeValue = data;
        console.warn(this.collegeValue);
      }

    });

  }
  educationSubmit() {
    this.user.profileId = this.profileId;
    console.log("hi how");
    console.warn(this.user);
    this.service.addEducation(this.user).subscribe({
      next: (data) => { },
      error: (error) => { this.error = error.error.message },
      complete: () => {
        this.toaster.open({ text: 'Education details added successfully', position: 'top-center', type: 'success' });
      }
    }); 
    setTimeout(
      () => {
        location.reload(); // the code to execute after the timeout
      },
      500// the time to sleep to delay for
    );
  }
  toogletag() {

    this.showMe = !this.showMe;

  }



  footer() {

    this.foot = !this.foot;

    if (this.foot == false) { this.foot = true };



  }


}
