import { Component, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { Packer } from "docx";
import { saveAs } from 'file-saver';
import { DocumentCreator } from "../profile-generator";
import { formatDate } from '@angular/common';

@Component({
    selector: 'app-viewprofile',
    templateUrl: './viewprofile.component.html',
    styleUrls: ['./viewprofile.component.css']
})
export class ViewprofileComponent implements OnInit {
    update: string;

    constructor(private service: UserserviceService, private view: DocumentCreator) { }
    profileId: number;
    profileIdDetails = {
        profileId: 0,
        profilestatus: '',
        updateddate:''
    };
    education: any;
    project: any;
    skill: any;
    language: any;
    objective: any;
    profileDetails: any;
    userDetails = {
        name: '',
        email: '',
        mobilenumber: '',
        userid: 0,
        designation: '',
        language:''
    };
    personalDetails: any;

    showMe: boolean = false;
    showMe1: boolean = false;
    showMe2: boolean = false;
    showMe3: boolean = false;
    showMe4: boolean = false;
    ngOnInit(): void {
        this.getUserDetails();
        this.getProfileIdByUserId();
    }

    createContactInfo() {
        this.view.createContactInfo(this.userDetails.mobilenumber, this.userDetails.designation, this.userDetails.email, this.userDetails.name);
    }

    createpersonalInfo() {
        this.view.createpersonalInfo(this.profileDetails['personaldetails'].objective);
    }

    toggletag() {
        this.showMe = !this.showMe;
    }
    toggletag1() {
        this.showMe1 = !this.showMe1;
    }
    toggletag2() {
        this.showMe2 = !this.showMe2;
    }
    toggletag3() {
        this.showMe3 = !this.showMe3;
    }
    toggletag4() {
        this.showMe4 = !this.showMe4;
    }

    getProfileByProfileId(profileId: number) {
        this.service.getProfileByProfileId(profileId).subscribe({
            next: (data: any) => {
                this.profileDetails = data,
                    this.language = this.profileDetails['personaldetails'].language;
                this.createpersonalInfo();
            }
        })
    }

    getUserDetails() {
        this.service.getUserProfile().subscribe({
            next: (data: any) => {
                this.userDetails = data,
                this.createContactInfo();
            },

        })
    }

    getEducationDetailsByProfileId(profileId: number) {
        this.service.getEducationDetailsByProfileId(profileId).subscribe({
            next: (data: any) => {
                this.education = data
            }
        })
    }

    getProjectDetailsByProfileId(profileId: number) {
        this.service.getProjectDetailsByProfileId(profileId).subscribe({
            next: (data: any) => {
                this.project = data
            }
        })
    }

    getSkillDetailsByProfileId(profileId: number) {
        this.service.getSkillDetailsByProfileId(profileId).subscribe({
            next: (data: any) => {
                this.skill = data
            }
        })
    }

    getProfileIdByUserId() {
        this.service.getProfileIdByUserId().subscribe({
            next: (data: any) => {
                this.profileIdDetails = data,
                console.log(this.profileIdDetails),
                this.profileId = this.profileIdDetails.profileId,
                this.update = formatDate(this.profileIdDetails.updateddate, 'dd-MM-YYYY', 'en'),
                this.getProfileByProfileId(this.profileId),
                this.getEducationDetailsByProfileId(this.profileId)
                this.getProjectDetailsByProfileId(this.profileId)
                this.getSkillDetailsByProfileId(this.profileId)
            }
        })
    }

    getPersonalDetailByProfileId(profileId: number) {
        this.service.getPersonalDetailByProfileId(profileId).subscribe({
            next: (data: any) => {
                this.personalDetails = data,
                this.createpersonalInfo();
            },
        })
    }
    updateProfileStatus() {
        const profile =
        {
            userId: this.userDetails.userid,
            profileId: this.profileIdDetails.profileId,
            profileStatusId: 2
        }
        console.log(profile);
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
            saveAs(blob, "example.docx");
            console.log("Document created successfully");
        });
    }
}
