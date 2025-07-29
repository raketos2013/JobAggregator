import { Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { OrganizationDetails } from './pages/organization-details/organization-details';
import { Vacancies } from './pages/vacancies/vacancies/vacancies';
import { VacancyDetails } from './pages/vacancies/vacancy-details/vacancy-details';
import { VacancyMain } from './pages/vacancies/vacancy-main/vacancy-main';

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
        path: 'organization/:id',
        component: OrganizationDetails
    },
    {
        path: 'vacancies',
        component: VacancyMain
    },
    {
        path: 'vacancies/:id',
        loadComponent: () => import('./pages/vacancies/vacancy-details/vacancy-details').then(m => m.VacancyDetails)
    }
];
