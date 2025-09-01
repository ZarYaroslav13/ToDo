import React, { useState, useEffect } from "react";
import {
    Dialog, DialogTitle, DialogContent, DialogActions,
    TextField, Button, FormControl, InputLabel, Select, MenuItem, FormHelperText
} from "@mui/material";
import { Priority } from "../../enums/priority";

export function EditTaskDialog({ open, task, onClose, onSave }) {
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [priority, setPriority] = useState("None");
    const [deadline, setDeadline] = useState("");

    const [errors, setErrors] = useState({ title: "", priority: "", deadline: "" });

    useEffect(() => {
        if (task) {
            setTitle(task.title);
            setDescription(task.description || "");
            setPriority(task.priority.name);
            setDeadline(task.deadline ? task.deadline.split("T")[0] : "");
            setErrors({ title: "", priority: "", deadline: "" });
        }
    }, [task]);

    const validate = () => {
        const newErrors = { title: "", priority: "", deadline: "" };
        const today = new Date();
        today.setHours(0, 0, 0, 0); // reset to start of day

        if (!title.trim()) newErrors.title = "Title is required";
        if (!priority || priority === "None") newErrors.priority = "Priority is required";
        if (!deadline) {
            newErrors.deadline = "Deadline is required";
        } else {
            const selectedDate = new Date(deadline);
            if (selectedDate < today) newErrors.deadline = "Deadline cannot be in the past";
        }

        setErrors(newErrors);
        return !newErrors.title && !newErrors.priority && !newErrors.deadline;
    };

    const handleSave = () => {
        if (!validate()) return;

        onSave({
            ...task,
            title: title.trim(),
            description: description.trim(),
            priority: Priority[priority.toUpperCase()],
            deadline: new Date(deadline).toISOString()
        });
    };

    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Edit Task</DialogTitle>
            <DialogContent sx={{ display: "flex", flexDirection: "column", gap: 2, mt: 1 }}>
                <TextField
                    margin="normal"
                    label="Title"
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    error={!!errors.title}
                    helperText={errors.title}
                />
                <TextField
                    label="Description"
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                />
                <FormControl error={!!errors.priority} margin="normal">
                    <InputLabel id="demo-simple-select-autowidth-label">Priority</InputLabel>
                    <Select
                        labelId="demo-simple-select-autowidth-label"
                        id="demo-simple-select-autowidth"
                        value={priority}
                        autoWidth
                        label="Priorirt"
                        onChange={(e) => setPriority(e.target.value)}>
                        {Object.values(Priority).map(p => (
                            <MenuItem key={p.name} value={p.name}>{p.name}</MenuItem>
                        ))}
                    </Select>

                    <FormHelperText>{errors.priority}</FormHelperText>
                </FormControl>
                <TextField
                    label="Deadline"
                    type="date"
                    value={deadline}
                    onChange={(e) => setDeadline(e.target.value)}
                    InputLabelProps={{ shrink: true }}
                    error={!!errors.deadline}
                    helperText={errors.deadline}
                />
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose}>Cancel</Button>
                <Button onClick={handleSave} variant="contained" disabled={!title || !priority || !deadline}>
                    Save
                </Button>
            </DialogActions>
        </Dialog>
    );
}
