import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../data-service/task.service';

@Component({
  selector: 'task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css'],
  providers: [TaskService]
})
export class TaskListComponent implements OnInit {

  constructor(private taskService: TaskService) { }

  public tasks = [{ name: "TODO1", completed: true }, { name: "TODO2", completed: false }];

  ngOnInit() {
  }

}
