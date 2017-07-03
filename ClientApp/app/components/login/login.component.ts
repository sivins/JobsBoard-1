import { Component, AfterViewInit } from '@angular/core';
import * as $ from 'jquery';


@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})
export class LoginComponent implements AfterViewInit{

    constructor(){

    }

    ngAfterViewInit(){
        $('#login-form-link').click(function(e) {
		$("#login-form").delay(100).fadeIn(100);
 		$("#register-form").fadeOut(100);
		$('#register-form-link').removeClass('active');
		$(this).addClass('active');
		e.preventDefault();
	});
	$('#register-form-link').click(function(e) {
		$("#register-form").delay(100).fadeIn(100);
 		$("#login-form").fadeOut(100);
		$('#login-form-link').removeClass('active');
		$(this).addClass('active');
		e.preventDefault();
	});
    }

}
