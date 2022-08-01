import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup,FormBuilder, FormControl, Validators } from '@angular/forms';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { Designation } from 'Models/designation';
import { Organisation } from 'Models/organisation';
import { User} from 'Models/user';
import { Toaster } from 'ngx-toast-notifications';
import { UserserviceService } from 'src/app/service/userservice.service';
@Component({
  selector: 'app-createusers',
  templateUrl: './createusers.component.html',
  styleUrls: ['./createusers.component.css']
})
export class CreateusersComponent implements OnInit {
  IsLoading:boolean=false;
  error:string=""
  createusers:any;
  filteredOptions:any;
  Mobilenumber:any;
  Gender:any;
  Organisation:any;
  Designation:any;
  userValue:User[]=[];
  organisationValue:Organisation[]=[];
  designationValue:Designation[]=[];
  UserId:number=0;
  Name:string='';
  Email:string= '';
  UserName: string='';
  Password: string='';
  GenderValue: number=0;
  CountryCodeValue: string='';
  MobileNumber:string='';
  OrganisationValue:number= 0;
  DesignationValue:number= 0;
  ReportingPersonUsername:string='';
  item:any;
  userForm:FormGroup;
  formSubmitted: boolean = false;
  selectedUsername:any;
  // error: any;
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

  constructor(private FB: FormBuilder,private service:UserserviceService,private http: HttpClient,private toaster: Toaster) { 
    this.userForm=this.FB.group({});
  }
  
 
  

  ngOnInit(): void {
    this.userForm=this.FB.group({
      Name: ['', [Validators.required,Validators.minLength(3),Validators.maxLength(30)]],
      MailAddress: ['', [Validators.required,  Validators.pattern("([a-zA-Z0-9-_\.]{5,22})@(aspiresys.com)")]],
      UserName: ['', [Validators.required,Validators.minLength(3),Validators.maxLength(30),Validators.pattern("^[A-z][a-z|\.|\s]+$")]],
      Password: ['', [Validators.required,Validators.pattern("^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$")]],
      Gender: ['', [Validators.required]],
      MobileNumber: ['', [Validators.required,Validators.pattern('[0-9]*')]],
      Organisation: ['', [Validators.required,Validators.minLength(3),Validators.maxLength(40)]],
      Designation: ['', [Validators.required,Validators.minLength(3),Validators.maxLength(40)]],
      ReportingPersonUsername: ['', [Validators.required]],
    });
    this.getOrganisation();
    this.getDesignation();
  }
  onSelectReportingPersonUsername(event:any)
  {
    this.selectedUsername = event.option.id;
    console.log(this.selectedUsername)
    // this.service.getProfileBytotalStatus(this.selectedUsername).subscribe(data=>{
    // this.awardeeData=data;
    // this.isAwardee=1;
    // console.log(this.awardeeData);
  }
  getDesignation()
  {
    this.service.getDesignation().subscribe(data => this.designationValue=data);
    console.log(this.designationValue);
    // console.log(data);
  }
  getOrganisation()
  {
    this.service.getOrganisation().subscribe(data => this.organisationValue=data);
    console.log(this.organisationValue);
  }

  userdata(){
    this.IsLoading=true
    this.formSubmitted = true ;
    var userDetails:any={
      "userId":0,
     "name": this.Name,
     "email": this.Email,
     "userName": this.UserName,
     "password": this.Password,
    "countryCodeId": this.CountryCodeValue,
     "mobileNumber": this.MobileNumber,
     "genderId":this.GenderValue,
     "organisationId":this.OrganisationValue,
    //  "organisationId":2,
     "designationId":this.DesignationValue,
     "reportingPersonUsername":this.ReportingPersonUsername,
    };
 

     console.log(userDetails);
    this.service.addEmployee(userDetails).subscribe({next:(data)=>{},
    error:(error)=>{
      this.error=error.error;
      console.log(this.error);
      this.IsLoading=false;
    },
    
    complete:()=>{
      this.toaster.open({ text: 'User has been created successfully', position: 'top-center', type: 'success' })
    }
    });//data=>this.user.push(data)
    setTimeout(
      () => {
        location.reload(); // the code to execute after the timeout
      },
      1000// the time to sleep to delay for
    );
    console.error(this.userValue);
    

   }


    
}
