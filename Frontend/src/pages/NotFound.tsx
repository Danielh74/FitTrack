import { Link } from "react-router-dom";
import useAuth from "../hooks/useAuth";

const NotFound = () => {
    const { isLoggedIn } = useAuth();
    const path = isLoggedIn ? "/dashboard" : "/";
    return (
        <div style={{ textAlign: 'center', padding: '50px' }}>
            <h1>404 - Page Not Found</h1>
            <p>Sorry, the page you are looking for does not exist.</p>
            <Link to={path} className=" underline">Go back to Home</Link>
        </div>
    );
};

export default NotFound;