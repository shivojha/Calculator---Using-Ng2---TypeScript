
import { Inject, Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import 'rxjs/add/operator/map'
import { Observable } from 'rxjs/Observable';
import { ConfigurationTest } from '../app/calculator.constants';

@Injectable()
export class CalculatorService implements ICalculatorService {
        
    private actionUrl: string;
    private actionUrlGetKeys: string;
    private headers: Headers;

    constructor(private _http: Http, private _configuration: ConfigurationTest) {

        this.actionUrl = _configuration.ServerWithCalcApiUrl + 'evaluateexpression';
        this.actionUrlGetKeys = _configuration.ServerWithCalcApiUrl + 'getkeys';

        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
              this.headers.append('Access-Control-Allow-Origin', '*');
        this.headers.append('Access-Control-Allow-Methods','GET, POST, PATCH, PUT, DELETE, OPTIONS');
        this.headers.append('Access-Control-Allow-Headers','Origin, Content-Type, X-Auth-Token');
    }

    evalExpression(expression: MathExpression): Observable<MathExpression>{

        let jsonExpression = JSON.stringify(expression);

        return this._http.post(this.actionUrl, jsonExpression, { headers: this.headers })
            .map((response: Response) => <MathExpression>response.json());
    }

    getKeys(): Observable<string[][]> {
        return this._http.get(this.actionUrlGetKeys, { headers: this.headers })
            .map((response: Response) => <string[][]>response.json());
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}

interface ICalculatorService {
    evalExpression(mathExpression: MathExpression): Observable<MathExpression>;
    getKeys():Observable<string[][]>
}
export class MathExpression {
    expression: string;
    key: string;
}

  