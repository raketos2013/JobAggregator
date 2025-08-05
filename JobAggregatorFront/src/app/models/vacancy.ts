import { Handbook } from "./handbook";
import { UserDTO } from "./userDTO";

export interface Vacancy{
    id: number;
    name: string;
    description: string;
    location?: string;
    salary?: number;
    priority: number;
    countViews: number;
    countResponses: number;
    created?: Date;
    organizationId: number;
    scheduleType: number;
    requirements?: Handbook[];
    responsibilities?: Handbook[];
    offers?: Handbook[];
    specialisations?: Handbook[];
    skills?: Handbook[];
}