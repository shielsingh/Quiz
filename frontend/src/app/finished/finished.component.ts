import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';

@Component({
  templateUrl: './finished.component.html'
})
export class FinishedComponent {
  constructor(@Inject(MAT_DIALOG_DATA) private data) { 
  }
}
