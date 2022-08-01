import { Component, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { Packer } from "docx";
import { saveAs } from 'file-saver'; 
import { DocumentCreator } from "../profile-generator";
import {
  AlignmentType,
  Document,
  HeadingLevel,
  Paragraph,
  TabStopPosition,
  TabStopType,
  TextRun
} from "docx";
// import { ProfileGeneratorComponent } from '../profile-generator/profile-generator.component';
// import { ProfileServiceService } from '../profile-service.service';

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

  showMe:boolean = false;
  showMe1:boolean = false;
  showMe2:boolean = false;
  showMe3:boolean = false;
  showMe4:boolean = false;
  ngOnInit(): void {
    this.getUserDetails();
    this.getProfileIdByUserId();
    // console.log("happy");
    // console.log(this.profileId);
    
   
  }

  createContactInfo()
  {
    console.log("Welcome");
    this.view.createContactInfo(this.userDetails.mobilenumber,this.userDetails.designation,this.userDetails.email,this.userDetails.name);
  }
  createpersonalInfo()
  {
    console.log(this.profileDetails['personaldetails'][0].objective);
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
        // this.objective=(this.profileDetails['personaldetails'][0].objective);
        
        // this.ps.profileDetails = data;
        this.createpersonalInfo();
      }
    })
    console.log("profile details");
    console.log(this.profileDetails);
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
      // this.objective
    ]);

    Packer.toBlob(doc).then(blob => {
      console.log(blob);
      saveAs(blob, "example.docx");
      console.log("Document created successfully");
    });
  }
  


}



// import { Component, OnInit } from '@angular/core';
// import { UserserviceService } from '../service/userservice.service';
// import { ActivatedRoute, ParamMap } from '@angular/router';


// @Component({
//   selector: 'app-viewprofile',
//   templateUrl: './viewprofile.component.html',
//   styleUrls: ['./viewprofile.component.css']
// })
// export class ViewprofileComponent implements OnInit {

//   constructor(private service:UserserviceService,private route: ActivatedRoute) { }
//   profileId:number=0;
//   profileDetails:any;
//   userDetails:any;
//   showMe:boolean = false;
//   showMe1:boolean = false;
//   showMe2:boolean = false;
//   showMe3:boolean = false;
//   showMe4:boolean = false;
//   ngOnInit(): void {
//     this.route.params.subscribe(params => {
//       this.profileId = params['profileId'];
//       console.log('View profile id : '+this.profileId);
//     })
//     this.getProfileByProfileId();
//     this.getUserDetails();
   
//   }
//   toggletag(){
//     this.showMe=!this.showMe;
//   }
//   toggletag1(){
//     this.showMe1=!this.showMe1;
//   }
//   toggletag2(){
//     this.showMe2=!this.showMe2;
//   }
//   toggletag3(){
//     this.showMe3=!this.showMe3;
//   }
//   toggletag4(){
//     this.showMe4=!this.showMe4;
//   }
//   getProfileByProfileId()
//   {
//     console.log("View :"+this.profileId);
//     this.service.getProfileByProfileId(this.profileId).subscribe( {
//       next:(data:any)=>{this.profileDetails=data,console.warn(this.profileDetails)}
//     })
//     console.log("profile details");
//     console.log(this.profileDetails);
//   }
//   getUserDetails()
//   {
//     this.service.getUserProfile().subscribe( {
//       next:(data:any)=>{this.userDetails=data,console.warn(this.userDetails)}
//     })
//   }


// }
