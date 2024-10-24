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
    isAdmin: boolean,
    token?: string | null,
    currentUser?: User | null,
    handleLogin: (token: string, userData: User) => void,
    logoutUser: () => void,
    reloadUser: (data: User) => void
}
interface Props {
    children: ReactNode
}
const initialValues: AuthContextType = {
    isAdmin: false,
    token: null,
    currentUser: null,
    handleLogin: () => { },
    logoutUser: () => { },
    reloadUser: () => { }
}

const AuthContext = createContext(initialValues);

function AuthProvider({ children }: Props) {
    const [token, setToken] = useState<string | null>(null);
    const [currentUser, setCurrentUser] = useState<User | null>(null);
    const [isLoading, setIsLoading] = useState(true);
    const [isAdmin, setIsAdmin] = useState<boolean>(false);

    useEffect(() => {
        const fetchUserData = () => {
            const storedToken = localStorage.getItem("token");
            if (storedToken) {
                auth.getCurrentUser(storedToken)
                    .then((userData) => {
                        console.log(userData);
                        setToken(storedToken);
                        const payload: TokenPayload = jwtDecode<TokenPayload>(storedToken);
                        if (payload.role && payload.role === "Admin") {
                            setCurrentUser(userData);
                            setIsAdmin(true);
                        } else {
                            setCurrentUser(userData);
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
                setToken(null);
                setCurrentUser(null);
            }
            setIsLoading(false);
        };
        fetchUserData();
    }, []);

    const handleLogin = (token: string, userData: User) => {
        localStorage.setItem("token", token);
        const payload: TokenPayload = jwtDecode(token);
        if (payload.role && payload.role === "Admin") {
            setIsAdmin(true);
            setCurrentUser(userData);
        } else {
            setIsAdmin(false);
            setCurrentUser(userData);
        }
        setToken(token);
    };

    const logoutUser = () => {
        localStorage.removeItem("token");
        setToken(null);
        setCurrentUser(null);
    };

    const reloadUser = (data: User) => {
        setCurrentUser(data);
    };

    if (isLoading)
        return <div className="flex justify-center items-center h-screen w-screen">
            <Loader />
        </div>

    return <AuthContext.Provider value={{ token, currentUser, isAdmin, reloadUser, handleLogin, logoutUser }}>{children}</AuthContext.Provider>
};

export { AuthContext, AuthProvider }