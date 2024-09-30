import { createContext, useEffect, useState } from "react";

interface Props {
    darkMode: boolean,
    toggle: () => void
}

const initialValues: Props = {
    darkMode: false,
    toggle: () => { }
}

const DarkModeContext = createContext(initialValues);

function DarkModeProvider({ children }) {
    const [darkMode, setDarkMode] = useState(false)

    useEffect(() => {
        const theme = localStorage.getItem("theme");
        if (theme === "dark") {
            setDarkMode(false);
            document.body.classList.add("dark");
        }
    }, []);

    const toggle = () => {
        const currentTheme = !darkMode ? "dark" : "light";
        localStorage.setItem("theme", currentTheme);
        setDarkMode((prev) => !prev);
        document.body.classList.toggle("dark");
    }
    return <DarkModeContext.Provider value={{ darkMode, toggle }}>{children}</DarkModeContext.Provider>
}

export { DarkModeContext, DarkModeProvider }