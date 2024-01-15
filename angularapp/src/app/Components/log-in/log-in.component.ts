import { Component, Inject, OnInit } from '@angular/core';
import { EmailValidator, FormBuilder,FormControl,FormGroup,Validators } from '@angular/forms';
import { UserService } from '../../Services/user.service';
import { UserValidationService } from 'src/app/Services/user-validation.service';
import { User } from 'src/app/Interfaces/user';
import { Auntservice } from 'src/app/Services/auntservice.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {
 
  userLogIn!:FormGroup;
 
 constructor(private formBuilder:FormBuilder,private userAunt:Auntservice,private userValidator:UserValidationService,private router :Router){
 }
 
  ngOnInit(): void {
  this.userLogIn=this.formBuilder.group({
  email:['',{
    validators: [Validators.required,Validators.email],
    asyncValidators:[this.userValidator.validateEmailExists],
    Updated:'blur'
  }],
  password:['',[Validators.required,Validators.pattern('^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d).{8,}$')]]
  })
  }


get emailFormControl():FormControl{
  return this.userLogIn.get('email') as FormControl
}
get passwordFormControl():FormControl{
  return this.userLogIn.get('password') as FormControl
}

logIn(){
  this.userAunt.logInUser(this.emailFormControl.value,this.passwordFormControl.value).subscribe((user)=>{
    this.router.navigate(['/home'])
  })
    
}



}
