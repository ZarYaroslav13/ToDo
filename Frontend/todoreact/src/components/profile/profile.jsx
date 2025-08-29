import styles from "./profile.module.css";
import Snackbar from '@mui/material/Snackbar';
import Alert from '@mui/material/Alert';
import { useProfileViewModel } from "./profileViewModel";

export const Profile = () => {
    const {
        userInfo,
        snackbarOpen,
        snackbarMessage,
        snackbarSeverity,
        closeSnackbar
    } = useProfileViewModel();

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
                    <ul>
                        {userInfo.tasks.map((task, index) => (
                            <li key={task.id ?? index}>{task.title ?? task}</li>
                        ))}
                    </ul>
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
