import { useState, useEffect } from "react";
import { useUserDomain } from "../../hooks/api/users";
import { useTasksDomain } from "../../hooks/api/tasks";
import { useAuth } from "../authprovider/authprovider";

export function useProfileViewModel() {
    const users = useUserDomain();
    const tasks = useTasksDomain();
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
                setUserInfo(data);
                setSnackbarMessage(`Welcome, ${data.name}`);
                setSnackbarSeverity("success");
                setSnackbarOpen(true);
            } catch (err) {
                console.error("Failed to fetch user info:", err);
                setSnackbarMessage("Failed to fetch user info");
                setSnackbarSeverity("error");
                setSnackbarOpen(true);
            }
        };

        const fetchUserTasks = async () => {
            try {
                const data = await tasks.fetch(auth.user.Id);
                setUserInfo((prev) => ({ ...prev, tasks: data }));
            } catch (err) {
                console.error("Failed to fetch user tasks info:", err);
                setSnackbarMessage("Failed to fetch user info");
                setSnackbarSeverity("error");
                setSnackbarOpen(true);
            }
        };

        fetchUser().then(fetchUserTasks);

    }, [auth.user]);

    const closeSnackbar = () => setSnackbarOpen(false);

    const updateTask = async (taskId, updatedTask) => await tasks.update(taskId, updatedTask);

    const deleteTask = async (taskId) => await tasks.delete(taskId);

    return {
        userInfo,
        snackbarOpen,
        snackbarMessage,
        snackbarSeverity,
        closeSnackbar,
        updateTask,
        deleteTask,
    };
}
