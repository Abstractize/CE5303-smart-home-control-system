import { AuthActionType } from "../action-types/auth-action-types";

class AuthAction {
    constructor(type){
        this.type = type;
    }
}

export class FailureAuthAction extends AuthAction {
    constructor(error){
        this.error = error;
        super(AuthActionType.SUCCESS);
    }
}

export class SuccessAuthAction extends AuthAction {
    constructor(user){
        this.user = user;
        super(AuthActionType.SUCCESS);
    }
}

export class LoginAuthAction extends AuthAction {
    constructor(){
        super(AuthActionType.SUCCESS);
    }
}
