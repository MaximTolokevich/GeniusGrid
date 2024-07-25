import {HttpHandlerFn, HttpInterceptorFn, HttpRequest} from "@angular/common/http";
import { inject } from "@angular/core";
import { UserService } from "./user.service";
import {catchError, switchMap, throwError} from "rxjs";

let isRefreshing = false

export const authTokenInterceptor: HttpInterceptorFn = (req, next) => {
  const userService = inject(UserService)
  const token = userService.token

  if (!token) return next(req)

  if (isRefreshing) {
    return refreshAdnProceed(userService, req, next)
  }

  return next(addToken(req, token))
    .pipe(
      catchError(error => {
        if(error.status === 403) {
          return refreshAdnProceed(userService, req, next)
        }

        return throwError(error)
      })
    )
}

const refreshAdnProceed = (
  userService: UserService,
  req: HttpRequest<any>,
  next: HttpHandlerFn
) => {
  if (!isRefreshing) {
    isRefreshing = true
    return userService.refreshAuthToken()
      .pipe(
        //TODO access token
        switchMap((res) => {
          isRefreshing = false
          return next(addToken(req, res.token))
        })
      )
  }

  return next(addToken(req, userService.token!))
}

const addToken = (req: HttpRequest<any>, token: string) => {
  return req.clone({
    setHeaders: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': 'http://localhost:4200',
      Authorization: `Bearer ${token}`
    }
  });
}
