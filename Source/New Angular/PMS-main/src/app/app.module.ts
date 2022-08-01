import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreateusersComponent } from './hr/createusers/createusers.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { TopbarComponent } from './topbar/topbar.component';
import { HrhomeComponent } from './hr/hrhome/hrhome.component';
import { HomeComponent } from './hr/home/home.component';
import { SearchComponent } from './hr/search/search.component';
import { LoginComponent } from './hr/login/login.component';
import { CardComponent } from './hr/card/card.component';
import { Card11Component } from './card11/card11.component';
import { HttpClientModule } from '@angular/common/http';
import {NgxPaginationModule} from 'ngx-pagination';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ChangepasswordComponent } from './changepassword/changepassword.component';
import { HrprofileComponent } from './hrprofile/hrprofile.component';
import { EducationComponent } from './education/education.component';
import { EdituserComponent } from './edituser/edituser.component';
import { EditeducationComponent } from './editeducation/editeducation.component';
import { EducationcardComponent } from './educationcard/educationcard.component';
import { AchievementComponent } from './achievement/achievement.component';
import { SkillsComponent } from './skills/skills.component';
import { ProjectComponent } from './project/project.component';
import { EducationtwoComponent } from './educationtwo/educationtwo.component';
import { SkillcardComponent } from './skillcard/skillcard.component';
import { ProjectcardComponent } from './projectcard/projectcard.component';
import { EditskillComponent } from './editskill/editskill.component';
import { AchievementcardComponent } from './achievementcard/achievementcard.component';
import { ProfilehomeComponent } from './profilehome/profilehome.component';
import { ViewprofileComponent } from './viewprofile/viewprofile.component';
import { EditprojectComponent } from './editproject/editproject.component';
import { CreateprofileComponent } from './createprofile/createprofile.component';
import { PersonalComponent } from './personal/personal.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { EditpersonalComponent } from './editpersonal/editpersonal.component';
import { DatePipe } from '@angular/common';
import { HrsearchComponent } from './hrsearch/hrsearch.component';
import { HrsidebarComponent } from './hrsidebar/hrsidebar.component';
import { HrchangepasswordComponent } from './hrchangepassword/hrchangepassword.component';
import { FiltercardComponent } from './filtercard/filtercard.component';
import { ApprovedprofileComponent } from './approvedprofile/approvedprofile.component';
import { DeclinedprofileComponent } from './declinedprofile/declinedprofile.component';
import { DocumentCreator } from './profile-generator';
import { ViewprofileByIdComponent } from './viewprofile-by-id/viewprofile-by-id.component';
import { WaitingprofileComponent } from './waitingprofile/waitingprofile.component';
import { TotalprofileComponent } from './totalprofile/totalprofile.component';
import { Dashboard11Component } from './dashboard11/dashboard11.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { SnapbarComponent } from './snapbar/snapbar.component';
import { LanguageComponent } from './language/language.component';
import { SharepageComponent } from './sharepage/sharepage.component';
import { ToastNotificationsModule } from 'ngx-toast-notifications';
import { LanguageandsocialComponent } from './languageandsocial/languageandsocial.component';
import { EditoriginalpersonalComponent } from './editoriginalpersonal/editoriginalpersonal.component';
import { MatDialogModule } from '@angular/material/dialog';
import { DialogBoxComponent } from './dialog-box/dialog-box.component';
import { HomecardComponent } from './homecard/homecard.component';
import { MyInfoComponent } from './my-info/my-info.component';
@NgModule({
  declarations: [		
    AppComponent,
    CreateusersComponent,
    SidebarComponent,
    TopbarComponent,
    HrhomeComponent,
    HomeComponent,
    SearchComponent,
    LoginComponent,
    CardComponent,
    Card11Component,
    ChangepasswordComponent,
    HrprofileComponent,
    EducationComponent,
    EdituserComponent,
    EditeducationComponent,
    EducationcardComponent,
    AchievementComponent,
    SkillsComponent,
    ProjectComponent,
    EducationtwoComponent,
    SkillcardComponent,
    ProjectcardComponent,
    EditskillComponent,
    AchievementcardComponent,
    ProfilehomeComponent,
    ViewprofileComponent,
    EditprojectComponent,
    CreateprofileComponent,
    PersonalComponent,
    EditpersonalComponent,
    HrsearchComponent,
    HrsidebarComponent,
    HrchangepasswordComponent,
    FiltercardComponent,
    ApprovedprofileComponent,
    DeclinedprofileComponent,
    ViewprofileByIdComponent,
    WaitingprofileComponent,
    TotalprofileComponent,
      Dashboard11Component,
      SnapbarComponent,
      LanguageComponent,
      SharepageComponent,
      LanguageandsocialComponent,
      EditoriginalpersonalComponent,
      DialogBoxComponent,
      HomecardComponent,
      MyInfoComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgxPaginationModule,
    Ng2SearchPipeModule,
    FormsModule,
    ReactiveFormsModule,
    NoopAnimationsModule,
    MatAutocompleteModule,
    MatFormFieldModule,
    MatInputModule,
    ToastNotificationsModule.forRoot({duration: 6000, type: 'primary'}),
    MatDialogModule
  ],
  providers: [DocumentCreator],
  // providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
