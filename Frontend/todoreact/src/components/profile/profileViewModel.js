import { useState, useEffect } from "react";
import { useUserDomain } from "../../hooks/api/users";
import { useTasksDomain } from "../../hooks/api/tasks";
import { useAuth } from "../authprovider/authProvider";
import {useSnackBar} from "../snackbarProvider/snackbarProvider";


export function useProfileViewModel() {
    const users = useUserDomain();
    const tasksApi = useTasksDomain();
    const auth = useAuth();
    const snackBar = useSnackBar();

    const [userInfo, setUserInfo] = useState(null);

    useEffect(() => {
        if (!auth.user?.Id) return;

        const fetchUser = async () => {
            try {
                const data = await users.fetch(auth.user.Id);
                const userTasks = await tasksApi.fetch(auth.user.Id);
                setUserInfo({ ...data, tasks: userTasks });
                snackBar.showSnackbar(`Welcome, ${data.name}`);
            } catch (err) {
                console.error(err);
                snackBar.showSnackbar("Failed to fetch user info", "error");
            }
        };

        fetchUser();
    }, [auth.user]);

    const handleUpdatingUser = async (updatedUser) => {
        try {
            let result = await users.update(updatedUser);

            if (result.succeeded) {
                setUserInfo({...result.data, tasks: userInfo.tasks});
                snackBar.showSnackbar("Updated successfully user info");
                return result.data;
            }
        } catch (err) {
            console.error(err);
            snackBar.showSnackbar("Failed to update user info", "error");
        }
        return null;
    };

    const handleUpdatingPassword = async (updatingForm) => {
        try {
            let result = await users.updatePassword(updatingForm);

            if (result) {
                snackBar.showSnackbar("Updated successfully user info");
                return result.data;
            }
        } catch (err) {
            console.error(err);
            snackBar.showSnackbar("Failed to update password", "error");
        }

        snackBar.showSnackbar("Failed to update password", "error");
        return null;
    };

    const addTask = async (newTask) => {
        try {
            const taskToAdd = { ...newTask, userId: auth.user.Id  };
            const createdTask = await tasksApi.create(taskToAdd);
            if (createdTask) {
                snackBar.showSnackbar("Task added successfully");
                setUserInfo(prev => ({
                    ...prev,
                    tasks: [...(prev?.tasks ?? []), createdTask]
                }));
                return createdTask;
            }
        } catch (err) {
            console.error(err);
            snackBar.showSnackbar("Failed to add task", "error");
        }
        return null;
    };

    const updateTask = async (updatedTask) => {
        try {
            const result = await tasksApi.update(updatedTask);
            if (result) {
                snackBar.showSnackbar("Task updated successfully",);
                setUserInfo(prev => ({
                    ...prev,
                    tasks: prev.tasks.map(t => t.id === result.id ? result : t)
                }));
                return result;
            }
        } catch (err) {
            console.error(err);
            snackBar.showSnackbar("Failed to update task", "error");
        }
        return null;
    };

    const deleteTask = async (taskId) => {
        try {
            const result = await tasksApi.delete(taskId);
            if (result?.succeeded) {
                snackBar.showSnackbar("Task deleted successfully");
                setUserInfo(prev => ({
                    ...prev,
                    tasks: prev.tasks.filter(t => t.id !== taskId)
                }));
                return true;
            }
        } catch (err) {
            console.error(err);
            snackBar.showSnackbar("Failed to delete task", "error");
        }
        return false;
    };

    return {
        userInfo,

        handleUpdatingUser,
        handleUpdatingPassword,
        updateTask,
        deleteTask,
        addTask
    };
}
