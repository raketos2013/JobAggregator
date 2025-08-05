import { OrganizationDTO } from "./organizationDTO";

export interface CreateOrganizationDTO{
    organization: OrganizationDTO,
    userId: number
}