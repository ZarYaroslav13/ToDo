import { createContext, useContext, useEffect } from "react";
import { useLocalStorage } from "../../hooks/localStorage";
import { useAuthorization } from "../../hooks/api/authorization";

const AuthDataContext = createContext(undefined);

export const useAuth = () => {
    const context = useContext(AuthDataContext);
    if (!context) throw new Error("useAuth must be used within AuthProvider");
    return context;
};

export const AuthProvider = ({ children }) => {
    const { login, logout, loading, error } = useAuthorization();
    const [user, setUser] = useLocalStorage("user", null);

    const signIn = async (credentials) => {
        const decoded = await login(credentials);
        setUser(decoded);
    };

    const signOut = () => {
        logout();
        setUser(null);
    };

    // optional JWT expiration auto-logout
    useEffect(() => {
        if (!user) return;
        if (user.exp && Math.floor(Date.now() / 1000) > user.exp) {
            signOut();
        }
    }, [user]);

    return (
        <AuthDataContext.Provider value={{ user, signIn, signOut, loading, error }}>
            {children}
        </AuthDataContext.Provider>
    );
};
