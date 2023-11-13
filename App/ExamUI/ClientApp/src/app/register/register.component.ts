import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { IdentityService } from '../services/identity.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form!: FormGroup;
  id: string | undefined;
  isAddMode: boolean | undefined = true ;
  loading = false;
  submitted = false;

  constructor(
      private formBuilder: FormBuilder,
      private route: ActivatedRoute,
      private router: Router,
      private identityService: IdentityService,
  ) {}

  ngOnInit() {
      this.id = this.route.snapshot.params['id'];
      this.isAddMode = !this.id;
      
      // password not required in edit mode
      const passwordValidators = [Validators.minLength(6)];
      if (this.isAddMode) {
          passwordValidators.push(Validators.required);
      }

      this.form = this.formBuilder.group({
          firstName: ['', Validators.required],
          lastName: ['', Validators.required],
          username: ['', Validators.required],
          password: ['', passwordValidators]
      });

      // if (!this.isAddMode) {
      //     this.identityService.getById(this.id)
      //         .pipe(first())
      //         .subscribe(x => this.form.patchValue(x));
      // }
  }

  // convenience getter for easy access to form fields
  get f() { return this.form.controls; }

  onSubmit() {
      this.submitted = true;

      // stop here if form is invalid
      if (this.form.invalid) {
          return;
      }

      this.loading = true;
      if (this.isAddMode) {
          this.createUser();
      } else {
          this.updateUser();
      }
  }

  private createUser() {
      this.identityService.createUser(this.form.value)
          .pipe(first())
          .subscribe({
              next: () => {
                  // this.alertService.success('User added successfully', { keepAfterRouteChange: true });
                  this.router.navigate(['../'], { relativeTo: this.route });
              },
              error: error => {
                  // this.alertService.error(error);
                  this.loading = false;
              }
          });
  }

  private updateUser() {
      // this.accountService.update(this.id, this.form.value)
      //     .pipe(first())
      //     .subscribe({
      //         next: () => {
      //             this.alertService.success('Update successful', { keepAfterRouteChange: true });
      //             this.router.navigate(['../../'], { relativeTo: this.route });
      //         },
      //         error: error => {
      //             this.alertService.error(error);
      //             this.loading = false;
      //         }
      //     });
  }
}