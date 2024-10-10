import { createContext, ReactNode, useEffect, useState } from "react";
import { User } from "../models/User";
import { auth } from "../services/AuthService";
import { toast } from "react-toastify";
import Loader from "../components/Loader";


interface AuthContextType {
    isLoggedIn: boolean,
    token: string | null,
    user: User | null,
    loginUser: (token: string, userData: User) => void,
    logoutUser: () => void
}
interface Props {
    children: ReactNode
}
const initialValues: AuthContextType = {
    isLoggedIn: false,
    token: null,
    user: null,
    loginUser: () => { },
    logoutUser: () => { }
}

const AuthContext = createContext(initialValues);

function AuthProvider({ children }: Props) {
    const [isLoggedIn, setIsLoggedIn] = useState<boolean>(false);
    const [token, setToken] = useState<string | null>(null);
    const [user, setUser] = useState<User | null>(null);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        const fetchUserData = async () => {
            const storedToken = localStorage.getItem("token");
            if (storedToken) {
                try {
                    const userData = await auth.userInfo(storedToken);
                    console.log(userData);
                    setIsLoggedIn(true);
                    setToken(storedToken);
                    setUser(userData);
                } catch (err) {
                    toast.error(err);
                }
            } else {
                setIsLoggedIn(false);
                setToken(null);
                setUser(null);
            }
            setIsLoading(false);
        }
        fetchUserData();
    }, []);

    const loginUser = (token: string, userData: User) => {
        localStorage.setItem("token", token);
        setUser(userData);
        setIsLoggedIn(true);
        setToken(token);
        console.log(userData);
    };

    const logoutUser = () => {
        localStorage.removeItem("token");
        setIsLoggedIn(false);
        setToken("");
        setUser(null);
    };

    if (isLoading)
        return <div className="flex justify-center items-center h-screen w-screen">
            <Loader />
        </div>

    return <AuthContext.Provider value={{ isLoggedIn, token, user, loginUser, logoutUser }}>{children}</AuthContext.Provider>
};

export { AuthContext, AuthProvider }