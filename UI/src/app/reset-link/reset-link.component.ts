import { Component } from '@angular/core';
import { CommonSidebarComponent } from '../common-sidebar/common-sidebar.component';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-reset-link',
  standalone: true,
  imports: [
    CommonSidebarComponent,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    MatCardModule
  ],
  templateUrl: './reset-link.component.html',
  styleUrl: './reset-link.component.css'
})
export class ResetLinkComponent {


}
