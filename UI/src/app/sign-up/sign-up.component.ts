import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { CommonSidebarComponent } from '../common-sidebar/common-sidebar.component';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from 'express';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [CommonModule, CommonSidebarComponent,
    MatButtonModule,
    MatInputModule,
    MatCardModule,
    MatIconModule,
    ReactiveFormsModule,
    FormsModule
    
  ],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.css'
})
export class SignUpComponent {

  loginForm: FormGroup;
  passwordFieldType: string = 'password';

  constructor(private fb: FormBuilder) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  togglePasswordVisibility(): void {
    this.passwordFieldType = this.passwordFieldType === 'password' ? 'text' : 'password';
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      console.log('Form Submitted!', this.loginForm.value);
  
    }
  }
}
