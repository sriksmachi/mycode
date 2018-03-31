var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ProductListComponent } from './product-list.component';
import { ProductDetailComponent } from './product-detail.component';
import { ConvertToSpacesPipe } from '../shared/convert-to-spaces.pipe';
import { RouterModule } from '@angular/router';
import { ProductGuardService } from './product-guard.service';
import { ProductService } from '../core/services/product.service';
import { SharedModule } from './../shared/shared.module';
var ProductModule = (function () {
    function ProductModule() {
    }
    ProductModule = __decorate([
        NgModule({
            imports: [
                RouterModule.forChild([
                    { path: 'products', component: ProductListComponent },
                    { path: 'products/:id',
                        canActivate: [ProductGuardService],
                        component: ProductDetailComponent }
                ]),
                SharedModule,
                CommonModule,
                BrowserModule,
                FormsModule
            ],
            declarations: [
                ProductListComponent,
                ProductDetailComponent,
                ConvertToSpacesPipe
            ],
            providers: [
                ProductService,
                ProductGuardService
            ]
        })
    ], ProductModule);
    return ProductModule;
}());
export { ProductModule };
//# sourceMappingURL=product.module.js.map