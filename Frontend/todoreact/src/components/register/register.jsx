import styles from "./register.module.css";
import { useState } from "react";
import { FaEye } from 'react-icons/fa';
import { FaEyeSlash } from 'react-icons/fa';

export const Register = () => {
    const [registerModel, setRegisterModel] = useState({
        name: "",
        surname: "",
        email: "",
        password: "",
        confirmPassword: "",
    })
    const [type, setType] = useState("password");
    const [showPassword, setShowPassword] = useState(false);

    const [typeConfirm, setTypeConfirm] = useState("password");
    const [showConfirmPassword, setShowConfirmPassword] = useState(false);

    const handlePasswordVisibilityToggle = () => {
        if(showPassword) {
            setShowPassword(false);
            setType("password");
        } else {
            setShowPassword(true);
            setType("text");
        }
    }

    const handleConfirmPasswordVisibilityToggle = () => {
        if(showConfirmPassword) {
            setShowConfirmPassword(false);
            setTypeConfirm("password");
        } else {
            setShowConfirmPassword(true);
            setTypeConfirm("text");
        }
    }

    function handleRegisterModelChange(key, value) {
        setRegisterModel((prevModel) => ({
            ...prevModel,
            [key]: value,
        }));
    }

    return (
        <form className={styles.Register}>
            <h1 className={styles.Title}><strong>Register</strong></h1>

            <div  className={styles.InputWrapper}>
                <input
                    required
                    className={styles.Input}
                    type="string"
                    name="nameInput"
                    placeholder="Name"
                    value={registerModel.name}
                    onChange={(e) => handleRegisterModelChange("name", e.target.value)}
                />
            </div>

            <div  className={styles.InputWrapper}>
                <input
                    required
                    className={styles.Input}
                    type="string"
                    name="surnameInput"
                    placeholder="Surname"
                    value={registerModel.surname}
                    onChange={(e) => handleRegisterModelChange("surname", e.target.value)}
                />
            </div>

            <div  className={styles.InputWrapper}>
                <input
                    required
                    className={styles.Input}
                    type="email"
                    name="emailInput"
                    placeholder="Email"
                    autoComplete="on"
                    value={registerModel.email}
                    onChange={(e) => handleRegisterModelChange("email", e.target.value)}
                />
            </div>

            <div className={styles.InputWrapper}>
                <input
                    type={type}
                    name="password"
                    placeholder="Password"
                    value={registerModel.password}
                    onChange={(e) => handleRegisterModelChange("password", e.target.value)}
                    autoComplete="current-password"
                />
                <span className={styles.ToggleIcon} onClick={handlePasswordVisibilityToggle}>
                    {showPassword ? <FaEye size={20}/> : <FaEyeSlash size={20}/>}
                </span>
            </div>

            <div className={styles.InputWrapper}>
                <input
                    type={typeConfirm}
                    name="confirmPasswordInout"
                    placeholder="Confirm password"
                    value={registerModel.confirmPassword}
                    onChange={(e) => handleRegisterModelChange("confirmPassword", e.target.value)}
                />
                <span className={styles.ToggleIcon} onClick={handleConfirmPasswordVisibilityToggle}>
                    {showConfirmPassword ? <FaEye size={20}/> : <FaEyeSlash size={20}/>}
                </span>
            </div>

            <button className={styles.Button} type="submit">Register</button>
        </form>
    );
};
