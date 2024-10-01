import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import Home from "../pages/Home";
import LoginPage from "../pages/LoginPage";
import RegisterPage from "../pages/RegisterPage";
import { AuthRoute, NotAuthRoute } from "./ProtectedRoutes";
import Dashboard from "../pages/Dashboard";

export const router = createBrowserRouter([
    {
        path: "", element: <App />, children: [
            { path: "/", element: <Home /> },
            { path: "/login", element: <NotAuthRoute><LoginPage /></NotAuthRoute> },
            { path: "/register", element: <NotAuthRoute><RegisterPage /> </NotAuthRoute> },
            { path: "/dashboard", element: <AuthRoute><Dashboard /> </AuthRoute> },
        ]
    }
]); 