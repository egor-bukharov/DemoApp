import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskListItemComponent } from './task-list-item.component';
import { MatInputModule, MatDatepickerModule, MatNativeDateModule } from '@angular/material';
import { FormsModule } from '@angular/forms';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { TaskService } from '../../data-service/task.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ITask } from '../../data/task';

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

  describe('isNewRecord', () => {
    it('should return false when task.id is set to non-empty string', () => {
      component.task.id = 'some id';
      expect(component.isNewRecord()).toBeFalsy();
    });

    it('should return true when task.id is not set', () => {
      component.task = {};
      expect(component.isNewRecord()).toBeTruthy();
    });

    it('should return true when task.id is null', () => {
      component.task = { id: null };
      expect(component.isNewRecord()).toBeTruthy();
    });

    it('should return true when task.id is empty string', () => {
      component.task = { id: '' };
      expect(component.isNewRecord()).toBeTruthy();
    });
  });

  describe('submit', () => {
    it('should invoke TaskService.add when isNewRecord() is true', async () => {
      const dataToSend : ITask = {
        name: 'name',
      };

      const dataToBeReceived : ITask = {
        id: 'id',
        name: dataToSend.name
      };

      component.task = dataToSend;

      expect(component.isNewRecord()).toBeTruthy();

      const taskService = TestBed.get(TaskService);
      spyOn(taskService, 'add').and.returnValue(dataToBeReceived);
      spyOn(taskService, 'edit').and.throwError('edit method should not be invoked');

      await component.submit();

      expect(taskService.add).toHaveBeenCalledWith(dataToSend);
      expect(component.task).toBe(dataToBeReceived);
    });

    it('should invoke TaskService.edit when isNewRecord() is false', async () => {
      const dataToSend : ITask = {
        id: 'id',
        name: 'name',
      };

      const dataToBeReceived = {};

      component.task = dataToSend;

      expect(component.isNewRecord()).toBeFalsy();

      const taskService = TestBed.get(TaskService);
      spyOn(taskService, 'add').and.throwError('add method should not be invoked');
      spyOn(taskService, 'edit').and.returnValue(dataToBeReceived);

      await component.submit();

      expect(taskService.edit).toHaveBeenCalledWith(dataToSend);
      expect(component.task).toBe(dataToBeReceived);
    });
  });
});
