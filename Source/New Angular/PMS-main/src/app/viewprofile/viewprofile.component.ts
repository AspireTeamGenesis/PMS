import { Component, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { Packer } from "docx";
import { saveAs } from 'file-saver'; 
import { DocumentCreator } from "../profile-generator";
@Component({
  selector: 'app-viewprofile',
  templateUrl: './viewprofile.component.html',
  styleUrls: ['./viewprofile.component.css']
})
export class ViewprofileComponent implements OnInit {

  constructor(private service:UserserviceService,private view:DocumentCreator) { }
  profileId:number;
   profileIdDetails={
    profileId:0,
    profilestatus:''
   };
   education:any;
   project:any;
   skill:any;
   language:any;
   objective:any;
  profileDetails:any;
  userDetails={
    name:'',
    email:'',
    mobilenumber:'',
    userid:0,
    designation:''
  };
  personalDetails:any;

  showMe:boolean = false;
  showMe1:boolean = false;
  showMe2:boolean = false;
  showMe3:boolean = false;
  showMe4:boolean = false;
  ngOnInit(): void {
    this.getUserDetails();
    this.getProfileIdByUserId();
  }

  createContactInfo()
  {
    this.view.createContactInfo(this.userDetails.mobilenumber,this.userDetails.designation,this.userDetails.email,this.userDetails.name);
  }

  createpersonalInfo()
  {
    this.view.createpersonalInfo(this.profileDetails['personaldetails'][0].objective);
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
    console.log("View :"+profileId);
    this.service.getProfileByProfileId(profileId).subscribe( {
      next:(data:any)=>{
        this.profileDetails=data,console.warn(this.profileDetails),
        this.language=this.profileDetails['personaldetails'][0].language;
        this.createpersonalInfo();
      }
    })
  }

  getUserDetails()
  {this.service.getUserProfile().subscribe( {
    next:(data:any)=>{this.userDetails=data,console.warn(this.userDetails),
      console.log(this.userDetails.userid);
      console.log(this.userDetails.mobilenumber);
      console.log(this.userDetails.designation);
      console.log(this.userDetails.email);
      this.createContactInfo();
    },
    
  })
  }

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
        this.createpersonalInfo();
    },
  })
  }
  updateProfileStatus()
  {
    const profile=
    {
      userId:this.userDetails.userid,
      profileId:this.profileIdDetails.profileId,
      profileStatusId:2
    }
    this.service.updateProfileStatus(profile).subscribe();
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
      console.log(blob);
      saveAs(blob, "example.docx");
      console.log("Document created successfully");
    });
  }
}
