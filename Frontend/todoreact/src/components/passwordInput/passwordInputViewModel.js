import {useState} from "react";

export function usePasswordInputViewModel(){
    const [showPassword, setShowPassword] = useState(false);

    const handleToggle = () => {
        setShowPassword(!showPassword);
    };

    return {
        showPassword,
        handleToggle
    };
}