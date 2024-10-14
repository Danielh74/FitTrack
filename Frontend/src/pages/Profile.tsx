
import { Field, Form, Formik } from "formik";
import useAuth from "../hooks/useAuth";
import { useState } from "react";
import "../styles/Form.scss"
import { auth } from "../services/UserService";
import { toast } from "react-toastify";
import { handleApiErrors } from "../utils/Helpers";
import bodyImage from '../assets/body.png';
import Card from "../components/Card";
import "../styles/Card.scss";
import { jwtDecode } from "jwt-decode";
import { TokenPayload } from "../models/User";

interface valuesType {
    city: string,
    age: number,
    goal: string,
    height: number,
    neck: number,
    pecs: number,
    arm: number,
    waist: number,
    abdominal: number,
    thighs: number,
    hips: number,
    weight: number
}

const Profile = () => {
    const { user, reloadUser, token } = useAuth();
    const [isDisabled, setIsDisabled] = useState<boolean>(true);

    const initialValues = {
        city: user.city,
        age: user.age,
        goal: user.goal,
        height: user.height,
        neck: user.neckCircumference,
        pecs: user.pecsCircumference,
        arm: user.armCircumference,
        waist: user.waistCircumference,
        abdominal: user.abdominalCircumference,
        thighs: user.thighsCircumference,
        hips: user.hipsCircumference,
        weight: user.weight[user.weight.length - 1]?.value ?? 0
    }



    const handleSubmit = (e: valuesType) => {
        const updatedValues = {
            city: e.city,
            age: e.age,
            goal: e.goal,
            height: e.height,
            weight: e.weight,
            neckCircumference: e.neck,
            pecsCircumference: e.pecs,
            armCircumference: e.arm,
            waistCircumference: e.waist,
            abdominalCircumference: e.abdominal,
            hipsCircumference: e.hips,
            thighsCircumference: e.thighs,

        };

        auth.updateUser(updatedValues).then((response) => {
            toast.success('Measurements updated successfully');
            reloadUser(response.data);
        }).catch((error) => {
            const errorMsg = handleApiErrors(error);
            toast.error(errorMsg)
        }).finally(() => {
            setIsDisabled(true);
        });
    };

    return (
        <div className="p-3 h-[calc(100vh-4rem)]">
            <div className="flex flex-col w-full">
                <Formik initialValues={initialValues} onSubmit={handleSubmit}>
                    {() => (
                        <Form className="flex flex-col">
                            <div className="flex flex-row justify-between">
                                <section className="flex flex-col w-1/2">
                                    <Card title="User info" className="profile-card h-1/2">
                                        <h1 className="flex flex-row font-medium text-2xl justify-center mb-4">
                                            {user.firstName + " " + user.lastName}
                                        </h1>
                                        <main className="flex flex-col">
                                            <div className="flex flex-row ms-5 mt-5 justify-around mb-2">
                                                <span>
                                                    <label>Age:</label>
                                                    <Field name="age" disabled={isDisabled} className='body-field' />
                                                </span>
                                                <span>
                                                    <label className="me-1">Gender:</label>
                                                    {user.gender}
                                                </span>
                                            </div>
                                            <div className="flex ms-5 mt-5 justify-around mb-2 ">
                                                <span>
                                                    <label>City:</label>
                                                    <Field name="city" disabled={isDisabled} className='body-field' />
                                                </span>
                                                <span>
                                                    <label>Goal: </label>
                                                    {isDisabled ?
                                                        <Field
                                                            as="input"
                                                            name="goal"
                                                            className="body-field"
                                                            disabled={isDisabled}>
                                                        </Field>
                                                        :
                                                        <Field
                                                            as="select"
                                                            name="goal"
                                                            className="body-select"
                                                            disabled={isDisabled}>
                                                            <option value="Build Mass" className="text-black">Build Mass</option>
                                                            <option value="toning" className="text-black">toning</option>
                                                        </Field>
                                                    }
                                                </span>
                                            </div>
                                            <span className="flex ms-5 mt-5 justify-center">
                                                Body fat: {user.bodyFatPrecentage === 0 ? "N/A" : user.bodyFatPrecentage + '%'}
                                            </span>
                                        </main>
                                    </Card>
                                    <Card title="Account info" className="profile-card mt-3 h-1/2">
                                        <article className="flex flex-col h-full">
                                            <span>
                                                Email: {jwtDecode<TokenPayload>(token).email}
                                            </span>
                                        </article>
                                    </Card>
                                </section>

                                <section className="flex flex-col w-1/2 ml-5">
                                    <Card title="Measurments" className="profile-card">
                                        <div className="flex flex-row justify-center">
                                            <div className="flex flex-col">
                                                <span className="flex mt-16 border-b-2 border-black">
                                                    <label>Neck:</label>
                                                    <Field name="neck" disabled={isDisabled} className='body-field' /> cm
                                                </span>
                                                <span className="flex mt-9 border-b-2 border-black">
                                                    <label>Arm:</label>
                                                    <Field name="arm" disabled={isDisabled} className="body-field" /> cm
                                                </span>
                                                <span className="flex mt-6 border-b-2 border-black">
                                                    <label>Abdominal:</label>
                                                    <Field name="abdominal" disabled={isDisabled} className="body-field" /> cm
                                                </span>
                                                <span className="flex mt-8 border-b-2 border-black">
                                                    <label>Thighs:</label>
                                                    <Field name="thighs" disabled={isDisabled} className="body-field" /> cm
                                                </span>
                                                <span className="flex mt-32">
                                                    <label>Height:</label>
                                                    <Field name="height" disabled={isDisabled} className="body-field" /> cm
                                                </span>
                                            </div>
                                            <div className="flex">
                                                <img src={bodyImage} alt="body" className="img" />
                                            </div>
                                            <div className="flex flex-col">
                                                <span className="flex mt-28 border-b-2 border-black">
                                                    <label>Chest:</label>
                                                    <Field name="pecs" disabled={isDisabled} className="body-field" /> cm
                                                </span>
                                                <span className="flex mt-4 border-b-2 border-black">
                                                    <label>Waist:</label>
                                                    <Field name="waist" disabled={isDisabled} className="body-field" /> cm
                                                </span>
                                                <span className="flex mt-4 border-b-2 border-black">
                                                    <label>Hips:</label>
                                                    <Field name="hips" disabled={isDisabled} className="body-field" /> cm
                                                </span>
                                                <span className="flex mt-40">
                                                    <label>Weight</label>
                                                    <Field name="weight" disabled={isDisabled} className="body-field" /> kg
                                                </span>
                                            </div>
                                        </div>
                                    </Card>
                                </section>
                            </div>
                            <div className="my-3 ml-16 self-center">
                                {isDisabled && <button
                                    className="bg-gray-400 border-2 border-black rounded-lg p-2 font-semibold"
                                    type="button"
                                    onClick={() => setIsDisabled(false)} >
                                    Edit information
                                </button>}
                                {!isDisabled && <button
                                    className="bg-blue-400 border-2 border-black rounded-lg p-2 font-semibold"
                                    type="submit" >
                                    Confirm
                                </button>
                                }
                            </div>
                        </Form>
                    )}
                </Formik>
            </div>
        </div >
    )
}

export default Profile