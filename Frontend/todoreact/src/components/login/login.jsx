import styles from "./login.module.css";
import { FaEye, FaEyeSlash } from "react-icons/fa";
import { useLoginViewModel } from "./loginViewModel";

export const Login = () => {
    const vm = useLoginViewModel();

    return (
        <form className={styles.Login} onSubmit={vm.handleSubmit}>
            <h1 className={styles.Title}><strong>Login</strong></h1>

            {vm.error && <p className={styles.Error}>{vm.error}</p>}

            <div className={styles.InputWrapper}>
                <input
                    required
                    className={styles.Input}
                    type="email"
                    placeholder="Email"
                    autoComplete="on"
                    value={vm.email}
                    onChange={(e) => vm.setEmail(e.target.value)}
                />
            </div>

            <div className={styles.InputWrapper}>
                <input
                    type={vm.showPassword ? "text" : "password"}
                    placeholder="Password"
                    value={vm.password}
                    onChange={(e) => vm.setPassword(e.target.value)}
                    autoComplete="current-password"
                />
                <span className={styles.ToggleIcon} onClick={vm.handleToggle}>
                    {vm.showPassword ? <FaEye size={20}/> : <FaEyeSlash size={20}/> }
                </span>
            </div>

            <button className={styles.Button} type="submit">
                {vm.loading ? "Logging in..." : "Login"}
            </button>
        </form>
    );
};
