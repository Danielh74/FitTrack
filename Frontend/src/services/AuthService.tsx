import axios from "axios";

const baseUrl = import.meta.env.VITE_BASE_URL + "/account";

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

const register = (props: RegisterProps) => {
    return axios.post(`${baseUrl}/register`, { props });
};

const login = (email: string, password: string) => {
    return axios.post(`${baseUrl}/login`, { email, password })
        .then((response) => {
            if (response.data.token) {
                localStorage.setItem("token", JSON.stringify(response.data));
            }
            return response;
        });
};

export const auth = { register, login }


