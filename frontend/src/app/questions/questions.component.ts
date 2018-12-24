import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'questions',
  templateUrl: './questions.component.html',
})
export class QuestionsComponent implements OnInit {

  questions;

  constructor (private api: ApiService, private route : ActivatedRoute) {}

  ngOnInit() {
    var quizId = this.route.snapshot.paramMap.get('quizId');
    this.api.getQuestions(quizId).subscribe(res => {
      this.questions = res;
    });
  }
}
