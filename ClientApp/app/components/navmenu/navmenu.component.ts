import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { AuthService } from "../services/auth.service";

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {

    constructor(private http:Http, private authService:AuthService){
        
    }
    sendAuth(){
        this.authService.login("user1","user1psd").then(result=>{
            console.log(result);
            if (result.State == 1) {
                    console.log('was successfuly');
                }
                else {
                    console.log('failed');
                    alert(result.Msg);
                }

        })
    }
}
