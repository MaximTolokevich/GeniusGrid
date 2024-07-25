import {Component, inject} from '@angular/core';
import {RouterOutlet} from "@angular/router";
import {SidebarComponent} from "../sidebar/sidebar.component";
import {UserService} from "../../user/user.service";
import {JsonPipe} from "@angular/common";

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [
    RouterOutlet,
    SidebarComponent,
    JsonPipe
  ],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {
  userService = inject(UserService)
  users: any = []

  ngOnInit() {
    this.userService.getAll().subscribe(val => {
      console.log(val)
    })
  }
}
