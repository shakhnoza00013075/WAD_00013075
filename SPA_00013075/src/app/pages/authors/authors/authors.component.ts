import { Component, OnInit } from '@angular/core';
import { Author } from '../../../models/author.model';
import { AuthorsService } from '../authors.service';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-authors',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './authors.component.html',
  styleUrl: './authors.component.css'
})
export class AuthorsComponent implements OnInit {
  authors!: Author[];

  constructor(private service: AuthorsService, private router: Router){}

  ngOnInit(): void{
    this.service.getAll()
      .subscribe(authors => this.authors = authors);
  }

  delete(id: number): void{
    this.service.delete(id).subscribe(
      response => {
        window.location.reload();
      }
    );
  }
}
