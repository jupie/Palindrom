import {Component} from '@angular/core';
import {RouterOutlet} from '@angular/router';
import {FormsModule} from '@angular/forms';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Eingabe, PalindromeErgebnis, PalindromeReadModel} from './HttpContract';


@Component({
  selector: 'app-root',
  imports: [FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})

export class AppComponent {
  eingabe = 0;
  zyklen = 0;
  berechnet = false;
  ergebnis = 0;
  ergebnisse: PalindromeReadModel[] = [];


  constructor(private httpClient: HttpClient) {
  }

  speichern() {
    let body = {eingabe: this.eingabe};
    this.httpClient.post<Eingabe>("/api/Palindrome",body ).subscribe(res  => {
    alert("erfolgreich gespeichert")
    });
  }

  sendeBerechnung() {
    let params = new HttpParams().set("eingabe", this.eingabe);
    this.httpClient.get<PalindromeErgebnis>("/api/Palindrome/Berechne", {params: params}).subscribe(res  => {
      this.ergebnis = res.palindrome
      this.zyklen = res.zyklen;
      this.berechnet = true;
    });
  }

  gebeAlleAus(){
    this.httpClient.get<PalindromeReadModel[]>("/api/Palindrome/AllePalindrome").subscribe(res  => {
      this.ergebnisse = res;
    });
  }
}
