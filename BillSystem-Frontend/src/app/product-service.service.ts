import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {

  constructor(private http: HttpClient) { }
  private readonly ItemUrl="http://localhost:5228/api/Item";
 getItem(){
  return this.http.get<any[]>(this.ItemUrl+"/");
 }
 postItem(item :any)
 {
  console.log(item)
  return this.http.post<any>(this.ItemUrl,item);
  console.log("added ");
 }

 deleteItem(itemId: number, item: any): Observable<any> {
  console.log('Deleting item with id:', itemId);
  return this.http.delete<any>(this.ItemUrl+"/"+itemId, item);
}
updateItem(itemid:number,item:any):Observable<any>
{
  console.log(itemid)
  item.itemId=itemid;
  return this.http.put<any>(this.ItemUrl+"/"+itemid,item)
}
}