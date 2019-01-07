import { Component } from '@angular/core';
import { QuestionComponent } from './question/question.component'

@Component({
  selector: 'app-root',
  template: '<app-nav class="mat-elevation-z6"></app-nav><router-outlet></router-outlet>'
})
export class AppComponent {
}
