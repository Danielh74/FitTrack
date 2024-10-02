import { createContext, ReactNode, useEffect, useState } from "react";
import { User } from "../models/User";


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

    useEffect(() => {
        setIsLoggedIn(!!localStorage.getItem("token"))
        setToken(localStorage.getItem("token") ?? null)
        setUser(JSON.parse(localStorage.getItem("user")) ?? null)
    }, []);

    const loginUser = (token: string, userData: User) => {
        localStorage.setItem("token", token);
        setUser(userData);
        localStorage.setItem("user", JSON.stringify(userData));
        setIsLoggedIn(true);
        setToken(token);
        console.log(userData);
    };

    const logoutUser = () => {
        localStorage.removeItem("token");
        localStorage.removeItem("user");
        setIsLoggedIn(false);
        setToken("");
        setUser(null);
    };


    return <AuthContext.Provider value={{ isLoggedIn, token, user, loginUser, logoutUser }}>{children}</AuthContext.Provider>
};

export { AuthContext, AuthProvider }