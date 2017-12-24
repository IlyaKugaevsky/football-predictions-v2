import { Component, Input } from "@angular/core";
import { DatePipe } from "@angular/common";

import { MatchInfo } from "./match-info.model";

@Component({
  selector: "pred-match-info",
  templateUrl: "./match-info.component.html"
})
export class MatchInfoComponent {
  @Input() matchInfo: MatchInfo;
}
