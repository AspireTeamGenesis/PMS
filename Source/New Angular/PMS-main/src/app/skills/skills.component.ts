import { Component, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Toaster } from 'ngx-toast-notifications';


@Component({
  selector: 'app-skills',
  templateUrl: './skills.component.html',
  styleUrls: ['./skills.component.css']
})
export class SkillsComponent implements OnInit {
  error: any;
  formSubmitted: boolean = false;
  skillForm: FormGroup;
  constructor(private FB: FormBuilder, private service: UserserviceService, private http: HttpClient, private route: ActivatedRoute, private toaster: Toaster) { }
  
  domainValue: any = {
    domainId: 0,
    domainName: ''
  }

  technologyValue: any={
    technologyId:0,
    technologyName:''
  }

  profileIdDetails: any = {
    profileId: 0
  }
  showMe: boolean = false;
  foot: boolean = true;

  ngOnInit(): void {
    this.skillForm = this.FB.group({
      domainType: ['', [Validators.required]],
      technologyType: ['', [Validators.required]]
    });
    this.getDomain();
    this.getTechnology();
    this.getProfileIdByUserId();
  }

  getDomain() {
    this.service.getDomain().subscribe((data: any) => {
      this.domainValue = data;
    });
  }

  getTechnology() {
    this.service.getTechnology().subscribe((data: any) => {
      this.technologyValue = data;
    });
  }

  getProfileIdByUserId() {
    this.service.getProfileIdByUserId().subscribe({
      next: (data: any) => {
        this.profileIdDetails = data;
      }
    })
  }

  submitSkills() {
    this.formSubmitted=true;
    const skillDetails={
      skillId:0,
      domainId:this.skillForm.value['domainType'],
      technologyId:this.skillForm.value['technologyType'],
      profileId:this.profileIdDetails.profileId,
    }
    this.service.submitSkills(skillDetails).subscribe({
      next: (data) => { },
      error: (error) => { this.error = error.error },
      complete: () => {
        this.toaster.open({ text: 'Skills added successfully', position: 'top-center', type: 'success' });
      }
    });
    setTimeout(
      () => {
        location.reload(); // the code to execute after the timeout
      },
      1000// the time to sleep to delay for
    );
  }

  toogletag() {
    this.showMe = !this.showMe;
  }

  footer() {
    this.foot = !this.foot;
    if (this.foot == false) { this.foot = true };
  }
}
