import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ProductServiceService } from '../product-service.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators, } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [FormsModule,CommonModule,ReactiveFormsModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent {
  formData:any ={
    name:'',
    qty:'',
    price:'',
  };
  constructor(private http:HttpClient,private formBuilder: FormBuilder, private router: Router,private service:ProductServiceService){}
  
  
  onSubmit() {
    console.log('Form submitted with:', this.formData.name, this.formData.qty, this.formData.price);
   
    
      this.service.postItem(this.formData).subscribe({next:response=>
        {
          console.log("Item added");
          this.router.navigate(['/detail']);
        },
        error:error =>{
          console.error("Failed to add item",error);} 
      });  
    
   
  
  
    }
 }

