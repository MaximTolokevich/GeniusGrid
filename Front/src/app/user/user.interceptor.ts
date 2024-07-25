import { HttpInterceptorFn } from "@angular/common/http";
import { inject } from "@angular/core";
import { UserService } from "./user.service";

export const authTokenInterceptor: HttpInterceptorFn = (req, next) => {
  const token = inject(UserService).token;

  console.log(token)
  if (!token) return next(req);

  req = req.clone({
    setHeaders: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': 'http://localhost:4200',
      Authorization: `Bearer ${token}`
    }
  });

  return next(req);
};
