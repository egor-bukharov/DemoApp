import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskListComponent } from './task-list.component';
import { TaskListItemComponent } from '../task-list-item/task-list-item.component';
import { TaskService } from '../../data-service/task.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';

describe('TaskListComponent', () => {
  let component: TaskListComponent;
  let fixture: ComponentFixture<TaskListComponent>;

  const baseUrl = "http://base.url/";

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaskListComponent, TaskListItemComponent ],
      imports: [HttpClientTestingModule, FormsModule],
      providers: [TaskService, { provide: 'BASE_URL', useFactory: () => { return baseUrl }, deps: [] }]
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
});
