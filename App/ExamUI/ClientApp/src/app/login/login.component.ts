import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs';
import { Login } from '../models/login';
import { IdentityService } from '../services/identity.service';
import * as JSEncrypt from 'jsencrypt';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form!: FormGroup;
  loading = false;
  submitted = false;
  credentials: Login = {
    username: '',
    password: ''
  };
  username: string = "";
  password: string = "";
  message: string = "";
  show: boolean = false;
  public publicKey: string = '-----BEGIN PUBLIC KEY-----\n' +
    'MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA2bq72ckd0dqEgxWAYHALaiQ0B8RFZ7GO1Zjs4QnBFUNAutiLhpz7WjWaGuD8R1plyF1OWhJQfoBSbCDGW/Y1BSU2AJI5mobMnL2fOyygCVlEzw9RMP4y1BmTdIi + QDcuOSIOoT0Abjd / MOb54gmrCbGiDrI5oCE / pDCBDViwndkD + 6JsPTgQ4I9rAHGkTy0pDLv8NvvyACNFVPMfqS6RYVTOAGBaUeVooiqxGGPkMQTSGuBz3fZrrfwN9QbiR8JZJLMl7dsEmEgksifZ1kn622yJRSjtVC1jk0Iu8jfQz28dTZPDmGXsesqIApvagTr7raN7Z7SeIZTy1xRU3zDG5QIDAQAB\n' + 'MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA2bq72ckd0dqEgxWAYHALaiQ0B8RFZ7GO1Zjs4QnBFUNAutiLhpz7WjWaGuD8R1plyF1OWhJQfoBSbCDGW/Y1BSU2AJI5mobMnL2fOyygCVlEzw9RMP4y1BmTdIi + QDcuOSIOoT0Abjd / MOb54gmrCbGiDrI5oCE / pDCBDViwndkD + 6JsPTgQ4I9rAHGkTy0pDLv8NvvyACNFVPMfqS6RYVTOAGBaUeVooiqxGGPkMQTSGuBz3fZrrfwN9QbiR8JZJLMl7dsEmEgksifZ1kn622yJRSjtVC1jk0Iu8jfQz28dTZPDmGXsesqIApvagTr7raN7Z7SeIZTy1xRU3zDG5QIDAQAB\n' +
    '-----END PUBLIC KEY-----';



  constructor(
    private formBuilder: FormBuilder,
    private identityService: IdentityService,
    private route: ActivatedRoute,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
    this.fetchPublicKey();
  }

  fetchPublicKey() {
    // this.identityService.identityCompanyPublic(this.credentials)
    //   .subscribe({
    //     next: (response: any) => {
    //       console.log(response);
    //       sessionStorage.setItem('publickey', response.auth_token);
    //       this.publicKey = response.auth_token;
    //     },
    //     error: (error: any) => {
    //       this.message = 'Error in Fetching Company Details!';
    //       this.loading = false;
    //     }
    //   });
  }



  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }

    this.loading = true;
    this.credentials.username = this.f.username.value;

    const kpassword: string = this.encryptCredentials(this.f.username.value, this.f.password.value);
    this.credentials.password = kpassword;


    this.identityService.authanticateUser(this.credentials)
      .pipe(first())
      .subscribe({
        next: (response: any) => {
          console.log(response);
          localStorage.setItem('token', response.auth_token);
          this.router.navigateByUrl('home');
        },
        error: error => {
          this.message = "Authantication Failed!"
          this.loading = false;
        }
      });
  }
  encryptCredentials(login: string, password: string): string {
    const encrypt = new JSEncrypt.JSEncrypt();
    encrypt.setPublicKey(this.publicKey);


    return encrypt.encrypt(password) as string;

    // Use the encrypted login and password as needed (e.g., send them to the server)
  }
  //submit() {
  //  if (this.username != "") {
  //    this.credentials.username = this.username;
  //  } else {
  //    this.message = "Username is required!";
  //    return;
  //  }
  //  if (this.password != "") {
  //    this.credentials.password = this.password;
  //  } else {
  //    this.message = "Password is required!";
  //    return;
  //  }



  //  this.clear();
  //}
  //clear() {
  //  this.username = "";
  //  this.password = "";
  //  this.show = true;
  //}
}
