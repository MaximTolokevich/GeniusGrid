import { inject, Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {tap} from "rxjs";
import {RegistrationResponce} from "./auth.interface";
import {CookieService} from "ngx-cookie-service";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  http: HttpClient = inject(HttpClient)
  cookieServise = inject(CookieService)
  baseApiUrl = 'https://localhost:7000/User/'

  token: string | null = '';
  // refreshToken: string | null = null

  get isAuth() {
    if (!this.token) {
      this.token = this.cookieServise.get('token')
    }
    return !!this.token
  }

  registration(payload: { password: string; name: string; email: string; }) {
    return this.http.post<RegistrationResponce>(
      `${this.baseApiUrl}Registration`,
      payload
    ).pipe(
      tap(val => {
        this.token = val.token

        this.cookieServise.set('token', this.token)
      })
    )
  }

  getAll() {
    return this.http.post(`${this.baseApiUrl}GetAll`, "")
  }
}
