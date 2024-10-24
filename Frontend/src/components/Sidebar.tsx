import { NavLink } from 'react-router-dom'
import useAuth from '../hooks/useAuth';


const Sidebar = () => {
    const { isAdmin } = useAuth();

    return <nav id='app-nav' className="fixed top-16 left-0 w-32 h-[calc(100vh-4rem)] sidebar-bg pt-4 z-40">

        <div className="flex-col min-h-full px-0 flex flex-wrap items-center justify-between w-full overflow-y-auto overflow-x-hidden">
            <div className="flex flex-col overflow-y-auto overflow-x-hidden h-auto z-40 items-center flex-1 rounded w-full">
                <div className=" flex flex-col">
                    {!isAdmin ?
                        <>
                            <NavLink to="/dashboard" className={({ isActive }) => `${isActive ? 'text-blue-600 text-lg' : 'text-md'} font-bold block pt-1 pb-4`}>

                                <h6 className="ml-3">Dashboard</h6>
                            </NavLink>
                            <NavLink to="/profile" className={({ isActive }) => `${isActive ? 'text-blue-600 text-lg' : 'text-md'} font-bold block pt-1 pb-4`}>

                                <h6 className="ml-3">Profile</h6>
                            </NavLink>
                            <NavLink to="/plans" className={({ isActive }) => `${isActive ? 'text-blue-600 text-lg' : 'text-md '} font-bold block pt-1 pb-4`}>

                                <h6 className="ml-3">Plans</h6>
                            </NavLink>
                            <NavLink to="/menu" className={({ isActive }) => `${isActive ? 'text-blue-600 text-lg' : 'text-md '} font-bold block pt-1 pb-4`}>

                                <h6 className="ml-3">Menu</h6>
                            </NavLink>
                        </>
                        :
                        <>
                            <NavLink to="/admin/dashboard" className={({ isActive }) => `${isActive ? 'text-blue-600 text-lg' : 'text-md'} font-bold block pt-1 pb-4`}>

                                <h6 className="ml-3">Admin Dashboard</h6>
                            </NavLink>
                            <NavLink to="/admin/users" className={({ isActive }) => `${isActive ? 'text-blue-600 text-lg' : 'text-md'} font-bold block pt-1 pb-4`}>

                                <h6 className="ml-3">Users</h6>
                            </NavLink>
                            <NavLink to="/plans" className={({ isActive }) => `${isActive ? 'text-blue-600 text-lg' : 'text-md '} font-bold block pt-1 pb-4`}>

                                <h6 className="ml-3">Plans</h6>
                            </NavLink>
                            <NavLink to="/menu" className={({ isActive }) => `${isActive ? 'text-blue-600 text-lg' : 'text-md '} font-bold block pt-1 pb-4`}>

                                <h6 className="ml-3">Menu</h6>
                            </NavLink>
                        </>
                    }

                </div>
            </div>
        </div>
    </nav>;
}

export default Sidebar