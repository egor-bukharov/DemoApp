import { Injectable, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ITask } from '../data/task';

@Injectable()
export class TaskService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public getAll : () => Promise<ITask[]> = () => {
    return this.http.get<ITask[]>(this.baseUrl + 'api/task').toPromise();
  };

  public add: (task: ITask) => Promise<ITask> = (task: ITask) => {
    return this.http.post<ITask>(this.baseUrl + 'api/task', task).toPromise();
  };

  public edit: (task: ITask) => Promise<ITask> = (task: ITask) => {
    return this.http.put<ITask>(this.baseUrl + 'api/task', task).toPromise();
  };
}
