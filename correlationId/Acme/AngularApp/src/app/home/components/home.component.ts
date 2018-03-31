import { Component, OnInit } from '@angular/core';
import { ProductService } from './../../core/services/product.service';
import { Product } from './../../models/products';
import { Http } from '@angular/http';

@Component({
    selector: 'app-home-component',
    templateUrl: './home.component.html'
})

export class HomeComponent implements OnInit { // home component

    public searchString: string;
    url: string;
    products: Product[] = [];
    top5products: Product[] = [];
    errorMessage: string;

    constructor(private dataService: ProductService, private http: Http) {
    }

    ngOnInit() {
        this.getTop5();
    }

    search() {
        this.dataService.search(this.searchString)
            .subscribe(products => {
                this.products = products;
            },
        error => this.errorMessage = <any>error);
        console.log("Search String: "+ this.searchString);
    }

    getTop5() {
        this.dataService.getTop5()
            .subscribe(products => {
                this.top5products = products;
            },
                error => this.errorMessage = <any>error);
        console.log("Search String: " + this.searchString);
    }

    onRatingClicked(message: string): void {
        console.log('Rating Clicked: ' + message);
    }
}
