import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { NavbarComponent } from "./navbar/navbar.component";
import { RouterLink } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthService } from './auth.service';
import { ProductServiceService } from './product-service.service';
@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [RouterOutlet, SignupComponent, LoginComponent, NavbarComponent,HomeComponent,RouterLink,NavbarComponent],
    providers: [AuthService,ProductServiceService]
})
export class AppComponent {
  title = 'Billsystem';
  constructor(private router:Router){}
}
