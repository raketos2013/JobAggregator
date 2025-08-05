import { Gender } from "../enums/gender";
import { Handbook } from "../handbook";
import { Language } from "../language";

export interface ResumeDTO{
    userId: number;
    experience?: string | null;
    links?: string | null;
    age: number;
    gender: Gender;
    photo?: string | null;
    languages: Language[];
    education?: string | null;
    skills: Handbook[];
}