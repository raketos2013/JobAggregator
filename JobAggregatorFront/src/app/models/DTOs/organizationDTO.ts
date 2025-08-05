import { Handbook } from "../handbook";

export interface OrganizationDTO{
    name: string;
    description: string;
    website?: string;
    email: string;
    phoneNumber: number;
    address?: string;
    activities?: Handbook[];
}