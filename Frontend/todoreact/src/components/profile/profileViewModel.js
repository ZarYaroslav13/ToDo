import { useState, useEffect } from "react";
import { useUserDomain } from "../../hooks/api/users";
import { useTasksDomain } from "../../hooks/api/tasks";
import { useAuth } from "../authprovider/authprovider";

export function useProfileViewModel() {
    const users = useUserDomain();
    const tasksApi = useTasksDomain();
    const auth = useAuth();

    const [userInfo, setUserInfo] = useState(null);
    const [snackbarOpen, setSnackbarOpen] = useState(false);
    const [snackbarMessage, setSnackbarMessage] = useState("");
    const [snackbarSeverity, setSnackbarSeverity] = useState("success");

    useEffect(() => {
        if (!auth.user?.Id) return;

        const fetchUser = async () => {
            try {
                const data = await users.fetch(auth.user.Id);
                const userTasks = await tasksApi.fetch(auth.user.Id);
                setUserInfo({ ...data, tasks: userTasks });
                showSnackbar(`Welcome, ${data.name}`, "success");
            } catch (err) {
                console.error(err);
                showSnackbar("Failed to fetch user info", "error");
            }
        };

        fetchUser();
    }, [auth.user]);

    const showSnackbar = (message, severity = "success") => {
        setSnackbarMessage(message);
        setSnackbarSeverity(severity);
        setSnackbarOpen(true);
    };

    const closeSnackbar = () => setSnackbarOpen(false);

    const updateTask = async (updatedTask) => {
        try {
            const result = await tasksApi.update(updatedTask);
            if (result) {
                showSnackbar("Task updated successfully", "success");
                return result;
            }
        } catch (err) {
            console.error(err);
            showSnackbar("Failed to update task", "error");
        }
        return null;
    };

    const deleteTask = async (taskId) => {
        try {
            const result = await tasksApi.delete(taskId);
            if (result?.succeeded) {
                showSnackbar("Task deleted successfully", "success");
                return true;
            }
        } catch (err) {
            console.error(err);
            showSnackbar("Failed to delete task", "error");
        }
        return false;
    };

    return {
        userInfo,
        snackbarOpen,
        snackbarMessage,
        snackbarSeverity,
        closeSnackbar,
        updateTask,
        deleteTask,
        showSnackbar
    };
}
