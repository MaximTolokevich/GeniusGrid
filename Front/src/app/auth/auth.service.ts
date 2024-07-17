import {inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  // http: HttpClient = inject(HttpClient)

  login(payload: {username: string, password: string}) {
    // return this.http.post("", payload)
  }
}
