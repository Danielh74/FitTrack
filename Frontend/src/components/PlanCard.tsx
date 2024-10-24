import { useState } from "react"
import '../styles/Card.scss';
import useTheme from "../hooks/useTheme";
import { planService } from "../services/PlanService";
import useAuth from "../hooks/useAuth";
import { toast } from "react-toastify";
import { Plan, PlanDetails } from "../models/Plan";
import { handleApiErrors } from "../utils/Helpers";
import { FaRegCirclePlay } from "react-icons/fa6";
import Card from "./Card";
import Loader from "../components/Loader";

interface Props {
    id: number,
    name: string,
    isCompleted: boolean,
    planDetails: PlanDetails[],
    customClass?: string
}

const PlanCard = ({ name, id, isCompleted, planDetails, customClass = '' }: Props) => {
    const { darkMode } = useTheme();
    const { currentUser, reloadUser } = useAuth();
    const [isChecked, setIsChecked] = useState(isCompleted);
    const [isLoading, setIsLoading] = useState<boolean>(false);

    const handleChecked = (e) => {
        setIsLoading(true);
        const checked = e.target.checked;
        setIsChecked(checked);

        const updatedPlan = {
            id: id,
            name: name,
            isCompleted: checked,
        }

        planService.updatePlanComplete(updatedPlan)
            .then((response) => {
                const updatedList: Plan[] = currentUser.plans.map((p) => {
                    if (p.id === updatedPlan.id) {
                        return response.data;
                    }
                    return p;
                });

                reloadUser({ ...currentUser, plans: updatedList });

                if (checked) {
                    toast.success('Plan completed, good job!');
                }
            }).catch((error) => {
                const errorMsg = handleApiErrors(error);
                toast.error(errorMsg);
                console.error('Update Plan Error:', error);
            }).finally(() => {
                setIsLoading(false);
            });
    };

    return (
        <div
            style={{ backgroundColor: isChecked && (darkMode ? '#2b7a40' : 'lightgreen') }}
            className={`${customClass} plan-card card shadow-xl`}>
            {isLoading &&
                (<div className="absolute inset-0 flex justify-center items-center">
                    <Loader />
                </div>)}

            <h1>
                <input
                    type="checkbox"
                    checked={isChecked}
                    onChange={handleChecked}
                    className="plan-checkbox"
                    id={`${id}`}
                />
                <label htmlFor={`${id}`}>{name}</label>
            </h1>
            {planDetails.map((ex) => (
                <Card title='' customClass="mb-2" key={ex.orderInPlan}>
                    <div>
                        <div className="flex flex-row justify-between">
                            <div className="flex flex-col">
                                <div className="text-lg font-semibold">
                                    <span className="me-1">{ex.orderInPlan}.</span>
                                    <span>{ex.exerciseName}</span>
                                </div>
                                <div>
                                    {ex.reps} reps, {ex.sets} sets
                                </div>
                            </div>
                            <div className="flex flex-col justify-center">
                                <button className="text-black dark:text-white text-2xl">
                                    <FaRegCirclePlay />
                                </button>
                            </div>
                        </div>
                        <div className="flex flex-row gap-10 text-sm">
                            <div>
                                Previous weight: {ex.previousWeight ? ex.previousWeight + ' kg' : '--'}
                            </div>
                            <div>
                                Current weight: {ex.currentWeight ? ex.currentWeight + ' kg' : '--'}
                            </div>
                        </div>
                    </div>
                </Card>
            ))}

            Completed? {isCompleted ? 'yes' : 'no'}

        </div>
    );
};

export default PlanCard;