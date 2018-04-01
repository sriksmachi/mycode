import { RouterModule } from '@angular/router';
import { AboutComponent } from './about/components/about.component';
import { HomeComponent } from './home/components/home.component';
export var routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'about', component: AboutComponent },
    { path: 'home', component: HomeComponent }
];
export var AppRoutes = RouterModule.forRoot(routes);
//# sourceMappingURL=app.routes.js.map