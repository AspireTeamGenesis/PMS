import { Component, OnInit } from '@angular/core';
import { UserserviceService } from 'src/app/service/userservice.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-language',
  templateUrl: './language.component.html',
  styleUrls: ['./language.component.css']
})
export class LanguageComponent implements OnInit {

  constructor(private FB: FormBuilder, private service: UserserviceService, private http: HttpClient) { }
  profileIdDetails: any;
  profileId: any;
  personalDetails: any;
  languageArray: any = [];
  ngOnInit(): void {
    this.getProfileIdByUserId();
  }
  getProfileIdByUserId() {
    this.service.getProfileIdByUserId().subscribe({
      next: (data: any) => {
        this.profileIdDetails = data,
          this.profileId = this.profileIdDetails.profileId,
          console.warn(this.profileId),
          console.log(this.profileIdDetails),
          this.getPersonalDetailsByProfileId(this.profileId)


      }

    })
  }
  getPersonalDetailsByProfileId(profileId: number) {
    this.service.getPersonalDetailByProfileId(profileId).subscribe({
      next: (data: any) => {
        this.personalDetails = data,
          console.log(this.personalDetails)
        for (var item in this.personalDetails[0]['language']) {
          console.log(this.personalDetails[0]['language'][item]['languageName'])
          this.languageArray.push(this.personalDetails[0]['language'][item]['languageName'])
        }

      }
    });
  }
  // disableLanguage()
  // {
  //   this.service.disableLanguage().subscribe();
  // }

}
