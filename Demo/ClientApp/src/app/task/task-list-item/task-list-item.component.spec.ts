import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskListItemComponent } from './task-list-item.component';
import { MatInputModule, MatDatepickerModule, MatNativeDateModule } from '@angular/material';
import { FormsModule } from '@angular/forms';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { TaskService } from '../../data-service/task.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('TaskListItemComponent', () => {
  const baseUrl = "http://base.url"

  let component: TaskListItemComponent;
  let fixture: ComponentFixture<TaskListItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaskListItemComponent ],
      imports: [
        MatInputModule, 
        FormsModule, 
        MatDatepickerModule, 
        MatNativeDateModule, 
        NoopAnimationsModule,
        HttpClientTestingModule
      ],
      providers: [TaskService, { provide: 'BASE_URL', useFactory: () => { return baseUrl }, deps: [] }]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  describe('showDetails', () => {
    it('should be false by default', () => {
      expect(component.showDetails).toBe(false);
    })
  });

  describe('toggleDetails', () => {
    it('should inverse showDetails value', () => {
      component.showDetails = false;
      
      component.toggleDetails();
      expect(component.showDetails).toBe(true);

      component.toggleDetails();
      expect(component.showDetails).toBe(false);

      component.showDetails = true;
      component.toggleDetails();
      expect(component.showDetails).toBe(false);

      component.toggleDetails();
      expect(component.showDetails).toBe(true);
    });
  });
});
