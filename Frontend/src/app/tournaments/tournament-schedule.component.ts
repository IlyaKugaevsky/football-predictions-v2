import { Component, OnInit } from "@angular/core";

import { TournamentService } from "./tournament.service";
import { Tournament } from "./tournament";
import { Tour } from "../tours/tour";

@Component({
  selector: "pred-tournament-schedule",
  templateUrl: "./tournament-schedule.component.html"
})
export class TournamentScheduleComponent implements OnInit {
  constructor(private tournamentService: TournamentService) {}

  tournaments: Tournament[] = [];
  tours: Tour[];
  tournament: Tournament;

  ngOnInit(): void {
    this.getTournamentSchedule();
  }

  getTournamentSchedule(): void {
    this.tournamentService
      .getTournamentScheduleFake()
      .subscribe((data: Tournament) => {
        this.tours = data.newTours;
        this.tournament = data;
      });
  }

  getTournaments(): void {
    this.tournamentService
      .getTournamentsFake()
      .subscribe((data: Tournament[]) => (this.tournaments = data));
  }
}
