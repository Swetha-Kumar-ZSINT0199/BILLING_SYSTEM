import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

   loggedIn: boolean = false;
   userEmail: string | null = null; // Simulate user email

  constructor() { }

  isLoggedIn() {
    return this.loggedIn;
  }

  login(Username:string) {
    // Simulate a login request (replace with actual login logic)
    this.loggedIn = true;
    //this.userEmail = 'user@example.com'; // Set user email upon login
    sessionStorage.setItem('currentUser',Username)
  }

  logout() {
    // Simulate a logout request (replace with actual logout logic)
    this.loggedIn = false;
    this.userEmail = null; // Reset user email upon logout
    sessionStorage.removeItem('currentUser')
    
  }

  getUserEmail(): string | null {
    return this.userEmail;
  }
}
