import { Language } from "./language";
import { BreakDuration } from "./breakduration";
import { SocialMedia } from "./socialMedia";
import { User } from "./user";

export class PersonalDetails {
    personalDetailsId: number=0;
    profileId: number=0;
    profilePhoto:string='';
    name: string='';
    objective: string='';
    dateOfBirth: string='';
    nationality: string='';
    mailAddress: string='';
    dateOfJoining: string='';
    languageid: number=0;
    breakDurationid: number=0;
    socialmediaid: number=0;
    userId!: number;
    language!: Language | null;
    breakDuration!: BreakDuration | null;
    socialmedia!: SocialMedia | null;
    users!: User | null;
    isActive: boolean=true;
}