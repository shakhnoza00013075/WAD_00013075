import { Routes } from '@angular/router';
import { AuthorsComponent } from './pages/authors/authors/authors.component';
import { CreateAuthorComponent } from './pages/authors/create-author/create-author.component';
import { EditAuthorComponent } from './pages/authors/edit-author/edit-author.component';

export const routes: Routes = [
    {
        path: 'authors',
        component: AuthorsComponent
    },
    {
        path: 'create-author',
        component: CreateAuthorComponent
    },
    {
        path: 'edit-author/:id',
        component: EditAuthorComponent
    }
];
