import { Handbook } from "../handbook";

export interface OrganizationUsersDTO{
    id: number;
    name: string;
    description: string;
    website?: string;
    email: string;
    phoneNumber: number;
    address?: string;
    activities?: Handbook[];
    idUsers: number[]
}