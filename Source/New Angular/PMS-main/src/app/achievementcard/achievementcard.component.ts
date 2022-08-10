import { Component, Input, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { DialogBoxComponent } from '../dialog-box/dialog-box.component';
import { DialogueboxService } from '../service/dialoguebox.service';

@Component({
    selector: 'app-achievementcard',
    templateUrl: './achievementcard.component.html',
    styleUrls: ['./achievementcard.component.css']
})
export class AchievementcardComponent implements OnInit {
    profileIdDetails: any;
    totalLength: any;
    page: number = 1;
    achievementDetails: any;
    profileId: number;
    constructor(private FB: FormBuilder, private service: UserserviceService, private http: HttpClient, private dialogueService: DialogueboxService) { }

    ngOnInit(): void {
        this.getProfileIdByUserId();
    }
    getProfileIdByUserId() {
        this.service.getProfileIdByUserId().subscribe({
            next: (data: any) => {
                this.profileIdDetails = data,
                    this.profileId = this.profileIdDetails.profileId,
                    this.getAchievementByProfileId();
            }
        })
    }

    getAchievementByProfileId() {
        console.log('child called')
        this.service.getAchievementByProfileId(this.profileId).subscribe((data) => {
            this.achievementDetails = data;
            this.totalLength = this.achievementDetails.length;
            console.warn(this.achievementDetails);
        })
    }

    async cancelAchievement(achievementid: number) {
        await this.dialogueService.IsDeleteConfirmed().then((value) => {

            if (value)
                this.service.cancelAchievement(achievementid).subscribe(() => this.getAchievementByProfileId());
        });

        setTimeout(
            () => {
                location.reload(); // the code to execute after the timeout
            },
            500// the time to sleep to delay for
        );
    }


}
