import { createContext, useEffect, useState } from "react";

interface Props {
    darkMode: boolean
    lightColor: string
    toggle: () => void
}

const initialValues: Props = {
    darkMode: false,
    lightColor: '#E7ECEF',
    toggle: () => { }
}

const ThemeContext = createContext(initialValues);

function ThemeProvider({ children }) {
    const [darkMode, setDarkMode] = useState(false)
    const lightColor = '#E7ECEF';
    useEffect(() => {
        const theme = localStorage.getItem("theme");
        if (theme === "dark") {
            setDarkMode(true);
            document.body.classList.add("dark");
        }
    }, []);

    const toggle = () => {
        const currentTheme = !darkMode ? "dark" : "light";
        localStorage.setItem("theme", currentTheme);
        setDarkMode((prev) => !prev);
        document.body.classList.toggle("dark");
    }
    return <ThemeContext.Provider value={{ darkMode, lightColor, toggle }}>{children}</ThemeContext.Provider>
}

export { ThemeContext, ThemeProvider }