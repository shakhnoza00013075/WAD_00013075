import { Author } from "./author.model";

export class Book{
    id: number = 0;
    title: string = '';
    description: string = '';
    price: number = 0;
    publisher: string = '';
    author: Author = { id: 0, firstName: '', lastName: '', birthday: new Date()};
    publishedDate: Date = new Date();
}