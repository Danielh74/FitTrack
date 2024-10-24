import { ErrorMessage, Field, Form, Formik } from "formik";
import { useState } from "react"
import { Link } from "react-router-dom";
import * as Yup from 'yup';
import { auth } from "../services/UserService";
import Card from "../components/Card";
import Loader from "../components/Loader";
import { toast } from "react-toastify";
import useAuth from "../hooks/useAuth";
import "../styles/background.scss";
import "../styles/Form.scss";
import "../styles/Card.scss";
import { handleApiErrors } from "../utils/Helpers";

const LoginPage = () => {
    interface LoginInputs {
        email: string,
        password: string
    }

    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState<string>(null);

    const { handleLogin } = useAuth();

    const validationSchema = Yup.object({
        email: Yup.string().email("Invalid email").required("Email is required").matches(/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/, "Invalid email"),
        password: Yup.string().required().min(8).matches(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,}$/, "Password must have minimum 8 characters and contain at least one uppercase letter, one lowercase character and one special character.")
    });

    const initialValues = {
        email: "",
        password: ""
    };

    const handleSubmit = ({ email, password }: LoginInputs) => {
        setIsLoading(true);
        setError(null);

        auth.login({ email, password }).then((response) => {
            console.log(response);
            toast.success("Login Successful");
            handleLogin(response.token, response.user);
        }).catch((error) => {
            const errorMsg = handleApiErrors(error);
            toast.error(errorMsg);
            setError(errorMsg);
        }).finally(() => {
            setIsLoading(false);
        });
    };

    return (
        <div className="login-bg block w-full h-screen">
            <Formik
                initialValues={initialValues}
                validationSchema={validationSchema}
                onSubmit={handleSubmit}>

                <Form className="flex flex-col items-center pt-24">
                    <Card title="Log-in" customClass="auth-card">
                        <div className="flex flex-col items-start my-2">
                            <label className="block mb-2 text-sm font-medium text-gray-900 dark:text-white" htmlFor="email">Email</label>
                            <Field
                                type="email"
                                id="email"
                                name="email"
                                placeholder="name@company.com"
                                className="auth-field" />
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
                                className="auth-field" />
                            <ErrorMessage
                                name="password"
                                component="span"
                                className="text-sm text-red-500" />
                        </div>
                        {error && <div className="text-red-500 text-center font-bold">{error}</div>}
                        {isLoading ? <Loader /> : <button type="submit" className="w-full mt-4 text-white bg-blue-600 hover:bg-blue-700 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Login</button>}
                        <div className="text-sm font-medium text-black pt-3 ps-1 dark:text-white">
                            Not registered? <Link to="/register" className="text-blue-700 hover:underline dark:text-blue-500">Create account</Link>
                        </div>
                    </Card>
                </Form>
            </Formik>
        </div>
    )
}

export default LoginPage