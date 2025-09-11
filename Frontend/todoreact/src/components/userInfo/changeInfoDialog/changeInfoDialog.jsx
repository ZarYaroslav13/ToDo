import React, { useState, useEffect } from "react";
import {
    Dialog, DialogTitle, DialogContent, DialogActions,
    TextField, Button
} from "@mui/material";

export function EditUserInfoDialog({ open, userInfo, onClose, onSave }) {
    const [name, setName] = useState("");
    const [surname, setSurname] = useState("");
    const [email, setEmail] = useState("");
    const [errors, setErrors] = useState({ name: "", surname: "", email: "" });

    useEffect(() => {
        if (userInfo) {
            setName(userInfo.name || "");
            setSurname(userInfo.surname || "");
            setEmail(userInfo.email || "");
            setErrors({ name: "", surname: "", email: "" });
        }
    }, [userInfo]);

    const validate = () => {
        const newErrors = { name: "", surname: "", email: "" };

        if (!name.trim()) newErrors.name = "Name is required";
        if (!surname.trim()) newErrors.surname = "Surname is required";
        if (!email.trim()) {
            newErrors.email = "Email is required";
        } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) {
            newErrors.email = "Invalid email format";
        }

        setErrors(newErrors);
        return !newErrors.name && !newErrors.surname && !newErrors.email;
    };

    const handleSave = async () => {
        if (!validate()) return;

        await onSave({
            id: userInfo.id,
            name: name.trim(),
            surname: surname.trim(),
            email: email.trim()
        });
    };

    return (
        <Dialog open={open} onClose={onClose} maxWidth="sm" fullWidth>
            <DialogTitle>Edit User Info</DialogTitle>
            <DialogContent sx={{ display: "flex", flexDirection: "column", gap: 2, mt: 1 }}>
                <TextField
                    margin="normal"
                    label="Name"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                    error={!!errors.name}
                    helperText={errors.name}
                    fullWidth
                />
                <TextField
                    label="Surname"
                    value={surname}
                    onChange={(e) => setSurname(e.target.value)}
                    error={!!errors.surname}
                    helperText={errors.surname}
                    fullWidth
                />
                <TextField
                    label="Email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    error={!!errors.email}
                    helperText={errors.email}
                    fullWidth
                />
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose}>Cancel</Button>
                <Button onClick={handleSave} variant="contained">
                    Save
                </Button>
            </DialogActions>
        </Dialog>
    );
}
