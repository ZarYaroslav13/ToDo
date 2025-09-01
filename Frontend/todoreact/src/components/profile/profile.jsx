import styles from "./profile.module.css";
import Snackbar from '@mui/material/Snackbar';
import Alert from '@mui/material/Alert';
import { useProfileViewModel } from "./profileViewModel";
import { TasksTable } from "../tasktable/taskTable";
import { useState, useEffect } from "react";
import { EditTaskDialog } from "../editTaskDialog/editTaskDialog";
import { AddTaskDialog } from "../addTaskDialog/addTaskDialog";
import { UserInfo } from "../userInfo/userInfo";

export const Profile = () => {
    const viewModel = useProfileViewModel();

    const [tasks, setTasks] = useState(viewModel.userInfo?.tasks ?? []);
    const [editingTask, setEditingTask] = useState(null);
    const [addingTask, setAddingTask] = useState(false);

    useEffect(() => {
        setTasks(viewModel.userInfo?.tasks ?? []);
    }, [viewModel.userInfo?.tasks]);

    const handleEditTask = (task) => setEditingTask(task);
    const handleAddTask = () => setAddingTask(true);

    const handleSaveTask = async (task) => {
        const updated = await viewModel.updateTask(task);
        if (updated) setEditingTask(null);
    };

    const handleAddNewTask = async (task) => {
        const created = await viewModel.addTask(task);
        if (created) setAddingTask(false);
    };

    if (!viewModel.userInfo) return <p>Loading...</p>;

    return (
        <>
            <form className={styles.ProfileForm}>
                <h1>User Profile</h1>

                <UserInfo userInfo={viewModel.userInfo} />

                <section className={styles.TasksCard}>
                    <h2>Tasks</h2>
                    <TasksTable
                        tasks={tasks}
                        onAdd={handleAddTask}
                        onEdit={handleEditTask}
                        onDelete={viewModel.deleteTask}
                    />

                    {addingTask && (
                        <AddTaskDialog
                            open={addingTask}
                            onClose={() => setAddingTask(false)}
                            onSave={handleAddNewTask}
                        />
                    )}

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
                open={viewModel.snackbarOpen}
                autoHideDuration={3000}
                onClose={viewModel.closeSnackbar}
                anchorOrigin={{ vertical: "top", horizontal: "center" }}
            >
                <Alert
                    onClose={viewModel.closeSnackbar}
                    severity={viewModel.snackbarSeverity}
                    variant="filled"
                    sx={{ width: '100%' }}
                >
                    {viewModel.snackbarMessage}
                </Alert>
            </Snackbar>
        </>
    );
};
