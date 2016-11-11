import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';


import { CalculatorModule } from './calculator.module';
import 'rxjs/Rx';

platformBrowserDynamic().bootstrapModule(CalculatorModule);
