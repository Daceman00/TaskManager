import { Injectable, OnInit } from '@angular/core';
import { TASKS } from '../mock-tasks';
import { Task } from '../Task';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-type': 'application/json'
  }) 
}

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  apiUrl = 'https://localhost:7246/api'
  constructor(private http: HttpClient) {
  }

  getTasks(): Observable<Task[]>{
    return this.http.get<Task[]>(this.apiUrl + `/tasks`)
  }

  deleteTask(task:Task): Observable<Task> {
    return this.http.delete<Task>(this.apiUrl + `/tasks/${task.id}`);
  } 

  updateTaskReminder(task:Task){
    return this.http.put<Task>(this.apiUrl + `/tasks/${task.id}`, task, httpOptions)
  }

  addTask(task:Task){
    return this.http.post<Task>(this.apiUrl + `/tasks/`, task, httpOptions)
  }
}
