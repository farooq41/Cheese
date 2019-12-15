import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Cheese } from '../add-cheese/add-cheese.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

cheeseCollection: Cheese[];
cheeseStorage: Cheese[];

  constructor(private route: ActivatedRoute, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) { }

  ngOnInit() {
    this.getCheese(); // Get all cheese    
  }

  getCheese(){
    const httpOptions = {

      headers: new HttpHeaders({

          'Content-Type': 'application/json'

      })
    };
    this.http.get<any>(this.baseUrl + 'api/cheese/allCheese',httpOptions).subscribe(result => {

      result.forEach((cheese)=>{
        cheese.image = 'data:image/png;base64,' + cheese.picture.picture; // use this in <img src="..."> binding
        var newCheese = {description:cheese.description, id:cheese.id, name:cheese.name, picture:null,createddate:null,price:cheese.price};
        this.cheeseStorage.push(newCheese);
      })

      this.cheeseCollection = result;
      localStorage.setItem('cheese', JSON.stringify(this.cheeseStorage)); // add the user to local storage

  }, error => console.error(error));
  }
  onCheeseEdit(id){
    this.router.navigate(['/editcheese/'+id]);
  }

  onDeleteCheese(id:number){
    const httpOptions = {

      headers: new HttpHeaders({

          'Content-Type': 'application/json'

      })
    };
    this.http.get<any>(this.baseUrl + 'api/cheese/delete/' + id,httpOptions).subscribe(result => {

      this.getCheese();

  }, error => console.error(error));
  }

}
