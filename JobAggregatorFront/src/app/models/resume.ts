import { Handbook } from "./handbook";

export interface Resume{
    resumeId: number;
    userId: number;
    experience?: string;
    links?: string;
    age: number;
    education?: string;
    countViews: number;
    priority: number;
    created: Date;
    skills?: Handbook[];
}