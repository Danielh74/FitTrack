import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import Home from "../pages/Home";
import LoginPage from "../pages/LoginPage";
import RegisterPage from "../pages/RegisterPage";
import { AuthRoute, NotAuthRoute } from "./ProtectedRoutes";
import Dashboard from "../pages/Dashboard";
import Plans from "../pages/Plans";
import Profile from "../pages/Profile";
import MenuPage from "../pages/MenuPage";
import NotFound from "../pages/NotFound";

export const router = createBrowserRouter([
    {
        path: "", element: <App />, children: [
            { path: "/", element: <NotAuthRoute><Home /></NotAuthRoute> },
            { path: "/login", element: <NotAuthRoute><LoginPage /></NotAuthRoute> },
            { path: "/register", element: <NotAuthRoute><RegisterPage /> </NotAuthRoute> },
            { path: "/dashboard", element: <AuthRoute><Dashboard /> </AuthRoute> },
            { path: "/plans", element: <AuthRoute><Plans /> </AuthRoute> },
            { path: "/profile", element: <AuthRoute><Profile /> </AuthRoute> },
            { path: "/menu", element: <AuthRoute><MenuPage /> </AuthRoute> },

        ]

    },
    { path: "*", element: <NotFound /> }
]); 