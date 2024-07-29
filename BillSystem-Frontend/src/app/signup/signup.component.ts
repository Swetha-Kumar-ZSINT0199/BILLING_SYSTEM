import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router,RouterLink } from '@angular/router';
import { UserServiceService } from '../user-service.service';
import { HomeComponent } from '../home/home.component';
import { __values } from 'tslib';
import { CommonModule } from '@angular/common';
import { LoginComponent } from '../login/login.component';
@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [FormsModule,RouterLink,HomeComponent,CommonModule,LoginComponent],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {
  formData={
    Name:'',
    Password:'',
    Email:'',
  };
  constructor(private http:HttpClient, private router: Router,private service:UserServiceService){}
  
  async onSubmit() {
  try{
    const response =await this.service.GetUser(this.formData.Email)
    if(!response)
      {      
        (await this.service.RegisterPost(this.formData)).subscribe({
        next:(response)=>{
          this.router.navigate(['/login'])
        },
        error:(error)=>{
          console.log('Registration Successful', error);
        }
       });
  }
  else
  { 
    console.log("User already exists");
  }
}
catch(error)
{
  console.log("error occured",error);
}
}
}
