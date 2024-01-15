import { Injectable, OnInit } from '@angular/core';
import { UserService } from './user.service';
import { User } from '../Interfaces/user';
import { AsyncValidatorFn, AbstractControl, ValidationErrors, ValidatorFn, FormControl, FormGroup } from '@angular/forms';
import { Observable, of, map } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserValidationService  {
  [x: string]: any;



  private prohibiteddNames:string[]=[
    'admin',
    'root',
    'name',
    'firstName',
    'name'
  ];

  constructor(private http:HttpClient) {

  }

  private apiUrl = "https://localhost:7259/User";
  CheckEmailExists(email:string){
    return this.http.get<boolean>(`${this.apiUrl}/CheckEmail?email=${email}`)
  }

  
  
  validateEmailExists = (control: AbstractControl): Observable<ValidationErrors | null> =>{
    const email=control.value as string ;


    return this.CheckEmailExists(email).pipe(
      map((exists:boolean)=>{
      
        return exists? null: {emailEror:true} 
      })
    )
    
  }
 
  validateEmailNotExists= (control: AbstractControl): Observable<ValidationErrors | null> =>{
    const email=control.value as string ;

    return this.CheckEmailExists(email).pipe(
      map((exists:boolean)=>{
      
        return exists? {emailEror: true} :null 
      })
    )
    
  }


  prohibitedNameValidator():ValidatorFn{
    return(control:AbstractControl):ValidationErrors | null =>
    {
      const invalidName:boolean=this.prohibiteddNames.includes(control.value);

      return invalidName ? null :{nameEror:true};

    }

  }

}