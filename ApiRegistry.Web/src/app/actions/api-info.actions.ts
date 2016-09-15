import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { ApiInfoService } from "../services";
import { AppState, AppStore } from "../store";
import { ADD_API_INFO_SUCCESS, GET_API_INFO_SUCCESS, REMOVE_API_INFO_SUCCESS } from "../constants";
import { ApiInfo } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class ApiInfoActions {
    constructor(private _apiInfoService: ApiInfoService, private _store: AppStore) { }

    public add(apiInfo: ApiInfo) {
        const newGuid = guid();
        this._apiInfoService.add(apiInfo)
            .subscribe(book => {
                this._store.dispatch({
                    type: ADD_API_INFO_SUCCESS,
                    payload: apiInfo
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._apiInfoService.get()
            .subscribe(apiInfos => {
                this._store.dispatch({
                    type: GET_API_INFO_SUCCESS,
                    payload: apiInfos
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._apiInfoService.remove({ id: options.id })
            .subscribe(apiInfo => {
                this._store.dispatch({
                    type: REMOVE_API_INFO_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._apiInfoService.getById({ id: options.id })
            .subscribe(apiInfo => {
                this._store.dispatch({
                    type: GET_API_INFO_SUCCESS,
                    payload: [apiInfo]
                });
                return true;
            });
    }
}
