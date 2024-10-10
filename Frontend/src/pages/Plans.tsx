import { useEffect, useState } from "react"
import useAuth from "../hooks/useAuth";
import { Plan } from "../models/Plan";

function Plans() {
    const { user } = useAuth();
    const [plans, setPlans] = useState<Plan[]>([]);

    useEffect(() => {
        setPlans(user.plans);
    }, [user.plans])
    return (
        <div className="p-3 h-[calc(100vh-4rem)]">
            {plans ? plans.map((plan, i) => {
                const sortedPlanDetails = [...plan.planDetails].sort((a, b) => a.orderInPlan - b.orderInPlan)
                return (
                    <div key={i} className="flex-col">
                        <h1>{plan.name}</h1>
                        {sortedPlanDetails.map((s, j) =>
                            <ul key={j}>
                                <li>Order: {s.orderInPlan}</li>
                                <li>{s.exerciseName}</li>
                                <li>Reps: {s.reps}</li>
                                <li>Sets:{s.sets}</li>
                                <li> Description: {s.description}</li>
                            </ul>
                        )}
                    </div>
                )

            }
            )
                : "No plans"}
        </div>
    )
}

export default Plans