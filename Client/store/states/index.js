import { Auth } from "./auth-state";

export class ApplicationState {
    constructor(auth = new Auth()) {
        this.auth = auth
    }
}