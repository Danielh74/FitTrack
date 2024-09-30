import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../pages/HomePage";
import LoginPage from "../pages/LoginPage";
import RegisterPage from "../pages/RegisterPage";
import { AuthRoute, NotAuthRoute } from "./ProtectedRoutes";

export const router = createBrowserRouter([
    {
        path: "", element: <App />, children: [
            { path: "/", element: <HomePage /> },
            { path: "/login", element: <NotAuthRoute><LoginPage /></NotAuthRoute> },
            { path: "/register", element: <NotAuthRoute><RegisterPage /> </NotAuthRoute> }
        ]
    }
]); 