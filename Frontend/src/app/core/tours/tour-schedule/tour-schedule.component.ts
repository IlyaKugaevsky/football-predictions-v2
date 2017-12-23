import { Component, OnInit, Input } from "@angular/core";

// import { TourInfo } from "../../tours/tour-info/tour-info.model";
import { TourSchedule } from "../../tours/tour-schedule/tour-schedule.model";

@Component({
  selector: "pred-tour-schedule",
  templateUrl: "./tour-schedule.component.html"
})
export class TourScheduleComponent {
  @Input() tourSchedule: TourSchedule;
  // matchTable: matchTable;
}
