import { ReactNode } from 'react'
import { Navigate } from 'react-router-dom';
import useAuth from '../hooks/useAuth';

interface Props {
    children: ReactNode
}

export const AuthRoute = ({ children }: Props) => {
    const { isLoggedIn } = useAuth();
    if (isLoggedIn) {
        return children;
    }
    return <Navigate to="/login" />
};

export const NotAuthRoute = ({ children }: Props) => {
    const { isLoggedIn } = useAuth();
    if (isLoggedIn) {
        return <Navigate to="/" />
    }
    return children;
};
