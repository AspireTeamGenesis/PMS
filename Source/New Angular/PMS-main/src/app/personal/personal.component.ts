import { Component, OnInit } from '@angular/core';
import { UserserviceService } from 'src/app/service/userservice.service';
import { HttpClient } from '@angular/common/http';
import { PersonalDetails } from 'Models/personalDetails';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Toaster } from 'ngx-toast-notifications';
@Component({
  selector: 'app-personal',
  templateUrl: './personal.component.html',
  styleUrls: ['./personal.component.css']
})
export class PersonalComponent implements OnInit {

  profileId: number;
  imageError: string = "";
  cardImageBase64: string = "";
  isImageSaved: boolean = false;
  profileDetails:any={
    userid:0
  };
  profileIdDetails: any;
  response: string = '';

  formSubmitted: boolean = false;
  showMe: boolean = false;
  foot: boolean = true;
  error: string = "";
  maxDate:any;
  base64header:any;
  // user: any = {
  //   personalDetailsId: 0,
  //   profileId: 0,
  //   base64header: '',
  //   image: null,
  //   objective: '',
  //   dateOfBirth: '',
  //   nationality: '',
  //   dateOfJoining: '',
  //   userId: 0
  // }

  personalForm = this.FB.group({
    profilePhoto: ['', [Validators.required]],
    objective: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(500)]],
    dateofBirth: ['', [Validators.required]],
    nationality: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(40)]],
    dateofJoining: ['', [Validators.required]],
  });
  constructor(private FB: FormBuilder, private service: UserserviceService, private http: HttpClient, private toaster: Toaster) {}
  ngOnInit(): void {
    this.dateValidation();
    this.getProfileIdByUserId();
    this.getUserProfile();
  }

  getProfileIdByUserId() {
    this.service.getProfileIdByUserId().subscribe({
      next: (data) => {
        this.profileIdDetails = data,
          this.profileId = this.profileIdDetails.profileId,
          console.warn(this.profileId),
          console.log(this.profileIdDetails)
      }
    })
  }
  Personal: any;
  personal: PersonalDetails[] = [];
  data: any;
  year: number = 0;
  languageArray: any = [];
  personalDetails: any;
  toogletag() {
    this.showMe = !this.showMe;
  }
  footer() {
    this.foot = !this.foot;
    if (this.foot == false) { this.foot = true };
  }
  getUserProfile() {
    this.service.getUserProfile().subscribe({
      next: (data) => {
        this.profileDetails = data
      }
    })
  }
  personalSubmit() {
    const personalDetails={
      personalDetailsId:0,
      profileId:this.profileId,
      base64header: this.cardImageBase64,
      userId:this.profileDetails.userid,
      objective:this.personalForm.value['objective'],
      nationality:this.personalForm.value['nationality'],
      dateofBirth:this.personalForm.value['dateofBirth'],
      dateofJoining:this.personalForm.value['dateofJoining']
    }   
    console.log(personalDetails);
    this.service.addPersonalDetail(personalDetails).subscribe(
      {
        next: (data) => this.response = data.message,
        error: (error) => this.error = error.error,
        complete: () => {
          this.clearInputFields(),
            this.toaster.open({ text: 'Personal Details has been created Successfully', position: 'top-center', type: 'success' })
        }
      }
    );
    console.log(this.error);
    console.log(this.response);
  }

  dateValidation() {
    var date: any = new Date();
    var toDate: any = date.getDate();
    if (toDate < 10) {
      toDate = "0" + toDate;
    }
    var month = date.getMonth() + 1;
    if (month < 10) {
      month = '0' + month;
    }
    var year = date.getFullYear(); 
    this.maxDate = year + "-" + month + "-" + toDate;
    console.log(this.maxDate);
    return true;
  }

  validateDateOfBirth() {
    this.year = parseInt(this.personalForm.value['dateofBirth']);
    if (((new Date().getFullYear() - this.year) <= 18))
     {
      return true;
    }
    if((new Date().getFullYear() - this.year) >= 60){
      return true;
    }
    return false;
  }

  clearInputFields()
   {
    this.formSubmitted = false;
    setTimeout(() => {
      this.response = '';
      this.personalForm.reset();
    }, 1000);
  }

  fileChangeEvent(fileInput: any) {
    this.imageError = "";
    if (fileInput.target.files && fileInput.target.files[0]) {
      const max_size = 20971520;
      const allowed_type = ['image/jpeg', 'image/png'];
      if (fileInput.target.files[0].size > max_size) {
        this.imageError = 'maximum file size allowed is ' + max_size / 1000 + 'Mb';
        return false;
      }
      console.log(fileInput.target.files[0].type)
      if (!allowed_type.includes(fileInput.target.files[0].type)) {
        this.imageError = 'Only images are allowed (either JPG or PNG)';
        return false;
      }
      const reader = new FileReader();
      reader.onload = (e: any) => {
        const image = new Image();
        image.src = e.target.result;
        image.onload = rs => {
          const imgBase64Path = e.target.result;
          this.cardImageBase64 = imgBase64Path;
          this.cardImageBase64 = this.cardImageBase64.replace("data:image/png;base64,", "");
          this.cardImageBase64 = this.cardImageBase64.replace("data:image/jpg;base64,", "");
          this.cardImageBase64 = this.cardImageBase64.replace("data:image/jpeg;base64,", "");
          this.base64header = this.cardImageBase64;
          this.isImageSaved = true;
        }
      };
      reader.readAsDataURL(fileInput.target.files[0]);
    } return false;
  }
}
