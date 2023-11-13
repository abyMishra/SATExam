import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DestinationMasterViewAllComponent } from './destination-master-view-all.component';

describe('DestinationMasterViewAllComponent', () => {
  let component: DestinationMasterViewAllComponent;
  let fixture: ComponentFixture<DestinationMasterViewAllComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DestinationMasterViewAllComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DestinationMasterViewAllComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
