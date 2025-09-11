import {usePasswordInputViewModel} from "./passwordInputViewModel";
import styles from "../login/login.module.css";
import {FaEye, FaEyeSlash} from "react-icons/fa";

export function PasswordInput({register, formProperty = "password", placeholder = "Password", autoComplete = "off"}){
    const vm = usePasswordInputViewModel();

    return (
        <div className={styles.InputWrapper}>
            <input
                required
                type={vm.showPassword ? "text" : "password"}
                placeholder={placeholder}
                autoComplete={autoComplete}
                {...register(formProperty)}
            />
            <span className={styles.ToggleIcon} onClick={vm.handleToggle}>
                    {vm.showPassword ? <FaEye size={20}/> : <FaEyeSlash size={20}/> }
                </span>
        </div>
    )
}