import axios from "axios"
import { useEffect, useState } from "react"
import useAuth from "../hooks/useAuth";
import Loader from "../components/Loader";
import { Plan } from "../models/Plan";

const baseUrl = import.meta.env.VITE_BASE_URL + "/plans";
function Plans() {
    const { user, token } = useAuth();
    const [loading, setLoading] = useState<boolean>(false);
    const [plans, setPlans] = useState<Plan[]>([]);

    useEffect(() => {
        const fetchPlans = async () => {
            setLoading(true);
            try {
                await axios.get(baseUrl + "/" + user.id, {
                    headers: {
                        Authorization: `Bearer ${token}`
                    }
                })
                    .then((response) => {
                        console.log(response.data);
                        setPlans(response.data);
                    })
            } catch (error) {
                console.log(error);
            }
            finally {
                setLoading(false);
            }
        }

        fetchPlans();
    }, [user, token])
    return (
        <div>
            {loading && <Loader />}
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