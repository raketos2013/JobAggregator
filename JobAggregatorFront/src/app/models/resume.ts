import { Gender } from "./enums/gender";
import { Handbook } from "./handbook";
import { Language } from "./language";

export interface Resume{
    id: number;
    userId: number;
    experience?: string | null;
    links: string | null;
    age: number;
    gender: Gender;
    photo?: string | null;
    languages: Language[];
    education?: string | null;
    countViews: number;
    priority: number;
    created: Date;
    skills: Handbook[];
}