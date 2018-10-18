import { Component } from '@angular/core';

@Component({
  selector: 'tickets',
  templateUrl: './tickets.component.html',
})
export class TicketsTableComponent {
  columnDefs = [
      {headerName: '#', field: 'id'},
      {headerName: 'Name', field: 'name'},
      {headerName: 'Description', field: 'description'},
      {headerName: 'Priority', field: 'priority'}
  ];

  rowData: ITicketsTableDataItem[] = [
      { id: 1, name: "Name 01", description: "Description 01", priority: Priority.Low },
      { id: 2, name: "Name 01", description: "Description 01" },
      { id: 10000001, name: "Name 0X", description: "Description 0X", priority: Priority.Normal },
  ];

  public refresh = () => {
    debugger;
    
  }
}

interface ITicketsTableDataItem
{
  id: number;
  name: string;
  description?: string;
  priority?: Priority;
}

enum Priority
{
  Low = 1,
  Normal = 10,
  High = 20,
}
