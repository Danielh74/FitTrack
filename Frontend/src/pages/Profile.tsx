
import { Field, Form, Formik } from "formik";
import useAuth from "../hooks/useAuth";
import { useState } from "react";
import "../styles/Form.scss"
import { auth } from "../services/UserService";
import { toast } from "react-toastify";
import { handleApiErrors } from "../utils/Helpers";
import bodyImage from '../assets/body.png';
interface valuesType {
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
    const { user, reloadUser } = useAuth();
    const [isDisabled, setIsDisabled] = useState<boolean>(true);

    const initialValues = {
        neck: user.neckCircumference,
        pecs: user.pecsCircumference,
        arm: user.armCircumference,
        waist: user.waistCircumference,
        abdominal: user.abdominalCircumference,
        thighs: user.thighsCircumference,
        hips: user.hipsCircumference,
        weight: user.weight[user.weight.length - 1]?.value ?? 0
    }



    const handleSubmit = async (e: valuesType) => {
        const updatedValues = {
            city: user.city,
            age: user.age,
            goal: user.goal,
            height: user.height,
            weight: e.weight,
            neckCircumference: e.neck,
            pecsCircumference: e.pecs,
            armCircumference: e.arm,
            waistCircumference: e.waist,
            abdominalCircumference: e.abdominal,
            hipsCircumference: e.hips,
            thighsCircumference: e.thighs,

        };

        try {
            const response = await auth.updateUser(updatedValues);
            if (response.status === 200) {
                toast.success('Measurements updated successfully');
                reloadUser(response.data);
            }
        } catch (error) {
            const errorMsg = handleApiErrors(error);
            toast.error(errorMsg)
        } finally {
            setIsDisabled(true);
        }
    };

    return (
        <div className="p-5 h-[calc(100vh-4rem)]">
            <div className="flex flex-row">
                <main className="flex flex-col w-1/2">
                    <div className="flex flex-row font-semibold text-xl justify-center">
                        {user.firstName + " " + user.lastName}
                    </div>
                    <div>
                        Age: {user.age}
                        <br />
                        Gender: {user.gender}
                        <br />
                        City: {user.city}
                        <br />
                        Height: {user.height / 100}m
                        <br />
                    </div>
                </main>

                <Formik initialValues={initialValues} onSubmit={handleSubmit}>
                    {() => (
                        <Form className="flex flex-col items-center w-1/2">
                            <div className="flex flex-row justify-center">
                                <div className="flex flex-col">
                                    <span className="flex mt-16 border-b-2 border-black">
                                        <label>Neck:</label>
                                        <Field name="neck" disabled={isDisabled} className='body-field' />
                                    </span>
                                    <span className="flex mt-9 border-b-2 border-black">
                                        <label>Arm:</label>
                                        <Field name="arm" disabled={isDisabled} className="body-field" />
                                    </span>
                                    <span className="flex mt-6 border-b-2 border-black">
                                        <label>Abdominal:</label>
                                        <Field name="abdominal" disabled={isDisabled} className="body-field" />
                                    </span>
                                    <span className="flex mt-8 border-b-2 border-black">
                                        <label>Thighs:</label>
                                        <Field name="thighs" disabled={isDisabled} className="body-field" />
                                    </span>
                                    <span className="flex mt-32">
                                        <label>Current weight:</label>
                                        <Field name="weight" disabled={isDisabled} className="body-field" />
                                    </span>
                                </div>
                                <div className="flex">
                                    <img src={bodyImage} alt="body" className="img" />
                                </div>
                                <div className="flex flex-col">
                                    <span className="flex mt-28 border-b-2 border-black">
                                        <label>Chest:</label>
                                        <Field name="pecs" disabled={isDisabled} className="body-field" />
                                    </span>
                                    <span className="flex mt-4 border-b-2 border-black">
                                        <label>Waist:</label>
                                        <Field name="waist" disabled={isDisabled} className="body-field" />
                                    </span>
                                    <span className="flex mt-4 border-b-2 border-black">
                                        <label>Hips:</label>
                                        <Field name="hips" disabled={isDisabled} className="body-field" />
                                    </span>
                                    <span className="flex mt-40">
                                        Body fat: {user.bodyFatPrecentage === 0 ? "N/A" : user.bodyFatPrecentage + '%'}
                                    </span>
                                </div>
                            </div>
                            <div className="mt-10 ml-16">
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