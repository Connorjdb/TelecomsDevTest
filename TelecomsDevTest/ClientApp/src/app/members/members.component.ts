import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html'
})
export class MembersComponent {
  public members: Member[] = [];

  private _client: HttpClient;
  private _baseURL: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Member[]>(baseUrl + 'member').subscribe(result => {
      this.members = result;
    }, error => console.error(error));

    this._client = http;
    this._baseURL = baseUrl;
  }
}

interface Member {
  id: string;
  membershipNumber: number;
  firstName: string;
  surname: string;
  dateOfBirth: Date;
}
