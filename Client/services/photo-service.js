import axios from 'axios';
import { API_URL } from '@env';

const find = (id) =>
    (`${API_URL}photo/${id}`);

const get = () =>
    axios.get(`photo/`);

const add = (value) =>
    axios.post(`photo/`, value);

export const photoService = { find, get, add };