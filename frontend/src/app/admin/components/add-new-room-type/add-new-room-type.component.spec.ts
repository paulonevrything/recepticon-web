import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import { AddNewRoomTypeComponent } from './add-new-room-type.component';

describe('AddNewRoomTypeComponent', () => {
  let component: AddNewRoomTypeComponent;
  let fixture: ComponentFixture<AddNewRoomTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddNewRoomTypeComponent ],
      imports: [ ReactiveFormsModule, HttpClientTestingModule, MatSnackBarModule,
        FormsModule, MatFormFieldModule, MatInputModule, NoopAnimationsModule, ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddNewRoomTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
