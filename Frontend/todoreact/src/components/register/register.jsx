import styles from "./register.module.css";
import {useRegisterViewModel} from "./registerViewModel";
import {PasswordInput} from "../passwordInput/passwordInput";
import {Link, Typography} from "@mui/material";
import {Link as RouterLink} from "react-router";
import {UrlAddresses} from "../router/router";

export const Register = () => {
    const vm = useRegisterViewModel();

    return (
        <form className={styles.Register} onSubmit={vm.handleSubmit}>
            <h1 className={styles.Title}><strong>Register</strong></h1>

            <Typography variant="body2" sx={{ mt: 2 }}>
                Already have an account ?{" "}
                <Link component={RouterLink} to={UrlAddresses.Login}>
                    Login
                </Link>
            </Typography>

            <div  className={styles.InputWrapper}>
                <input
                    required
                    className={styles.Input}
                    type="string"
                    name="nameInput"
                    placeholder="Name"
                    {...vm.register("name")}
                />
            </div>

            <div  className={styles.InputWrapper}>
                <input
                    required
                    className={styles.Input}
                    type="string"
                    name="surnameInput"
                    placeholder="Surname"
                    {...vm.register("surname")}
                />
            </div>

            <div  className={styles.InputWrapper}>
                <input
                    required
                    className={styles.Input}
                    type="email"
                    name="emailInput"
                    placeholder="Email"
                    autoComplete="off"
                    {...vm.register("email")}
                />
            </div>

            <PasswordInput register={vm.register} />

            <PasswordInput register={vm.register}
                           formProperty="confirmPassword"
                           placeholder="Confirm password"/>

            <button className={styles.Button} type="submit">
                {vm.loading ? "Registering in..." : "Register"}
            </button>
        </form>
    );
};
