import { ReactNode } from "react"

interface Props {
    title: string,
    children: ReactNode
}

const Card = ({ children, title }: Props) => {
    return (
        <div className="w-full p-6 bg-white bg-opacity-30 backdrop-blur-sm rounded-lg shadow-xl dark:border md:my-4 sm:max-w-md xl:p-6 dark:bg-gray-800 dark:border-gray-700">
            <h1 className="text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl dark:text-white">
                {title}
            </h1>
            {children}
        </div>
    )
}

export default Card