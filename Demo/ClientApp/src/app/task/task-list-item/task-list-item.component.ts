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

  constructor(private taskDataService: TaskService) { }

  public ngOnInit() {};

  public isNewRecord() : boolean {
    return !this.task.id || this.task.id.length == 0;
  };

  public toggleDetails() {
    this.showDetails = !this.showDetails;
  };

  public async submit() {
    this.task = this.isNewRecord()
      ? await this.taskDataService.add(this.task) 
      : await this.taskDataService.edit(this.task);
  };
}
