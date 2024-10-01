export interface User {
    id: string
    firstName: string
    lastName: string
    age: number
    gender: string
    city: string
    goal: string
    height: number
    weight: number
    abdominalCircumference: number
    agreedToTerms: boolean
    armCircumference: number
    bodyFatPrecentage: number
    healthDeclarationId: number | null
    hipsCircumference: number
    menu: Menu | null
    neckCircumference: number
    pecsCircumference: number
    plans: Plan[]
    thighsCircumference: number
    waistCircumference: number
};

export interface Menu {
    id: number
    userName: string
    menuDetails: MenuDetails[]
};

export interface MenuDetails {
    order: number
    name: string
    proteinPoints: number
    carbsPoints: number
    fatsPoints: number
};

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

