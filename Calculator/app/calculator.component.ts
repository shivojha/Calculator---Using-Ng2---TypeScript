import { Component, OnInit } from '@angular/core';
import { CalculatorService, MathExpression } from '../app/calculator.service';
import { ConfigurationTest } from '../app/calculator.constants';

@Component({
    selector: 'calculator-app',
    styleUrls: ['../app/calculator.style.css'],
    templateUrl: '../app/calculator.component.html',
    providers: [CalculatorService, ConfigurationTest]
})
export class CalculatorComponent implements OnInit {

    calcKeysLayout: string[][];
    mathExpression = new MathExpression();
    errorMessage: string;

    constructor(private calculatorService: CalculatorService) { }

    ngOnInit() {
        this.loadCalculatorView();
        this.resetErrorMessage();
    };

    loadCalculatorView() {
        this.getKeys();
        this.mathExpression = { expression: '', key: '' };
    }

    getKeys() {
        this.calculatorService.getKeys()
            .subscribe(res => this.calcKeysLayout = res,
            err => { console.log(err._body); this.errorMessage = err._body; }
            );
    }

    resetErrorMessage() {
        this.errorMessage = null;
    }

    onKeySelection(key: string) {
        this.resetErrorMessage();
        this.mathExpression.key = key;
        this.computeExpression();
    }

    computeExpression() {
        this.calculatorService.evalExpression(this.mathExpression)
            .subscribe(res => this.mathExpression = res,
            err => { console.log(err._body); this.errorMessage = err._body; }
            );
    }
}
