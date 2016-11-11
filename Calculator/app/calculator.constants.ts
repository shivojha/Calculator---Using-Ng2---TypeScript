import { Injectable } from '@angular/core';

@Injectable()
export class ConfigurationTest {
    public Server: string = "http://localhost:65105/";
    public CalculatorApiUrl: string = "api/calculator/";
    public ServerWithCalcApiUrl = this.Server + this.CalculatorApiUrl;
}