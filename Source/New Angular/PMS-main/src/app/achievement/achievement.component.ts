import { Component, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Toaster } from 'ngx-toast-notifications';


@Component({
    selector: 'app-achievement',
    templateUrl: './achievement.component.html',
    styleUrls: ['./achievement.component.css']
})
export class AchievementComponent implements OnInit {

     error: any;
     toggle: boolean = false;
     formSubmitted: boolean = false;
     foot: boolean = true;
     achievementForm: FormGroup;
     imageError: string = "";
     profileIdDetails: any = {
         profileId: 0
     }
     isImageSaved: boolean = false;
     cardImageBase64: any;
    
    constructor(private FB: FormBuilder, private service: UserserviceService, private http: HttpClient, private route: ActivatedRoute, private toaster: Toaster) { }
    // Model for Achievement
    achievement: any = {
        achievementId: 0,
        profileId: 0,
        achievementTypeId: 0,
        base64header: '',
        achievementImage: '',
    }
//    Component Initialisation
    ngOnInit(): void {
        this.achievementForm = this.FB.group({
            AchievementPhoto: ['', [Validators.required]],
            AchievementType: ['', [Validators.required]]
        })
        this.getProfileIdByUserId();

    }
    // Gets Profile for the CurrentUser
    getProfileIdByUserId() {
        this.service.getProfileIdByUserId().subscribe({
            next: (data: any) => {
                this.profileIdDetails = data

            }
        })
    }

    // Adds the Achievement Details Provided by the user
    submitAchievement() {
        this.formSubmitted = true;
        this.achievement.achievementTypeId = this.achievementForm.value['AchievementType'];
        this.achievement.profileId = this.profileIdDetails.profileId,

            this.service.addAchievement(this.achievement).subscribe(
                {
                    next: (data) => { },
                    error: (error) => { this.error = error.error.message },
                    complete: () => {
                        this.toaster.open({ text: 'Achievement added successfully', position: 'top-center', type: 'success' });
                    }
                }
            );
        setTimeout(
            () => {
                location.reload(); // the code to execute after the timeout
            },
            1000
        );
    }
    // Image Handling Function
    fileChangeEvent(fileInput: any) {
        this.imageError = "";
        if (fileInput.target.files && fileInput.target.files[0]) {
            const max_size = 20971520;
            const allowed_types = ['image/png', 'image/jpeg'];
            if (fileInput.target.files[0].size > max_size) {
                this.imageError =
                    'Maximum size allowed is ' + max_size / 1000 + 'Mb';
                return false;
            }
            if (!allowed_types.includes(fileInput.target.files[0].type)) {
                this.imageError = 'Only Images are allowed ( JPEG | PNG )';
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
                    this.achievement.base64header = this.cardImageBase64;
                    this.isImageSaved = true;
                }
            };
            reader.readAsDataURL(fileInput.target.files[0]);
        } return false
    }
    // Toggle for showing the details for adding the awards and certificates
    toggletag() {

        this.toggle = !this.toggle;

    }
    // Show Toast Message when Submit Button is Clicked
    submit() {
        this.toaster.open({ text: 'Form submitted successfully', position: 'top-center', type: 'success' });
    }
    // Sets footer for the Page
    footer() {

        this.foot = !this.foot;
        if (this.foot == false) { this.foot = true };
    }
}
