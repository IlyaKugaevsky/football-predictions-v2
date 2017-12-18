import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule }   from '@angular/common/http';

import { TournamentsRoutingModule } from "./tournaments-routing.module";
import { TournamentScheduleComponent } from "./tournament-schedule.component";
import { TournamentService } from "./tournament.service"

@NgModule({
  declarations: [TournamentScheduleComponent],
  imports: [CommonModule, HttpClientModule, TournamentsRoutingModule],
  providers: [TournamentService]
})
export class TournamentsModule {}
