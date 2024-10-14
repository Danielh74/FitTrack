import { ReactNode } from "react"

interface Props {
    title: string,
    children: ReactNode,
    className: string
}

const Card = ({ children, title, className }: Props) => {
    return (
        <div className={`${className}`}>
            <h1 className="text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl dark:text-white">
                {title}
            </h1>
            {children}
        </div>
    )
}

export default Card