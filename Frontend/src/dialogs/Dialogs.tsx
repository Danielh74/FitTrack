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

const showSuccessToast = (message: string) => {
    return Swal.fire({
        position: "top-end",
        icon: "success",
        title: message,
        showConfirmButton: false,
        color: "white",
        background: "green",
        width: 500,
        heightAuto: false,
        iconColor: "white",
        timer: 2000
    });
};

const showErrorToast = (message: string) => {
    return Swal.fire({
        position: "top-end",
        icon: "error",
        title: message,
        showConfirmButton: false,
        color: "white",
        background: "red",
        width: 500,
        heightAuto: false,
        iconColor: "white",
        timer: 2000
    })
};

export const dialogs = { SuccessAlert: showSuccessAlert, SuccessToast: showSuccessToast, errorAlert: showErrorAlert, errorToast: showErrorToast };