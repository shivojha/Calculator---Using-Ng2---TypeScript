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
var calculator_service_1 = require('../app/calculator.service');
var calculator_constants_1 = require('../app/calculator.constants');
var CalculatorComponent = (function () {
    function CalculatorComponent(calculatorService) {
        this.calculatorService = calculatorService;
        this.mathExpression = new calculator_service_1.MathExpression();
    }
    CalculatorComponent.prototype.ngOnInit = function () {
        this.loadCalculatorView();
        this.resetErrorMessage();
    };
    ;
    CalculatorComponent.prototype.loadCalculatorView = function () {
        this.getKeys();
        this.mathExpression = { expression: '', key: '' };
    };
    CalculatorComponent.prototype.getKeys = function () {
        var _this = this;
        this.calculatorService.getKeys()
            .subscribe(function (res) { return _this.calcKeysLayout = res; }, function (err) { console.log(err._body); _this.errorMessage = err._body; });
    };
    CalculatorComponent.prototype.resetErrorMessage = function () {
        this.errorMessage = null;
    };
    CalculatorComponent.prototype.onKeySelection = function (key) {
        this.resetErrorMessage();
        this.mathExpression.key = key;
        this.computeExpression();
    };
    CalculatorComponent.prototype.computeExpression = function () {
        var _this = this;
        this.calculatorService.evalExpression(this.mathExpression)
            .subscribe(function (res) { return _this.mathExpression = res; }, function (err) { console.log(err._body); _this.errorMessage = err._body; });
    };
    CalculatorComponent = __decorate([
        core_1.Component({
            selector: 'calculator-app',
            styleUrls: ['../app/calculator.style.css'],
            templateUrl: '../app/calculator.component.html',
            providers: [calculator_service_1.CalculatorService, calculator_constants_1.ConfigurationTest]
        }), 
        __metadata('design:paramtypes', [calculator_service_1.CalculatorService])
    ], CalculatorComponent);
    return CalculatorComponent;
}());
exports.CalculatorComponent = CalculatorComponent;
//# sourceMappingURL=calculator.component.js.map