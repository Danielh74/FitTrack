import axios from "axios";

export const handleApiErrors = (error) => {
    if (axios.isAxiosError(error)) {
        if (error.response) {
            const status = error.response.status;
            if ([400, 401, 403, 404, 500].includes(status)) {
                return (error.response.data);
            }
        }
        return (error.message || "An error occurred");
    }
    return ("An unexpected error occurred");
};
