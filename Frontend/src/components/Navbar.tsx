import { FaMoon, FaSun } from "react-icons/fa"
import { NavLink } from "react-router-dom"
import useAuth from "../hooks/useAuth";
import logo from "../assets/app_icon.png"
import useTheme from "../hooks/useTheme";

function Navbar() {
    const { darkMode, toggle } = useTheme();
    const { logoutUser, currentUser } = useAuth();
    return (
        <nav id="app-nav" className="fixed top-0 left-0 w-full h-16 z-50 flex gap-3 p-2 navbar-bg items-center">
            <NavLink to={`${currentUser ? "/dashboard" : "/"}`} className="p-2">
                <img src={logo} alt="logo" className="w-10" />
            </NavLink>
            {currentUser ?
                <>
                    <div>Welcome, {currentUser.firstName} {currentUser.lastName}</div>
                    <div className="flex-1" />
                    <div className="hidden sm:flex items-center">
                        <NavLink to="/" className="p-2"><button onClick={logoutUser}>Logout</button></NavLink>
                    </div>
                </>
                :
                <>
                    <div className="flex-1" />
                    <div className="hidden sm:flex items-center">
                        <NavLink to="/login" className="p-2">Login</NavLink>
                        <NavLink to="/register" className="p-2">Register</NavLink>
                    </div>
                </>}
            <button onClick={toggle}>{darkMode ? <FaSun /> : <FaMoon />}</button>
        </nav>
    );
};

export default Navbar