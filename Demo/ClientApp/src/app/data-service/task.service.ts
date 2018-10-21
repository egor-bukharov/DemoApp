import { Injectable, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs/Observable';

@Injectable()
export class TaskService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public getAll = () => {
    return this.http.get(this.baseUrl + 'api/task').toPromise();
  };
}
