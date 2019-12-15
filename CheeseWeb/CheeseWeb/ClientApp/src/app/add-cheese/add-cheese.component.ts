import { Component, OnInit } from '@angular/core';
import { HttpRequest, HttpClient, HttpEventType, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-cheese',
  templateUrl: './add-cheese.component.html',
  styleUrls: ['./add-cheese.component.css']
})
export class AddCheeseComponent implements OnInit {

  public cheese:Cheese = {name:"",description:"",price:0, id:0, createddate:null, picture:null};
  public progress: number;
  public message: string;
  
  constructor(private http: HttpClient, private router: Router) { }
  fileToUpload: File = null;
  ngOnInit() {
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


  const uploadReq = new HttpRequest('POST', `api/cheese/create`, formData, {
    headers,
    reportProgress: true
  });

  this.http.request(uploadReq).subscribe(event => {
    if (event.type === HttpEventType.UploadProgress)
      this.progress = Math.round(100 * event.loaded / event.total);
    else if (event.type === HttpEventType.Response)
      this.message = event.body.toString();

      this.router.navigate(['']);
  });

  }
}

export class Cheese{
  id:number;
  name:string;
  description:string
  price:number;
  createddate:Date
  picture:CheesePicture;
  
}

export class CheesePicture{
  id:number;
  picture: any;
}
