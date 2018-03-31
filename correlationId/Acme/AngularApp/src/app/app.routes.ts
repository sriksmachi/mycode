import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/components/about.component';
import { HomeComponent } from './home/components/home.component';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'about', component: AboutComponent },
    { path: 'home', component: HomeComponent }
];

export const AppRoutes = RouterModule.forRoot(routes);
