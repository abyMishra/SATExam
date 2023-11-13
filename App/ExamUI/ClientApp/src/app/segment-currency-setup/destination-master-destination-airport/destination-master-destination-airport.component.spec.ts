import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DestinationMasterDestinationAirportComponent } from './destination-master-destination-airport.component';

describe('DestinationMasterDestinationAirportComponent', () => {
  let component: DestinationMasterDestinationAirportComponent;
  let fixture: ComponentFixture<DestinationMasterDestinationAirportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DestinationMasterDestinationAirportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DestinationMasterDestinationAirportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
