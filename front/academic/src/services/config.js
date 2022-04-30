import axios from 'axios'

export const http = axios.create({
    baseURL: 'https://localhost:7226/api/v1'
});