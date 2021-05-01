import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PetOwnerComponent } from './pet-owner.component';

describe('PetOwnerComponent', () => {
  let component: PetOwnerComponent;
  let fixture: ComponentFixture<PetOwnerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PetOwnerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PetOwnerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
