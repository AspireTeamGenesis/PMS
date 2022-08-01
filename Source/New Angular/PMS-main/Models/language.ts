export interface Language {
    languageId: number;
    languageName: string;
    read: boolean;
    write: boolean;
    speak: boolean;
    
    createdOn: string | null;
    createdBy: number | null;
    updatedOn: string | null;
    updatedBy: number | null;
    isActive: boolean;
}