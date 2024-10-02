export interface Plan {
    id: number
    userName: string
    name: string
    planDetails: PlanDetails[]
};

export interface PlanDetails {
    orderInPlan: number
    exerciseName: string
    reps: number
    sets: number
    description: string
};