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

interface updatedUserProps {
    city: string,
    age: number,
    goal: string,
    height: number,
    neckCircumference: number,
    pecsCircumference: number,
    armCircumference: number,
    waistCircumference: number,
    abdominalCircumference: number,
    thighsCircumference: number,
    hipsCircumference: number,
    weight: number
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
    try {
        const response = await axios.post(`${baseUrl}/register`, props);
        return response;
    } catch (error) {
        console.log(error);
    }
}

const login = async (email: string, password: string) => {
    try {
        const response = await axios.post(`${baseUrl}/login`, { email, password });
        return response;
    } catch (error) {
        return error;
    }
};

const getUserInfo = async (token: string) => {
    const userId: TokenProps = jwtDecode<TokenProps>(token);
    try {
        return await axios.get(`${baseUrl}/${userId.nameid}`, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
            .then((response) => {
                return response.data
            });
    } catch (error) {
        return error;
    }

};

const updateUser = async (updatedUser: updatedUserProps) => {
    try {
        const response = await axios.put(`${baseUrl}`, updatedUser, {
            headers: {
                Authorization: `Bearer ${localStorage.getItem("token")}`,
            },
        });
        return response;
    } catch (error) {

        return error;
    }
};

export const auth = { register, login, getUserInfo, updateUser }


