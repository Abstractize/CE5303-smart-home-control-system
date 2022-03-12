import axios from 'axios';

const url = "https://localhost:5000/photo";

function find(id) {
    return (`${url}/${id}`);
}
function get() {
    return axios.get(url);
}
function add(value) {
    return axios.post(url, value);
}

export const photoService = {find, get, add};