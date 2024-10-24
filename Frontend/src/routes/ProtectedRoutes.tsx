import { ReactNode } from 'react'
import { Navigate } from 'react-router-dom';
import useAuth from '../hooks/useAuth';

interface Props {
    children: ReactNode
}

export const AuthRoute = ({ children }: Props) => {
    const { isAdmin, currentUser } = useAuth();

    if (currentUser && isAdmin) {
        return <Navigate to="/admin/dashboard" />
    }

    return currentUser ? children : <Navigate to="/login" />
};

export const NotAuthRoute = ({ children }: Props) => {
    const { currentUser } = useAuth();

    return !currentUser ? children : <Navigate to="/dashboard" />;
};

export const AdminRoute = ({ children }: Props) => {
    const { currentUser, isAdmin } = useAuth();


    if (currentUser && !isAdmin) {
        return <Navigate to="/dashboard" />
    }
    return children;
};
