import { ApiInfo } from "../models";

export interface AppState {
    apiInfos: Array<ApiInfo>;
	currentUser: any;
    isLoggedIn: boolean;
    token: string;
}
