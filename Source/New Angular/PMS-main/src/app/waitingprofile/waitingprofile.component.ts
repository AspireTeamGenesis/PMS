import { Component, Input, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Toaster } from 'ngx-toast-notifications';
@Component({
  selector: 'app-waitingprofile',
  templateUrl: './waitingprofile.component.html',
  styleUrls: ['./waitingprofile.component.css']
})
export class WaitingprofileComponent implements OnInit {

  profileIdDetails: any;

  totalLength: any;
  page: number = 1;
  achievementDetails: any;
  profileId: number;
  waitingProfiles: any;
  acceptedProfile: any

  constructor(private FB: FormBuilder, private service: UserserviceService, private http: HttpClient, private toaster: Toaster) { }

  ngOnInit(): void {
    this.getProfileByWaitingStatus();
  }
  getProfileByWaitingStatus() {
    this.service.getProfileByWaitingStatus().subscribe({
      next: (data: any) => {
        this.waitingProfiles = data
      }
    })
  }
  acceptorrejectprofile(profileid: number, response: number) {
    this.service.acceptorrejectprofile(profileid, response).subscribe
      ({
        next: (data: any) => {
          this.acceptedProfile = data
        },
        complete: () => {
          this.toaster.open({ text: 'updated successfully', position: 'top-center', type: 'success' });
        }


});
setTimeout(
  () => {
    location.reload(); // the code to execute after the timeout
  },
  1000// the time to sleep to delay for
);


  }
editToUpdate() {
  this.toaster.open({ text: 'Request to update sent successfully via mail', position: 'top-center', type: 'success' })
}
}