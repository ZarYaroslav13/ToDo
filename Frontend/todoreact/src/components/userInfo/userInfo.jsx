import styles from "./userInfo.module.css";
import EditNoteIcon from '@mui/icons-material/EditNote';
import LockResetIcon from '@mui/icons-material/LockReset';
import {Button, Chip, Stack} from "@mui/material";

export function UserInfo ({userInfo}) {
    return (
        <section className={styles.UserInfoCard}>
            <h2>User Info</h2>
            <Stack className={styles.UserStack}>
                <strong>Name: </strong>
                <Chip label={ `${userInfo.name} ${userInfo.surname}` } />
            </Stack>
            <Stack className={styles.UserStack}>
                <strong>Email: </strong>
                <Chip label={ userInfo.email } />
            </Stack>
            <Stack className={styles.UserButtonStack}>
                <Button variant={"contained"} endIcon={<EditNoteIcon/>}>Change info</Button>
                <Button variant={"contained"} endIcon={<LockResetIcon/>}>Change password</Button>
            </Stack>
        </section>
    );
}