import { useState } from "react";
import styles from "./userInfo.module.css";
import EditNoteIcon from "@mui/icons-material/EditNote";
import LockResetIcon from "@mui/icons-material/LockReset";
import { Button, Chip, Stack, Typography } from "@mui/material";
import { EditUserInfoDialog } from "./changeInfoDialog/changeInfoDialog"; // your dialog
import { ChangePasswordDialog } from "./changePasswordDialog/changePasswordDialog"; // hypothetical dialog

export function UserInfo({ userInfo, onUpdatingUser, onUpdatingPassword }) {
    const [editInfoOpen, setEditInfoOpen] = useState(false);
    const [changePasswordOpen, setChangePasswordOpen] = useState(false);

    return (
        <section className={styles.UserInfoCard}>
            <Typography variant="h5" gutterBottom>
                User Info
            </Typography>

            <Stack direction="row" spacing={1} className={styles.UserStack}>
                <Typography variant="subtitle1" fontWeight="bold">
                    Name:
                </Typography>
                <Chip label={`${userInfo.name} ${userInfo.surname}`} />
            </Stack>

            <Stack direction="row" spacing={1} className={styles.UserStack}>
                <Typography variant="subtitle1" fontWeight="bold">
                    Email:
                </Typography>
                <Chip label={userInfo.email} />
            </Stack>

            <Stack direction="row" spacing={2} className={styles.UserButtonStack}>
                <Button
                    variant="contained"
                    endIcon={<EditNoteIcon />}
                    onClick={() => setEditInfoOpen(true)}
                >
                    Change info
                </Button>
                <Button
                    variant="contained"
                    endIcon={<LockResetIcon />}
                    onClick={() => setChangePasswordOpen(true)}
                >
                    Change password
                </Button>
            </Stack>

            {editInfoOpen && (
                <EditUserInfoDialog
                    open={editInfoOpen}
                    userInfo={userInfo}
                    onClose={() => setEditInfoOpen(false)}
                    onSave={async (updatedUser) =>  {

                        onUpdatingUser(updatedUser);

                        setEditInfoOpen(false);
                    }}
                />
            )}

            {changePasswordOpen && (
                <ChangePasswordDialog
                    open={changePasswordOpen}
                    onClose={() => setChangePasswordOpen(false)}
                    onSave={async (updatingForm) => {
                        await onUpdatingPassword(updatingForm);

                        setChangePasswordOpen(false);
                    }}
                />
            )}
        </section>
    );
}
