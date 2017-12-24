import { Component, OnInit } from "@angular/core";

import { TournamentService } from "../tournament.service";
import { TournamentInfo } from "../tournament-info/tournament-info.model";

@Component({
  selector: "pred-tournament-list",
  templateUrl: "./tournament-list.component.html"
})
export class TournamentListComponent implements OnInit {
  constructor(private tournamentService: TournamentService) {}

  tournamentInfos: TournamentInfo[];

  ngOnInit(): void {
    this.setUp();
  }

  setUp(): void {
    this.tournamentService
      .getTournamentsFake()
      .subscribe((data: TournamentInfo[]) => {
        this.tournamentInfos = data;
      });
  }
}
