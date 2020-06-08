import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SportsService } from '../../Services/sports/sports.service';
import { Sport } from '../../Interfaces/app.interfaces'

@Component({
  selector: 'sport',
  templateUrl: './sport.component.html'
})
export class SportComponent implements OnInit, OnDestroy {
  public sport: Sport;
  private sub: any;
  id: number;

  constructor(private route: ActivatedRoute, private sportsService: SportsService)
  {
  }

  ngOnInit()
  {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number

      this.sportsService.get(this.id).subscribe(result => {
        this.sport = result;
      }, error => console.error(error));

    }); 
  }
  ngOnDestroy()
  {
    this.sub.unsubscribe();
  }
}



