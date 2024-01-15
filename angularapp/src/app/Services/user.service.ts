import { HttpClient } from '@angular/common/http';
import { Injectable,OnInit } from '@angular/core';
import { Observable, first, of, tap,map, switchMap, throwError } from 'rxjs';
import { User } from '../Interfaces/user';
import { UserCreateDTO } from '../Interfaces/user-create';
import { UserUpdateDTO } from '../Interfaces/user-update';
import { BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  private userSubject=new BehaviorSubject<User[]>([]);
  user$=this.userSubject.asObservable();


  private apiUrl = "https://localhost:7259/User";
  
  constructor( private http:HttpClient ) {
    this.fetchUsers();
   }



   fetchUsers():void{
    this.http.get<User[]>(this.apiUrl).subscribe(users =>
      {
        this.userSubject.next(users);
      })
   }

   CreateUser(user: UserCreateDTO):Observable<User>{
    return this.http.post<User>(`${this.apiUrl}`,user).pipe(
      tap(()=> 
      this.fetchUsers()))
   }

   UpDateUser(user:UserUpdateDTO,userId:number ):Observable<User>{
    return this.http.put<User>(`${this.apiUrl}?id=${userId}`, user).pipe(
      tap(()=>
        this.fetchUsers()
      )
    )
   }


  DeleteUser(userId:number){
    return this.http.delete<User>(`${this.apiUrl}?id=${userId}`)
  }


  



}