import { Component } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent {
  
  constructor(private auth: AuthService) { }
}
