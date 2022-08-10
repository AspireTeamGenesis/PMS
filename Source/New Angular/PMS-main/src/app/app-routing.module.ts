import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Card11Component } from './card11/card11.component';
import { CardComponent } from './hr/card/card.component';
import { CreateusersComponent } from './hr/createusers/createusers.component';
import { HrhomeComponent } from './hr/hrhome/hrhome.component';
import { LoginComponent } from './hr/login/login.component';
import { SearchComponent } from './hr/search/search.component';
import { ChangepasswordComponent } from './changepassword/changepassword.component';
import { HrprofileComponent } from './hrprofile/hrprofile.component';
import { EducationComponent } from './education/education.component';
import { EdituserComponent } from './edituser/edituser.component';
import { EditeducationComponent } from './editeducation/editeducation.component';
import { AchievementComponent } from './achievement/achievement.component';
import { EducationtwoComponent } from './educationtwo/educationtwo.component';
import { SkillsComponent } from './skills/skills.component';
import { SkillcardComponent } from './skillcard/skillcard.component';
import { ProjectComponent } from './project/project.component';
import { ProjectcardComponent } from './projectcard/projectcard.component';
import { EditskillComponent } from './editskill/editskill.component';
import { ProfilehomeComponent } from './profilehome/profilehome.component';
import { ViewprofileComponent } from './viewprofile/viewprofile.component';
import { EditprojectComponent } from './editproject/editproject.component';
import { CreateprofileComponent } from './createprofile/createprofile.component';
import { PersonalComponent } from './personal/personal.component';
import { EditpersonalComponent } from './editpersonal/editpersonal.component';
import { HrchangepasswordComponent } from './hrchangepassword/hrchangepassword.component';
import { ApprovedprofileComponent } from './approvedprofile/approvedprofile.component';
import { DeclinedprofileComponent } from './declinedprofile/declinedprofile.component';
import { ViewprofileByIdComponent } from './viewprofile-by-id/viewprofile-by-id.component';
import { WaitingprofileComponent } from './waitingprofile/waitingprofile.component';
import { TotalprofileComponent } from './totalprofile/totalprofile.component';
import { Dashboard11Component } from './dashboard11/dashboard11.component';
import { SnapbarComponent } from './snapbar/snapbar.component';
import { LanguageComponent } from './language/language.component';
import { SharepageComponent } from './sharepage/sharepage.component';
import { LanguageandsocialComponent } from './languageandsocial/languageandsocial.component';
import { EditoriginalpersonalComponent } from './editoriginalpersonal/editoriginalpersonal.component';
import { HomecardComponent } from './homecard/homecard.component';
import { MyInfoComponent } from './my-info/my-info.component';
import { DummyComponent } from './dummy/dummy.component';


const routes: Routes = [
  {path:"hrhome",component:HrhomeComponent},
  {path:"search",component:SearchComponent},
  {path:"card",component:CardComponent},
  {path:"newcard",component:Card11Component},
  {path:"createuser",component:CreateusersComponent},
  {path:"changepassword",component:ChangepasswordComponent},
  {path:"hrprofile",component:HrprofileComponent},
  {path:"hrprofile/:userId",component:HrprofileComponent},
  {path:"education",component:EducationComponent},
  {path:"editUser/:userId",component:EdituserComponent},
  {path:"editeducation/:educationid",component:EditeducationComponent},
  {path:"achievement",component:AchievementComponent},
  {path:"educationtwo",component:EducationtwoComponent},
  {path:"skill",component:SkillsComponent},
  {path:"skillcard",component:SkillcardComponent},
  {path:"achievement",component:AchievementComponent},
  {path:"project",component:ProjectComponent},
  {path:"projectcard",component:ProjectcardComponent},
  {path:"editproject/:projectid",component:EditprojectComponent},
  {path:"editskill/:skillid",component:EditskillComponent},
  {path:"profilehome",component:ProfilehomeComponent},
  {path:"viewprofile",component:ViewprofileComponent},
  {path:"createprofile",component:CreateprofileComponent},
  {path:"editpersonal",component:EditpersonalComponent},
  {path:"personal",component:PersonalComponent},
  {path:"hrchangepassword",component:HrchangepasswordComponent},
  {path:"approvedprofile",component:ApprovedprofileComponent},
  {path:"declinedprofile",component:DeclinedprofileComponent},
  {path:"viewprofilebycard/:userId",component:ViewprofileByIdComponent},
  {path:"waitingprofile",component:WaitingprofileComponent},
  {path:"totalprofile",component:TotalprofileComponent},
  {path:"dashboard",component:Dashboard11Component},
  {path:"snapbar",component:SnapbarComponent},
  {path:"language",component:LanguageComponent},
  {path:"sharepage/:name",component:SharepageComponent},
  {path:"languagesocial",component:LanguageandsocialComponent},
  {path:"editoriginalpersonal",component:EditoriginalpersonalComponent},
  {path:"homecard",component:HomecardComponent},
  {path: "myinfo",component:MyInfoComponent},
  {path:"dummy",component:DummyComponent},
  {path:"",component:LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
