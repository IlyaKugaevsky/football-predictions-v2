import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";

import { Tournament } from "./tournament";

@Injectable()
export class TournamentService {
  constructor(private http: HttpClient) {}

  getTournamentScheduleFake(): Observable<any> {
    return this.http.get("assets/fake-data/tournament-schedule.json");
  }

  getTournamentsFake(): Observable<any> {
    return this.http.get("assets/fake-data/tournaments.json");
  }

  getTournaments(): Observable<any> {
    return this.http.get("http://localhost:5000/api/tournaments/");
  }
}
