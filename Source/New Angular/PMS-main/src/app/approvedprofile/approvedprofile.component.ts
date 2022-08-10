import { Component, Input, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Toaster } from 'ngx-toast-notifications';

@Component({
    selector: 'app-approvedprofile',
    templateUrl: './approvedprofile.component.html',
    styleUrls: ['./approvedprofile.component.css']
})
export class ApprovedprofileComponent implements OnInit {

    profileIdDetails: any;

    totalLength: any;
    page: number = 1;
    achievementDetails: any;
    profileId: number;
    approvedProfiles: any;
    constructor(private FB: FormBuilder, private service: UserserviceService, private http: HttpClient, private toaster: Toaster) { }

    ngOnInit(): void {
        this.getProfileByApprovedStaus();
    }
    getProfileByApprovedStaus() {
        this.service.getProfileByApprovedStaus().subscribe({
            next: (data: any) => {
                this.approvedProfiles = data
            }
        })
    }
    editToUpdate() {
        this.toaster.open({ text: 'Request to update sent successfully via mail', position: 'top-center', type: 'success' })
    }

}
