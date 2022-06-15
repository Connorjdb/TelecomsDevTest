import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html'
})
export class MembersComponent {
  public members: Member[] = [];
  public checkInResult: boolean | undefined;
  public qrBase64: SafeResourceUrl | undefined;

  private _client: HttpClient;
  private _baseURL: string;
  private _sanitizer: DomSanitizer;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, sanitizer: DomSanitizer) {
    http.get<Member[]>(baseUrl + 'member').subscribe(result => {
      this.members = result;
    }, error => console.error(error));

    this._client = http;
    this._baseURL = baseUrl;
    this._sanitizer = sanitizer;
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

  loadQr(id: string): void {
    this._client.get(this._baseURL + 'member/qr/' + id, {responseType: 'text'}).subscribe(result => {
      this.qrBase64 = this._sanitizer.bypassSecurityTrustResourceUrl('data:image/jpg;base64,' + result);
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
