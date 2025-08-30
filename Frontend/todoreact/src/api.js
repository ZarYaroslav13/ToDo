import axios from "axios";

const authHttp = axios.create({
    baseURL: `${process.env.REACT_APP_API_BASE_URL}authorization`,
    headers: {
        "content-type": "application/json"},
    timeout: 5000,
});

const http = axios.create({
    baseURL: process.env.REACT_APP_API_BASE_URL,
    headers: {
        "Content-Type": "application/json"},
    timeout: 5000,
});

http.interceptors.request.use((config) => {
    const token = localStorage.getItem("token");
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});

http.interceptors.response.use(({ data}) => data);

export const api = {
    authorization:{
        register(data){
            return authHttp
                .post("register", data);
        },

        async login(data){
            const result = await authHttp.post("login", data);

            return result;
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

        async delete(id){
            const result = await  http.delete(`users/${id}`);

            if(result.status === 200){
                localStorage.removeItem("token");
            }

            return result;
        }
    },

    tasks:{
        getUserTasks(userId){
            return http.get(`tasks/users/${userId}`);
        },

        getUserTask(id){
            return http.get(`tasks/${id}`);
        },

        create(data){
            return http.post(`tasks`, data);
        },

        update(id, data) {
            return http.put(`tasks/${id}`, data);
        },

        delete(id){
            return http.delete(`tasks/${id}`);
        }
    },
};