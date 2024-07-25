import {inject} from "@angular/core";
import {UserService} from "./user.service";
import {Router} from "@angular/router";

export const canActivateAuth = () => {
  const isLoggedIn = inject(UserService).isAuth

  if (isLoggedIn) {
    return true
  }

  return inject(Router).createUrlTree([''])
}
