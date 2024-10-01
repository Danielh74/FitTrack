import axios from "axios";
import { jwtDecode } from "jwt-decode";

const baseUrl = import.meta.env.VITE_BASE_URL + "/accounts";

interface RegisterProps {
    firstName: string,
    lastName: string,
    age: number,
    gender: string,
    goal: string,
    email: string,
    password: string,
    validatePassword: string,
    agreedToTerms: boolean
}

interface TokenProps {
    aud: string
    email: string
    exp: number
    iat: number
    iss: string
    nameid: string
    nbf: number
    role: string
}

const register = async (props: RegisterProps) => {
    return await axios.post(`${baseUrl}/register`, { props });
};

const login = async (email: string, password: string) => {
    return await axios.post(`${baseUrl}/login`, { email, password })
        .then((response) => {
            return response.data;
        });
};

const userInfo = async (token: string) => {
    const userId: TokenProps = jwtDecode<TokenProps>(token);
    return await axios.get(`${baseUrl}/${userId.nameid}`, {
        headers: {
            Authorization: `Bearer ${token}`
        }
    })
        .then((response) => {
            return response.data
        });
}

export const auth = { register, login, userInfo }


