import { Routes } from '@angular/router';
import { SignUpComponent } from './sign-up/sign-up.component';
import { CommonSidebarComponent } from './common-sidebar/common-sidebar.component';
import { ForgetPasswordComponent } from './forget-password/forget-password.component';
import { ResetLinkComponent } from './reset-link/reset-link.component';
import { UserListComponent } from './dashboard/user-list/user-list.component';
import { AddUserComponent } from './dashboard/add-user/add-user.component';



export const routes: Routes = [
    {path: '', component:SignUpComponent},
    {path: 'sidebar', component:CommonSidebarComponent},
    {path: 'forget', component:ForgetPasswordComponent},
    {path: 'reset', component:ResetLinkComponent},
    {path:'Dashboard', component: UserListComponent},
    {path: 'create', component: AddUserComponent},
  
];
