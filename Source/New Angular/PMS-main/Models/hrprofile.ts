export class Hrprofile 
{
    userId:number=0;
    name:string='';
    email:string='';
    gender:Gender=new Gender();
    designation:Designation = new Designation();
    // designation:Designation[]=[];
    organisation:Organisation=new Organisation();
    reportingPersonUsername:string='';
}
export class Gender
{
    usergender:string='';
}
export class Designation{
    designationName:string='';
}
export class Organisation
{
    organisationName:string='';
}