import { useState } from "react";
import { api } from "../../api";
import { Priority, PriorityFunctions } from "../../enums/priority"; // adjust path if needed

export function useTasksDomain() {
    const [tasks, setTasks] = useState([]);
    const [errorMessage, setErrorMessage] = useState(null);
    const [isLoading, setIsLoading] = useState(false);

    async function fetchUserTasks(userId) {
        setIsLoading(true);
        setErrorMessage(null);
        try {
            const response = await api.tasks.getUserTasks(userId);

            const mapped = response.data.map(task => ({
                ...task,
                priority: PriorityFunctions.fromValue(task.priority),
            }));

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
            // convert priority to numeric before API call
            const payload = {
                ...createData,
                priority: PriorityFunctions.toValue(createData.priority),
            };

            const response = await api.tasks.create(payload);

            const created = {
                ...response.data,
                priority: PriorityFunctions.fromValue(response.data.priority),
            };

            setTasks(prev => [...prev, created]);
            return created;
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
            const payload = {
                ...updatedData,
                priority: PriorityFunctions.toValue(updatedData.priority),
            };

            const response = await api.tasks.update(taskId, payload);

            const updated = {
                ...response.data,
                priority: PriorityFunctions.fromValue(response.data.priority),
            };

            setTasks(prev => prev.map(t => t.id === taskId ? updated : t));
            return updated;
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
