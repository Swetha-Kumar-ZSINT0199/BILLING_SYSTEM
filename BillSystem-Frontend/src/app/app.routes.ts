import { Routes,RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';
import { NgModule } from '@angular/core';
import { CreateComponent } from './create/create.component';
import { DetailComponent } from './detail/detail.component';
import { UpdateComponent } from './update/update.component';
import { DeleteComponent } from './delete/delete.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { AuthService } from './auth.service';
export const routes: Routes = [
    {
        path:'signup',
        component:SignupComponent
    },
    {
        path:'home',
        component:HomeComponent
    },
    {
        path:'',
        redirectTo:'home',
        pathMatch:'prefix'
    },
    {
        path:'login',
        component:LoginComponent
    },
    {
        path:'navbar',
        component:NavbarComponent
    },
    {
        path:'create',
        component:CreateComponent
    },
    {
        path:'detail',
        component:DetailComponent
    },
    {
        path:'update/:itemId',
        component:UpdateComponent
    },
    {
        path:'delete/:itemId',
        component:DeleteComponent
    }
];
@NgModule({
    imports: [RouterModule.forRoot(routes),MatPaginatorModule,MatTableModule],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }