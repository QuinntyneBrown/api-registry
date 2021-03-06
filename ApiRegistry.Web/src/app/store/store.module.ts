import { NgModule } from '@angular/core';
import * as ngrxStore from '@ngrx/store';
import { compose } from "@ngrx/core/compose";
import { localStorageSync } from "ngrx-store-localstorage";
import { apiInfosReducer } from "./api-info.reducer";

import { AppStore } from "./app-store";
import { initialState } from "./initial-state";

const providers = [
    AppStore
];

@NgModule({
    imports: [
        ngrxStore.StoreModule.provideStore(
            {
                apiInfos: apiInfosReducer
            },
            [initialState]
        )],
    providers: providers
})
export class StoreModule { }
