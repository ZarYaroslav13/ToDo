import { useState } from "react";
import { useAuth } from "../authprovider/authProvider";
import { useNavigate } from "react-router-dom";
import { useForm } from "react-hook-form"
import { UrlAddresses } from "../router/router";
import {useSnackBar} from "../snackbarProvider/snackbarProvider";

export function useLoginViewModel() {
    const auth = useAuth();
    const navigate = useNavigate();
    const snackbar = useSnackBar()

    const {register, handleSubmit  } = useForm()
    const [error, setError] = useState(null);

    const onSubmit = async (data) => {
        setError(null);
        try {
            await auth.signIn( data );
            navigate(UrlAddresses.Profile);
        } catch (err) {
            snackbar.showSnackbar(err.message || "Login failed", "error");
        }
    };

    return {
        register,
        handleSubmit: handleSubmit(onSubmit),
        error,
        loading: auth.loading
    };
}
