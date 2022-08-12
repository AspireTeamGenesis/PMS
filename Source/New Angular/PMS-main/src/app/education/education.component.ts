import { Component, OnInit, ViewChild } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { EducationcardComponent } from '../educationcard/educationcard.component';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Toaster } from 'ngx-toast-notifications';
@Component({
    selector: 'app-education',
    templateUrl: './education.component.html',
    styleUrls: ['./education.component.css']
})
export class EducationComponent implements OnInit {
    @ViewChild(EducationComponent) child: EducationcardComponent
    selectedYear: number = 0;
    years: number[] = [];
    educationForm: FormGroup;
    formSubmitted: boolean = false;
    error = ''
    constructor(private FB: FormBuilder, private service: UserserviceService, private http: HttpClient, private route: ActivatedRoute, private toaster: Toaster) {
        this.selectedYear = new Date().getFullYear();
        for (let year = this.selectedYear; year >= 1990; year--) {
            this.years.push(year);
        }
        this.educationForm = this.FB.group({});
    }
    showMe: boolean = false;
    foot: boolean = true;
    collegeValue: any;
    profileId: number = 0;
    profileDetails: any;
    profileIdDetails: any;
    ngOnInit() {
        this.educationForm = this.FB.group({
            Degree: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
            Course: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(500)]],
            College: ['', [Validators.required]],
            StartingYear: ['', [Validators.required]],
            EndingYear: ['', [Validators.required]],
            Percentage: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
        });
        this.getUserProfile;
        this.getCollege();
        this.getProfileIdByUserId();
    }
    getUserProfile() {
        this.service.getUserProfile().subscribe({
            next: (data) => {
                this.profileDetails = data
            }
        })
    }

    getProfileIdByUserId() {
        this.service.getProfileIdByUserId().subscribe({
            next: (data: any) => {
                this.profileIdDetails = data,
                    this.profileId = this.profileIdDetails.profileId
            }
        })
    }

    getCollege() {
        this.service.getCollege().subscribe({
            next: (data) => {
                this.collegeValue = data;
                console.warn(this.collegeValue);
            }
        });
    }

    educationSubmit() {
        const educationDetails = {
            educationId: 0,
            profileId: this.profileId,
            degree: this.educationForm.value['Degree'],
            course: this.educationForm.value['Course'],
            collegeId: this.educationForm.value['College'],
            starting: this.educationForm.value['StartingYear'],
            ending: this.educationForm.value['EndingYear'],
            percentage: this.educationForm.value['Percentage'],
        }
        this.service.addEducation(educationDetails).subscribe({
            next: (data) => { },
            error: (error) => { this.error = error.error.message },
            complete: () => {
                this.toaster.open({ text: 'Education details added successfully', position: 'top-center', type: 'success' });
            }
        });
        setTimeout(
            () => {
                location.reload(); // the code to execute after the timeout
            },
            500// the time to sleep to delay for
        );
    }
    toggletag() {
        this.showMe = !this.showMe;
    }
    footer() {
        this.foot = !this.foot;
        if (this.foot == false) { this.foot = true };
    }
}
