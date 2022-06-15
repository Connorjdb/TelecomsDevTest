import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html'
})
export class MembersComponent {
  public members: Member[] = [];
  public checkInResult: boolean | undefined;

  private _client: HttpClient;
  private _baseURL: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Member[]>(baseUrl + 'member').subscribe(result => {
      this.members = result;
    }, error => console.error(error));

    this._client = http;
    this._baseURL = baseUrl;
  }

  deleteMember(id: string): void {
    this._client.delete<Member[]>(this._baseURL + 'member/' + id).subscribe(result => {
      this.members = result;
    }, error => console.error(error));
  }

  checkInMember(id: string): void {
    this._client.get<boolean>(this._baseURL + 'member/checkin/' + id).subscribe(result => {
      this.checkInResult = result;
    }, error => console.error(error));
  }
}

interface Member {
  id: string;
  membershipNumber: number;
  firstName: string;
  surname: string;
  dateOfBirth: Date;
  membershipType: string;
  accessCode: string;
}
