import { Injectable } from '@angular/core';

@Injectable()
export class TournamentService {
  private data: String[] = ["t1", "t2"];

  getData(): String[] {
    return this.data;
  }
}
