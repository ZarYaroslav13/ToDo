import {useEffect, useState} from "react";
import { api } from "../../api";

export function useUserDomain(){
    const [user, setUser] = useState({});
    const [errorMessage, setErrorMessage] = useState();
    const [isLoading, setIsLoading] = useState(false);

    async function fetchUserInfo(id) {
        setIsLoading(true);
        try {
            const data = await api.users.getInfo(id);
            setUser(data);
        } catch (error) {
            setErrorMessage("Failed to get user info. Please try again later.");
        } finally {
            setIsLoading(false);
        }
    }

    async function handleUpdate(id, updatedUser) {
        setIsLoading(true);
        try {
            await api.users.update(id, updatedUser);
            await fetchUserInfo();
        } catch (error) {
            setErrorMessage("Failed to update user. Please try again later.");
        } finally {
            setIsLoading(false);
        }
    }

    async function handleUpdatePassword(id, updatedPassword) {
        setIsLoading(true);
        try {
            await api.users.updatePassword(updatedPassword);
            await fetchUserInfo();
        } catch (error) {
            setErrorMessage("Failed to update user password. Please try again later.");
        } finally {
            setIsLoading(false);
        }
    }

    async function handleDelete(id) {
        setIsLoading(true);
        try {
            await api.users.delete(id);
        } catch (error) {
            setErrorMessage("Failed to delete user. Please try again later.");
        } finally {
            setIsLoading(false);
        }
    }

    return {
        isLoading,
        data: user,
        fetch: fetchUserInfo,
        update: handleUpdate,
        updatePassword: handleUpdatePassword,
        delete: handleDelete,
        error: {
            message: errorMessage,
            clear: () => setErrorMessage(),
        },
    };
}