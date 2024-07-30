import { Routes } from '@angular/router';
import { SignUpComponent } from './auth/sign-up/sign-up.component';
import { CommonSidebarComponent } from './auth/common-sidebar/common-sidebar.component';
import { ForgetPasswordComponent } from './Passwords/forget-password/forget-password.component';
import { ResetLinkComponent } from './Passwords/reset-link/reset-link.component';
import { UserListComponent } from './dashboard/user-list/user-list.component';
import { AddUserComponent } from './dashboard/add-user/add-user.component';
import { SidebarComponent } from './dashboard/sidebar/sidebar.component';
import { MainmenuComponent } from './dashboard/mainmenu/mainmenu.component';
import { ResetPasswordComponent } from './Passwords/reset-password/reset-password.component';



export const routes: Routes = [
    {path: '', component:SignUpComponent},
    {path: 'sidebar', component:CommonSidebarComponent},
    {path: 'forget', component:ForgetPasswordComponent},
    {path: 'reset', component:ResetLinkComponent},
    {path:'Dashboard', component: UserListComponent},
    {path: 'create', component: AddUserComponent},
    {path: 'sidebarnew', component: SidebarComponent},
    {path: 'menu', component: MainmenuComponent},
    {path: 'reset-password', component: ResetPasswordComponent},
];
