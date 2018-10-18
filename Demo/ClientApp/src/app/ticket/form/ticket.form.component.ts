import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl, AbstractControl } from '@angular/forms';
import { TicketService } from '../../data/ticket.service';
import { ITicket } from '../ticket';

@Component({
  selector: 'ticket-form',
  templateUrl: './ticket.form.component.html',
  providers: [TicketService],
  styleUrls: ['./ticket.form.component.css']
})
export class TicketFormComponent implements OnInit {

  constructor(private ticketService: TicketService) { }

  private ticketForm: any;

  public ticket : ITicket = { id: 1, name: "Name" };

  public ngOnInit = () => {
    this.ticketForm = new FormGroup({
      'name': new FormControl(this.ticket.name, [
        Validators.required,
        Validators.minLength(4),
        this.validateName
      ])
    });
  };

  public validateName = () => {
    return (control: AbstractControl): {[key: string]: any} | null => { 
      return { "error": "Error message" };
    };
  }
}
