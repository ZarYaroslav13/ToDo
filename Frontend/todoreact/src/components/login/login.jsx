import styles from "./login.module.css";
import { useState } from "react";
import { FaEye } from 'react-icons/fa';
import { FaEyeSlash } from 'react-icons/fa';

export const Login = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [type, setType] = useState("password");
    const [showPassword, setShowPassword] = useState(false);

    const handleToggle = () => {
        if(showPassword) {
            setShowPassword(false);
            setType("password");
        } else {
            setShowPassword(true);
            setType("text");
        }
    }

    return (
        <form className={styles.Login}>
            <h1 className={styles.Title}><strong>Login</strong></h1>

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

            <div className={styles.PasswordWrapper}>
                <input
                    type={type}
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


            <button className={styles.Button} type="submit">Login</button>
        </form>
    );
};
