"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var http_1 = require('@angular/http');
require('rxjs/add/operator/map');
var Observable_1 = require('rxjs/Observable');
var calculator_constants_1 = require('../app/calculator.constants');
var CalculatorService = (function () {
    function CalculatorService(_http, _configuration) {
        this._http = _http;
        this._configuration = _configuration;
        this.actionUrl = _configuration.ServerWithCalcApiUrl + 'evaluateexpression';
        this.actionUrlGetKeys = _configuration.ServerWithCalcApiUrl + 'getkeys';
        this.headers = new http_1.Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
        this.headers.append('Access-Control-Allow-Origin', '*');
        this.headers.append('Access-Control-Allow-Methods', 'GET, POST, PATCH, PUT, DELETE, OPTIONS');
        this.headers.append('Access-Control-Allow-Headers', 'Origin, Content-Type, X-Auth-Token');
    }
    CalculatorService.prototype.evalExpression = function (expression) {
        var jsonExpression = JSON.stringify(expression);
        return this._http.post(this.actionUrl, jsonExpression, { headers: this.headers })
            .map(function (response) { return response.json(); });
    };
    CalculatorService.prototype.getKeys = function () {
        return this._http.get(this.actionUrlGetKeys, { headers: this.headers })
            .map(function (response) { return response.json(); });
    };
    CalculatorService.prototype.handleError = function (error) {
        console.error(error);
        return Observable_1.Observable.throw(error.json().error || 'Server error');
    };
    CalculatorService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http, calculator_constants_1.ConfigurationTest])
    ], CalculatorService);
    return CalculatorService;
}());
exports.CalculatorService = CalculatorService;
var MathExpression = (function () {
    function MathExpression() {
    }
    return MathExpression;
}());
exports.MathExpression = MathExpression;
//# sourceMappingURL=calculator.service.js.map