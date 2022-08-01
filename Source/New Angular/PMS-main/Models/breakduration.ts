export interface BreakDuration {
    breakDuration_Id: number;
    starting_Month: string;
    starting_Year: string;
    ending_Month: string;
    ending_Year: string;
    startingBreakMonth: string | null;
    startingBreakYear: number | null;
    endingBreakMonth: string | null;
    endingBreakYear: number | null;
    createdOn: string | null;
    createdBy: number | null;
    updatedOn: string | null;
    updatedBy: number | null;
    isActive: boolean;
}