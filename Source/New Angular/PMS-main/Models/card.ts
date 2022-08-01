export class Card 
{
    userId:number=0;
    name:string='';
    reportingPersonUsername:string='';
    designation:Designation = new Designation();
    // designation:Designation[]=[];
    
}
export class Designation{
    designationName:string=''
}