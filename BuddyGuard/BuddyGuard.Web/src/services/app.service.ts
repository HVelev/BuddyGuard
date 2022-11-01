import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AppService {
  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
  }

  public getWeatherForecast(): Observable<string> {
    return this.http.get('/WeatherForecast/GetWeather', { responseType: 'text' });
  }
}
