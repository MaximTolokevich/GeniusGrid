import { Routes } from '@angular/router';
import {LoginPageComponent} from "./pages/login-page/login-page.component";
import {LayoutComponent} from "./common-ui/layout/layout.component";

export const routes: Routes = [
  {path: '', component: LayoutComponent, children: [
      // {path: '', component: LoginPageComponent }
    ]
  },
  {path: 'login', component: LoginPageComponent }
];
