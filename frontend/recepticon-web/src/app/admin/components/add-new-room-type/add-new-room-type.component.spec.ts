import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewRoomTypeComponent } from './add-new-room-type.component';

describe('AddNewRoomTypeComponent', () => {
  let component: AddNewRoomTypeComponent;
  let fixture: ComponentFixture<AddNewRoomTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddNewRoomTypeComponent ]
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
