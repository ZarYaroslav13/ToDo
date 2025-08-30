import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import { Login } from "../login/login";
import { Register } from "../register/register";
import { Profile } from "../profile/profile";
import { PrivateRoute } from "./PrivateRoute";

export const UrlAddresses = {
    Home: "/",
    Login: "/login",
    Register: "/register",
    Profile: "/profile",
};

export const Router = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path={UrlAddresses.Home} element={<Navigate to={UrlAddresses.Login} replace />} />
                <Route path={UrlAddresses.Login} element={<Login />} />
                <Route path={UrlAddresses.Register} element={<Register />} />

                <Route
                    path={UrlAddresses.Profile}
                    element={
                        <PrivateRoute>
                            <Profile />
                        </PrivateRoute>
                    }
                />
            </Routes>
        </BrowserRouter>
    );
};
