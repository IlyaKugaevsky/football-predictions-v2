import { Component, OnInit } from "@angular/core";

import { TournamentService } from "../tournament.service";
import { TournamentSchedule } from "./tournament-schedule.model";
import { TournamentInfo } from "../tournament-info/tournament-info.model";
import { TourInfo } from "../../tours/tour-info/tour-info.model";
import { TourSchedule } from "../../tours/tour-schedule/tour-schedule.model";

@Component({
  selector: "pred-tournament-schedule",
  templateUrl: "./tournament-schedule.component.html"
})
export class TournamentScheduleComponent implements OnInit {
  constructor(private tournamentService: TournamentService) {}

  tournamentInfo: TournamentInfo;
  tourSchedules: TourSchedule[];
  tourMatchesExpanded: boolean[];

  ngOnInit(): void {
    this.setUp();
  }

  handleMatchesPanelBtnClick(tourNumber: number): void {
    this.tourMatchesExpanded[tourNumber - 1]
      ? this.hideMatches(tourNumber)
      : this.expandMatches(tourNumber);
  }

  hideMatches(tourNumber: number): void {
    this.tourMatchesExpanded[tourNumber - 1] = false;
  }

  expandMatches(tourNumber: number): void {
    this.tourMatchesExpanded[tourNumber - 1] = true;
  }

  setUp(): void {
    this.tournamentService
      .getTournamentScheduleFake()
      .subscribe((data: TournamentSchedule) => {
        this.tourSchedules = data.tourSchedules;
        this.tournamentInfo = data.tournamentInfo;
        this.tourMatchesExpanded = Array(this.tourSchedules.length);
        this.tourMatchesExpanded.fill(true);
        // console.log(this.tourSchedules);
      });
  }
}
