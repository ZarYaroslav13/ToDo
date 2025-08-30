import styles from "./profile.module.css";
import Snackbar from '@mui/material/Snackbar';
import Alert from '@mui/material/Alert';
import { useProfileViewModel } from "./profileViewModel";
import { TasksTable } from "../tasktable/taskTable";
import { useState, useEffect } from "react";
import { EditTaskDialog } from "../editTaskDialog/editTaskDialog";

export const Profile = () => {
    const { userInfo, snackbarOpen, snackbarMessage, snackbarSeverity, closeSnackbar, updateTask, deleteTask } = useProfileViewModel();

    const [tasks, setTasks] = useState(userInfo?.tasks ?? []);
    const [editingTask, setEditingTask] = useState(null);

    useEffect(() => {
        setTasks(userInfo?.tasks ?? []);
    }, [userInfo?.tasks]);

    const handleEditTask = (task) => setEditingTask(task);

    const handleSaveTask = async (task) => {
        const updatedTask = await updateTask(task);
        if (updatedTask) {
            setTasks(prev => prev.map(t => t.id === updatedTask.id ? updatedTask : t));
            setEditingTask(null);
        }
    };

    const handleDeleteTask = async (id) => {
        const success = await deleteTask(id);
        if (success) {
            setTasks(prev => prev.filter(t => t.id !== id));
        }
    };

    if (!userInfo) return <p>Loading...</p>;

    return (
        <>
            <form className={styles.ProfileForm}>
                <h1>User Profile</h1>

                <section className={styles.UserInfoCard}>
                    <h2>User Info</h2>
                    <p>Name: {userInfo.name} {userInfo.surname}</p>
                    <p>Email: {userInfo.email}</p>
                </section>

                <section className={styles.TasksCard}>
                    <h2>Tasks</h2>
                    <TasksTable
                        tasks={tasks}
                        onDelete={handleDeleteTask}
                        onEdit={handleEditTask}
                        onAdd={() => console.log("add new task")}
                    />

                    {editingTask && (
                        <EditTaskDialog
                            open={!!editingTask}
                            task={editingTask}
                            onClose={() => setEditingTask(null)}
                            onSave={handleSaveTask}
                        />
                    )}
                </section>
            </form>

            <Snackbar
                open={snackbarOpen}
                autoHideDuration={3000}
                onClose={closeSnackbar}
                anchorOrigin={{ vertical: "top", horizontal: "center" }}
            >
                <Alert
                    onClose={closeSnackbar}
                    severity={snackbarSeverity}
                    variant="filled"
                    sx={{ width: '100%' }}
                >
                    {snackbarMessage}
                </Alert>
            </Snackbar>
        </>
    );
};
