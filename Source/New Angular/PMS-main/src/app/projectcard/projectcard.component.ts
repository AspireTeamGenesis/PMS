import { Component, Input, OnInit} from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { FormGroup,FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { DialogBoxComponent } from '../dialog-box/dialog-box.component';
import { DialogueboxService } from '../service/dialoguebox.service';

@Component({
  selector: 'app-projectcard',
  templateUrl: './projectcard.component.html',
  styleUrls: ['./projectcard.component.css']
})
export class ProjectcardComponent implements OnInit {
  @Input() profileId:number
  totalLength:any;
  page:number=1;
  projectDetails:any;
  profileIdDetails:any;
  // profileId=2;
  constructor(private FB: FormBuilder,private service: UserserviceService,private http: HttpClient, private dialogueService: DialogueboxService) { }
  
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
        this.getProjectDetailByProfileID();
          }
    })
  }

  getProjectDetailByProfileID()
  {
    console.log('child called')
    this.service.getProjectDetailByProfileID(this.profileId).subscribe((data)=>{
      this.projectDetails=data;
       this.totalLength=this.projectDetails.length;
       console.log("Hi Project");
       console.warn(this.projectDetails);
     })
     console.log(this.projectDetails);
  }
  // console.log(projectDetails);

  
  async cancelProject(projectid: number) {


    await this.dialogueService.IsDeleteConfirmed().then((value) => {

      if (value)
        this.service.cancelProject(projectid).subscribe(() => this.getProjectDetailByProfileID());
    });

    setTimeout(
      () => {
          location.reload(); // the code to execute after the timeout
      },
      500// the time to sleep to delay for
  );
  }

}
