import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../data-service/task.service';
import { ITask } from '../../data/task';

@Component({
  selector: 'task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css'],
  providers: [TaskService]
})
export class TaskListComponent implements OnInit {

  constructor(private taskService: TaskService) { }

  public tasks: ITask[] = [];

  async ngOnInit() {
    this.tasks = await this.taskService.getAll();
  }
}
