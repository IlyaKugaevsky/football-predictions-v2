import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { TournamentsRoutingModule } from "./tournaments-routing.module";
import { TournamentScheduleComponent } from "./tournament-schedule.component";

@NgModule({
  declarations: [TournamentScheduleComponent],
  imports: [CommonModule, TournamentsRoutingModule],
  providers: []
})
export class TournamentsModule {}
