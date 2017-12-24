import { Component, Input } from "@angular/core";
import { DatePipe } from "@angular/common";

import { MatchInfo } from "../match-info/match-info.model";

@Component({
  selector: "pred-match-table",
  templateUrl: "./match-table.component.html"
})
export class MatchTableComponent {
  @Input() matchInfos: MatchInfo[];
}
