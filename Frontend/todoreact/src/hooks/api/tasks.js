import { useState } from "react";
import { api } from "../../api";

export function useTasksDomain() {
    const [tasks, setTasks] = useState([]);
    const [errorMessage, setErrorMessage] = useState(null);
    const [isLoading, setIsLoading] = useState(false);

    async function fetchUserTasks(userId) {
        setIsLoading(true);
        setErrorMessage(null);
        try {
            const response = await api.tasks.getUserTasks(userId);
            setTasks(response.data);
            return response.data;
        } catch (error) {
            setErrorMessage("Failed to get tasks. Please try again later.");
        } finally {
            setIsLoading(false);
        }
    }

    async function handleCreation(createData) {
        setIsLoading(true);
        setErrorMessage(null);
        try {
            const response = await api.tasks.create(createData);
            setTasks(prev => [...prev, response.data]); // add created task
            return response.data;
        } catch (error) {
            setErrorMessage("Failed to create task. Please try again later.");
        } finally {
            setIsLoading(false);
        }
    }

    async function handleUpdate(taskId, updatedData) {
        setIsLoading(true);
        setErrorMessage(null);
        try {
            const response = await api.tasks.update(taskId, updatedData);
            setTasks(prev => prev.map(t => t.id === taskId ? response.data : t)); // update task locally
            return response.data;
        } catch (error) {
            setErrorMessage("Failed to update task. Please try again later.");
        } finally {
            setIsLoading(false);
        }
    }

    async function handleDelete(taskId) {
        setIsLoading(true);
        setErrorMessage(null);
        try {
            await api.tasks.delete(taskId);
            setTasks(prev => prev.filter(t => t.id !== taskId)); // remove task locally
        } catch (error) {
            setErrorMessage("Failed to delete task. Please try again later.");
        } finally {
            setIsLoading(false);
        }
    }

    return {
        isLoading,
        data: tasks,
        fetch: fetchUserTasks,
        create: handleCreation,
        update: handleUpdate,
        delete: handleDelete,
        error: {
            message: errorMessage,
            clear: () => setErrorMessage(null),
        },
    };
}
