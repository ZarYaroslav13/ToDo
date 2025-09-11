import {useEffect, useState} from "react";
import { api } from "../../api";

export function useUserDomain(){
    const [user, setUser] = useState({});
    const [errorMessage, setErrorMessage] = useState();
    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {
        localStorage.setItem("user", {user});
    }, [user]);

    async function fetchUserInfo(id) {
        setIsLoading(true);
        try {
            const data = await api.users.getInfo(id);
            setUser(data);

            return data.data;
        } catch (error) {
            setErrorMessage("Failed to get user info. Please try again later.");
        } finally {
            setIsLoading(false);
        }
    }

    async function handleUpdate(updatedUser) {
        setIsLoading(true);
        try {
            let result = await api.users.update(updatedUser);

            if(result.succeeded){
                setUser(result.data);
            }
            return result;
        } catch (error) {
            setErrorMessage("Failed to update user. Please try again later.");
        } finally {
            setIsLoading(false);
        }
    }

    async function handleUpdatePassword(updatedPassword) {
        setIsLoading(true);
        try {
            let result = await api.users.updatePassword(updatedPassword);
            return result.succeeded;
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