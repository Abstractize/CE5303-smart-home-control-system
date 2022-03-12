import axios from 'axios';
import { API_URL } from '@env';

const find = (id) =>
    axios.get(`${API_URL}${id}`);

const get = () =>
    axios.get(API_URL);

const add = (value) =>
    axios.post(API_URL, value);

const update = (value) =>
    axios.put(API_URL, value);

const remove = (value) =>
    axios.delete(API_URL, value);

export const authService = { find, get, add, update, remove };
