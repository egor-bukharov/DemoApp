import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskListComponent } from './task-list.component';
import { TaskListItemComponent } from '../task-list-item/task-list-item.component';
import { TaskService } from '../../data-service/task.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';
import { MatDatepickerModule, MatNativeDateModule, MatInputModule } from '@angular/material';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

describe('TaskListComponent', () => {
  let component: TaskListComponent;
  let fixture: ComponentFixture<TaskListComponent>;
  let taskService: TaskService;

  const baseUrl = "http://base.url/";

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaskListComponent, TaskListItemComponent ],
      imports: [
        HttpClientTestingModule, 
        FormsModule, 
        MatInputModule, 
        MatDatepickerModule, 
        MatNativeDateModule,
        NoopAnimationsModule
      ],
      providers: [
        TaskService, 
        { provide: 'BASE_URL', useFactory: () => { return baseUrl }, deps: [] }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  describe('ngOnInit', () => {
    it('should call TaskService.getAll()', async () => {
      const taskService: TaskService = TestBed.get(TaskService);
      spyOn(taskService, 'getAll').and.returnValue([
        { id: 'id', name: 'name' }
      ]);

      const component = new TaskListComponent(taskService);
      await component.ngOnInit();

      expect(taskService.getAll).toHaveBeenCalledWith();
    });
  });
});
