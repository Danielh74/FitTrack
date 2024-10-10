import { Menu } from "./Menu"
import { Plan } from "./Plan"

export interface User {
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





