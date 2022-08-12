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
    // Pagenation Settings
    totalLength: any;
    page: number = 1;
    // To store Approved Profile Response from Server
     approvedProfiles: any;
    constructor(private service: UserserviceService, private http: HttpClient, private toaster: Toaster) { }
    // Component Initialization
    ngOnInit(): void {
        this.getProfileByApprovedStatus();
    }
//    Gets Profile By Approved Status
    getProfileByApprovedStatus() {
        this.service.getProfileByApprovedStatus().subscribe({
            next: (data: any) => {
                this.approvedProfiles = data
            }
        })
    }
    // Request to Update Function
    editToUpdate() {
        this.toaster.open({ text: 'Request to update sent successfully via mail', position: 'top-center', type: 'success' })
    }

}
