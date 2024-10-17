import { ReactNode } from "react"

interface Props {
    title: string,
    children: ReactNode,
    customClass: string
}

const Card = ({ children, title, customClass }: Props) => {
    return (
        <div className={`${customClass} card`}>
            <h1 className="text-2xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl dark:text-white">
                {title}
            </h1>
            {children}
        </div>
    )
}

export default Card