import axios from 'axios';
import { API_URL } from '@env';

const find = (id) =>
    (`${API_URL}photo${id}`);

const get = () =>
    axios.get(`${API_URL}photo/`);

const add = (value) =>
    axios.post(`${API_URL}photo/`, value);

export const photoService = { find, get, add };