import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskListComponent } from './task-list.component';
import { TaskListItemComponent } from '../task-list-item/task-list-item.component';
import { TaskService } from '../../data-service/task.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';
import { MatDatepickerModule, MatNativeDateModule, MatInputModule } from '@angular/material';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { ITask } from '../../data/task';

describe('TaskListComponent', () => {
  let component: TaskListComponent;
  let fixture: ComponentFixture<TaskListComponent>;
  let tasksData: ITask[];

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
    tasksData = [
      { id: '1', name: 'name1' },
      { id: '2', name: 'name2' }
    ];

    const service: TaskService = TestBed.get(TaskService);
    spyOn(service, 'getAll').and.returnValue(Promise.resolve(tasksData));
    spyOn(service, 'add').and.throwError('add() method should not be called');
    spyOn(service, 'edit').and.throwError('edit() method should not be called');

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
      await expect(taskService.getAll).toHaveBeenCalledWith();
      expect(component.tasks).toBe(tasksData);
    });
  });
});
