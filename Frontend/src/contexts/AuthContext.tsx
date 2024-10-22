import { createContext, ReactNode, useEffect, useState } from "react";
import { User } from "../models/User";
import { auth } from "../services/UserService";
import Loader from "../components/Loader";
import { handleApiErrors } from "../utils/Helpers";
import { dialogs } from "../dialogs/Dialogs";
import { Navigate } from "react-router-dom";
import { TokenPayload } from "../models/User";
import { jwtDecode } from "jwt-decode";


interface AuthContextType {
    isLoggedIn: boolean,
    isAdmin: boolean,
    token: string | null,
    user: User | null,
    loginUser: (token: string, userData: User) => void,
    logoutUser: () => void,
    reloadUser: (data: User) => void
}
interface Props {
    children: ReactNode
}
const initialValues: AuthContextType = {
    isLoggedIn: false,
    isAdmin: false,
    token: null,
    user: null,
    loginUser: () => { },
    logoutUser: () => { },
    reloadUser: () => { }
}

const AuthContext = createContext(initialValues);

function AuthProvider({ children }: Props) {
    const [isLoggedIn, setIsLoggedIn] = useState<boolean>(false);
    const [token, setToken] = useState<string | null>(null);
    const [user, setUser] = useState<User | null>(null);
    const [isLoading, setIsLoading] = useState(true);
    const [isAdmin, setIsAdmin] = useState<boolean>(false);

    useEffect(() => {
        const fetchUserData = () => {
            const storedToken = localStorage.getItem("token");
            if (storedToken) {
                auth.getLoggedInUser(storedToken)
                    .then((userData) => {
                        console.log(userData);
                        setIsLoggedIn(true);
                        setToken(storedToken);
                        const payload: TokenPayload = jwtDecode<TokenPayload>(storedToken);
                        if (payload.role && payload.role === "Admin") {
                            setUser({ ...userData, role: "Admin" });
                            setIsAdmin(true);
                        } else {
                            setUser({ ...userData, role: "User" });
                            setIsAdmin(false);
                        }
                    })
                    .catch((error) => {
                        const errorMsg = handleApiErrors(error);
                        dialogs.errorAlert(errorMsg);
                        logoutUser();
                        return <Navigate to="/" />;
                    });
            } else {
                setIsLoggedIn(false);
                setToken(null);
                setUser(null);
            }
            setIsLoading(false);
        };
        fetchUserData();
    }, []);

    const loginUser = (token: string, userData: User) => {
        localStorage.setItem("token", token);
        const payload: TokenPayload = jwtDecode(token);
        if (payload.role && payload.role === "Admin") {
            setIsAdmin(true);
        } else {
            setIsAdmin(false);
        }
        setUser(userData);
        setIsLoggedIn(true);
        setToken(token);
        console.log(userData);
    };

    const logoutUser = () => {
        localStorage.removeItem("token");
        setIsLoggedIn(false);
        setToken(null);
        setUser(null);
    };

    const reloadUser = (data: User) => {
        setUser(data);
    };

    if (isLoading)
        return <div className="flex justify-center items-center h-screen w-screen">
            <Loader />
        </div>

    return <AuthContext.Provider value={{ isLoggedIn, token, user, isAdmin, reloadUser, loginUser, logoutUser }}>{children}</AuthContext.Provider>
};

export { AuthContext, AuthProvider }