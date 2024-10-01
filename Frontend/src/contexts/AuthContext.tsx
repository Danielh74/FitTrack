import { createContext, useEffect, useState } from "react";
import { auth } from "../services/AuthService";
import { User } from "../types/Types";


interface AuthContextType {
    isLoggedIn: boolean,
    token: string,
    user: User,
    login: (token: string) => void,
    logout: () => void
}

const initialValues: AuthContextType = {
    isLoggedIn: false,
    token: "",
    user: {
        id: "",
        firstName: "",
        lastName: "",
        age: 0,
        gender: "",
        city: "",
        goal: "",
        height: 0,
        weight: 0,
        abdominalCircumference: 0,
        agreedToTerms: false,
        armCircumference: 0,
        bodyFatPrecentage: 0,
        healthDeclarationId: null,
        hipsCircumference: 0,
        menu: null,
        neckCircumference: 0,
        pecsCircumference: 0,
        plans: [],
        thighsCircumference: 0,
        waistCircumference: 0
    },
    login: () => { },
    logout: () => { }
}

const AuthContext = createContext(initialValues);

function AuthProvider({ children }) {
    const [isLoggedIn, setIsLoggedIn] = useState(!!localStorage.getItem("token"));
    const [token, setToken] = useState(localStorage.getItem("token") ?? "");
    const [user, setUser] = useState<User>(JSON.parse(localStorage.getItem("user")) ?? initialValues.user);

    const login = async (token: string, userData: User) => {
        localStorage.setItem("token", token);
        setUser(userData);
        localStorage.setItem("user", JSON.stringify(userData));
        setIsLoggedIn(true);
        setToken(token);
        console.log(user);
    };

    const logout = () => {
        localStorage.removeItem("token");
        localStorage.removeItem("user");
        setIsLoggedIn(false);
        setToken("");
        setUser(initialValues.user);
    };


    return <AuthContext.Provider value={{ isLoggedIn, token, user, login, logout }}>{children}</AuthContext.Provider>
};

export { AuthContext, AuthProvider }