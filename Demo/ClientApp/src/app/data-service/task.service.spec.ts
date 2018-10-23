import { TestBed, inject } from '@angular/core/testing';
import { HttpClient, HttpHandler } from "@angular/common/http";
import { TaskService } from './task.service';
import { HttpClientTestingModule, HttpTestingController, RequestMatch } from '@angular/common/http/testing'
import { ITask } from '../data/task';

describe('TaskService', () => {
  const baseUrl = "http://base.url/";

  let service: TaskService;
  let http: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ TaskService, { provide: 'BASE_URL', useFactory: () => { return baseUrl }, deps: [] } ]
    });

    service = TestBed.get(TaskService);
    http = TestBed.get(HttpTestingController);
  });

  it('should be created', inject([TaskService], (service: TaskService) => {
    expect(service).toBeTruthy();
  }));

  describe('getAll', () => {
    it('should call http.get() with parameters', async () => {
      const getAllPromise = service.getAll();

      const expectedId = 'some guid';
      const expectedName = 'name value';

      const itemsRequest = http.expectOne(baseUrl + 'api/task');
      itemsRequest.flush([{id: expectedId, name: expectedName}]);
  
      http.verify();
  
      const dataArray = await getAllPromise;

      expect(dataArray.length).toBe(1);
      expect(dataArray[0].id).toBe(expectedId);
      expect(dataArray[0].name).toBe(expectedName);
    });
  });

  describe('add', () => {
    it('should call http.post() with parameters', async () => {
      const dataToSend: ITask = {};
      const dataToBeReceived: ITask = {};
      
      const addPromise = service.add(dataToSend);
      const requestMatch: RequestMatch = {url: baseUrl + 'api/task', method: 'POST'};
      
      const request = http.expectOne(requestMatch);
      expect(request.request.body).toBe(dataToSend);
      
      request.flush(dataToBeReceived);

      http.verify();

      const data = await addPromise;
      expect(data).toBe(dataToBeReceived);
      //expect(data).toBe(dataToSend);
    });
  });

  describe('edit', () => {
    it('should call http.put() with parameters', async () => {
      const dataToSend: ITask = {};
      const dataToBeRecevied: ITask = {};

      const editPromise = service.edit(dataToSend);

      const requestMatch: RequestMatch = {
        url: baseUrl + 'api/task',
        method: 'PUT'
      };
      const request = http.expectOne(requestMatch);
      request.flush(dataToBeRecevied);

      const result = await editPromise;
    });
  });
});
