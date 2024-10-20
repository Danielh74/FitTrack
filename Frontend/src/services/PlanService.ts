import axios from "axios";

interface updatedPlanProps {
    id: number,
    name: string,
    isCompleted: boolean,
}

const baseUrl = import.meta.env.VITE_BASE_URL + "/plans";

const getPlan = (id: number) => {
    return axios.get(`${baseUrl}/${id}`, {
        headers: {
            Authorization: `Bearer ${localStorage.getItem("token")}`,
        },
    });
};

const updatePlanComplete = (plan: updatedPlanProps) => {
    return axios.put(`${baseUrl}/${plan.id}`, { name: plan.name, isCompleted: plan.isCompleted }, {
        headers: {
            Authorization: `Bearer ${localStorage.getItem("token")}`,
        },
    });
};

export const planService = { updatePlanComplete, getPlan }