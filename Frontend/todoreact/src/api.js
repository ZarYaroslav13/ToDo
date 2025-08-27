import axios from "axios";

const http = axios.create({
    baseURL: import.meta.env.API_BASE_URL,
    headers: {"content-type": "application/json"},
    timeout: 5000,
});

http.interceptors.response.use(({ data}) => data);

export const api = {
    authorization:{
        register(data){
            return http
                .post("authorization/register", data);
        },

        login(data){
            return http.post("authorization/login", data);
        }
    },

    users: {
        getInfo(id){
            return http.get(`users/${id}`);
        },

        update(id, data){
            return http.put(`users/${id}`, data);
        },

        updatePassword(data){
            return http.put("users/update-user-password", data);
        },

        delete(id){
            return http.delete(`users/${id}`);
        }
    },

    tasks:{
        getUserTasks(id){
            return http.get(`tasks/users/${id}`);
        },

        create(data){
            return http.post(`tasks/task`, data);
        },

        update(id, data) {
            return http.put(`tasks/${id}`, data);
        },

        delete(id){
            return http.delete(`tasks/${id}`);
        }
    },
};