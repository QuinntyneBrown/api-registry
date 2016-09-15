import { Action } from "@ngrx/store";
import { API_INFO_ADD_SUCCESS, API_INFO_GET_SUCCESS, API_INFO_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { ApiInfo } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const apiInfosReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case API_INFO_ADD_SUCCESS:
            var entities: Array<ApiInfo> = state.apiInfos;
            var entity: ApiInfo = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { apiInfos: entities });

        case API_INFO_GET_SUCCESS:
            var entities: Array<ApiInfo> = state.apiInfos;
            var newOrExistingApiInfos: Array<ApiInfo> = action.payload;
            for (let i = 0; i < newOrExistingApiInfos.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingApiInfos[i] });
            }                                    
            return Object.assign({}, state, { apiInfos: entities });

        case API_INFO_REMOVE_SUCCESS:
            var entities: Array<ApiInfo> = state.apiInfos;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { apiInfos: entities });

        default:
            return state;
    }
}

