import styles from "./profile.module.css";
import { useState, useEffect } from "react";
import { useUserDomain } from "../../hooks/api/users";
import Snackbar from '@mui/material/Snackbar';
import { useAuth } from "../authprovider/authprovider";
import Alert from '@mui/material/Alert';

export const Profile = () => {
    const [snackbarOpen, setSnackbarOpen] = useState(true);
    const [snackbarMessage, setSnackbarMessage] = useState("");
    const users = useUserDomain();
    const auth = useAuth();
    const [userInfo, setUserInfo] = useState(null);

    useEffect(() => {
        if (!auth.user?.Id) return;

        const fetchUser = async () => {
            try {
                const data = await users.fetch(auth.user.Id);
                setUserInfo(data);
                setSnackbarMessage(`Welcome, ${data.name}`);
                setSnackbarOpen(true);
            } catch (err) {
                console.error("Failed to fetch user info:", err);
                setSnackbarMessage("Failed to fetch user info");
                setSnackbarOpen(true);
            }
        };

        fetchUser();
    }, [auth.user]);

    const handleCloseSnackbar = (_, reason) => {
        if (reason === 'clickaway') return;
        setSnackbarOpen(false);
    };

    if (!userInfo) {
        console.log("User",auth.user);
        return (
            <>
                <Snackbar open={snackbarOpen} autoHideDuration={6000} onClose={handleCloseSnackbar}>
                    <Alert
                        onClose={handleCloseSnackbar}
                        severity="success"
                        variant="filled"
                        sx={{ width: '100%' }}
                    >
                        Name: {auth.user.Id}
                        Message: {snackbarMessage}
                    </Alert>
                </Snackbar>
                <p>Loading...</p>
            </>
        );
    }

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
                onClose={handleCloseSnackbar}
                message={snackbarMessage}
            />
        </>
    );
};
