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
  error:string=""
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

  constructor(private FB: FormBuilder,private service:UserserviceService,private http: HttpClient,private toaster: Toaster) { 
    
  }
  ngOnInit(): void {
    this.userForm=this.FB.group({
      Name: ['', [Validators.required,Validators.minLength(3),Validators.maxLength(30)]],
      MailAddress: ['', [Validators.required,  Validators.pattern("([a-zA-Z0-9-_\.]{5,22})@(aspiresys.com)")]],
      UserName: ['', [Validators.required,Validators.minLength(3),Validators.maxLength(30),Validators.pattern("^[A-z][a-z|\.|\s]+$")]],
      Password: ['', [Validators.required,Validators.pattern("^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$")]],
      Gender: ['', [Validators.required]],
      CountryCode:['', [Validators.required]],
      MobileNumber: ['', [Validators.required,Validators.pattern('[0-9]*')]],
      Organisation: ['', [Validators.required,Validators.minLength(3),Validators.maxLength(40)]],
      Designation: ['', [Validators.required,Validators.minLength(3),Validators.maxLength(40)]],
      ReportingPersonUsername: ['', [Validators.required]],
    });
    this.getOrganisation();
    this.getDesignation();
  }
  getDesignation()
  {
    this.service.getDesignation().subscribe({next:(data)=>{
      this.designationValue=data;

    }
  });
    console.log(this.designationValue);
    // console.log(data);
  }
  getOrganisation()
  {
    this.service.getOrganisation().subscribe({next:(data)=>{
      this.organisationValue=data;
    }
    
  });
    console.log(this.organisationValue);
  }

  userdata(){
    this.formSubmitted = true ;
    const userDetails ={
     userId:0,
     name: this.userForm.value['Name'],
     email: this.userForm.value['MailAddress'],
     userName: this.userForm.value['UserName'],
     password: this.userForm.value['Password'],
     countryCodeId: this.userForm.value['CountryCode'],
     mobileNumber: this.userForm.value['MobileNumber'],
     genderId:this.userForm.value['Gender'],
     organisationId:this.userForm.value['Organisation'],
     designationId:this.userForm.value['Designation'],
     reportingPersonUsername:this.userForm.value['ReportingPersonUsername'],
    };
 

     console.log(userDetails);
    this.service.addEmployee(userDetails).subscribe({next:(data)=>{},
    error:(error)=>{
      this.error=error.error;
      console.log(this.error);
    },
    
    complete:()=>{
      this.toaster.open({ text: 'User has been created successfully', position: 'top-center', type: 'success' })
    }
    });
    setTimeout(
      () => {
        location.reload(); // the code to execute after the timeout
      },
      1000// the time to sleep to delay for
    );
    console.error(this.userValue);
    

   }


    
}
