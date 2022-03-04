import axios from 'axios';

const url = "https://localhost:5000/auth";

function find(id) {
    return axios.get(`${url}/${id}`);
}
function get() {
    return axios.get(url);
}
function add(value) {
    return axios.post(url, value);
}
function update(value) {
    return axios.put(url, value);
}
function remove(value) {
    return axios.delete(url, value);
}

export const authService = {find, get, add, update, remove};
