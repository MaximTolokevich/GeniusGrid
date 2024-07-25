import {Component, inject} from '@angular/core';
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {UserService} from "../../user/user.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-registration-page',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './registration-page.component.html',
  styleUrl: './registration-page.component.css'
})
export class RegistrationPageComponent {
  authService = inject(UserService)
  router = inject(Router)
  formBuilder = inject(FormBuilder);

  form: FormGroup;

  constructor() {
    this.form = this.formBuilder.group({
      name: ['', Validators.required],
      password: ['', Validators.required],
      email: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.form.valid) {
      //@ts-ignore
      this.authService.registration(this.form.value).subscribe(
        (response) => {
          console.log('Registration successful:', response);
          this.router.navigate([''])
        },
        (error) => {
          console.error('Registration error:', error);
        }
      );
    } else {
      console.log('Form is invalid');
    }
  }
}
