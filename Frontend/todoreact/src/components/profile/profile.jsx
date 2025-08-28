import styles from "./profile.module.css";
import {Fragment, useState} from "react";
import { useUserDomain } from "../../hooks/api/users"

export const Profile = () => {
    const [userInfo, setUserInfo] = useState({
        id: 2,
        name: "name",
        surname: "surname",
        email: "email",
        tasks: []
    });

    return (<form>
        <title>User profile</title>
        <section className={styles.UserInfoCard}>
            <h1> User info </h1>
            <p>User: {userInfo.name} {userInfo.surname}</p>
            <p>Email: {userInfo.email}</p>
        </section>

        <section className={styles.TasksCard}>
            <h1> Tasks </h1>

            <ul>
                {userInfo.tasks.map((task) => (
                    <li key={task.id}>
                        {task}
                    </li>
                ))}
            </ul>
        </section>
    </form>);

}