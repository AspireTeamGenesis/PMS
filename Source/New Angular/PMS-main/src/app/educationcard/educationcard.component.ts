import { Component, Input, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { FormGroup,FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { DialogueboxService } from '../service/dialoguebox.service';

@Component({
  selector: 'app-educationcard',
  templateUrl: './educationcard.component.html',
  styleUrls: ['./educationcard.component.css']
})
export class EducationcardComponent implements OnInit {
  @Input() 
  public profileId:number
  totalLength:any;
  page:number=1;
  educationDetails:any;
  profileIdDetails:any;
  // profileId=7;
  // hello:100;
  constructor(private FB: FormBuilder,private service: UserserviceService,private http: HttpClient, private route : Router,private dialogueService:DialogueboxService) { }
  
  ngOnInit(): void {
    this.getProfileIdByUserId();   
    console.warn(this.profileId);
  }

  getProfileIdByUserId()
  {
    this.service.getProfileIdByUserId().subscribe({
        next:(data:any)=>{this.profileIdDetails=data,
        this.profileId=this.profileIdDetails.profileId,
        console.warn(this.profileId),
        console.log(this.profileIdDetails),
        this.getEducationByProfileId();  }
    })
  }
  
  getEducationByProfileId()
  {
    console.log('child called')
    this.service.getEducationByProfileId(this.profileId).subscribe((data)=>{
      this.educationDetails=data;
       this.totalLength=this.educationDetails.length;
       console.warn(this.educationDetails);
     })
  }

  // navigate(){
  //   this.route.navigate(['/editeducation/this.educationDetails.educationId/this.profileId'])
  // }

  // cancelEducation(educationid:number)
  // {
  //   this.service.cancelEducation(educationid).subscribe(()=>this.getEducationByProfileId());
  // }
  async cancelEducation(educationid: number) {

  
    await this.dialogueService.IsDeleteConfirmed().then((value)=> {

      if(value)
      this.service.cancelEducation(educationid).subscribe(()=>this.getEducationByProfileId());    
    });

    setTimeout(
      () => {
          location.reload(); // the code to execute after the timeout
      },
      500// the time to sleep to delay for
  );
  }

}
