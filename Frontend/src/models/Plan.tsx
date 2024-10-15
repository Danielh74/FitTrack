export interface Plan {
    id: number
    userName: string
    isCompleted: boolean
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