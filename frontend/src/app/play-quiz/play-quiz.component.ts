import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { ActivatedRoute } from '@angular/router';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { FinishedComponent } from '../finished/finished.component';

@Component({
  selector: 'app-play-quiz',
  templateUrl: './play-quiz.component.html',
})
export class PlayQuizComponent implements OnInit {

  quizId;
  questions;
  step = 0;

  constructor(private api: ApiService, private route : ActivatedRoute, private dialog: MatDialog) { }

  setStep(index: number) {
    this.step = index;
  }

  nextStep() {
    this.step++;
  }

  prevStep() {
    this.step--;
  }

  finish(){
    var correct =0;
    this.questions.forEach(q=> {
      if(q.correctAnswer == q.selectedAnswer)
        correct++;
    });

    this.dialog.open(FinishedComponent, {
      data: {correct, total : this.questions.length }
    });

    console.log(correct);
  }

  ngOnInit() {
    this.quizId = this.route.snapshot.paramMap.get('quizId');

    this.api.getQuestions(this.quizId).subscribe(res => {
      this.questions = res

      this.questions.forEach(q => {
        q.answers = [q.correctAnswer, q.option1, q.option2, q.option3];
        shuffle(q.answers);
      });
    });
  }
}

function shuffle(a) 
{
  for(let i = a.length; i; i--) {
    let j = Math.floor(Math.random() * i);
    [a[i - 1], a[j]] = [a[j], a[i - 1]];
  }
}
