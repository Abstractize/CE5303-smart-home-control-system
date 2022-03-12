import axios from 'axios';

const find = (id) =>
    axios.get(`$auth/${id}`);

const get = () =>
    axios.get(`auth`);

const add = (value) =>
    axios.post(`auth`, value);

const update = (id, value) =>
    axios.put(`auth/${id}`, value);

const remove = (id) =>
    axios.delete(`auth/${id}`);

export const authService = { find, get, add, update, remove };
