import { Component, OnInit, Input } from '@angular/core';
import { ITaskListItem } from '../../data/task';


@Component({
  selector: 'task-list-item',
  templateUrl: './task-list-item.component.html',
  styleUrls: ['./task-list-item.component.css'],
})
export class TaskListItemComponent implements OnInit {

  @Input() task: ITaskListItem = {};
  @Input() showDetails: boolean = false;

  public toggleDetails = () => {
    this.showDetails = !this.showDetails;
  };

  constructor() { }

  ngOnInit() {
  }

}
