import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { User } from './userModel.component';

@Component({
    selector: 'user',
    templateUrl: './user.component.html',
    styleUrls: ['./user.component.css']
})

export class userDataComponent {
    public users: User[];

    constructor(http: Http) {
        http.get('/api/UserData/getAllUsers').subscribe(result => {
            this.users = result.json() as User[];
        });
    }
}

