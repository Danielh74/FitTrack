import { ReactNode, useEffect } from 'react'
import { Navigate } from 'react-router-dom';
import useAuth from '../hooks/useAuth';

interface Props {
    children: ReactNode
}

export const AuthRoute = ({ children }: Props) => {
    const { isLoggedIn, user } = useAuth();

    useEffect(() => {
        if (!isLoggedIn) {
            <Navigate to="/login" />
        }
    }, [isLoggedIn]);

    return isLoggedIn && user ? children : <Navigate to="/login" />
};

export const NotAuthRoute = ({ children }: Props) => {
    const { isLoggedIn, user } = useAuth();

    useEffect(() => {
        if (isLoggedIn) {
            <Navigate to="/dashboard" />
        }
    }, [isLoggedIn]);

    return !isLoggedIn && !user ? children : <Navigate to="/dashboard" />;
};
