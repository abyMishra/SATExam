import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DestinationMasterGeneralInformationComponent } from './destination-master-general-information.component';

describe('DestinationMasterGeneralInformationComponent', () => {
  let component: DestinationMasterGeneralInformationComponent;
  let fixture: ComponentFixture<DestinationMasterGeneralInformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DestinationMasterGeneralInformationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DestinationMasterGeneralInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
