import { useContext } from "react"
import { FaHome, FaMoon, FaSun } from "react-icons/fa"
import { NavLink } from "react-router-dom"
import { DarkModeContext } from "../contexts/DarkModeContext"
import { AuthContext } from "../contexts/AuthContext";

function Navbar() {
    const { darkMode, toggle } = useContext(DarkModeContext);
    const { isLoggedIn, logout, user } = useContext(AuthContext);
    return (
        <nav id="app-nav" className="flex gap-3 p-2 bg-slate-100 text-slate-900 dark:bg-slate-900 dark:text-slate-100 items-center">
            <NavLink to="/" className="p-2">
                <FaHome />
            </NavLink>

            <div className="flex-1" />
            {!isLoggedIn ? <div className="hidden sm:flex items-center">
                <NavLink to="/login" className="p-2">Login</NavLink>
                <NavLink to="/register" className="p-2">Register</NavLink>
            </div>
                : <div className="hidden sm:flex items-center">
                    <div>Hello {user.firstName} {user.lastName}</div>
                    <NavLink to="/" className="p-2"><button onClick={logout}>Logout</button></NavLink>
                </div>
            }

            <button onClick={toggle}>{darkMode ? <FaSun /> : <FaMoon />}</button>

        </nav>
    )
}

export default Navbar