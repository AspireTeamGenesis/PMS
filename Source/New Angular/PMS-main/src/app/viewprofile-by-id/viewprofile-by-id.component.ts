import { Component, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { Packer } from "docx";
import { saveAs } from 'file-saver'; 
import { DocumentCreator } from "../profile-generator";
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Toaster } from 'ngx-toast-notifications';
import { formatDate } from '@angular/common';

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
  update: any;

  constructor(private service:UserserviceService,private view:DocumentCreator,private route: ActivatedRoute,private toaster: Toaster) { }
  profileId:number;
  profileIdDetails:any;
  name:any;
  // mobilenumber:any;
  designation:any;
  education:any;
  project:any;
  skill:any;
  language:any;
  objective:any;
  email:any;
 profileDetails:any;
 userDetails={
  username:'',
  name:'',
  email:'',
  mobilenumber:'',
  designation:'',
  organisation:'',
  gender:''
 };
 personalDetails:any;

 userId:number;
 userDetailsValue:any;
 profileIdDetailsInCard={
  profilestatus:'',
  profileId:0,
  updateddate:''
 };
 

 showMe:boolean = false;
 showMe1:boolean = false;
 showMe2:boolean = false;
 showMe3:boolean = false;
 showMe4:boolean = false;
 ngOnInit(): void {
  this.route.params.subscribe(params => {
    this.userId = params['userId'];
  })
   this.getUserDetailsByUserId(this.userId);
   this.getProfileIdDetailsByUserId(this.userId);
   
  
 }

 getUserDetailsByUserId(userId:number)
    {this.service.getUserDetailsByUserId(userId).subscribe( {
      next:(data:any)=>{this.userDetails=data,
        this.createContactInfo()
      },
    })
  }
  getProfileIdDetailsByUserId(userId:number)
  {
    this.service.getProfileIdDetailsByUserId(userId).subscribe( {
      next:(data:any)=>{this.profileIdDetailsInCard=data,
        console.log(this.profileIdDetailsInCard),
        this.update = formatDate(this.profileIdDetailsInCard.updateddate, 'dd-MM-YYYY', 'en'),
        this.getProfileByProfileId(this.profileIdDetailsInCard.profileId)
        this.getEducationDetailsByProfileId(this.profileIdDetailsInCard.profileId)
      this.getProjectDetailsByProfileId(this.profileIdDetailsInCard.profileId)
      this.getSkillDetailsByProfileId(this.profileIdDetailsInCard.profileId)
      },
    })

  }

 createContactInfo()
 {
   this.view.createContactInfo(this.userDetails.mobilenumber,this.userDetails.designation,this.userDetails.email,this.userDetails.name);
 }

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
   this.service.getProfileByProfileId(profileId).subscribe( {
     next:(data:any)=>{
       this.profileDetails=data,
       this.language=this.profileDetails?.personaldetails.language;
     }
   })
 }

 getEducationDetailsByProfileId(profileId:number)
 {
   this.service.getEducationDetailsByProfileId(profileId).subscribe({
     next:(data:any)=>{this.education=data
     }
   })
 }
 getProjectDetailsByProfileId(profileId:number)
 {
   this.service.getProjectDetailsByProfileId(profileId).subscribe({
     next:(data:any)=>{this.project=data
     }
   })
 }
 getSkillDetailsByProfileId(profileId:number)
 {
   this.service.getSkillDetailsByProfileId(profileId).subscribe({
     next:(data:any)=>{this.skill=data
    }
   })
 }

 getProfileIdByUserId()
 {
   this.service.getProfileIdByUserId().subscribe({
     next:(data:any)=>{this.profileIdDetails=data,
     this.profileId=this.profileIdDetails.profileId,
     this.getProfileByProfileId(this.profileId),
     this.getEducationDetailsByProfileId(this.profileId)
     this.getProjectDetailsByProfileId(this.profileId)
     this.getSkillDetailsByProfileId(this.profileId)
     }
 })
 }
 editToUpdate(){
  this.toaster.open({ text: 'Request to update sent successfully via mail', position: 'top-center', type: 'success' })
}
 getPersonalDetailByProfileId(profileId:number)
 {
   this.service.getPersonalDetailByProfileId(profileId).subscribe( {
     next:(data:any)=>{this.personalDetails=data
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
   ]);

   Packer.toBlob(doc).then(blob => {
     saveAs(blob, "example.docx");
     console.log("Document created successfully");
   });
 }
  


}

