import { Component, OnInit } from "@angular/core";

import { TournamentService } from "./tournament.service";
import { TournamentSchedule } from "./tournament-schedule";
import { TournamentInfo } from "./tournament-info";
import { TourInfo } from "../tours/tour-info";

@Component({
  selector: "pred-tournament-schedule",
  templateUrl: "./tournament-schedule.component.html"
})
export class TournamentScheduleComponent implements OnInit {
  constructor(private tournamentService: TournamentService) {}

  tournamentSchedule: TournamentSchedule;

  ngOnInit(): void {
    this.getTournamentSchedule();
  }

  getTournamentSchedule(): void {
    this.tournamentService
      .getTournamentScheduleFake()
      .subscribe((data: TournamentSchedule) => {
        // this.tours = data.newTours;
        this.tournamentSchedule = data;
      });
  }

  // getTournaments(): void {
  //   this.tournamentService
  //     .getTournamentsFake()
  //     .subscribe((data: Tournament[]) => (this.tournaments = data));
  // }
}
