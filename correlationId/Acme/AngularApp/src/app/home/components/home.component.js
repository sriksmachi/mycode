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
import { ThingService } from './../../core/services/thing-data.service';
import { Thing } from './../../models/thing';
var HomeComponent = (function () {
    function HomeComponent(dataService) {
        this.dataService = dataService;
        this.things = [];
        this.thing = new Thing();
        this.message = '{{Angular 4 Workshop}}';
    }
    HomeComponent.prototype.ngOnInit = function () {
        this.getAllThings();
    };
    HomeComponent.prototype.addThing = function () {
        var _this = this;
        this.dataService
            .add(this.thing)
            .subscribe(function () {
            _this.getAllThings();
            _this.thing = new Thing();
        }, function (error) {
            console.log(error);
        });
    };
    HomeComponent.prototype.deleteThing = function (thing) {
        var _this = this;
        this.dataService
            .delete(thing.id)
            .subscribe(function () {
            _this.getAllThings();
        }, function (error) {
            console.log(error);
        });
    };
    HomeComponent.prototype.getAllThings = function () {
        var _this = this;
        this.dataService
            .getAll()
            .subscribe(function (data) { return _this.things = data; }, function (error) { return console.log(error); }, function () { return console.log('Get all complete'); });
    };
    HomeComponent = __decorate([
        Component({
            selector: 'app-home-component',
            templateUrl: './home.component.html'
        }),
        __metadata("design:paramtypes", [ThingService])
    ], HomeComponent);
    return HomeComponent;
}());
export { HomeComponent };
//# sourceMappingURL=home.component.js.map