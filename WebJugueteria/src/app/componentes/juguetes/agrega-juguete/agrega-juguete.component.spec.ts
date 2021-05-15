import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregaJugueteComponent } from './agrega-juguete.component';

describe('AgregaJugueteComponent', () => {
  let component: AgregaJugueteComponent;
  let fixture: ComponentFixture<AgregaJugueteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AgregaJugueteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AgregaJugueteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
