import styles from "./profile.module.css";
import Snackbar from '@mui/material/Snackbar';
import Alert from '@mui/material/Alert';
import { useProfileViewModel } from "./profileViewModel";
import { TasksTable } from "../tasktable/taskTable";
import { useState, useEffect } from "react";
import { EditTaskDialog } from "../editTaskDialog/editTaskDialog";
import { AddTaskDialog } from "../addTaskDialog/addTaskDialog";

export const Profile = () => {
    const {
        userInfo,
        snackbarOpen,
        snackbarMessage,
        snackbarSeverity,
        closeSnackbar,
        updateTask,
        deleteTask,
        addTask
    } = useProfileViewModel();

    const [tasks, setTasks] = useState(userInfo?.tasks ?? []);
    const [editingTask, setEditingTask] = useState(null);
    const [addingTask, setAddingTask] = useState(false);

    useEffect(() => {
        setTasks(userInfo?.tasks ?? []);
    }, [userInfo?.tasks]);

    const handleEditTask = (task) => setEditingTask(task);
    const handleAddTask = () => setAddingTask(true);

    const handleSaveTask = async (task) => {
        const updated = await updateTask(task);
        if (updated) setEditingTask(null);
    };

    const handleAddNewTask = async (task) => {
        const created = await addTask(task);
        if (created) setAddingTask(false);
    };

    const handleDeleteTask = async (id) => {
        await deleteTask(id);
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
                        onAdd={handleAddTask}
                    />

                    {editingTask && (
                        <EditTaskDialog
                            open={!!editingTask}
                            task={editingTask}
                            onClose={() => setEditingTask(null)}
                            onSave={handleSaveTask}
                        />
                    )}

                    {addingTask && (
                        <AddTaskDialog
                            open={addingTask}
                            onClose={() => setAddingTask(false)}
                            onSave={handleAddNewTask}
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
