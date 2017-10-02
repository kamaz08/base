//import { Http, Response, Headers, RequestOptions } from '@angular/http';
//import { Observable } from 'rxjs/Observable';

//export class HttpServiceBase {

//    constructor(public http: Http) {
//        console.log('http', this.http); //just do this to prove that it is there - it is!
//    }

    //get(url: string): Observable<any> {
    //    return this._http.get(url)
    //        .map((response: Response) => <any>response.json());
    //}

    //post(url: string, model: any): Observable<any> {
    //    let body = JSON.stringify(model);
    //    let headers = new Headers({ 'Content-Type': 'application/json' });
    //    let options = new RequestOptions({ headers: headers });
    //    return this._http.post(url, body, options)
    //        .map((response: Response) => <any>response.json());
    //}

    //put(url: string, id: number, model: any): Observable<any> {
    //    let body = JSON.stringify(model);
    //    let headers = new Headers({ 'Content-Type': 'application/json' });
    //    let options = new RequestOptions({ headers: headers });
    //    return this._http.put(url + id, body, options)
    //        .map((response: Response) => <any>response.json());
    //}

    //delete(url: string, id: number): Observable<any> {
    //    let headers = new Headers({ 'Content-Type': 'application/json' });
    //    let options = new RequestOptions({ headers: headers });
    //    return this._http.delete(url + id, options)
    //        .map((response: Response) => <any>response.json());
    //}


    //handleError(error: any): Promise<any> {
    //    console.error('Application Error', error); //this logs fine

    //    // TypeError: Cannot read property 'http' of null
    //    this.http.get('/Account/IsLoggedIn')
    //        .map(response => console.log('RESPONSE: ', response));

    //    return Promise.reject(error.message || error);
    //}
//}