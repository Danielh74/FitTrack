import { ErrorMessage, Field, Form, Formik } from "formik";
import { useState } from "react"
import { Link, useNavigate } from "react-router-dom";
import * as Yup from 'yup';
import { auth } from "../services/UserService";
import Card from "../components/Card";
import { dialogs } from "../dialogs/Dialogs";
import Loader from "../components/Loader";
import { handleApiErrors } from "../utils/Helpers";

function RegisterPage() {

    interface RegisterInputs {
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

    const [isLoading, setIsLoading] = useState(false);

    const navigate = useNavigate();

    const validationSchema = Yup.object({
        firstName: Yup.string().required().min(2, "First name has to be at least 2 characters"),
        lastName: Yup.string().required().min(2, "Last name has to be at least 2 characters"),
        age: Yup.number().required().positive().integer().max(120, "Age cannot exceed 120"),
        gender: Yup.string().required().min(3),
        goal: Yup.string().required().min(3),
        email: Yup.string().email("Invalid email").required("Email is required").matches(/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/, "Invalid email"),
        password: Yup.string().required().min(8).matches(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,}$/, "Password must have minimum 8 characters and contain at least one uppercase letter, one lowercase character and one special character."),
        validatePassword: Yup.string().oneOf([Yup.ref("password")], "Passwords must match"),
        agreedToTerms: Yup.boolean().required().oneOf([true], "You must agree to terms to continue")
    });

    const initialValues = {
        firstName: "",
        lastName: "",
        age: 1,
        gender: "",
        goal: "",
        email: "",
        password: "",
        validatePassword: "",
        agreedToTerms: false
    };

    const handleSubmit = async (inputs: RegisterInputs) => {
        setIsLoading(true);
        try {
            await auth.register(inputs);
            dialogs.SuccessAlert("Registration Successful");
            navigate("/login");
        } catch (error) {
            const errorMsg = handleApiErrors(error)
            dialogs.errorAlert(errorMsg);
        } finally {
            setIsLoading(false)
        }
    };

    return (
        <div className="register-bg block w-full pt-20 text-gray-900 bg-white  border border-t-0 border-gray-200 rounded-t-none shadow-sm sm:text-sm dark:bg-gray-900 dark:border-gray-600 dark:text-white block-canvas">
            <Formik
                initialValues={initialValues}
                validationSchema={validationSchema}
                onSubmit={handleSubmit}>
                {({ values }) => (
                    <Form className="flex flex-col items-center">
                        <Card title="Create an account">
                            <div className="flex flex-row">
                                <div className="flex flex-col gap-2 w-1/2 me-2 text-lg my-2">
                                    <label className="block mb-2 text-sm font-medium text-gray-900 dark:text-white" htmlFor="firstName">First Name</label>
                                    <Field
                                        id="firstName"
                                        placeholder="John"
                                        name="firstName"
                                        className="auth-field" />
                                    <ErrorMessage
                                        name="firstName"
                                        component="span"
                                        className="text-sm text-red-500" />
                                </div>
                                <div className="flex flex-col gap-2 w-1/2 ms-2 text-lg my-2">
                                    <label className="block mb-2 text-sm font-medium text-gray-900 dark:text-white" htmlFor="lastName">Last Name</label>
                                    <Field
                                        id="lastName"
                                        placeholder="Doe"
                                        name="lastName"
                                        className="auth-field" />
                                    <ErrorMessage
                                        name="lastName"
                                        component="span"
                                        className="text-sm text-red-500" />
                                </div>
                            </div>
                            <div className="flex flex-row">
                                <div className="flex flex-col gap-2 w-1/2 text-lg my-2">
                                    <label className="block mb-2 text-sm font-medium text-gray-900 dark:text-white" htmlFor="age">Age</label>
                                    <Field
                                        id="age"
                                        name="age"
                                        placeholder="18"
                                        className="auth-field" />
                                    <ErrorMessage
                                        name="age"
                                        component="span"
                                        className="text-sm text-red-500" />
                                </div>
                                <div className="flex flex-col gap-2 w-1/2 ms-4 text-lg my-2">
                                    <label className="block mb-2 text-sm font-medium text-gray-900 dark:text-white" htmlFor="gender">Gender</label>
                                    <Field
                                        as="select"
                                        id="gender"
                                        name="gender"
                                        className="auth-field"
                                        style={{ color: values.gender === '' ? '#9CA3AF' : 'black' }}>
                                        <option value="" className="text-gray-400">Select gender</option>
                                        <option value="Male" className="text-black">Male</option>
                                        <option value="Female" className="text-black">Female</option>
                                    </Field>
                                    <ErrorMessage
                                        name="gender"
                                        component="span"
                                        className="text-sm text-red-500" />
                                </div>
                            </div>

                            <div className="flex flex-col items-start my-2">
                                <label className="block mb-2 text-sm font-medium text-gray-900 dark:text-white" htmlFor="goal">Goal</label>
                                <Field
                                    as="select"
                                    id="goal"
                                    name="goal"
                                    className="auth-field"
                                    style={{ color: values.goal === '' ? '#9CA3AF' : 'black' }}>
                                    <option value="" className="text-gray-500" >Select goal</option>
                                    <option value="Build Mass" className="text-black">Build Mass</option>
                                    <option value="toning" className="text-black">toning</option>
                                </Field>
                                <ErrorMessage
                                    name="goal"
                                    component="span"
                                    className="text-sm text-red-500" />
                            </div>
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
                            <div className="flex flex-col items-start my-2">
                                <label htmlFor="validatePassword" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Validate Password</label>
                                <Field
                                    id="validatePassword"
                                    name="validatePassword"
                                    type="password"
                                    placeholder="••••••••"
                                    className="auth-field" />
                                <ErrorMessage
                                    name="validatePassword"
                                    component="span"
                                    className="text-sm text-red-500" />
                            </div>
                            <div className="flex items-start my-3">
                                <div className="flex items-center h-5">
                                    <Field
                                        type="checkbox"
                                        name="agreedToTerms"
                                        className="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-blue-300 dark:bg-gray-700 dark:border-gray-600 dark:focus:ring-blue-600 dark:ring-offset-gray-800" />
                                </div>
                                <div className="ml-3 text-sm">
                                    <label className="font-normal text-white dark:text-gray-300">I accept the </label>
                                    <Link to="#" className="font-medium text-blue-600 hover:underline dark:text-blue-500">Terms and Conditions</Link>
                                </div>
                                <ErrorMessage
                                    name="agreedToTerms"
                                    component="span"
                                    className="text-sm text-red-500" />
                            </div>

                            {isLoading ? <Loader /> : <button type="submit" className="w-full text-white bg-blue-600 hover:bg-primary-700 focus:ring-4 focus:outline-none focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800">Register</button>}
                        </Card>
                    </Form>
                )}
            </Formik>
        </div>
    )
}

export default RegisterPage