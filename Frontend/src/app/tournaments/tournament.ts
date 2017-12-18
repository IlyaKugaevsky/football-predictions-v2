import { Tour } from "../tours/tour";

export class Tournament {
  tournamentId: number;
  title: string;
  startDate: Date;
  endDate: Date;
  newTours: Tour[];
}
