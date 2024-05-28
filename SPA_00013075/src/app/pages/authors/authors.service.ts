import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Author } from '../../models/author.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorsService {
  api = 'http://localhost:5288/api/Author/';
  constructor(private httpClient: HttpClient){}

  getAll(): Observable<Author[]>{
    return this.httpClient.get<Author[]>(this.api);
  }

  get(id: number): Observable<Author>{
    return this.httpClient.get<Author>(this.api + id);
  }

  add(author: Author): Observable<any>{
    return this.httpClient.post<Author>(this.api, author);
  }

  delete(id: number): Observable<any>{
    return this.httpClient.delete<Author>(this.api + id);
  }

  edit(id: number, author: Author){
    return this.httpClient.put<Author>(this.api + id, author);
  }
}
