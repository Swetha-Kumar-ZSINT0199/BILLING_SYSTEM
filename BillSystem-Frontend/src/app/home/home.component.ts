import { Component } from '@angular/core';
import { SignupComponent } from '../signup/signup.component';
import { LoginComponent } from '../login/login.component';
import { response } from 'express';
import { ok } from 'assert';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [SignupComponent,LoginComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}

