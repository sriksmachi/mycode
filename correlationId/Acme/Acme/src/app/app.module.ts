import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AppRoutes } from './app.routes';
import { CoreModule } from './core/core.module';
import { HttpModule } from '@angular/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ProductListComponent } from './products/product-list.component';
import { ProductDetailComponent } from './products/product-detail.component';
import { ConvertToSpacesPipe } from './shared/convert-to-spaces.pipe';
import { RouterModule } from '@angular/router';
import { ProductGuardService } from './products/product-guard.service';
import { ProductService } from './core/services/product.service';
import { CommonModule } from '@angular/common';
import { CustomFooterComponent } from './shared/components/customfooter/customfooter.component';
import { NavigationComponent } from './shared/components/navigation/navigation.component';
import { StarComponent } from './shared/components/star.component';
import { AboutComponent } from './about/components/about.component';
import { HomeComponent } from './home/components/home.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: 'products', component: ProductListComponent },
            {
                path: 'products/:id',
                canActivate: [ProductGuardService],
                component: ProductDetailComponent
            }
        ]),
        BrowserModule,
        AppRoutes,
        CoreModule.forRoot(),
        CommonModule,
        ReactiveFormsModule,
        FormsModule,
        HttpModule,
        RouterModule,
        HttpClientModule
    ],

    declarations: [
        AboutComponent,
        ConvertToSpacesPipe,
        AppComponent,
        NavigationComponent,
        CustomFooterComponent,
        StarComponent,
        ProductListComponent,
        ProductDetailComponent,
        HomeComponent
    ],

    exports: [
        ConvertToSpacesPipe,
        AppComponent,
        NavigationComponent,
        CustomFooterComponent,
        StarComponent,
        AboutComponent,
        ProductListComponent,
        ProductDetailComponent,
        HomeComponent
    ],

    providers: [
        ProductService,
        ProductGuardService
    ],

    bootstrap: [AppComponent]
})

export class AppModule { }
