import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PeopleService } from '../../Services/people/people.service';
import { Person } from '../../Interfaces/person.interface'

@Component({
  selector: 'person',
  templateUrl: './person.component.html'
})
export class PersonComponent implements OnInit, OnDestroy {
  public person: Person;
  private sub: any;
  id: number;

  constructor(private route: ActivatedRoute, private peopleService: PeopleService)
  {
  }

  ngOnInit()
  {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number
      
      this.peopleService.get(this.id).subscribe(result => {
        this.person = result;
      }, error => console.error(error));

    }); 
  }
  ngOnDestroy()
  {
    this.sub.unsubscribe();
  }
}




