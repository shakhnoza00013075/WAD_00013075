import { Component } from '@angular/core';
import { Author } from '../../../models/author.model';
import { AuthorsService } from '../authors.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-authors',
  standalone: true,
  imports: [],
  templateUrl: './authors.component.html',
  styleUrl: './authors.component.css'
})
export class AuthorsComponent {
  authors!: Author[];

  constructor(private service: AuthorsService, private router: Router){}

  ngOnInit(): void{
    this.service.getAll()
      .subscribe(authors => this.authors = authors);
  }
}
