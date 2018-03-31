import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home.component';

const routes: Routes = [ // routes for home
    { path: 'home', component: HomeComponent }
];

export const HomeRoutes = RouterModule.forChild(routes);
