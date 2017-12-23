import { Component, Input } from "@angular/core";
import { DatePipe } from "@angular/common";

import { TournamentInfo } from "./tournament-info.model";

@Component({
  selector: "pred-tournament-info",
  templateUrl: "./tournament-info.component.html"
})
export class TournamentInfoComponent {
  @Input() tournamentInfo: TournamentInfo;
}
