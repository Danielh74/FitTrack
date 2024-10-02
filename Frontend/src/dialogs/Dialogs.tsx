import Swal from "sweetalert2"

const showSuccessAlert = (message: string) => {
    return Swal.fire({
        icon: "success",
        title: "Success",
        text: message,
        timer: 2000
    })
};

const showErrorAlert = (message: string) => {
    return Swal.fire({
        icon: "error",
        title: "Error",
        text: message,
        timer: 2000
    })
};

export const dialogs = { SuccessAlert: showSuccessAlert, errorAlert: showErrorAlert };