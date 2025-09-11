import { useState } from "react";
import {
    Dialog,
    DialogTitle,
    DialogContent,
    DialogActions,
    TextField,
    Button,
    FormHelperText,
} from "@mui/material";
import { useAuth } from "../../authprovider/authProvider";
import { useUserDomain } from "../../../hooks/api/users";

export function ChangePasswordDialog({ open, onClose, onSave }) {
    const auth = useAuth();
    const usersApi = useUserDomain();

    const [oldPassword, setOldPassword] = useState("");
    const [newPassword, setNewPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [errors, setErrors] = useState({ oldPassword: "", newPassword: "", confirmPassword: "" });

    const validate = () => {
        const newErrors = { oldPassword: "", newPassword: "", confirmPassword: "" };
        if (!oldPassword) newErrors.oldPassword = "Old password is required";
        if (!newPassword) newErrors.newPassword = "New password is required";
        else if (newPassword.length < 8) newErrors.newPassword = "Password must be at least 8 characters";
        else if (newPassword.length > 32) newErrors.newPassword = "Password must be at most 32 characters";
        if (!confirmPassword) newErrors.confirmPassword = "Confirm password is required";
        if (newPassword && confirmPassword && newPassword !== confirmPassword)
            newErrors.confirmPassword = "Passwords do not match";

        setErrors(newErrors);
        return !newErrors.oldPassword && !newErrors.newPassword && !newErrors.confirmPassword;
    };

    const handleSave = async () => {
        if (!validate()) return;

        try {
            const updatinForm = {
                UserId: auth.user.Id,
                OldPassword: oldPassword,
                NewPassword: newPassword,
                ConfirmPassword: confirmPassword,
            };

            await onSave(updatinForm);
        } catch (err) {
            console.error(err);
            setErrors((prev) => ({ ...prev, oldPassword: "Failed to update password" }));
        }
    };

    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Change Password</DialogTitle>
            <DialogContent sx={{ display: "flex", flexDirection: "column", gap: 2, mt: 1 }}>
                <TextField
                    margin="normal"
                    label="Old Password"
                    type="password"
                    value={oldPassword}
                    onChange={(e) => setOldPassword(e.target.value)}
                    error={!!errors.oldPassword}
                    helperText={errors.oldPassword}
                />
                <TextField
                    label="New Password"
                    type="password"
                    value={newPassword}
                    onChange={(e) => setNewPassword(e.target.value)}
                    error={!!errors.newPassword}
                    helperText={errors.newPassword}
                />
                <TextField
                    label="Confirm Password"
                    type="password"
                    value={confirmPassword}
                    onChange={(e) => setConfirmPassword(e.target.value)}
                    error={!!errors.confirmPassword}
                    helperText={errors.confirmPassword}
                />
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose}>Cancel</Button>
                <Button onClick={handleSave} variant="contained" disabled={!oldPassword || !newPassword || !confirmPassword}>
                    Save
                </Button>
            </DialogActions>
        </Dialog>
    );
}
