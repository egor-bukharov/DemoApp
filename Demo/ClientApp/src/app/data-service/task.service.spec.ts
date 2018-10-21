import { TestBed, inject } from '@angular/core/testing';
import { HttpClient, HttpHandler } from "@angular/common/http";
import { TaskService } from './task.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing'

describe('TaskService', () => {
  const baseUrl = "http://base.url/";

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ TaskService, { provide: 'BASE_URL', useFactory: () => { return baseUrl }, deps: [] } ]
    });
  });

  it('should be created', inject([TaskService], (service: TaskService) => {
    expect(service).toBeTruthy();
  }));

  it('should call http.get method with args', async () => {
    const service: TaskService = TestBed.get(TaskService);
    const http: HttpTestingController = TestBed.get(HttpTestingController);

    const getAllPromise = service.getAll();

    const itemsRequest = http.expectOne(baseUrl + 'api/task');
    itemsRequest.flush([{id: 1, name: "name"}]);

    http.verify();

    await getAllPromise;
  })
});
