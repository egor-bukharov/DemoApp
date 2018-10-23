import { Component, OnInit, Input } from '@angular/core';
import { ITask } from '../../data/task';
import { TaskService } from '../../data-service/task.service';


@Component({
  selector: 'task-list-item',
  templateUrl: './task-list-item.component.html',
  styleUrls: ['./task-list-item.component.css'],
})
export class TaskListItemComponent implements OnInit {

  @Input() task: ITask = {};
  @Input() showDetails: boolean = false;

  public toggleDetails = () => {
    this.showDetails = !this.showDetails;
  };

  public submit = async () => {
    this.task = await this.taskDataService.edit(this.task);
  };

  constructor(private taskDataService: TaskService) { }

  ngOnInit() {
  }

}
