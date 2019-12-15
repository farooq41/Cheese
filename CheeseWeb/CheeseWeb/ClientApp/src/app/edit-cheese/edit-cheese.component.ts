import { Component, OnInit } from '@angular/core';
import { HttpRequest, HttpClient, HttpEventType, HttpHeaders } from '@angular/common/http';
import { Cheese } from '../add-cheese/add-cheese.component';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-cheese',
  templateUrl: './edit-cheese.component.html',
  styleUrls: ['./edit-cheese.component.css']
})
export class EditCheeseComponent implements OnInit {

  public cheese:Cheese = {name:"",description:"",price:0, id:0, createddate:null, picture:null};
  public progress: number;
  public message: string;
  
  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) { }
  fileToUpload: File = null;

  ngOnInit() {
    this.cheese = JSON.parse(localStorage.getItem('cheese')).filter(x => x.id == this.route.snapshot.params["id"])[0];
  }

  handleFileInput(files: FileList){
    this.fileToUpload = files.item(0);
  }

  onSubmit(){

  const formData = new FormData();

  formData.append('file', this.fileToUpload, this.fileToUpload.name);
  formData.append("Name", this.cheese.name);
  formData.append("Price", this.cheese.price.toString());
  formData.append("Description", this.cheese.description);

  const headers = 
   new HttpHeaders({ "Accept": "application/json" })


  const uploadReq = new HttpRequest('PUT', `api/cheese/update`, formData, {
    headers,
    reportProgress: true
  });

  this.http.request(uploadReq).subscribe(event => {
    if (event.type === HttpEventType.UploadProgress)
      this.progress = Math.round(100 * event.loaded / event.total);
    else if (event.type === HttpEventType.Response)
      this.message = event.body.toString();


      this.router.navigate(['']);

  }, error => console.error(error));

  }

}
