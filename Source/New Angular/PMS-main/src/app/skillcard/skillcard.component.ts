import { Component, Input, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { FormGroup,FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { DialogueboxService } from '../service/dialoguebox.service';

@Component({
  selector: 'app-skillcard',
  templateUrl: './skillcard.component.html',
  styleUrls: ['./skillcard.component.css']
})
export class SkillcardComponent implements OnInit {
  @Input() profileId:number
  totalLength:any;
  profileIdDetails:any;
  page:number=1;
  skillDetails:any;
  // profileId=2;
  constructor(private FB: FormBuilder,private service: UserserviceService,private http: HttpClient,private dialogueService: DialogueboxService) { }

  ngOnInit(): void {
    this.getProfileIdByUserId();
  }

  getProfileIdByUserId()
  {
    this.service.getProfileIdByUserId().subscribe({
        next:(data:any)=>{this.profileIdDetails=data,
        this.profileId=this.profileIdDetails.profileId,
        console.warn(this.profileId),
        console.log(this.profileIdDetails),
        this.getSkillByProfileId();
          }
    })
  }

  getSkillByProfileId()
  {
    console.log('child called')
    this.service.getSkillByProfileId(this.profileId).subscribe((data)=>{
      this.skillDetails=data;
       this.totalLength=this.skillDetails.length;
       console.warn(this.skillDetails);
     })
  }

  async cancelSkill(skillid: number) {


    await this.dialogueService.IsDeleteConfirmed().then((value) => {

      if (value)
        this.service.cancelSkill(skillid).subscribe(() => this.getSkillByProfileId());
    });

    setTimeout(
      () => {
          location.reload(); // the code to execute after the timeout
      },
      500// the time to sleep to delay for
  );
  }
}
