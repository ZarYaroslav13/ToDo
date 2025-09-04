import {createContext, useContext} from "react";
import {useSnackbar} from "../../hooks/snackbar";
import Alert from "@mui/material/Alert";
import Snackbar from "@mui/material/Snackbar";

const SnackbarContext = createContext(undefined);

export const useSnackBar = () => {
    const context = useContext(SnackbarContext);
    if (!context) throw new Error("useSnackBar must be used within SnackbarProvider");
    return context;
};

export const SnackbarProvider = ({ children }) => {
    const { open, message, severity, time, showSnackbar, closeSnackbar } = useSnackbar();

    return (
        <SnackbarContext.Provider value={{ open, message, severity, time, showSnackbar, closeSnackbar }}>
            {children}

            <Snackbar
                open={open}
                autoHideDuration={time}
                onClose={closeSnackbar}
                anchorOrigin={{ vertical: "top", horizontal: "center" }}
            >
                <Alert
                    onClose={closeSnackbar}
                    severity={severity}
                    variant="filled"
                    sx={{ width: '100%' }}
                >
                    {message}
                </Alert>
            </Snackbar>
        </SnackbarContext.Provider>
    );
};
