import { Component, Input } from "@angular/core";
import { DatePipe } from "@angular/common";

import { TourInfo } from "./tour-info.model";

@Component({
  selector: "pred-tour-info",
  templateUrl: "./tour-info.component.html"
})
export class TourInfoComponent {
  @Input() tourInfo: TourInfo;
}
