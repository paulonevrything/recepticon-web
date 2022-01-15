import { StepperSelectionEvent } from '@angular/cdk/stepper';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { RecepticonService } from 'src/app/core/services/recepticon.service';

@Component({
  selector: 'app-new-booking',
  templateUrl: './new-booking.component.html',
  styleUrls: ['./new-booking.component.css']
})
export class NewBookingComponent implements OnInit {

  newGuestFormGroup!: FormGroup;
  bookingInformationFormGroup!: FormGroup;

  guest: any;

  reservation: any;

  constructor(private fb: FormBuilder, private service: RecepticonService) { }

  ngOnInit(): void {

    this.buildForms();
  }

  selectionChange(event: StepperSelectionEvent) {

    let stepLabel = event.selectedStep.label;

    if (stepLabel == "booking-form") {

      this.buildGuest(this.newGuestFormGroup.value);

    } else if (stepLabel == "submit-form") {

      this.buildBooking(this.bookingInformationFormGroup.value);

    }

  }

  buildForms() {

    this.newGuestFormGroup = this.fb.group({

      firstName: new FormControl('', Validators.compose([
        Validators.required
      ])),

      lastName: new FormControl('', Validators.compose([
        Validators.required
      ])),

      phoneNumber: new FormControl('', Validators.compose([
        Validators.required
      ])),

      address: new FormControl('', Validators.compose([
        Validators.required
      ]))
    })

    this.bookingInformationFormGroup = this.fb.group({

      roomType: new FormControl('', Validators.compose([
        Validators.required
      ])),

      roomNumber: new FormControl('', Validators.compose([
        Validators.required
      ])),

      checkInDate: new FormControl('', Validators.compose([
        Validators.required
      ])),

      checkOutDate: new FormControl('', Validators.compose([
        Validators.required
      ]))
    })

  }

  buildGuest(guestFormDetails: any) {

    console.log(guestFormDetails);

  }

  buildBooking(bookingFormDetails: any) {

    console.log(bookingFormDetails);

  }

  submitBooking() {


  }

}
