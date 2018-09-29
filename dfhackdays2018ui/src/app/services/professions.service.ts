import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Profession } from '../models/profession';

@Injectable({
  providedIn: 'root'
})
export class ProfessionsService {

  constructor(private http: HttpClient) { }

  getProfessions(): Observable<Profession[]> {
    return this.http.get<Profession[]>('http://localhost:5000/api/Professions');
  }

  getProfession(professionId: string): Observable<Profession> {
    // Add safe, URL encoded search parameter if there is a search term
    // const options = { params: new HttpParams().set('studentId', studentId) };

    return this.http.get<Profession>('http://localhost:5000/api/Professions/' + professionId);
  }
}
