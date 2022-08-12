import { Component, OnInit } from '@angular/core';
import { UserserviceService } from '../service/userservice.service';
import { FormGroup,FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Toaster } from 'ngx-toast-notifications';

@Component({
  selector: 'app-editproject',
  templateUrl: './editproject.component.html',
  styleUrls: ['./editproject.component.css']
})
export class EditprojectComponent implements OnInit {
  selectedYear: number=0;
  years: number[] = [];
  projectForm:FormGroup;
  error: any;

  constructor(private FB: FormBuilder, private service: UserserviceService, private http: HttpClient, private route: ActivatedRoute,private toaster:Toaster) {
    this.projectForm=this.FB.group({});
    this.selectedYear = new Date().getFullYear();
  for (let year = this.selectedYear; year >= 2000; year--) {
    this.years.push(year);
  }
    }
    projectDetails:any;
    projectid:number=0;
    profileId:number=0;
    showMe: boolean = false;
    formSubmitted: boolean = false;
    foot:boolean = true;
    projectfield: any = {
      projectId: 0,
      profileId: 0,
      projectName: '',
      projectDescription: '',
      startingMonth: '',
      startingYear: 0,
      endingMonth: '',
      endingYear: 0,
      designation: '',
      toolsUsed: '',
  
    }
  

  ngOnInit(): void {
    this.projectForm=this.FB.group({
      ProjectName: ['', [Validators.required,Validators.minLength(3),Validators.maxLength(100)]],
      ProjectDescription: ['', [Validators.required,Validators.minLength(3),Validators.maxLength(500)]],
      StartingMonth: ['', [Validators.required,Validators.minLength(3),Validators.maxLength(40)]],
      StartingYear: ['', [Validators.required]],
      EndingMonth: ['', [Validators.required,Validators.minLength(3),Validators.maxLength(40)]],
      EndingYear: ['', Validators.required],
      RolePlayed: ['', [Validators.required,Validators.minLength(2),Validators.maxLength(100)]],
      ToolsUsed: ['', [Validators.required,Validators.minLength(3),Validators.maxLength(600)]],
    });
    this.route.params.subscribe(params => {
      this.projectid = params['projectid'];
      this.profileId=params['profileId'];
      console.log('Project id : ' + this.projectid);
    })
    this.getProjectDetailsByProjectId(this.projectid);
  }
  getProjectDetailsByProjectId(projectId:number)
  {
    console.log(projectId);
    this.service.getProjectDetailsByProjectId(projectId).subscribe( (data)=>{
      this.projectDetails=data;
      console.log(this.projectDetails)});

  }
  updateproject()
  {
    this.formSubmitted=true;
    const project = {
      projectId: this.projectid,
      profileId: 7,
      projectName: this.projectDetails.projectname,
      projectDescription: this.projectDetails.projectdescription,
      startingMonth:this.projectDetails.startingMonth,
      startingYear: this.projectDetails.startingYear,
      endingMonth: this.projectDetails.endingMonth,
      endingYear: this.projectDetails.endingYear,
      designation :this.projectDetails.role,
      toolsUsed:this.projectDetails.toolsused
    }
      console.log("updateProject");
      console.log(project);
      this.service.updateproject(project).subscribe({
        error: (error) => { this.error = error.error.message },
        complete: () => {
          this.toaster.open({ text: 'Project edited successfully', position: 'top-center', type: 'success' });
        }
      });
  }

  toggletag()
  {
    this.showMe=!this.showMe;
  }

  footer()
  {
    this.foot=!this.foot;
    if(this.foot==false){this.foot=true};
  }

}
