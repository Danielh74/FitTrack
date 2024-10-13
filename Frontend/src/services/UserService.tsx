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

const getLoggedInUser = (token: string) => {
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

const updateUser = (updatedUser: updatedUserProps) => {
    return axios.put(`${baseUrl}`, updatedUser, {
        headers: {
            Authorization: `Bearer ${localStorage.getItem("token")}`,
        },
    });
};

export const auth = { baseUrl, getUserInfo, getLoggedInUser, updateUser }


