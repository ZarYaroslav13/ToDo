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

    const handleUpdatingUser = async (updatedUser) => {
        try {
            let result = await users.update(updatedUser);

            if (result.succeeded) {
                setUserInfo({...result.data, tasks: userInfo.tasks});
                showSnackbar("Updated successfully user info", "success");
                return result.data;
            }
        } catch (err) {
            console.error(err);
            showSnackbar("Failed to update user info", "error");
        }
        return null;
    };

    const handleUpdatingPassword = async (updatingForm) => {
        try {
            let result = await users.updatePassword(updatingForm);

            if (result) {
                showSnackbar("Updated successfully user info", "success");
                return result.data;
            }
        } catch (err) {
            console.error(err);
            showSnackbar("Failed to update password", "error");
        }

        showSnackbar("Failed to update password", "error");
        return null;
    };

    const addTask = async (newTask) => {
        try {
            const taskToAdd = { ...newTask, userId: auth.user.Id  };
            const createdTask = await tasksApi.create(taskToAdd);
            if (createdTask) {
                showSnackbar("Task added successfully", "success");
                setUserInfo(prev => ({
                    ...prev,
                    tasks: [...(prev?.tasks ?? []), createdTask]
                }));
                return createdTask;
            }
        } catch (err) {
            console.error(err);
            showSnackbar("Failed to add task", "error");
        }
        return null;
    };

    const updateTask = async (updatedTask) => {
        try {
            const result = await tasksApi.update(updatedTask);
            if (result) {
                showSnackbar("Task updated successfully", "success");
                setUserInfo(prev => ({
                    ...prev,
                    tasks: prev.tasks.map(t => t.id === result.id ? result : t)
                }));
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
                setUserInfo(prev => ({
                    ...prev,
                    tasks: prev.tasks.filter(t => t.id !== taskId)
                }));
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
        handleUpdatingUser,
        handleUpdatingPassword,
        updateTask,
        deleteTask,
        addTask,
        showSnackbar
    };
}
