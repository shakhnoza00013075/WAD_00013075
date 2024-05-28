import { Component } from '@angular/core';
import { Author } from '../../../models/author.model';
import { AuthorsService } from '../authors.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-create-author',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './create-author.component.html',
  styleUrl: './create-author.component.css'
})
export class CreateAuthorComponent {
  author: Author = {
    id: 0,
    firstName: '',
    lastName: '',
    birthday: new Date()
  };

  constructor(private service: AuthorsService, private router: Router){}

  create(author: Author){
    this.service.add(author)
      .subscribe(
        response => {
          this.router.navigate(['/authors']);
        }
      )
  }
}
