import { useState } from "react";
import { api } from "../../api";
import { jwtDecode } from "jwt-decode";

export function useAuthorization() {
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    async function login(credentials) {
        setLoading(true);
        setError(null);
        try {
            const result = await api.authorization.login(credentials);

            localStorage.setItem("token", result.data.data);

            const decoded = jwtDecode(result.data.data);


            return decoded;
        } catch (err) {
            setError(err.response?.data?.message || "Login failed");
            throw err;
        } finally {
            setLoading(false);
        }
    }

    async function register(data) {
        setLoading(true);
        setError(null);
        try {
            return await api.authorization.register(data);
        } catch (err) {
            setError(err.response?.data?.message || "Register failed");
            throw err;
        } finally {
            setLoading(false);
        }
    }

    function logout() {
        localStorage.removeItem("token");
    }

    return { login, register, logout, loading, error };
}
