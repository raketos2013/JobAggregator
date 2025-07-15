import { Handbook } from "./handbook";
import { User } from "./user";
import { Vacancy } from "./vacancy";

export interface Organization{
    id: number;
    name: string;
    website?: string;
    email: string;
    phoneNumber?: number;
    address?: string;
    activities?: Handbook[];
    users: User[];
    vacancies?: Vacancy[];
}