import { Action } from "@ngrx/store";
import { ADD_API_INFO_SUCCESS, GET_API_INFO_SUCCESS, REMOVE_API_INFO_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { ApiInfo } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const apiInfosReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case ADD_API_INFO_SUCCESS:
            var entities: Array<ApiInfo> = state.apiInfos;
            var entity: ApiInfo = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { apiInfos: entities });

        case GET_API_INFO_SUCCESS:
            var entities: Array<ApiInfo> = state.apiInfos;
            var newOrExistingApiInfos: Array<ApiInfo> = action.payload;
            for (let i = 0; i < newOrExistingApiInfos.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingApiInfos[i] });
            }                                    
            return Object.assign({}, state, { apiInfos: entities });

        case REMOVE_API_INFO_SUCCESS:
            var entities: Array<ApiInfo> = state.apiInfos;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { apiInfos: entities });

        default:
            return state;
    }
}

