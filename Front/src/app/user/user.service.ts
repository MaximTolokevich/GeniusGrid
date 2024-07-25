import { inject, Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {catchError, tap, throwError} from "rxjs";
import {RegistrationResponce} from "./auth.interface";
import {CookieService} from "ngx-cookie-service";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  http: HttpClient = inject(HttpClient)
  router = inject(Router)
  cookieServise = inject(CookieService)
  baseApiUrl = 'https://localhost:7000/User/'

  token: string | null = ""
  refreshToken: string | null = ""

  get isAuth() {
    if (!this.token) {
      this.token = this.cookieServise.get('token')
      this.refreshToken = this.cookieServise.get('refreshToken')
    }
    return !!this.token
  }

  registration(payload: { password: string; name: string; email: string; }) {
    return this.http.post<RegistrationResponce>(
      `${this.baseApiUrl}Registration`,
      payload
    ).pipe(
      tap(val => {
        this.saveTokens(val)
      })
    )
  }

  getAll() {
    return this.http.post(`${this.baseApiUrl}GetAll`, "")
  }

  refreshAuthToken() {
    return this.http.post<RegistrationResponce>(
      `${this.baseApiUrl}RefreshToken`,
      {
        refreshToken: this.refreshToken
      }
      ).pipe(
        tap(val => {
          this.saveTokens(val)
        }),
        catchError(err => {
          this.logout()
          return throwError(err)
        })
    )
  }

  logout() {
    this.cookieServise.deleteAll()
    this.token = ""
    this.refreshToken = ""
    this.router.navigate(['/login'])
  }

// TODO new interface for tokens and responce from AUTHMethods
  saveTokens(res: RegistrationResponce) {
    this.token = res.token
    // this.refreshToken = val.refreshToken

    this.cookieServise.set('token', this.token)
    // this.cookieServise.set('refreshToken', this.refreshToken)
  }
}
