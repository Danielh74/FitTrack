
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
import { GiBodyHeight, GiMuscleFat, GiWeightScale } from "react-icons/gi";

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
    const { currentUser, reloadUser, token } = useAuth();
    const [isDisabled, setIsDisabled] = useState<boolean>(true);

    const initialValues = {
        city: currentUser.city,
        age: currentUser.age,
        goal: currentUser.goal,
        height: currentUser.height,
        neck: currentUser.neckCircumference,
        pecs: currentUser.pecsCircumference,
        arm: currentUser.armCircumference,
        waist: currentUser.waistCircumference,
        abdominal: currentUser.abdominalCircumference,
        thighs: currentUser.thighsCircumference,
        hips: currentUser.hipsCircumference,
        weight: currentUser.weight[currentUser.weight.length - 1]?.value ?? 0
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

        auth.updateCurrentUser(updatedValues).then((response) => {
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
        <div className="p-3">
            <div className="flex flex-col w-full">
                <Formik initialValues={initialValues} onSubmit={handleSubmit}>
                    {() => (
                        <Form className="flex flex-col">
                            <div className="flex flex-row justify-between">
                                <section className="flex flex-col w-1/2">
                                    <Card title="User info" customClass="profile-card h-1/2">
                                        <h1 className="flex flex-row font-medium text-2xl justify-center mb-4">
                                            {currentUser.firstName + " " + currentUser.lastName}
                                        </h1>
                                        <main className="flex flex-col">
                                            <div className="flex flex-row ms-5 mt-5 justify-around mb-2">
                                                <span>
                                                    <label>Age:</label>
                                                    <Field name="age" disabled={isDisabled} className='profile-field' />
                                                </span>
                                                <span>
                                                    <label className="me-1">Gender:</label>
                                                    {currentUser.gender}
                                                </span>
                                            </div>
                                            <div className="flex ms-5 mt-5 justify-around mb-2 ">
                                                <span>
                                                    <label>City:</label>
                                                    <Field name="city" disabled={isDisabled} className='profile-field' />
                                                </span>
                                                <span>
                                                    <label>Goal: </label>
                                                    {isDisabled ?
                                                        <Field
                                                            as="input"
                                                            name="goal"
                                                            className="w-20"
                                                            disabled={isDisabled}>
                                                        </Field>
                                                        :
                                                        <Field
                                                            as="select"
                                                            name="goal"
                                                            className="profile-select"
                                                            disabled={isDisabled}>
                                                            <option value="Build Mass" className="text-black">Build Mass</option>
                                                            <option value="toning" className="text-black">toning</option>
                                                        </Field>
                                                    }
                                                </span>
                                            </div>
                                            <span className="flex ms-5 mt-5 justify-center">
                                                <div className="pt-1 pr-1">
                                                    <GiMuscleFat />
                                                </div>
                                                Body fat: {currentUser.bodyFatPrecentage === 0 ? "N/A" : currentUser.bodyFatPrecentage + '%'}
                                            </span>
                                        </main>
                                    </Card>
                                    <Card title="Account info" customClass="profile-card mt-3 h-1/2">
                                        <article className="flex flex-col h-full">
                                            <span>
                                                Email: {jwtDecode<TokenPayload>(token).email}
                                            </span>
                                        </article>
                                    </Card>
                                </section>

                                <section className="flex flex-col w-1/2 ml-5">
                                    <Card title="Measurments" customClass="profile-card">
                                        <div className="flex flex-row justify-center">
                                            <div className="flex flex-col">
                                                <span className="flex mt-16 border-b-2 border-black">
                                                    <label>Neck:</label>
                                                    <Field name="neck" disabled={isDisabled} className='profile-field' /> cm
                                                </span>
                                                <span className="flex mt-9 border-b-2 border-black">
                                                    <label>Arm:</label>
                                                    <Field name="arm" disabled={isDisabled} className="profile-field" /> cm
                                                </span>
                                                <span className="flex mt-6 border-b-2 border-black">
                                                    <label>Abdominal:</label>
                                                    <Field name="abdominal" disabled={isDisabled} className="profile-field" /> cm
                                                </span>
                                                <span className="flex mt-8 border-b-2 border-black">
                                                    <label>Thighs:</label>
                                                    <Field name="thighs" disabled={isDisabled} className="profile-field" /> cm
                                                </span>
                                                <span className="flex mt-32">
                                                    <div className="pt-1 pr-1">
                                                        <GiBodyHeight />
                                                    </div>
                                                    <label> Height:</label>
                                                    <Field name="height" disabled={isDisabled} className="profile-field" /> cm
                                                </span>
                                            </div>
                                            <div className="flex">
                                                <img src={bodyImage} alt="body" className="body-img" />
                                            </div>
                                            <div className="flex flex-col">
                                                <span className="flex mt-28 border-b-2 border-black">
                                                    <label>Chest:</label>
                                                    <Field name="pecs" disabled={isDisabled} className="profile-field" /> cm
                                                </span>
                                                <span className="flex mt-4 border-b-2 border-black">
                                                    <label>Waist:</label>
                                                    <Field name="waist" disabled={isDisabled} className="profile-field" /> cm
                                                </span>
                                                <span className="flex mt-4 border-b-2 border-black">
                                                    <label>Hips:</label>
                                                    <Field name="hips" disabled={isDisabled} className="profile-field" /> cm
                                                </span>
                                                <span className="flex mt-40">
                                                    <div className="pt-1 pr-1">
                                                        <GiWeightScale />
                                                    </div>
                                                    <label>Weight</label>
                                                    <Field name="weight" disabled={isDisabled} className="profile-field" /> kg
                                                </span>
                                            </div>
                                        </div>
                                    </Card>
                                </section>
                            </div>
                            <div className="my-3 ml-16 self-center">
                                {isDisabled && <button
                                    className="profile-button-edit"
                                    type="button"
                                    onClick={() => setIsDisabled(false)} >
                                    Edit information
                                </button>}
                                {!isDisabled && <button
                                    className="profile-button-confirm"
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