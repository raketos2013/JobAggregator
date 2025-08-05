import { Handbook } from "../handbook";

export interface VacancyDTO{
    name: string;
    description: string;
    location?: string;
    salary?: number;
    organizationId?: number;
    scheduleType: number;
    requirements?: Handbook[];
    responsibilities?: Handbook[];
    offers?: Handbook[];
    specialisations?: Handbook[];
    skills?: Handbook[];
}