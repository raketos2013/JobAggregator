import { Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { VacancyDetails } from './pages/vacancies/vacancy-details/vacancy-details';
import { VacancyMain } from './pages/vacancies/vacancy-main/vacancy-main';
import { Organizations } from './pages/organizations/organizations/organizations';
import { Resumes } from './pages/resumes/resumes/resumes';
import { CreateResume } from './pages/resumes/create-resume/create-resume';
import { Registration } from './pages/registration/registration';
import { CreateVacancy } from './pages/vacancies/create-vacancy/create-vacancy';
import { CreateOrganization } from './pages/organizations/create-organization/create-organization';
import { Profile } from './pages/profile/profile/profile';

export const routes: Routes = [
    { 
        path: '', 
        redirectTo: 'vacancies', 
        pathMatch: 'full' },
    {
        path: 'login',
        component: Login
    },
    {
        path: 'vacancy/:id',
        component: VacancyDetails
    },
    {
        path: 'organizations',
        component: Organizations
    },
    {
        path: 'vacancies',
        component: VacancyMain
    },
    {
        path: 'vacancies/:id',
        loadComponent: () => import('./pages/vacancies/vacancy-details/vacancy-details').then(m => m.VacancyDetails)
    },
    {
        path: 'organizations/:id',
        loadComponent: () => import('./pages/organizations/organization-details/organization-details').then(m => m.OrganizationDetails)
    },
    {
        path: 'resumes',
        component: Resumes
    },
    {
        path: 'resumes/:id',
        loadComponent: () => import('./pages/resumes/resume-details/resume-details').then(m => m.ResumeDetails)
    },
    {
        path: 'profile',
        component: Profile
    },
    {
        path: 'createResume',
        component: CreateResume
    },
    {
        path: 'registration',
        component: Registration
    },
    {
        path: 'createVacancy',
        component: CreateVacancy
    },
    {
        path: 'createOrganization',
        component: CreateOrganization
    },
    {
        path: 'createResume',
        component: CreateResume
    }
];
