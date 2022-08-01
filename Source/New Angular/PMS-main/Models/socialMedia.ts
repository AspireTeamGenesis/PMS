export interface SocialMedia {
    socialMedia_Id: number;
    socialMedia_Name: string;
    socialMedia_Link: string;
    createdOn: string | null;
    createdBy: number | null;
    updatedOn: string | null;
    updatedBy: number | null;
    isActive: boolean;
}