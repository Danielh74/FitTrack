import { createContext, useState } from "react"
import { auth } from "../services/AuthService"

interface AuthContextType {
    isLoggedIn: boolean,
    token: string,
    user: {
        id: string
        firstName: string
        lastName: string
        age: number
        gender: string
        city: string
        goal: string
        height: number
        weight: number
        abdominalCircumference: number
        agreedToTerms: boolean
        armCircumference: number
        bodyFatPrecentage: number
        healthDeclarationId: number | null
        hipsCircumference: number
        menu: [] | null
        neckCircumference: number
        pecsCircumference: number
        plans: []
        thighsCircumference: number
        waistCircumference: number
    }
    login: (token: string) => void,
    logout: () => void
}

const initialValues: AuthContextType = {
    isLoggedIn: false,
    token: "",
    user: {
        id: "2d922a5f-347d-4d58-b861-3a67e917af3a",
        firstName: "Avner",
        lastName: "Hazan",
        age: 26,
        gender: "Male",
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
    const [user, setUser] = useState(initialValues.user);

    const login = async (token: string) => {
        localStorage.setItem("token", token);
        setIsLoggedIn(true);
        setToken(token);
        setUser(await auth.userInfo(token));
        console.log(user);
    };

    const logout = () => {
        localStorage.removeItem("token");
        setIsLoggedIn(false);
        setToken("");
    };


    return <AuthContext.Provider value={{ isLoggedIn, token, user, login, logout }}>{children}</AuthContext.Provider>
};

export { AuthContext, AuthProvider }