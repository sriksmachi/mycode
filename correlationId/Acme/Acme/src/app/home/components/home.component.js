var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { ProductService } from './../../core/services/product.service';
import { Http } from '@angular/http';
var HomeComponent = (function () {
    function HomeComponent(dataService, http) {
        this.dataService = dataService;
        this.http = http;
        this.products = [];
        this.top5products = [];
    }
    HomeComponent.prototype.ngOnInit = function () {
        this.getTop5();
    };
    HomeComponent.prototype.search = function () {
        var _this = this;
        this.dataService.search(this.searchString)
            .subscribe(function (products) {
            _this.products = products;
        }, function (error) { return _this.errorMessage = error; });
        console.log("Search String: " + this.searchString);
    };
    HomeComponent.prototype.getTop5 = function () {
        var _this = this;
        this.dataService.getTop5()
            .subscribe(function (products) {
            _this.top5products = products;
        }, function (error) { return _this.errorMessage = error; });
        console.log("Search String: " + this.searchString);
    };
    HomeComponent.prototype.onRatingClicked = function (message) {
        console.log('Rating Clicked: ' + message);
    };
    HomeComponent = __decorate([
        Component({
            selector: 'app-home-component',
            templateUrl: './home.component.html'
        }),
        __metadata("design:paramtypes", [ProductService, Http])
    ], HomeComponent);
    return HomeComponent;
}());
export { HomeComponent };
//# sourceMappingURL=home.component.js.map