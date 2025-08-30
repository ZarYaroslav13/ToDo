import styles from "./profile.module.css";
import Snackbar from '@mui/material/Snackbar';
import Alert from '@mui/material/Alert';
import { useProfileViewModel } from "./profileViewModel";
import { TasksTable } from "../tasktable/taskTable";
import { useState, useEffect } from "react";

export const Profile = () => {
    const {
        userInfo,
        snackbarOpen,
        snackbarMessage,
        snackbarSeverity,
        closeSnackbar,
        deleteTask,
    } = useProfileViewModel();

    // Local state for tasks to allow immediate UI updates
    const [tasks, setTasks] = useState(userInfo?.tasks ?? []);

    useEffect(() => {
        setTasks(userInfo?.tasks ?? []);
    }, [userInfo?.tasks]);

    // Handle delete
    const handleDeleteTask = async (id) => {
        const result = await deleteTask(id);

        if (result.succeeded) {
            setTasks(prev => prev.filter(task => task.id !== id));
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
                        onEdit={(task) => console.log("edit", task)}
                        onAdd={() => console.log("add new task")}
                    />
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
