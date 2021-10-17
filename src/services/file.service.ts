import { CoreService } from './core.service';
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class FileService extends CoreService {
    constructor(http: HttpClient) {
        super(http, 'receivefile')
    }
}
