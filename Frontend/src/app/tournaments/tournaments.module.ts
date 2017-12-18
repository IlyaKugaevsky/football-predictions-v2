import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { TournamentsRoutingModule } from "./tournaments-routing.module";
import { TournamentScheduleComponent } from "./tournament-schedule.component";
import { TournamentService } from "./tournament.service"

@NgModule({
  declarations: [TournamentScheduleComponent],
  imports: [CommonModule, TournamentsRoutingModule],
  providers: [TournamentService]
})
export class TournamentsModule {}
