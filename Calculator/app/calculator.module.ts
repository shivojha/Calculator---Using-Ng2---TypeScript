import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';


import { CalculatorComponent } from './calculator.component';

@NgModule({
    imports: [BrowserModule, HttpModule],
  declarations: [CalculatorComponent ],
  bootstrap: [CalculatorComponent ]
})
export class CalculatorModule { }
