import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { AuthService } from '../auth.service';
import { MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterLink,],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit{

  constructor(private router:Router,private authService: AuthService, private snackbar: MatSnackBar,private cdr:ChangeDetectorRef){}
  userEmail:any
  previoususerEmail:any;
  isLoggedIn=false;
  ngOnInit(): void {
    // this.authService.isLoggedIn().subscribe((loggedIn) => {
    //   this.isLoggedIn = loggedIn;
    //   if (loggedIn) {
    //     const userEmail = sessionStorage.getItem('Username');
    //     this.userEmail = userEmail;
    //   } else {
    //     this.userEmail = null;
    //   }
    // });
   this.userEmail=sessionStorage.getItem('currentUser')
   this.previoususerEmail={...this.userEmail}
  
  }

  ngDoCheck(){
    if(this.userEmail!=this.previoususerEmail){
      this.previoususerEmail={...this.userEmail};
       this.userEmail=sessionStorage.getItem('currentUser')
    }
  }

 
  
  login(): void {
    this.router.navigate(['/login'])
  }

  logout(): void {
    this.authService.logout()
    this.userEmail=sessionStorage.getItem('currentUser') 
    this.router.navigate(['/login'])
  }

  isCurrentRoute(route: string): boolean {
    return this.router.url == route;}
  
  // isLoggedIn(): boolean {
  //     return this.authService.isLoggedIn();
  // }
  // logout(): void {
  //     this.authService.logout();
  //     //this.router.navigate(['/home']);
  //   }
  
}
