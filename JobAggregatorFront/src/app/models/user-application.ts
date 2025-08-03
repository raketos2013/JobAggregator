import { ApplicationStatus } from "./enums/application-status";
import { Vacancy } from "./vacancy";

export interface UserApplication{
    id: number;
    vacancy: Vacancy;
    status: ApplicationStatus
}