import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  constructor(private http: HttpClient) { }
  private readonly UserUrl="http://localhost:5228/api/User/";
  
  async RegisterPost(formdata:any){
    const response=await this.http.post<any>(this.UserUrl,formdata)
    return response;
}
async GetUser(UserName:string){
  try{
    const response =await fetch(this.UserUrl + "ByUserName/" + UserName);
      if (response.ok) {
          const userData = await response.json();
          return userData;
      }
      else{
      console.log("No user exists");
      }
  }
  catch(error)
  {
    return null;
  }
    
}
}
