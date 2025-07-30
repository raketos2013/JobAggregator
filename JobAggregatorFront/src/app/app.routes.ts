import { Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { VacancyDetails } from './pages/vacancies/vacancy-details/vacancy-details';
import { VacancyMain } from './pages/vacancies/vacancy-main/vacancy-main';
import { Organizations } from './pages/organizations/organizations/organizations';
import { Resumes } from './pages/resumes/resumes/resumes';

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
];
