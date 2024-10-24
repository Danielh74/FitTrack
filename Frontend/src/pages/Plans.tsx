import { useEffect, useState } from "react"
import useAuth from "../hooks/useAuth";
import { Plan } from "../models/Plan";
import PlanCard from "../components/PlanCard";

function Plans() {
    const { currentUser } = useAuth();
    const [plans, setPlans] = useState<Plan[]>([]);

    useEffect(() => {
        setPlans(currentUser.plans);
    }, [currentUser])

    return (
        <main className="flex flex-row p-3 items-center">
            {plans.length > 0 ? plans.map((plan) => {
                const sortedPlanDetails = [...plan.planDetails].sort((a, b) => a.orderInPlan - b.orderInPlan);
                return (
                    <article className="flex items-center w-full">
                        <PlanCard
                            id={plan.id}
                            name={plan.name}
                            planDetails={sortedPlanDetails}
                            isCompleted={plan.isCompleted}
                            customClass="m-2" key={plan.id}
                        />
                    </article >
                );
            }) : "No plans"}
        </main >
    );
};

export default Plans;