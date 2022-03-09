export const state = {
    data: [],
    error: null
}

export class Door {
    constructor(data = [], error = null){
        this.data = data;
        this.error = error;
    }
}