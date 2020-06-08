import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TeamsService } from '../../Services/teams/teams.service';
import { Team } from '../../Interfaces/app.interfaces'

@Component({
  selector: 'team',
  templateUrl: './team.component.html'
})
export class TeamComponent implements OnInit, OnDestroy {
  public team: Team;
  private sub: any;
  id: number;

  constructor(private route: ActivatedRoute, private teamsService: TeamsService)
  {
  }

  ngOnInit()
  {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number

      this.teamsService.get(this.id).subscribe(result => {
        this.team = result;
      }, error => console.error(error));

    }); 
  }
  ngOnDestroy()
  {
    this.sub.unsubscribe();
  }
}



