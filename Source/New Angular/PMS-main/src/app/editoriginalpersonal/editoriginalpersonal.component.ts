import { Component, ViewChild, OnInit } from '@angular/core';
import { UserserviceService } from 'src/app/service/userservice.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { formatDate } from '@angular/common';
@Component({
    selector: 'app-editoriginalpersonal',
    templateUrl: './editoriginalpersonal.component.html',
    styleUrls: ['./editoriginalpersonal.component.css']
})
export class EditoriginalpersonalComponent implements OnInit {

    profileId: number;
    imageError: string = "";
    cardImageBase64: string = "";
    isImageSaved: boolean = false;
    child: any;
    profileDetails: any;
    profileIdDetails: any;
    response: string = '';

    formSubmitted: boolean = false;
    showMe: boolean = false;
    personalForm: FormGroup;
    foot: boolean = true;
    error: string = "";
    personalDetails = {
        image: '',
        objective: '',
        nationality: '',
        personaldetailsid: 0,
        dateofjoining: '',
        dateofbirth: ''
    };
    user: any = {
        personalDetailsId: 0,
        profileId: 0,
        base64header: '',
        image: null,
        objective: '',
        dateOfBirth: '',
        nationality: '',
        dateOfJoining: '',
        userId: 0
    }
    dob: any;
    doj: any;
    constructor(private FB: FormBuilder, private service: UserserviceService, private http: HttpClient) {
        this.personalForm = this.FB.group({});
    }
    ngOnInit(): void {
        this.personalForm = this.FB.group({
            ProfilePhoto: ['', [Validators.required]],
            Objective: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
            DateofBirth: ['', [Validators.required]],
            Nationality: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(40)]],
            DateofJoining: ['', [Validators.required]],
            BreakDuration: ['', [Validators.required]],
            LanguagesKnown: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(40)]],
            SocialMediaName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(40)]],
            SocialMediaLink: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(25)]],
        });
        this.getProfileIdByUserId();
    }


    getProfileIdByUserId() {
        this.service.getProfileIdByUserId().subscribe({
            next: (data: any) => {
                this.profileIdDetails = data,
                    this.profileId = this.profileIdDetails.profileId,
                    this.getPersonalDetailsByProfileId(this.profileIdDetails.profileId)

            }

        })
    }
    getPersonalDetailsByProfileId(ProfileId: number) {
        this.service.getPersonalDetailByProfileId(ProfileId).subscribe({
            next: (data: any) => {
                this.personalDetails = data;
                this.dob = formatDate(this.personalDetails.dateofbirth, 'YYYY-MM-dd', 'en');
                this.doj = formatDate(this.personalDetails.dateofjoining, 'YYYY-MM-dd', 'en');
                this.cardImageBase64 = this.personalDetails.image;
            }
        })
    }


    updatePersonal() {
        console.log("111");
        const personal = {
            personalDetailsId: this.personalDetails.personaldetailsid,
            profileId: this.profileIdDetails.profileId,
            objective: this.personalDetails.objective,
            nationality: this.personalDetails.nationality,
            dateOfBirth: this.dob,
            dateOfJoining: this.doj,
            base64header: this.cardImageBase64,
        }
        console.log(personal.personalDetailsId);
        this.service.updatePersonalDetail(personal).subscribe();
    }

    // clearInputFields() {

    //     this.formSubmitted = false;
    //     setTimeout(() => {
    //         this.response = '';
    //         this.personalForm.reset();
    //     }, 1000);

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
