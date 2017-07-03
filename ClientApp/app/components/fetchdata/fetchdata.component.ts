import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { AuthService } from '../services/auth.service';


@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public forecasts: WeatherForecast[];

    constructor(http: Http, private authService: AuthService) {
        http.get('/api/SampleData/WeatherForecasts').subscribe(result => {
            this.forecasts = result.json() as WeatherForecast[];
        });

        console.log('on init was successful');
        let result = this.authService.authGet('/api/auth');
        result.then(x=> console.log(x));
        if(result){
            console.log('the result existed!');
            console.log(result);
        }
        else{
            console.log('everything sucks');
        }
    }
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}
