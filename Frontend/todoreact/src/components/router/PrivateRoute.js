import { Navigate } from "react-router-dom";
import { useAuth } from "../authprovider/authProvider";

export const PrivateRoute = ({ children }) => {
    const auth = useAuth();

    if (!auth.user) {
        return <Navigate to="/login" replace />;
    }

    return children;
};
