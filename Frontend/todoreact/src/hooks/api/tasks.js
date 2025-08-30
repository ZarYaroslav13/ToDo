import { useState } from "react";
import { api } from "../../api";

export function useTasksDomain() {
    const [tasks, setTasks] = useState([]);
    const [errorMessage, setErrorMessage] = useState(null);
    const [isLoading, setIsLoading] = useState(false);

    // ---- API MAPPERS ----
    function convertPriorityFromApi(priority) {
        switch (priority) {
            case 0: return "none";
            case 1: return "low";
            case 2: return "medium";
            case 3: return "high";
            default: return "none";
        }
    }

    function convertPriorityToApi(priority) {
        switch (priority) {
            case "low": return 1;
            case "medium": return 2;
            case "high": return 3;
            default: return 0;
        }
    }

    function mapTaskFromApi(task) {
        return { ...task, priority: convertPriorityFromApi(task.priority) };
    }

    // ---- CRUD ----
    async function fetchUserTasks(userId) {
        setIsLoading(true);
        setErrorMessage(null);
        try {
            const response = await api.tasks.getUserTasks(userId);
            const mapped = response.data.map(mapTaskFromApi);
            setTasks(mapped);
            return mapped;
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
            const payload = { ...createData, priority: convertPriorityToApi(createData.priority) };
            const response = await api.tasks.create(payload);
            const newTask = mapTaskFromApi(response.data);
            setTasks(prev => [...prev, newTask]);
            return newTask;
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
            const payload = { ...updatedData, priority: convertPriorityToApi(updatedData.priority) };
            const response = await api.tasks.update(taskId, payload);
            const updatedTask = mapTaskFromApi(response.data);
            setTasks(prev => prev.map(t => t.id === taskId ? updatedTask : t));
            return updatedTask;
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
            setTasks(prev => prev.filter(t => t.id !== taskId));
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
