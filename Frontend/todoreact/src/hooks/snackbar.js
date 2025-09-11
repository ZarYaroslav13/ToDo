import {useState} from "react";

export function useSnackbar()  {
    const [open, setOpen] = useState(false);
    const [message, setMessage] = useState("");
    const [severity, setSeverity] = useState("success");
    const [time, setTime] = useState(3000);

    const showSnackbar = (message, severity = "success", time=3000) => {
        setMessage(message);
        setSeverity(severity);
        setOpen(true);
        setTime(time);
    };

    const closeSnackbar = () => setOpen(false);

    return {
        open: open,
        message: message,
        severity: severity,
        time: time,
        showSnackbar,
        closeSnackbar,
    }
}