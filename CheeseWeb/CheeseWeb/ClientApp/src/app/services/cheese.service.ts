import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CheeseService {
  constructor() { }
  private _user: any;
  public getCheese(): any {
    return this._user;
  }
  public setCheese(value: any) {
    this._user = value;
  }
}
