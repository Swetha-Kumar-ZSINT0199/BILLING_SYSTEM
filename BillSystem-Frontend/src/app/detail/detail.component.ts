import { AfterViewInit, Component, OnInit ,ViewChild} from '@angular/core';
import { ProductServiceService } from '../product-service.service';
import { CommonModule } from '@angular/common';
import {MatTableModule} from '@angular/material/table'
import { Router, RouterLink,ROUTES } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatIconModule } from '@angular/material/icon';
import { routes } from '../app.routes';
import { AuthService } from '../auth.service';
@Component({
  selector: 'app-detail',
  standalone: true,
  imports: [CommonModule,MatTableModule,RouterLink,MatIconModule,MatPaginatorModule],
  templateUrl: './detail.component.html',
  styleUrl: './detail.component.css'
})
export class DetailComponent implements OnInit, AfterViewInit {
  items: any[]=[];
  displayedColumns: string[] = ['name', 'qty', 'price','actions'];
dataSource: MatTableDataSource<any>;
@ViewChild(MatPaginator) paginator?:MatPaginator;
constructor(private service:ProductServiceService,private router:Router, private authService: AuthService)
{
  this.dataSource= new MatTableDataSource<any>();
}
isLoggedIn: boolean = false;
userEmail:string | null = null;

  ngOnInit(): void {
  this.fetchItems();
  this.isLoggedIn=this.authService.isLoggedIn()
    if (this.isLoggedIn) {
      
      this.userEmail = sessionStorage.getItem('Username');

    } else {
      this.userEmail = null;
    }
  };

ngAfterViewInit(): void {
  if (this.paginator) {
    this.dataSource.paginator = this.paginator;
  }
}
fetchItems(): void {
  this.service.getItem().subscribe(
    data =>{
      console.log(data)
      this.dataSource.data =data;
    },
   )
}
 editItem(itemId:number,item: any): void {

  console.log('Editing item:', item);
  this.router.navigate(["/update",itemId])
  
}

deleteItem(itemId:number,item: any): void {
 
  console.log('Deleting item:', item);
  this.router.navigate(["/delete",itemId])
} 


}
