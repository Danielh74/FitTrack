import axios from "axios";
import { TokenPayload } from "../models/User";
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

const register = async (props: RegisterProps) => {
    return await axios.post(`${baseUrl}/register`, props);

}

const login = async (email: string, password: string) => {
    return await axios.post(`${baseUrl}/login`, { email, password });
};

const getUserInfo = async (payload: TokenPayload) => {
    return await axios.get(`${baseUrl}/${payload.nameid}`, {
        headers: {
            Authorization: `Bearer ${localStorage.getItem("token")}`
        }
    }).then((response) => {
        return response.data
    }).catch((error) => {
        throw error;
    });

};

const getLoggedInUser = async (token: string) => {
    const payload: TokenPayload = jwtDecode<TokenPayload>(token);
    return await axios.get(`${baseUrl}/${payload.nameid}`, {
        headers: {
            Authorization: `Bearer ${token}`
        }
    }).then((response) => {
        return response.data
    }).catch((error) => {
        throw error;
    });

};

const updateUser = async (updatedUser: updatedUserProps) => {
    return await axios.put(`${baseUrl}`, updatedUser, {
        headers: {
            Authorization: `Bearer ${localStorage.getItem("token")}`,
        },
    });
};

export const auth = { register, login, getUserInfo, getLoggedInUser, updateUser }


