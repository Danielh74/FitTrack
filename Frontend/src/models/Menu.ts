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