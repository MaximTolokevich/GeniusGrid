import { Routes } from '@angular/router';
import {RegistrationPageComponent} from "./pages/registration-page/registration-page.component";
import {LayoutComponent} from "./common-ui/layout/layout.component";
import {canActivateAuth} from "./user/access.quard";

export const routes: Routes = [
  {
    path: '', component: LayoutComponent, children: [
      // {path: '', component: RegistrationPageComponent }
    ],
    canActivate: [canActivateAuth]
  },
  {path: 'registration', component: RegistrationPageComponent }
];
