import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { InquiryDTO } from '../../models/inquiry.model';
import { InquiryService } from '../../services/inquiry.service';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent implements OnInit {
  private router: Router;
  private readonly service: InquiryService;
  private readonly snackbar: MatSnackBar;

  public form: FormGroup;
  constructor
    (
    router: Router,
    service: InquiryService,
    snackbar: MatSnackBar
  ) {
    this.router = router;
    this.service = service;
    this.snackbar = snackbar;

    this.form = new FormGroup({
      firstNameControl: new FormControl(undefined, Validators.required),
      lastNameControl: new FormControl(undefined, Validators.required),
      emailControl: new FormControl(undefined, Validators.required),
      phoneControl: new FormControl(undefined, Validators.required),
      inquiryControl: new FormControl(undefined, Validators.required),
    });
  }

  ngOnInit(): void {
  }

  public sendInquiry() {
    this.form.markAllAsTouched();

    if (this.form.valid) {
      const model = new InquiryDTO({
        firstName: this.form.get('firstNameControl')!.value,
        lastName: this.form.get('lastNameControl')!.value,
        email: this.form.get('emailControl')!.value,
        phone: this.form.get('phoneControl')!.value,
        inquiry: this.form.get('inquiryControl')!.value
      });

      this.service.sendInquiry(model).subscribe({
        next: () => {
          this.router.navigate(['/']);

          this.snackbar.open("Успешно изпратено запитване!", "Затвори", {
            duration: 4000
          });
        }
      });
    }
  }
}
