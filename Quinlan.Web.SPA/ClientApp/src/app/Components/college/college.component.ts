import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CollegesService } from '../../Services/colleges/colleges.service';
import { College } from '../../Interfaces/app.interfaces'

@Component({
  selector: 'college',
  templateUrl: './college.component.html'
})
export class CollegeComponent implements OnInit, OnDestroy {
  public college: College;
  private sub: any;
  id: number;

  constructor(private route: ActivatedRoute, private collegesService: CollegesService)
  {
  }

  ngOnInit()
  {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number

      this.collegesService.get(this.id).subscribe(result => {
        this.college = result;
      }, error => console.error(error));

    }); 
  }
  ngOnDestroy()
  {
    this.sub.unsubscribe();
  }
}



