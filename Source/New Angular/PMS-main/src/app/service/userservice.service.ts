import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { User} from 'Models/user';
import { Designation } from 'Models/designation';
import { Organisation } from 'Models/organisation';
import { College } from 'Models/college';
import { AuthenticationService } from './authentication.service';


@Injectable({
  providedIn: 'root'
})
export class UserserviceService {

  // headers= new HttpHeaders({ 
  //     'Access-Control-Allow-Origin':'*',
  //     'Access-Control-Allow-Methods': '*',
  //     'Access-Control-Allow-Headers':'*'
  //   })

  baseurl = 'https://localhost:7021/'
  constructor(private http: HttpClient) { }

  private headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${AuthenticationService.GetData("token")}`
  })

  getUserDetails(userId:number)
  {
    return this.http.get<any>(`https://localhost:7021/User/GetUserById?id=${userId}`,{ headers: this.headers });
  }
  getUserProfile()
  {
    return this.http.get<any>(`https://localhost:7021/User/GetUserProfile`,{ headers: this.headers });
  }

 
  // headers = new HttpHeaders({
  //   'Content-Type': 'application/json',
  // })
  // constructor(private http: HttpClient) { }

  getDesignation():Observable<Designation[]>
  {
    return this.http.get<Designation[]>('https://localhost:7021/Designation/ViewDesignations');
  }

  getCollege()
  {
    return this.http.get<any>('https://localhost:7021/College/ViewColleges');
  }

  getDomain()
  {
    return this.http.get<any>('https://localhost:7021/Domain/ViewDomains');
  }

  getTechnology()
  {
    return this.http.get<any>('https://localhost:7021/Technology/ViewTechnologies');
  }

  getProfileStatus()
  {
    return this.http.get<any>('https://localhost:7021/ProfileStatus/ViewProfileStatuss');   
  }

  
  getOrganisation():Observable<Organisation[]>
  {
    return this.http.get<Organisation[]>('https://localhost:7021/Organisation/ViewOrganisations');
  }

  onSubmit(userPassword:any)
  {
    console.log(userPassword);
    return this.http.put<any>(`https://localhost:7021/User/ChangePassword/Change Password?OldPassword=${userPassword.OldPassword}&NewPassword=${userPassword.NewPassword}&ConfirmPassword=${userPassword.ConfirmPassword}`,userPassword,{headers:this.headers})
  }


  Login(user:any)
  {
       return this.http.post<any>(`https://localhost:7021/Login/AuthLogin/Login?Username=${user.UserName}&password=${user.Password}`, user, { headers: this.headers })
  
  }
  // Login(user: any) {
  //   return this.http.post<any>(`https://localhost:7021/Login/AuthLogin/Login?Username=${user.UserName}&password=${user.Password}`, user, { headers: this.header })
  // }

  addEducation(user:any)
  {
    return this.http.post<any>(`https://localhost:7021/Profile/AddEducation`,user,{headers : this.headers});   
  }

  getEducationDetails(educationId:number)
  {
    return this.http.get<any>(`https://localhost:7021/Profile/GetEducationDetailsById?Educationid=${educationId}`,{headers:this.headers});
  }

  addEmployee(userValue:User):Observable<User>
  {
  const url='https://localhost:7021/User/AddUser';
  console.warn(userValue);
  return this.http.post<User>(url,userValue,{headers : this.headers});
  }

  CancelDrive(userId:number){
    console.log(userId);
     return this.http.delete<any>(`https://localhost:7021/User/Disable?id=${userId}`, { headers: this.headers });
  }
  updateUser(user:any)
  {
    return this.http.put<any>(`https://localhost:7021/User/UpdateUser`,user,{headers:this.headers});
  }

  updateEducation(education:any)
  {
    console.log("updateEducation");
    console.log(education);
    return this.http.put<any>(`https://localhost:7021/Profile/UpdateEducation`,education,{headers:this.headers});
  }
  getEducationByProfileId(profileId:number)
  {
    return this.http.get<any>( `https://localhost:7021/Profile/GetAllEducationDetailsByProfileId?Profileid=${profileId}`,{ headers: this.headers });
  }

  addAchievement(achievement:any)
  {
    return this.http.post<any>(`https://localhost:7021/Profile/AddAchievement`,achievement,{headers : this.headers});   

  }

  submitSkills(skill:any)
  {
    return this.http.post<any>(`https://localhost:7021/Profile/AddSkills`,skill,{headers : this.headers});   
  }

  getSkillByProfileId(profileId:number)
  {
    return this.http.get<any>( `https://localhost:7021/Profile/GetAllSkillDetailsByProfileId?Profileid=${profileId}`,{ headers: this.headers });
  }

  cancelEducation(educationId:number)
  {
    return this.http.delete<any>(`https://localhost:7021/Profile/DisableEducationalDetails?EducationId=${educationId}`, { headers: this.headers });
  }

  cancelSkill(skillid:number)
  {
    return this.http.delete<any>(`https://localhost:7021/Profile/DisableSkillDetails?SkillId=${skillid}`, { headers: this.headers });
  }


  // getProjectDetail(id : number) : Observable<any>{
  //   return this.http.get<any>(this.baseurl + `GetProjectDetailsById?Projectid=${id}`);
  // }
  
  getProjectDetailByProfileID(id : number) : Observable<any>{
    return this.http.get<any>(`https://localhost:7021/Profile/GetAllProjectDetailsByProfileId?Profileid=${id}`,{headers:this.headers});
  }
  
  getallProjectDetailByProfile( ) : Observable<any>{
    return this.http.get<any>(this.baseurl + `GetallProjectDetails`);
  }
  UpdateProjects(data:any){
    return this.http.put<any>(this.baseurl + `UpdateProjects`,data);
  }
  CreateProjects(data:any)
  {
    return this.http.post<any>(`https://localhost:7021/Profile/AddProjects`,data,{headers:this.headers});
  }


  getProjectByProfileId(profileId:number)
  {
    return this.http.get<any>(`https://localhost:7021/Profile/GetProjectDetailsById?Projectid=${profileId}`,{ headers: this.headers })
  }

  cancelProject(projectid:number)
  {
    return this.http.delete<any>(`https://localhost:7021/Profile/DisableProjectDetails?ProjectsId=${projectid}`, { headers: this.headers });
  }

  updateSkills(skill:any)
  {
    console.log(skill);
    return this.http.put<any>(`https://localhost:7021/Profile/UpdateSkills`,skill,{headers : this.headers});   
  }

  getSkillDetailsBySkillId(skillId:number)
  {
    console.log(skillId);
    return this.http.get<any>(`https://localhost:7021/Profile/GetSkillDetailsById?Skillid=${skillId}`,{headers : this.headers});
  }

  getAchievementByProfileId(profileId:number)
  {
     return this.http.get<any>(`https://localhost:7021/Profile/GetAllAchievementDetailsByProfileId?Profileid=${profileId}`,{headers : this.headers})
  }

  cancelAchievement(achievementid:number)
  {
    return this.http.delete<any>(`https://localhost:7021/Profile/DisableAchievements?achievementId=${achievementid}`,{headers : this.headers})
  }


  getProfileByProfileId(profileId:number)
  {
    return this.http.get<any>(`https://localhost:7021/Profile/GetProfileById?id=${profileId}`,{headers:this.headers});
  }

  getProjectDetailsByProjectId(projectId:number)
  {
    return this.http.get<any>(`https://localhost:7021/Profile/GetProjectDetailsById?Projectid=${projectId}`,{headers:this.headers});

  }
  updateproject(project:any)
  {
    return this.http.put<any>(`https://localhost:7021/Profile/UpdateProjects`,project,{headers : this.headers}); 
  }




  addPersonalDetail(user:any)
  {
    return this.http.post<any>(`https://localhost:7021/Profile/AddPersonalDetail`,user,{headers : this.headers}); 
  }

  getPersonalDetails(personalId:number)
  {    
    return this.http.get<any>(`https://localhost:7021/Profile/GetPersonalDetailsById?Personalid=${personalId}`,{headers:this.headers});
  }

  updatePersonalDetail(personalDetails:any)
  {
    console.log("updateEducation");
    console.log(personalDetails);
    return this.http.put<any>(`https://localhost:7021/Profile/UpdatePersonalDetail`,personalDetails,{headers:this.headers});
  }

  // getPersonalDetailByProfileId(profileId:number)
  // {
  //   return this.http.get<any>( `https://localhost:7021/Profile/GetPersonalDetailsByProfileId?Profileid=${profileId}`,{ headers: this.headers });
  // }


  
  createProfile(profile:any)
  {
    return this.http.post<any>(`https://localhost:7021/Profile/AddProfile`,profile,{headers : this.headers}); 
  }


  dashboardcount()
  {
    return this.http.get<any>(`https://localhost:7021/Profile/GetProfileCount`,{headers : this.headers});
  }

  getProfileIdByUserId()
  {
    return this.http.get<any>(`https://localhost:7021/Profile/GetProfileIdByUserId`,{headers:this.headers});
  }

  getProfileByFilters(filter:any)
  {
    return this.http.post<any>(`https://localhost:7021/Profile/GetFilteredProfile`,filter,{headers:this.headers});
  }

  getProfileByApprovedStaus()
  {
    return this.http.get<any>(`https://localhost:7021/User/Getallusers?profilestatusId=1`,{headers:this.headers});   
  }
  getProfileByDeclinedStatus()
  {
    return this.http.get<any>(`https://localhost:7021/User/Getallusers?profilestatusId=3`,{headers:this.headers});      
  }
  getProfileByWaitingStatus()
  {
    return this.http.get<any>(`https://localhost:7021/User/Getallusers?profilestatusId=2`,{headers:this.headers});      
  }

  getProfileBytotalStatus()
  {
    return this.http.get<any>(`https://localhost:7021/User/Getallusers?profilestatusId=0`,{headers:this.headers});         
  }

  getEducationDetailsByProfileId(profileId:number)

  {

    return this.http.get<any>(`https://localhost:7021/Profile/GetAllEducationDetailsByProfileId?Profileid=${profileId}`,{headers:this.headers});



  }

  getProjectDetailsByProfileId(profileId:number)

  {

    return this.http.get<any>(`https://localhost:7021/Profile/GetAllProjectDetailsByProfileId?Profileid=${profileId}`,{headers:this.headers});

  }

  getSkillDetailsByProfileId(profileId:number)

  {

    return this.http.get<any>(`https://localhost:7021/Profile/GetAllSkillDetailsByProfileId?Profileid=${profileId}`,{headers:this.headers});

  }

  getProfileIdByGivenUserId(userId:number)
  {
    return this.http.get<any>(`https://localhost:7021/Profile/GetProfileIdByGivenUserId?userId=${userId}`,{headers:this.headers});

  }
  getUserDetailsByUserId(userId:number)
  {
return this.http.get<any>(`https://localhost:7021/User/GetUserById?id=${userId}`,{headers:this.headers});

  }

  getProfileIdDetailsByUserId(userId:number)
  {
    return this.http.get<any>(`https://localhost:7021/Profile/GetProfileIdByGivenUserId?userId=${userId}`,{headers:this.headers});
  }
 


  // getProfileBySearch(username:any)
  // {
  //   return this.http.get<any>(``,{headers:this.headers});
  // }
acceptorrejectprofile(profileid : number,response : number)
{
  return this.http.post<any>(`https://localhost:7021/Profile/AcceptOrRejectProfile?profileId=${profileid}&response=${response}`,{headers:this.headers});
}

updateProfileStatus(profile:any)
{
  return this.http.put<any>(`https://localhost:7021/Profile/updateProfileStatus`,profile,{headers:this.headers});

}
addLanguage(languageDetails:any)
{
  return this.http.post<any>(`https://localhost:7021/Profile/AddLanguage`,languageDetails,{headers:this.headers});
}
getPersonalDetailByProfileId(profileId:number)
{
  return this.http.get<any>(`https://localhost:7021/Profile/GetPersonalDetailsByProfileId?Profileid=${profileId}`,{headers:this.headers})
}
addBreakDuration(breakDuration:any)
{
  return this.http.post<any>(`https://localhost:7021/Profile/AddBreakDuration`,breakDuration,{headers:this.headers});
}
addSocialMedia(socialMedia:any)
{
  return this.http.post<any>(`https://localhost:7021/Profile/AddSocialMedia`,socialMedia,{headers:this.headers});
}
disableSocialMedia(socialMediaId:number)
{
  return this.http.delete<any>(`https://localhost:7021/Profile/DisableSocialMedia?SocialMedia_Id=${socialMediaId}`,{headers : this.headers})
}
disableLanguage(languageId:number)
{
  return this.http.delete<any>(`https://localhost:7021/Profile/DisableLanguage?Language_Id=${languageId}`,{headers : this.headers})
}

 

}
  

