import { ErrorMessage, Field, Form, Formik } from "formik";
import { useContext, useState } from "react"
import { useNavigate } from "react-router-dom";
import * as Yup from 'yup';
import { auth } from "../services/AuthService";
import Card from "../components/Card";
import { dialogs } from "../dialogs/Dialogs";
import Loader from "../components/Loader";
import { AuthContext } from "../contexts/AuthContext";

const LoginPage = () => {
    interface LoginProps {
        email: string,
        password: string
    }

    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState<string>();

    const navigate = useNavigate();
    const { login } = useContext(AuthContext)

    const validationSchema = Yup.object({
        email: Yup.string().email("Invalid email").required("Email is required").matches(/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/, "Invalid email"),
        password: Yup.string().required().min(8).matches(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,}$/, "Password must have minimum 8 characters and contain at least one uppercase letter, one lowercase character and one special character.")
    });

    const initialValues = {
        email: "",
        password: ""
    };

    const handleSubmit = ({ email, password }: LoginProps) => {
        setIsLoading(true);

        auth.login(email, password)
            .then((response) => {
                dialogs.SuccessToast("Login Successfull")
                    .then(() => {
                        login(response.data.token);
                        navigate("/");
                    })
            }).catch((error) => {
                setError(error.message);
                dialogs.errorToast(error)
            }).finally(() => {
                setIsLoading(false)
            });
    }

    return (
        <div className="block w-full h-screen text-gray-900 bg-white border border-t-0 border-gray-200 rounded-t-none shadow-sm sm:text-sm dark:bg-gray-900 dark:border-gray-600 dark:text-white block-canvas">
            <Formik
                initialValues={initialValues}
                validationSchema={validationSchema}
                onSubmit={handleSubmit}>
                <Form className="flex flex-col items-center pt-10">
                    <Card title="Log-in">
                        <div className="flex flex-col items-start my-2">
                            <label className="block mb-2 text-sm font-medium text-gray-900 dark:text-white" htmlFor="email">Email</label>
                            <Field
                                type="email"
                                id="email"
                                name="email"
                                placeholder="name@company.com"
                                className="bg-gray-50 border-2 border-gray-400 text-gray-900 text-sm rounded-lg focus:ring-blue-600 focus:border-blue-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" />
                            <ErrorMessage
                                name="email"
                                component="span"
                                className="text-sm text-red-500" />
                        </div>
                        <div className="flex flex-col items-start my-2">
                            <label className="block mb-2 text-sm font-medium text-gray-900 dark:text-white" htmlFor="password">Password</label>
                            <Field
                                id="password"
                                name="password"
                                type="password"
                                placeholder="••••••••"
                                className="bg-gray-50 border-2 border-gray-400 text-gray-900 text-sm rounded-lg focus:ring-blue-600 focus:border-blue-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" />
                            <ErrorMessage
                                name="password"
                                component="span"
                                className="text-sm text-red-500" />
                        </div>
                        {error ?? <div>{error}</div>}
                        {isLoading ? <Loader /> : <button type="submit" className="w-full mt-4 text-white bg-blue-600 hover:bg-blue-700 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Login</button>}
                    </Card>
                </Form>
            </Formik>
        </div>


    )
}

export default LoginPage