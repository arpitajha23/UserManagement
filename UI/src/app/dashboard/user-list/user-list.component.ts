import { Component, OnInit } from '@angular/core';
import { MainmenuComponent } from '../mainmenu/mainmenu.component';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from '../sidebar/sidebar.component';

interface User {
  firstName: string;
  middleName: string;
  lastName: string;
  dob: string;
  email: string;
  contactNo: string;
  city: string;
  state: string;
}
@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [MainmenuComponent,
    CommonModule,
    SidebarComponent,
    
  ],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent implements OnInit {
  activeUsers = 20;
  inactiveUsers = 300;
  
  users: User[] = [
    {
      firstName: 'John',
      middleName: 'Michael',
      lastName: 'Smith',
      dob: '01/05/2000',
      email: 'john@gmail.com',
      contactNo: '(603) 555-0123',
      city: 'Los Angeles',
      state: 'California'
    },
    
  ];

  ngOnInit(): void {
  
  }

  viewUser(user: User): void {
   
    console.log(user);
  }
}
