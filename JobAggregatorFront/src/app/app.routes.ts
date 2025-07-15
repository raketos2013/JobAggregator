import { Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { GridList } from './grid-list/grid-list';

export const routes: Routes = [
    {
        path: '',
        component: GridList,
    },
    {
        path: 'login',
        component: Login
    }
];
