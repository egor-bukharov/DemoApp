import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class TicketService
{
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string){ }

    public getTickets = () => {
        return this.http.get(this.baseUrl + 'api/Tickets');
    };
}