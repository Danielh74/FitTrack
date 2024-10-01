import { Link, NavLink } from 'react-router-dom'

type Props = {}

const Sidebar = (props: Props) => {
    return (
        <nav className=" bg-blue-400 block py-4 px-6 top-0 bottom-0 w-64 rounded-r-xl h-screen shadow-xl left-0 flex-row flex-nowrap md:z-10 z-9999 transition-all duration-300 ease-in-out transform md:translate-x-0 -translate-x-full">

            <button className="md:hidden flex items-center justify-center cursor-pointer text-blueGray-700 w-6 h-10 border-l-0 border-r border-t border-b border-blueGray-100 text-xl leading-none bg-white rounded-r border border-solid border-transparent absolute top-1/2 -right-24-px focus:outline-none z-9998">
                <i className="fas fa-ellipsis-v"></i>
            </button>

            <div className="flex-col min-h-full px-0 flex flex-wrap items-center justify-between w-full mx-auto overflow-y-auto overflow-x-hidden">
                <div className="flex bg-white flex-col opacity-100 relative mt-4 overflow-y-auto overflow-x-hidden h-auto z-40 items-center flex-1 rounded w-full">
                    <div className="md:flex-col md:min-w-full flex flex-col list-none">
                        <NavLink to="/company/:ticker/companyProfile" className="md:min-w-full text-blueGray-500 text-xs uppercase font-bold block pt-1 pb-4 no-underline">

                            <h6 className="ml-3">Profile</h6>
                        </NavLink>
                        <NavLink to="/company/:ticker/companyProfile" className="md:min-w-full text-blueGray-500 text-xs uppercase font-bold block pt-1 pb-4 no-underline">

                            <h6 className="ml-3">Plan</h6>
                        </NavLink>
                        <NavLink to="/company/:ticker/incomeStatement" className="md:min-w-full text-blueGray-500 text-xs uppercase font-bold block pt-1 pb-4 no-underline">

                            <h6 className="ml-3">Menu</h6>
                        </NavLink>
                    </div>
                </div>
            </div>
        </nav>
    )
}

export default Sidebar