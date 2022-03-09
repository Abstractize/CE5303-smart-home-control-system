export const state = {
    isLoading: false,
    user: null,
    error: null
};

export class Auth {
    constructor(isLoading = false, user = null, error = null){
        this.isLoading = isLoading;
        this.user = user;
        this.error = error;
    }
}