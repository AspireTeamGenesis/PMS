import { Component, OnInit } from '@angular/core';
// import { Component, ViewChild, OnInit } from '@angular/core';
import { UserserviceService } from 'src/app/service/userservice.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
// import { DatePipe } from '@angular/common';
import { Toaster } from 'ngx-toast-notifications';


import { Language } from 'Models/language';
import { BreakDuration } from 'Models/breakduration';
import { SocialMedia } from 'Models/socialMedia';
import { PersonalDetails } from 'Models/personalDetails';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-editpersonal',
  templateUrl: './editpersonal.component.html',
  styleUrls: ['./editpersonal.component.css']
})
export class EditpersonalComponent implements OnInit {

  error: string;
  profileId: number = 0;
  imageError: string = "";
  cardImageBase64: string = "";
  isImageSaved: boolean = false;
  child: any;
  profileDetails: any;
  profileIdDetails: any;
  formSubmitted: boolean = false;
  personalForm: FormGroup;

  showMe: boolean = false;

  foot: boolean = true;



  constructor(private FB: FormBuilder, private service: UserserviceService, private http: HttpClient, public datepipe: DatePipe, private toaster: Toaster) {
    this.personalForm = this.FB.group({});
  }
  ngOnInit(): void {
    this.personalForm = this.FB.group({
      ProfilePhoto: ['', [Validators.required]],
      Objective: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(500)]],
      DateofBirth: ['', [Validators.required]],
      Nationality: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(40)]],
      DateofJoining: ['', [Validators.required]],
    })
    // this.getUserProfile();
    this.getProfileIdByUserId();

  }


  // getUserProfile(){
  //   this.service.getUserProfile().subscribe( {
  //     next:(data)=>{this.profileDetails=data,
  //     console.log(this.profileDetails),
  //     console.log(this.profileDetails.userid);
  //   }


  //   })

  // }
  getProfileIdByUserId() {
    console.warn("2")
    this.service.getProfileIdByUserId().subscribe({
      next: (data: any) => {
        this.profileIdDetails = data,
        this.profileId = this.profileIdDetails.profileId,
        console.warn(this.profileId),
        console.log(this.profileIdDetails),
        this.GetAllPersonalDetailsByProfileId(this.profileId)

      }
    })
  }



  // personalDetailsId : number = 2;
  Personal: any;
  personal: PersonalDetails[] = [];
  data: any;
  user: any;
  languageDetails: any =
    {

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



  GetAllPersonalDetailsByProfileId(profileId: number) {
    console.warn("1")
    this.service.getPersonalDetailByProfileId(profileId).subscribe((res) => {
      this.user = res;
      var start = new Date(this.user.starting);
      var estart = start.toString();
      estart = estart.replace('T', ' ');
      var end = this.datepipe.transform(estart, "dd-MM-yyyy");
      console.log(end);
      console.warn(this.user);
    })
  }
  toogletag() {
    this.showMe = !this.showMe;
  }



  footer() {

    this.foot = !this.foot;

    if (this.foot == false) { this.foot = true };



  }
  // getPersonalDetailsbyId(){
  //   this.userService.getPersonalDetails(this.personalDetailsId).subscribe((res)=>{
  //     this.user = res;
  //     this.user.designation = res.role;
  //     console.log(this.user);
  //   })
  // }


  //   // language: Language | null,
  //   // breakDuration: BreakDuration | null,
  //   // socialmedia: SocialMedia | null,
  //   // education: Education[] | null;
  //   // projects: Projects[] | null;
  //   // skills: Skills[] | null;
  //   // users: User | null,
  //   isActive: true,
  // }

  // personaldata()
  // {
  //   var personalDetails: any={
  //     "personalDetailsId": 0,
  //     "name": this.Name,
  //     "objective": this.Objective,
  //     "dateOfBirth": this.Dateofbirth,
  //     "nationality": this.Nationality,
  //     "mailAddress": this.Email,
  //     "dateOfJoining": this.Dateofjoining,
  //     "languageid": this.LanguageValue,
  //     "breakDurationid": this.BreakdurationValue,
  //     "socialmediaid": this.SocialmediaValue,
  //   };

  //   const headers={'content-type':'application/json'}
  //   console.log(this.personal)
  //   this.http.post<any>('https://localhost:7021/Profile/AddPersonal',this.personal,{headers:headers})
  //   .subscribe((data)=>{
  //     console.log(data)
  //   });


  // ngOnInit(): void {
  //   // this.http
  //   //   .get<any>(this.artsrc)
  //   //   .subscribe((data) => {
  //   //     this.data = data;
  //   //     this.totalLength = data.length;
  //   //     console.log(data);
  //   //   });
  // }

  // public data: PersonalDetails[] = [

  // ];

  personalSubmit() {
    this.formSubmitted = true;
    this.user.profileId = this.profileIdDetails.profileId;
    this.user.userId = this.profileDetails.userid;
    console.log("User ProfileId");
    console.log(this.user.profileId);
    console.log(this.user.userId);
    console.log(this.user);
    this.service.addPersonalDetail(this.user).subscribe(data => this.user.push(data));
  }

  updatePersonal() {
    this.data = this.user;
    console.warn(this.data);
    this.service.updatePersonalDetail(this.data).subscribe(data => this.data.push(data));
  }
  // {//   error: (error) => { this.error = error.error.message },
  //   complete: () => {
  //     this.toaster.open({ text: 'Achievement added successfully', position: 'top-center', type: 'success' });
  //   }
  // }

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
          this.user.base64header = this.cardImageBase64;
          this.isImageSaved = true;
        }
      };


      reader.readAsDataURL(fileInput.target.files[0]);
    } return false;

  }


}
