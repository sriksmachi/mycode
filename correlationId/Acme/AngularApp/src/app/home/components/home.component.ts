import { Component, OnInit } from '@angular/core';
import { ProductService } from './../../core/services/product.service';
import { Product } from './../../models/products';
import { Http } from '@angular/http';

@Component({
    selector: 'app-home-component',
    templateUrl: './home.component.html'
})

export class HomeComponent implements OnInit { // home component

    public message: string;
    public searchString: string;
    url: string;

    constructor(private dataService: ProductService, private http: Http) {
        this.message = 'Correlating events across MicroServices';
    }

    ngOnInit() { // home component on initialize object.
    }

    search() {
        console.log("Search String: "+ this.searchString);
    }
}
