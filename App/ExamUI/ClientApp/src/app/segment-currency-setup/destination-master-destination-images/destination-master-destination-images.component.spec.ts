import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DestinationMasterDestinationImagesComponent } from './destination-master-destination-images.component';

describe('DestinationMasterDestinationImagesComponent', () => {
  let component: DestinationMasterDestinationImagesComponent;
  let fixture: ComponentFixture<DestinationMasterDestinationImagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DestinationMasterDestinationImagesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DestinationMasterDestinationImagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
