import { useContext } from "react"
import { FaHome, FaMoon, FaSun } from "react-icons/fa"
import { NavLink } from "react-router-dom"
import { DarkModeContext } from "../contexts/DarkModeContext"
import useAuth from "../hooks/useAuth";

function Navbar() {
    const { darkMode, toggle } = useContext(DarkModeContext);
    const { isLoggedIn, logoutUser, user } = useAuth();
    return (
        <nav id="app-nav" className="fixed top-0 left-0 w-full h-16 z-50 flex gap-3 p-2 bg-slate-100 text-slate-900 dark:bg-slate-900 dark:text-slate-100 items-center">
            <NavLink to="/dashboard" className="p-2">
                <FaHome />
            </NavLink>

            <div className="flex-1" />
            {!isLoggedIn ? <div className="hidden sm:flex items-center">
                <NavLink to="/login" className="p-2">Login</NavLink>
                <NavLink to="/register" className="p-2">Register</NavLink>
            </div>
                : <div className="hidden sm:flex items-center">
                    <div>Welcome, {user.firstName} {user.lastName}</div>
                    <NavLink to="/" className="p-2"><button onClick={logoutUser}>Logout</button></NavLink>
                </div>
            }

            <button onClick={toggle}>{darkMode ? <FaSun /> : <FaMoon />}</button>

        </nav>
    )
}

export default Navbar