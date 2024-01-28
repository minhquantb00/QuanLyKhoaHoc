import axios from 'axios'
import { defineStore } from 'pinia'

export const authApi = defineStore('authApi', {
    actions:{
        login(params){
            return new Promise((resolve, reject) => {
                axios.post('/auth/DangNhap', {...params})
                    .then(res => resolve(res))
                    .catch(error => reject(error))
            })
        }
    }
})