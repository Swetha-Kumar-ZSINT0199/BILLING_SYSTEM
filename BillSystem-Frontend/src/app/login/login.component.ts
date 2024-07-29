import { Component, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { Router,RouterLink } from '@angular/router';
import { UserServiceService } from '../user-service.service';
import { HomeComponent } from '../home/home.component';
import { CommonModule } from '@angular/common';
import { AuthService } from '../auth.service';
import { EventEmitter } from 'stream';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule,RouterLink,HomeComponent,CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  log={
    Username:'',
    Password:''
  };
  constructor(private http:HttpClient,private service:UserServiceService,private router: Router,private authservice:AuthService){}
 
  async onsubmit(){
      var response =await this.service.GetUser(this.log.Username);
     
           console.log(response);
           console.log(this.log.Password);
           console.log(this.log.Username);
           console.log(response.Username);
          console.log(response.password);
          // Check if user data is retrieved successfully
          if (response) {
              // Compare the password entered by the user with the password retrieved from the service
              if (response.password == this.log.Password) {
                  console.log("login successful");
                 // sessionStorage.setItem('currentUser', JSON.stringify(response));
           
                 const response= this.authservice.login(this.log.Username);
                 console.log("response login",response);
                
                  this.router.navigate(['/detail']);
                  
              }
              else {
                  console.log("Incorrect password. Please try again.");
              }
          }
          else {
              console.log("User not found. Please check the username.");
          }

  }
}
