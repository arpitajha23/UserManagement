import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommonSidebarComponent } from './common-sidebar.component';

describe('CommonSidebarComponent', () => {
  let component: CommonSidebarComponent;
  let fixture: ComponentFixture<CommonSidebarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CommonSidebarComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CommonSidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
