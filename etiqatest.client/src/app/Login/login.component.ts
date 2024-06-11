import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
//import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  //loginForm: FormGroup;

  // constructor(private fb: FormBuilder, private authService: AuthService) {
  //   this.loginForm = this.fb.group({
  //     email: ['', [Validators.required, Validators.email]],
  //     password: ['', [Validators.required]]
  //   });
  // }

   ngOnInit(): void {}

  // onSubmit(): void {
  //   if (this.loginForm.valid) {
  //     this.authService.login(this.loginForm.value).subscribe(
  //       (response) => {
  //         console.log('Login successful:', response);
  //         // Handle successful login (e.g., store token, redirect)
  //       },
  //       (error) => {
  //         console.error('Login error:', error);
  //         // Handle login error
  //       }
  //     );
  //   }
  // }
}
