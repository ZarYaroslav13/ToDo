import { useState } from "react";
import { useAuth } from "../authprovider/authprovider";
import { useNavigate } from "react-router-dom";
import { UrlAddresses } from "../router/router";

export function useLoginViewModel() {
    const auth = useAuth();
    const navigate = useNavigate();

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [showPassword, setShowPassword] = useState(false);
    const [error, setError] = useState(null);

    const handleToggle = () => {
        setShowPassword(!showPassword);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError(null);
        try {
            await auth.signIn({ email, password });
            navigate(UrlAddresses.Profile);
        } catch (err) {
            setError(err.message || "Login failed");
        }
    };

    return {
        email,
        setEmail,
        password,
        setPassword,
        showPassword,
        handleToggle,
        handleSubmit,
        error,
        loading: auth.loading
    };
}
