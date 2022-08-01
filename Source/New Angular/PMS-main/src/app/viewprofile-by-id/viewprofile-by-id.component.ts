import { Component, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { Packer } from "docx";
import { saveAs } from 'file-saver'; 
import { DocumentCreator } from "../profile-generator";
import { ActivatedRoute, ParamMap } from '@angular/router';
import {
  AlignmentType,
  Document,
  HeadingLevel,
  Paragraph,
  TabStopPosition,
  TabStopType,
  TextRun
} from "docx";
@Component({
  selector: 'app-viewprofile-by-id',
  templateUrl: './viewprofile-by-id.component.html',
  styleUrls: ['./viewprofile-by-id.component.css']
})
export class ViewprofileByIdComponent implements OnInit {

  constructor(private service:UserserviceService,private view:DocumentCreator,private route: ActivatedRoute) { }
  profileId:number;
  profileIdDetails:any;
  name:any;
  mobilenumber:any;
  designation:any;
  education:any;
  project:any;
  skill:any;
  language:any;
  objective:any;
  email:any;
 profileDetails:any;
 userDetails:any;
 personalDetails:any;

 userId:number;
 userDetailsValue:any;
 profileIdDetailsInCard:any;
 

 showMe:boolean = false;
 showMe1:boolean = false;
 showMe2:boolean = false;
 showMe3:boolean = false;
 showMe4:boolean = false;
 ngOnInit(): void {
  this.route.params.subscribe(params => {
    this.userId = params['userId'];
    console.log('User id : ' + this.userId);
  })
   this.getUserDetailsByUserId(this.userId);
   this.getProfileIdDetailsByUserId(this.userId);
   
  
 }

 getUserDetailsByUserId(userId:number)
    {this.service.getUserDetailsByUserId(userId).subscribe( {
      next:(data:any)=>{this.userDetails=data,
        console.warn(this.userDetails)
        this.createContactInfo()
      },
    })
  }
  getProfileIdDetailsByUserId(userId:number)
  {
    this.service.getProfileIdDetailsByUserId(userId).subscribe( {
      next:(data:any)=>{this.profileIdDetailsInCard=data,
        console.warn(this.profileIdDetailsInCard),
        console.warn(this.profileIdDetailsInCard.profileId)
        this.getProfileByProfileId(this.profileIdDetailsInCard.profileId)
        this.getEducationDetailsByProfileId(this.profileIdDetailsInCard.profileId)
      this.getProjectDetailsByProfileId(this.profileIdDetailsInCard.profileId)
      this.getSkillDetailsByProfileId(this.profileIdDetailsInCard.profileId)
      },
    })

  }

 createContactInfo()
 {
   console.log("Welcome");
   console.log(this.userDetails.mobilenumber,this.userDetails.designation,this.userDetails.email,this.userDetails.name);
   this.view.createContactInfo(this.userDetails.mobilenumber,this.userDetails.designation,this.userDetails.email,this.userDetails.name);
 }
//  createpersonalInfo()
//  {
//    console.log(this.profileDetails['personaldetails'][0].objective);
//    this.view.createpersonalInfo(this.profileDetails['personaldetails'][0].objective);
//  }
 toggletag(){
   this.showMe=!this.showMe;
 }
 toggletag1(){
   this.showMe1=!this.showMe1;
 }
 toggletag2(){
   this.showMe2=!this.showMe2;
 }
 toggletag3(){
   this.showMe3=!this.showMe3;
 }
 toggletag4(){
   this.showMe4=!this.showMe4;
 }

 getProfileByProfileId(profileId:number)
 {
   console.log("View :"+profileId);
   this.service.getProfileByProfileId(profileId).subscribe( {
     next:(data:any)=>{
       this.profileDetails=data,console.warn(this.profileDetails),
       this.language=this.profileDetails['personaldetails'][0].language;
       // this.objective=(this.profileDetails['personaldetails'][0].objective);
       
       // this.ps.profileDetails = data;
      //  this.createpersonalInfo();
     }
   })
   console.log("profile details");
   console.log(this.profileDetails);
 }

//  getUserDetails()
//  {this.service.getUserProfile().subscribe( {
//    next:(data:any)=>{this.userDetails=data,console.warn(this.userDetails),
//      console.log(this.userDetails.mobilenumber);
//      console.log(this.userDetails.designation);
//      console.log(this.userDetails.email);
//      this.createContactInfo();
//    },
   
//  })
//  }

 getEducationDetailsByProfileId(profileId:number)
 {
   this.service.getEducationDetailsByProfileId(profileId).subscribe({
     next:(data:any)=>{this.education=data,
     console.warn(this.education)}
   })
 }
 getProjectDetailsByProfileId(profileId:number)
 {
   this.service.getProjectDetailsByProfileId(profileId).subscribe({
     next:(data:any)=>{this.project=data,
     console.warn(this.project)}
   })
 }
 getSkillDetailsByProfileId(profileId:number)
 {
   this.service.getSkillDetailsByProfileId(profileId).subscribe({
     next:(data:any)=>{this.skill=data,
     console.warn(this.skill)}
   })
 }

 getProfileIdByUserId()
 {
   this.service.getProfileIdByUserId().subscribe({

     next:(data:any)=>{this.profileIdDetails=data,

     this.profileId=this.profileIdDetails.profileId,

     console.warn(this.profileId),

     console.log(this.profileIdDetails),
     // this.createpersonalInfo()
     this.getProfileByProfileId(this.profileId),
     this.getEducationDetailsByProfileId(this.profileId)
     this.getProjectDetailsByProfileId(this.profileId)
     this.getSkillDetailsByProfileId(this.profileId)
     }



 })
 }
 
 getPersonalDetailByProfileId(profileId:number)
 {
   this.service.getPersonalDetailByProfileId(profileId).subscribe( {
     next:(data:any)=>{this.personalDetails=data,console.warn(this.personalDetails)
       console.log(this.personalDetails['personaldetails'][0].language)
      //  this.createpersonalInfo();
   },
 })
 }
 public download(): void {
   const documentCreator = new DocumentCreator();
   const doc = documentCreator.create([
     this.education,
     this.project,
     this.skill,
     this.language,
     // this.objective
   ]);

   Packer.toBlob(doc).then(blob => {
     console.log(blob);
     saveAs(blob, "example.docx");
     console.log("Document created successfully");
   });
 }
  


}

