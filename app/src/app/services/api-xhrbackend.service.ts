import { Injectable } from '@angular/core';
import { Request, XHRBackend, XHRConnection } from '@angular/http';
import { environment } from './../../environments/environment';

@Injectable()
export class ApiXHRBackendService extends XHRBackend {
    createConnection(request: Request): XHRConnection {
        //if (request.url.startsWith('/')){
        request.url = environment.apiUrl + request.url;     // prefix base url
        //}
        return super.createConnection(request);
    }
}