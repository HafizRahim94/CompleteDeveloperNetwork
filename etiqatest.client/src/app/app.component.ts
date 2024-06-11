import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { WeatherForecast, WeatherForecastService } from '../api';

// interface WeatherForecast {
//   date: string;
//   temperatureC: number;
//   temperatureF: number;
//   summary: string;
// }

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public forecasts!: WeatherForecast[];

  constructor(private http: HttpClient, private weatherForecastService :WeatherForecastService) {}

  ngOnInit() {
    this.weatherForecastService.getWeatherForecast().subscribe((data : WeatherForecast[]) => this.forecasts = data);
  }
}
