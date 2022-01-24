import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToolbarComponent } from './components/toolbar/toolbar.component';
import { NewBookingComponent } from './components/new-booking/new-booking.component';
import { GuestListComponent } from './components/guest-list/guest-list.component';
import { LayoutModule } from '@angular/cdk/layout';

@NgModule({
  declarations: [ToolbarComponent, NewBookingComponent, GuestListComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  exports: [
    FormsModule,
    ToolbarComponent,
    NewBookingComponent,
    GuestListComponent,
    ReactiveFormsModule,
    MaterialModule,
    LayoutModule
  ]
})
export class SharedModule { }
