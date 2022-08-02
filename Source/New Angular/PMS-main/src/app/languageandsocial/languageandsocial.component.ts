import { Component, ViewChild, OnInit } from '@angular/core';
import { UserserviceService } from 'src/app/service/userservice.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';


import { Language } from 'Models/language';
import { BreakDuration } from 'Models/breakduration';
import { SocialMedia } from 'Models/socialMedia';
import { PersonalDetails } from 'Models/personalDetails';
import { FormBuilder,Validators,FormGroup } from '@angular/forms';
import { ToastContentDirective } from 'ngx-toast-notifications/toast-content/toast-content.directive';
// import { Toaster } from 'ngx-toast-notifications';
@Component({
  selector: 'app-languageandsocial',
  templateUrl: './languageandsocial.component.html',
  styleUrls: ['./languageandsocial.component.css']
})
export class LanguageandsocialComponent implements OnInit {

  
  profileIdDetails:any;
  profileId:number;
  showMe: boolean = false;
  foot:boolean = true;
  error: string = "";
  response: string = '';
  formSubmitted: boolean = false;
  langsocialForm:FormGroup;




  constructor(private FB:FormBuilder ,private service: UserserviceService, private http: HttpClient) {
    this. langsocialForm=this.FB.group({});
   }
  ngOnInit(): void {
    this.getProfileIdByUserId();
    this.langsocialForm=this.FB.group({
      LanguageName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(15)]],
      SocialMediaName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(40)]],
      SocialMediaLink: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      });
  }

  getProfileIdByUserId()
  {
    this.service.getProfileIdByUserId().subscribe({
        next:(data:any)=>{this.profileIdDetails=data,
        this.profileId=this.profileIdDetails.profileId,
        console.warn(this.profileId),
        console.log(this.profileIdDetails),
        this.getPersonalDetailsByProfileId(this.profileId)
  } 
    })
  }

  languageValue:Language[]=[];
  language:number=0;
  breakdurationValue:BreakDuration[]=[];
  breakduration:number=0;
  socialmediaValue:SocialMedia[]=[];
  socialmedia:number=0;
  
  // personalDetailsId : number = 2;
  Personal:any;
  personal:PersonalDetails[]=[];

  personalDetails:any;

  
 
  languageDetails:any=
  {
    languageId:0,
    personalDetailsId:0,
    languageName:''
  }
  socialMedia:any=
  {
    personalDetailsId:0,
    socialMedia_Id:0,
    socialMedia_Name:'',
    socialMedia_Link:''
  }

    // language:any{
    //   languageId: 0,
    //   languageName: '',
    //   read: '',
    //   write: '',
    //   speak: '',
    // }

    // breakDuration : {
    //   breakDuration_Id: 0,
    //   starting:'',
    //   ending: '',
    // },
    
    // socialmedia : {
    //   socialMedia_Id: 0,
    //   socialMedia_Name: '',
    //   socialMedia_Link: '',
    // }
  
 getPersonalDetailsByProfileId(profileId:number)
 {
  this.service.getPersonalDetailByProfileId(profileId).subscribe({
    next:(data:any)=>{
      this.personalDetails=data,
      console.log(this.personalDetails) 
      console.log(this.personalDetails.personaldetailsid)   
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
addLanguage()
{
  this.languageDetails.personalDetailsId=this.personalDetails.personaldetailsid;
  console.log(this.languageDetails);
  this.service.addLanguage(this.languageDetails).subscribe(
    {
      next:(data)=>{this.response=data.message,this.getPersonalDetailsByProfileId(this.profileIdDetails.profileId)},
      error:(error)=>this.error=error.error 
    }
  );
  // setTimeout(
  //   () => {
  //     location.reload(); // the code to execute after the timeout
  //   },
  //   1000// the time to sleep to delay for
  // );

}
addSocialMedia()
{
  this.socialMedia.personalDetailsId=this.personalDetails.personaldetailsid;
  console.log(this.socialMedia)
  this.service.addSocialMedia(this.socialMedia).subscribe(
    {
      
        next:(data)=>{this.response=data.message,this.getPersonalDetailsByProfileId(this.profileIdDetails.profileId)},
        error:(error)=>this.error=error.error     
      
    },
    
  );
  // setTimeout(
  //   () => {
  //     location.reload(); // the code to execute after the timeout
  //   },
  //   1000// the time to sleep to delay for
  // );
}

disableLanguage(languageId:number)
  {
    this.service.disableLanguage(languageId).subscribe(
      {
      
        next:(data)=>{this.response=data.message,this.getPersonalDetailsByProfileId(this.profileIdDetails.profileId)},
        error:(error)=>this.error=error.error     
      
    },
    );

  }


  
  disableSocialMedia(socialMediaId:number)
  {
    this.service.disableSocialMedia(socialMediaId).subscribe(
      {
      
        next:(data)=>{this.response=data.message,this.getPersonalDetailsByProfileId(this.profileIdDetails.profileId)},
        error:(error)=>this.error=error.error     
      
    },
    );

  }

}
