import {  Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'question',
    templateUrl: './question.component.html'
})
export class QuestionComponent implements OnInit {

    question = {};
    quizId;

    constructor (private api: ApiService, private route : ActivatedRoute) {}

    ngOnInit() {
        this.quizId = this.route.snapshot.paramMap.get('quizId');
        this.api.questionSelected.subscribe(question => this.question = question);
      }

    Save(question)
    {
        question.quizId = this.quizId;
        
        if(question.questionId)
        {
            this.api.putQuestion(question);
        }
        else
        {
            this.api.postQuestion(question);
        }
    }
}