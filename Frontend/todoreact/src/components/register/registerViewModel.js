import {useForm} from "react-hook-form";
import {useState} from "react";
import { useNavigate } from "react-router-dom";
import {UrlAddresses} from "../router/router";
import {useAuthorization} from "../../hooks/api/authorization";
import {useSnackBar} from "../snackbarProvider/snackbarProvider";

export function useRegisterViewModel(){
    const auth = useAuthorization();
    const navigate = useNavigate();
    const snackbar = useSnackBar();

    const {register, handleSubmit, watch } = useForm();
    const [error, setError] = useState(null);

    const onSubmit = async (data) => {
        setError(null);
        try {
            await auth.register( data );
            navigate(UrlAddresses.Profile);
        } catch (err) {
            snackbar.showSnackbar(err.message || "Registering failed", "error");
        }
    };

    const password = watch("password");

    return {
        register: (name, options) =>
            register(name, {
                ...options,
                ...(name === "confirmPassword" && {
                    validate: (value) =>
                        value === password || snackbar.showSnackbar("Passwords do not match", "error"),
                }),
            }),

        handleSubmit: handleSubmit(onSubmit),
        error,
        loading: auth.loading
    }
}