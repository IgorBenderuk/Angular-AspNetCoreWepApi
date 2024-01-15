import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { User } from '../Interfaces/user';
import { HttpClient } from '@angular/common/http';
import { ActivatedRouteSnapshot, CanActivate, CanActivateFn, RouterStateSnapshot, UrlTree } from '@angular/router';
import { UserLogInDto } from '../Interfaces/user-log-in-dto';

@Injectable({
  providedIn: 'root'
})
export class Auntservice{
  private currentUserSubject = new BehaviorSubject<User| null>(null);
  currentUser$ = this.currentUserSubject.asObservable();
  private apiUrl = "https://localhost:7259/User"

  
  constructor(private http:HttpClient){}
  


  logInUser(email: string, password: string): Observable<User> {
    const userLogInDto: UserLogInDto = { email: email, password: password };
    return this.http.post<User>(`${this.apiUrl}/logIn`, userLogInDto).pipe(
      tap((user: User) => {
        this.currentUserSubject.next(user);
      })
    );

    
  }


}
