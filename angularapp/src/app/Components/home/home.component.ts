import { Component, Host, HostListener, Input, OnInit } from '@angular/core';
import { FormBuilder,FormControl,FormGroup,Validators} from '@angular/forms';
import { Observable, Subscribable, Subscription } from 'rxjs';
import { User } from 'src/app/Interfaces/user';
import { UserCreateDTO } from 'src/app/Interfaces/user-create';
import { UserService } from 'src/app/Services/user.service';
import { UserUpdateDTO } from 'src/app/Interfaces/user-update';
import { Auntservice } from 'src/app/Services/auntservice.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})


export class HomeComponent  implements OnInit{
  
  user!:User|null;

  constructor(private auntService:Auntservice){
  }

  
  ngOnInit(): void {
    this.auntService.currentUser$.subscribe((user)=>this.user=user )

  }


  
  
  
  
      
}
      
    
    