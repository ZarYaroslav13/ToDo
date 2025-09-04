import styles from "./login.module.css";
import { Typography, Link } from "@mui/material";
import { Link as RouterLink } from "react-router-dom";
import { UrlAddresses } from "../router/router";
import { useLoginViewModel } from "./loginViewModel";
import {PasswordInput} from "../passwordInput/passwordInput"

export const Login = () => {
    const vm = useLoginViewModel();

    return (
        <form className={styles.Login} onSubmit={vm.handleSubmit}>
            <h1 className={styles.Title}><strong>Login</strong></h1>

            <div className={styles.InputWrapper}>
                <input
                    required
                    className={styles.Input}
                    type="email"
                    placeholder="Email"
                    autoComplete="on"
                    {...vm.register("email")}
                />
            </div>

            <PasswordInput register={vm.register} formProperty="password" placeholder="Password"
                           autoComplete="current-password"/>

            <Typography variant="body2" sx={{ mt: 2 }}>
                Don’t have an account yet?{" "}
                <Link component={RouterLink} to={UrlAddresses.Register}>
                    Register
                </Link>
            </Typography>

            <button className={styles.Button} type="submit">
                {vm.loading ? "Logging in..." : "Login"}
            </button>
        </form>
    );
};
