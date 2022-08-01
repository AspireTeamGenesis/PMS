import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Designation } from 'Models/designation';
import { Organisation } from 'Models/organisation';
import { User } from 'Models/user';
import { UserserviceService } from 'src/app/service/userservice.service';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Toaster } from 'ngx-toast-notifications';


@Component({
  selector: 'app-edituser',
  templateUrl: './edituser.component.html',
  styleUrls: ['./edituser.component.css']
})
export class EdituserComponent implements OnInit {

  organisationValue: any;
  designationValue: any;




  // createusers: any;
  // Mobilenumber: any;
  // Gender: any;
  // Organisation: any;
  // Designation: any;
  // userValue: User[] = [];
  // organisationValue: Organisation[] = [];
  // designationValue: Designation[] = [];
  // UserId: number = 0;
  // Name: string = '';
  // Email: string = '';
  // UserName: string = '';
  // Password: string = '';
  // GenderValue: number = 0;
  // CountryCodeValue: string = '';
  // MobileNumber: string = '';
  // OrganisationValue: number = 0;
  // DesignationValue: number = 0;
  // ReportingPersonUsername: string = '';
  //TO get the input from the user



  //  registerForm = this.FB.group({
  //     Name: ['', [Validators.required, Validators.pattern('[a-zA-Z]*')]],
  //     Email: ['', [Validators.required, Validators.pattern(/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)]],
  //     UserName: ['', [Validators.required, Validators.pattern('[a-zA-Z]*')]],
  //     Password: ['', [Validators.required, Validators.pattern('')]],
  //     GenderValue: ['', [Validators.required, Validators.pattern('[a-zA-Z]*')]],
  //     CountryCodeValue:['',[Validators.required,Validators.pattern('[0-9][+]*')]],
  //     MobileNumber:['',[Validators.required,Validators.pattern('[0-9]*')]],
  //     organisationValue: ['', [Validators.required, Validators.pattern('[a-zA-Z]*')]],
  //     DesignationValue: ['', [Validators.required, Validators.pattern('[a-zA-Z]*')]],
  //     ReportingPerson: ['', [Validators.required, Validators.pattern('[a-zA-Z]*')]],
  // });


  userEmployeeId: number = 0;
  error: any;


  constructor(private FB: FormBuilder, private service: UserserviceService, private http: HttpClient, private route: ActivatedRoute,private toaster:Toaster) { }


   userDetails: any;
  //  = {
  //   userid: this.userEmployeeId,
  //   name: '',
  //   email: '',
  //   username: '',
  //   password: '',
  //   genderId: 0,
  //   countryCodeId: 0,
  //   mobilenumber: '',
  //   designationId: 0,
  //   reportingpersonUsername: '',
  //   organisationId: 0,
  // }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.userEmployeeId = params['userId'];
      console.log('User id : ' + this.userEmployeeId);
    })
    this.getOrganisation();
    this.getDesignation();
    this.getUserDetails(this.userEmployeeId);
    // this.getUser();
    // this.updateUser();
  }

  getDesignation()
  {
    this.service.getDesignation().subscribe(data => this.designationValue=data);
  }
  getOrganisation()
  {
    this.service.getOrganisation().subscribe(data => this.organisationValue=data);
  }

  // console.log(userEmployeeId);
  getUserDetails(userId: number) {
    console.log(userId);
    this.service.getUserDetails(userId).subscribe((data) => {
      this.userDetails = data;
      console.log(this.userDetails)
    });
  }
  // getUser()
  // {
  //   //console.log(userId);
  //   this.service.getUserProfile().subscribe( (data)=>{
  //     this.userDetails=data;
  //     console.log(this.userDetails)});
  //   }
  updateUser() {

    const userDetailsProfile = {
      userId: this.userEmployeeId,
      name:this.userDetails.name,
      email:this.userDetails.email,
      userName:this.userDetails.username,
      password: this.userDetails.password,
      genderId: this.userDetails.genderId,
      countryCodeId: this.userDetails.countryCodeId,
      mobileNumber: this.userDetails.mobilenumber,
      designationId: this.userDetails.designationId,
      reportingPersonUsername: this.userDetails.reportingpersonUsername,
      organisationId: this.userDetails.organisationId,
    }
    console.log("update");
    console.log(userDetailsProfile);
    this.service.updateUser(userDetailsProfile).subscribe({
      error: (error) => { this.error = error.error.message },
      complete: () => {
        this.toaster.open({ text: 'Updated user successfully', position: 'top-center', type: 'success' });
      }
    });

  }

}

