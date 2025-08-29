import styles from "./profile.module.css";
import { useState, useEffect } from "react";
import { useUserDomain } from "../../hooks/api/users";
import { useAuth } from "../authprovider/authprovider";

export const Profile = () => {
    const users = useUserDomain();
    const auth = useAuth();
    const [userInfo, setUserInfo] = useState(null);

    useEffect(() => {
        if (!auth.user?.id) return;

        const fetchUser = async () => {
            try {
                const data = await users.fetch(auth.user.id);
                setUserInfo(data);
            } catch (err) {
                console.error("Failed to fetch user info:", err);
            }
        };

        fetchUser();
    }, [auth.user]);

    if (!userInfo) {
        return <p>Loading...</p>;
    }

    return (
        <form>
            <h1>User Profile</h1>

            <section className={styles.UserInfoCard}>
                <h2>User Info</h2>
                <p>
                    Name: {userInfo.name} {userInfo.surname}
                </p>
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
    );
};
