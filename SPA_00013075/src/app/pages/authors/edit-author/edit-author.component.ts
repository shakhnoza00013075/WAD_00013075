import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Author } from '../../../models/author.model';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthorsService } from '../authors.service';

@Component({
  selector: 'app-edit-author',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './edit-author.component.html',
  styleUrl: './edit-author.component.css'
})
export class EditAuthorComponent implements OnInit {
  author: Author = {
    id: 0,
    firstName: '',
    lastName: '',
    birthday: new Date()
  };

  id = 0;

  constructor(private service: AuthorsService, private router: Router, private route: ActivatedRoute){}

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    this.id = idParam ? + idParam : 0; 
    console.log(this.id);
    this.get(this.id);  
  }

  edit(author: Author){
    this.service.edit(this.id, author)
      .subscribe(
        response => {
          this.router.navigate(['/authors']);
        }
      )
  }

  get(id: number): void {
    this.service.get(id)
      .subscribe(author => {
        this.author = author;
      });
  }
}
