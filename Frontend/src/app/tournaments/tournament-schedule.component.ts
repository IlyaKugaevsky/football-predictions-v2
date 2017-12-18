import { Component } from "@angular/core";

import { TournamentService } from "./tournament.service";

@Component({
  selector: "pred-tournament-schedule",
  templateUrl: "./tournament-schedule.component.html"
})
export class TournamentScheduleComponent {
  constructor(private tournamentService: TournamentService) {}

  tournaments: String[] = ["tournament", "LUL", "kek"];

  getTournaments(): void {
    this.tournaments = this.tournamentService.getFakeData();
  }
}
