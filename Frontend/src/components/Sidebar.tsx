import { NavLink } from 'react-router-dom'


const Sidebar = () => {

    return <nav id='app-nav' className="fixed top-16 left-0 w-32 h-[calc(100vh-4rem)] text-white bg-gray-800 p-4 z-40">

        <div className="flex-col min-h-full px-0 flex flex-wrap items-center justify-between w-full overflow-y-auto overflow-x-hidden">
            <div className="flex flex-col overflow-y-auto overflow-x-hidden h-auto z-40 items-center flex-1 rounded w-full">
                <div className=" flex flex-col list-none">
                    <NavLink to="/profile" className={({ isActive }) => `${isActive ? 'text-blue-500' : 'text-white '}  text-xs uppercase font-bold block pt-1 pb-4 no-underline`}>

                        <h6 className="ml-3">Profile</h6>
                    </NavLink>
                    <NavLink to="/plans" className={({ isActive }) => `${isActive ? 'text-blue-500' : 'text-white '}  text-xs uppercase font-bold block pt-1 pb-4 no-underline`}>

                        <h6 className="ml-3">Plans</h6>
                    </NavLink>
                    <NavLink to="/menu" className={({ isActive }) => `${isActive ? 'text-blue-500' : 'text-white '}  text-xs uppercase font-bold block pt-1 pb-4 no-underline`}>

                        <h6 className="ml-3">Menu</h6>
                    </NavLink>
                </div>
            </div>
        </div>
    </nav>;
}

export default Sidebar