import styles from "./login.module.css";
import { useState } from "react";
import { FaEye, FaEyeSlash } from "react-icons/fa";
import { useAuth } from "../authprovider/authprovider";
import { UrlAddresses } from "../router/router";
import { useNavigate } from "react-router-dom";

export const Login = () => {
    const auth = useAuth(); // useAuth() from AuthProvider
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
            await auth.signIn({ email, password }); // use signIn from context
            navigate(UrlAddresses.Profile);
        } catch (err) {
            setError(err.message || "Login failed");
        }
    };

    return (
        <form className={styles.Login} onSubmit={handleSubmit}>
            <h1 className={styles.Title}><strong>Login</strong></h1>

            {error && <p className={styles.Error}>{error}</p>}

            <div className={styles.InputWrapper}>
                <input
                    required
                    className={styles.Input}
                    type="email"
                    name="emailInput"
                    placeholder="Email"
                    autoComplete="on"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
            </div>

            <div className={styles.InputWrapper}>
                <input
                    type={showPassword ? "text" : "password"}
                    name="password"
                    placeholder="Password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    autoComplete="current-password"
                />
                <span className={styles.ToggleIcon} onClick={handleToggle}>
                    {showPassword ? <FaEye size={20}/> : <FaEyeSlash size={20}/>}
                </span>
            </div>

            <button className={styles.Button} type="submit">
                {auth.loading ? "Logging in..." : "Login"}
            </button>
        </form>
    );
};
