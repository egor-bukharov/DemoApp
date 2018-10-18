import { Component } from '@angular/core';
import { TicketService } from '../../data/ticket.service';
import { ITicket } from '../ticket';

@Component({
  selector: 'tickets-grid',
  templateUrl: './ticket.grid.component.html',
  providers: [TicketService],
  styleUrls: ['./ticket.grid.component.css']
})
export class TicketsGridComponent {
  public constructor(private ticketService: TicketService) { }

  public columnDefs = [
    {headerName: '#', field: 'id', cellClass: "row-clickable"},
    {headerName: 'Name', field: 'name'},
    {headerName: 'Description', field: 'description'},
    {headerName: 'Priority', field: 'priority'}
  ];

  public rowData: ITicket[] = [];

  private gridApi;
  private gridColumnApi;

  public onGridReady = (event) => {
    this.gridApi = event.api;
    this.gridColumnApi = event.columnApi;

    this.refreshData();
    this.sizeColumnsToFit();
  }

  public refreshData = () => {
    debugger;
    this.ticketService.getTickets().subscribe((data: ITicket[]) => {
      debugger;
      this.rowData = data;
    });
  }

  public sizeColumnsToFit = () => {
    this.gridApi.sizeColumnsToFit();
  }

  public autoSizeColumns = () => {
    var allColumnIds = [];

    this.gridColumnApi.getAllColumns().forEach(function(column) {
      allColumnIds.push(column.colId);
    });

    this.gridColumnApi.autoSizeColumns(allColumnIds);
  };
}