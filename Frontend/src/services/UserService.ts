import axios from "axios";
import { TokenPayload } from "../models/User";
import { jwtDecode } from "jwt-decode";

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

const baseUrl = import.meta.env.VITE_BASE_URL + "/accounts";

const register = (registerInputs) => {

    return axios.post(`${baseUrl}/register`, registerInputs).then((response) => {
        return response
    }).catch((error) => {
        throw error;
    });
};
const login = ({ email, password }) => {

    return axios.post(`${baseUrl}/login`, { email, password }).then((response) => {
        return response.data
    }).catch((error) => {
        throw error;
    });
};

const getUserInfo = (payload: TokenPayload) => {
    const token = localStorage.getItem("token");
    if (!token) {
        throw new Error("No token found. User is not authenticated.");
    }
    return axios.get(`${baseUrl}/${payload.nameid}`, {
        headers: {
            Authorization: `Bearer ${token}`
        }
    }).then((response) => {
        return response.data
    }).catch((error) => {
        throw error;
    });
};

const getCurrentUser = (token: string) => {
    const payload: TokenPayload = jwtDecode<TokenPayload>(token);
    return axios.get(`${baseUrl}/${payload.nameid}`, {
        headers: {
            Authorization: `Bearer ${token}`
        }
    }).then((response) => {
        return response.data;
    }).catch((error) => {
        throw error;
    });
};

const getAllUsers = () => {
    const token = localStorage.getItem("token");
    return axios.get(`${baseUrl}/admin`, {
        headers: {
            Authorization: `Bearer ${token}`
        }
    }).then((response) => {
        return response.data;
    }).catch((error) => {
        throw error;
    });
};

const updateCurrentUser = (updatedUser: updatedUserProps) => {
    return axios.put(`${baseUrl}`, updatedUser, {
        headers: {
            Authorization: `Bearer ${localStorage.getItem("token")}`,
        },
    });
};

export const auth = { register, login, getUserInfo, getCurrentUser, getAllUsers, updateCurrentUser }


