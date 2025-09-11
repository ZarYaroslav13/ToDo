import { useState, useEffect } from "react";

export function useLocalStorage(key, initialValue) {
    const [storedValue, setStoredValue] = useState(() => {
        try {
            const item = localStorage.getItem(key);
            return item ? JSON.parse(item) : initialValue;
        } catch (error) {
            console.log(error);
            return initialValue;
        }
    });

    const setValue = (value) => {
        try {
            const valueToStore = typeof value === "function" ? value(storedValue) : value;
            setStoredValue(valueToStore);
            localStorage.setItem(key, JSON.stringify(valueToStore));
        } catch (error) {
            console.log(error);
        }
    };

    useEffect(() => {
        const handleStorageChange = (event) => {
            if (event.key === key) {
                setStoredValue(JSON.parse(event.newValue || "null"));
            }
        };

        window.addEventListener("storage", handleStorageChange);
        return () => window.removeEventListener("storage", handleStorageChange);
    }, [key]);

    return [storedValue, setValue];
}
