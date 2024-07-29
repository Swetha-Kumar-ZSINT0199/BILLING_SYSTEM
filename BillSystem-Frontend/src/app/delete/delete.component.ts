import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { RouterLink,Router, ActivatedRoute } from '@angular/router';
import { ProductServiceService } from '../product-service.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatIcon } from '@angular/material/icon';


@Component({
  selector: 'app-delete',
  standalone: true,
  imports: [CommonModule, MatTableModule,ReactiveFormsModule, MatPaginatorModule, RouterLink,MatIcon],
  templateUrl: './delete.component.html',
  styleUrl: './delete.component.css'
})
export class DeleteComponent implements OnInit{
  itemId: number |null =null;
  ItemForm:FormGroup;
  items: any[]=[];
  displayedColumns: string[] = ['itemId', 'name', 'qty', 'price','delete'];
  constructor(private service:ProductServiceService, private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private http: HttpClient,){
    {
      this.ItemForm=this.fb.group({
        name:['',Validators.required],
        qty:['',Validators.required],
        price:['',Validators.required]
      });
    }
  }
  submit(): void {
    if(this.ItemForm.valid && this.itemId!== null){
      this.service.deleteItem(this.itemId,this.ItemForm.value).subscribe(
      (response:any ) => {
        console.log('Item deleted successfully',response);
        this.router.navigate(['/detail']);
      },
      (error) =>{
        console.error('error updating the item',error);
  
      });
    }else{
      console.error('Form is invalid or ItemId in null');
    }
    
  }
 ngOnInit():void
 {
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
  )
}

}
