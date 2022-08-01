import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/service/authentication.service';
import { User } from 'Models/user';
import { UserserviceService } from 'src/app/service/userservice.service';
import { Toaster } from 'ngx-toast-notifications';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  IsAdmin: boolean = false;
  IsHR: boolean = false;
  userValue: User[] = [];
  submitted: boolean;
  loading: boolean;
  error: string = '';
  isCommanError: boolean = false;

  loginForm = this.formBuilder.group({
    UserName: ['', [Validators.required, Validators.pattern("^[A-z][a-z|\.|\s]+$")]],
    Password: ['', [Validators.required, Validators.pattern("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$")]]
  });

  // employeeDetails: any;
  //employeeID='';
  // employeeACENumber: any;
  constructor(private formBuilder: FormBuilder,
    private http: HttpClient, private route: Router,
    private service: UserserviceService,private toaster: Toaster) { 
      this.onChanges();
    }
  user: any = {

    UserName: '',
    Password: '',

  }
  ngOnInit(): void {
  }

  onSubmit() {
    this.submitted = true;
    if(this.loginForm.valid){
      this.loading = true
      const user = {
        UserName: this.loginForm.value['UserName'],
        Password: this.loginForm.value['Password']
      }
      this.service.Login(user).subscribe({
        next: (data) => {
          this.IsAdmin = data.isAdmin
          this.IsHR = data.isHR

          AuthenticationService.SetDateWithExpiry("token", data.token, data.expiryInMinutes)
          AuthenticationService.SetDateWithExpiry("Admin", data.isAdmin, data.expiryInMinutes)
          AuthenticationService.SetDateWithExpiry("HR", data.isHR, data.expiryInMinutes)

          if (this.IsAdmin) {
            this.route.navigateByUrl("/");  //navigation
          }
          else if (this.IsHR) {
            this.route.navigateByUrl("/search");
          }
          else {
            this.route.navigateByUrl("/dashboard");
          }

        },
        error: (error: any) => {
          if (error.status == 404) {
            this.route.navigateByUrl("errorPage");
          }
          if (!(error.error.toString().includes('UserName') || error.error.toString().includes('Password'))) {
            this.isCommanError = true;
          }
          this.error = error.error;
          this.loading = false;
        },
        complete: () => {
          this.toaster.open({ text: 'Logged in successfully', position: 'top-center', type: 'success' });
          return this.loading = false;
        }
      });
    }
  }
  onChanges() : void {
    this.loginForm.valueChanges.subscribe(val => {
      if (this.loginForm.valid) {
      } else {
      }
      });
  }
}
