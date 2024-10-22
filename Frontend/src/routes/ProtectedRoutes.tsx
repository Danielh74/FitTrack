import { ReactNode } from 'react'
import { Navigate } from 'react-router-dom';
import useAuth from '../hooks/useAuth';

interface Props {
    children: ReactNode
}

export const AuthRoute = ({ children }: Props) => {
    const { isLoggedIn, isAdmin, user } = useAuth();

    if (isLoggedIn && isAdmin) {
        return <Navigate to="/admin/dashboard" />
    }

    return isLoggedIn && user ? children : <Navigate to="/login" />
};

export const NotAuthRoute = ({ children }: Props) => {
    const { isLoggedIn, user } = useAuth();

    return !isLoggedIn && !user ? children : <Navigate to="/dashboard" />;
};

export const AdminRoute = ({ children }: Props) => {
    const { user, isAdmin } = useAuth();


    if (user && !isAdmin) {
        return <Navigate to="/dashboard" />
    }
    return children;
};
