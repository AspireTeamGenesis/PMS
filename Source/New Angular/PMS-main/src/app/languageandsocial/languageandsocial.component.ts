import { Component, ViewChild, OnInit } from '@angular/core';
import { UserserviceService } from 'src/app/service/userservice.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';


import { Language } from 'Models/language';
import { BreakDuration } from 'Models/breakduration';
import { SocialMedia } from 'Models/socialMedia';
import { PersonalDetails } from 'Models/personalDetails';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ToastContentDirective } from 'ngx-toast-notifications/toast-content/toast-content.directive';
// import { Toaster } from 'ngx-toast-notifications';
@Component({
  selector: 'app-languageandsocial',
  templateUrl: './languageandsocial.component.html',
  styleUrls: ['./languageandsocial.component.css']
})
export class LanguageandsocialComponent implements OnInit {


  profileIdDetails: any;
  profileId: number;
  showMe: boolean = false;
  foot: boolean = true;
  error: string = "";
  response: string = '';
  formSubmitted: boolean = false;
  langsocialForm: FormGroup;




  constructor(private FB: FormBuilder, private service: UserserviceService, private http: HttpClient) {
    this.langsocialForm = this.FB.group({});
  }
  ngOnInit(): void {
    this.getProfileIdByUserId();
    this.langsocialForm = this.FB.group({
      LanguageName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(15)]],
      SocialMediaName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(40)]],
      SocialMediaLink: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      Read:[false],
      Write:[false],
      Speak:[false]

    });
  }

  getProfileIdByUserId() {
    this.service.getProfileIdByUserId().subscribe({
      next: (data: any) => {
        this.profileIdDetails = data,
        this.profileId = this.profileIdDetails.profileId,
        this.getPersonalDetailsByProfileId(this.profileId)
      }
    })
  }

  languageValue: Language[] = [];
  language: number = 0;
  breakdurationValue: BreakDuration[] = [];
  breakduration: number = 0;
  socialmediaValue: SocialMedia[] = [];
  socialmedia: number = 0;
  Personal: any;
  personal: PersonalDetails[] = [];
  personalDetails: any;

  languageDetails: any =
    {
      languageId: 0,
      personalDetailsId: 0,
      languageName: '',
      read: false,
      write: false,
      speak: false
    }

  socialMedia: any =
    {
      personalDetailsId: 0,
      socialMedia_Id: 0,
      socialMedia_Name: '',
      socialMedia_Link: ''
    }

  getPersonalDetailsByProfileId(profileId: number) {
    this.service.getPersonalDetailByProfileId(profileId).subscribe({
      next: (data: any) => {
        this.personalDetails = data
      }
    });
  }

  toogletag() {
    this.showMe = !this.showMe;
  }

  footer() {
    this.foot = !this.foot;
    if (this.foot == false) { this.foot = true };
  }

  //  check:true;

  addLanguage(read:any,write:any,speak:any) {
    // alert(this.languageDetails.read)
    this.languageDetails.personalDetailsId = this.personalDetails.personaldetailsid;
    this.languageDetails.languageName=this.langsocialForm.value['LanguageName'];
    this.languageDetails.read = read.checked
    this.languageDetails.write = write.checked
    this.languageDetails.speak = speak.checked

    this.service.addLanguage(this.languageDetails).subscribe(
      {
        next: (data) => { this.response = data.message, this.getPersonalDetailsByProfileId(this.profileIdDetails.profileId) },
        error: (error) => this.error = error.error
      }
    );
  }

  addSocialMedia() {
    this.socialMedia.personalDetailsId = this.personalDetails.personaldetailsid;
    this.service.addSocialMedia(this.socialMedia).subscribe(
      {
        next: (data) => { this.response = data.message, this.getPersonalDetailsByProfileId(this.profileIdDetails.profileId) },
        error: (error) => this.error = error.error
      },
    );
  }

  disableLanguage(languageId: number) {
    this.service.disableLanguage(languageId).subscribe(
      {
        next: (data) => { this.response = data.message, this.getPersonalDetailsByProfileId(this.profileIdDetails.profileId) },
        error: (error) => this.error = error.error
      },
    );
  }

  disableSocialMedia(socialMediaId: number) {
    this.service.disableSocialMedia(socialMediaId).subscribe(
      {
        next: (data) => { this.response = data.message, this.getPersonalDetailsByProfileId(this.profileIdDetails.profileId) },
        error: (error) => this.error = error.error
      },
    );
  }
}
