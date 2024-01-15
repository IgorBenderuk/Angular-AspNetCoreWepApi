import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators, AbstractControl, ValidationErrors, AsyncValidatorFn,ValidatorFn } from '@angular/forms';
import { Observable, map } from 'rxjs';
import { UserCreateDTO } from 'src/app/Interfaces/user-create';
import { UserValidationService } from 'src/app/Services/user-validation.service';
import { UserService } from 'src/app/Services/user.service';
import { Router } from '@angular/router';
import { Auntservice } from 'src/app/Services/auntservice.service';

@Component({
  selector: 'app-log-up',
  templateUrl: './log-up.component.html',
  styleUrls: ['./log-up.component.css']
})
export class LogUpComponent  implements OnInit{
  
  userLogUp!: FormGroup;
  userService: any;
  

  constructor(private formBuilder:FormBuilder,private userServece:UserService,private userValidator:UserValidationService,private router :Router,private userAunt:Auntservice ){
    
  }
  ngOnInit(): void {
    this.userLogUp=this.formBuilder.group({
      firstName:['',[Validators.required,this.userValidator.prohibitedNameValidator]],
      password:['',[Validators.required,Validators.pattern('^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d).{8,}$')]],
      confirmPassword:['',[Validators.required ] ],
      age:['',[Validators.required,Validators.min(18)]],
      email: ['',{
        validators: [Validators.required,Validators.email],
        asyncValidators:[this.userValidator.validateEmailNotExists],
        Updated:'blur'
      } 
      ]
    })
    this.userLogUp.valueChanges.subscribe((resu)=>{

      if(this.confirmPasswordFormControl.value!==this.passwordFormControl.value){
        this.confirmPasswordFormControl.setErrors({missmatch:true})
      }
       
    } 
    )


  }

  get firstNameFormControl():FormControl{
    return this.userLogUp.get('firstName') as FormControl
  }
  
  get emailFormControl():FormControl{
    return this.userLogUp.get('email') as FormControl
  }
  
  get passwordFormControl():FormControl{
    return this.userLogUp.get('password') as FormControl
  }
  
  get ageFormControl():FormControl{
    return this.userLogUp.get('age') as FormControl
  }
  get confirmPasswordFormControl():FormControl{
    return this.userLogUp.get('confirmPassword') as FormControl
  }

  
  CreateUser():void {
    let newUser:UserCreateDTO ={
      firstName:this.firstNameFormControl.value,
      email:this.emailFormControl.value,
      password:this.passwordFormControl.value,
      age:this.ageFormControl.value
    }
    
    this.userServece.CreateUser(newUser).subscribe((user)=>
    {
     this.userAunt.logInUser(user.email,user.password).subscribe((user)=>
     {
      this.router.navigate(['/home'])
     }) 
    } )
    
    this.userLogUp.reset();
  }

}




