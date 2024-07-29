import { Component,OnInit } from '@angular/core';
import { FormBuilder,FormGroup,Validator,ReactiveFormsModule, Validators } from '@angular/forms';
import {Router,ActivatedRoute} from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ProductServiceService } from '../product-service.service';
import { response } from 'express';

@Component({
  selector: 'app-update',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './update.component.html',
  styleUrl: './update.component.css'
})
export class UpdateComponent implements OnInit{
ItemForm:FormGroup;

  itemId: number |null =null;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private http: HttpClient,
    private service:ProductServiceService
  )
  {
    this.ItemForm=this.fb.group({
      name:['',Validators.required],
      qty:['',Validators.required],
      price:['',Validators.required]
    });
  }
  ngOnInit(): void {
    this.route.paramMap.subscribe((params)=>{
      const itemIdParam= params.get('itemId');
      if(itemIdParam!==null){
        this.itemId=+itemIdParam;
        console.log('Item Id:', this.itemId);
        this.getItem(this.itemId);
      }
    });
  }
getItem(itemId:number): void{
  this.http.get('http://localhost:5228/api/Item/ByItemId/'+itemId).subscribe(
  (response:any) =>{
    console.log(response)
    this.ItemForm.patchValue(response);
  },
  (error) => {
    console.error('Error fetching item details',error);
  }
);
}

async onSubmit(){
  if(this.ItemForm.valid && this.itemId!== null){
    await this.service.updateItem(this.itemId,this.ItemForm.value).subscribe(
    (response:any ) => {
      console.log('Item Updated successfully',response);
      this.router.navigate(['/detail']);
    },
    (error) =>{
      console.error('error updating the item',error);

    });
  }else{
    console.error('Form is invalid or ItemId in null');
  }
  }
}





