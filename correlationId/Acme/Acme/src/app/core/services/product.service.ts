import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import { Configuration } from './../../app.constants';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';

import { Product } from '../../models/products';

@Injectable()
export class ProductService {
    private _productUrl: string;
    private _searchUrl: string;
    private _top5: string;
    private headers: HttpHeaders;

    constructor(private http: HttpClient, private configuration: Configuration) { // Products Service constructor to initialize objects.
        this._productUrl = configuration.Server + 'api/products/'
        this._searchUrl = configuration.Server + 'api/products/search/'
        this._top5 = configuration.Server + 'api/products/top5'

        this.headers = new HttpHeaders();
        this.headers = this.headers.set('Content-Type', 'application/json');
        this.headers = this.headers.set('Accept', 'application/json');
    }

    getProducts(): Observable<Product[]> { // get list of products
        return this.http.get<Product[]>(this._productUrl)
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    search(searchTerm: string): Observable<Product[]> { // search list of products
        return this.http.get<Product[]>(this._searchUrl + searchTerm)
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    getTop5(): Observable<Product[]> { // get top 5 products
        return this.http.get<Product[]>(this._top5)
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    getProduct(id: number): Observable<Product> { // get product by Id
        return this.getProducts()
            .map((products: Product[]) => products.find(p => p.productId === id));
    }

    private handleError(err: HttpErrorResponse) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        let errorMessage = '';
        if (err.error instanceof Error) {
            // A client-side or network error occurred. Handle it accordingly.
            errorMessage = `An error occurred: ${err.error.message}`;
        } else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.error(errorMessage);
        return Observable.throw(errorMessage);
    }
}
