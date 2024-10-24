import { useEffect, useState } from "react"
import { UsersList } from "../models/User";
import { auth } from "../services/UserService";
import { handleApiErrors } from "../utils/Helpers";
import { toast } from "react-toastify";
import Loader from "../components/Loader";
import Card from "../components/Card";
import { HiDotsHorizontal } from "react-icons/hi";

function Users() {
    const [users, setUsers] = useState<UsersList[]>(null);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [openDropdown, setOpenDropdown] = useState(null);

    useEffect(() => {
        const fetchAllUsers = () => {
            setIsLoading(true);
            auth.getAllUsers().then((response) => {
                console.log(response);
                setUsers(response);
            }).catch((error) => {
                const errorMsg = handleApiErrors(error);
                toast.error(errorMsg);
            }).finally(() => {
                setIsLoading(false);
            });
        }
        fetchAllUsers();
    }, [])

    const toggleDropdown = (id) => {
        setOpenDropdown(prevDropdown => (prevDropdown === id ? null : id)); // Toggle dropdown visibility
    };

    return (
        <div className="flex">
            {isLoading && <Loader />}
            {users ?
                <Card title="Users" customClass="m-2 dashboard-card">
                    <div className="overflow-x-auto rounded-md border mt-3 dark:border-black">
                        <table className="w-full text-sm text-center font-medium">
                            <thead className="text-xs bg-gray-200 dark:bg-gray-800 uppercase border-b">
                                <tr>
                                    <th scope="col" className="px-4 py-3">ID</th>
                                    <th scope="col" className="px-4 py-3">Full name</th>
                                    <th scope="col" className="px-4 py-3">Gender</th>
                                    <th scope="col" className="px-4 py-3">Age</th>
                                    <th scope="col" className="px-4 py-3">City</th>
                                    <th scope="col" className="px-4 py-3">Has agreed to terms</th>
                                    <th scope="col" className="px-4 py-3">Has filled health declaration</th>
                                    <th scope="col" className="px-4 py-3"><span>Actions</span></th>
                                </tr>
                            </thead>
                            <tbody>
                                {users.map((user) => (
                                    <tr key={user.id} className="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-t dark:border-gray-700">
                                        <th scope="row" className="px-4 py-3 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                                            {user.id}
                                        </th>
                                        <td className="px-4 py-3">{user.firstName} {user.lastName}</td>
                                        <td className="px-4 py-3">{user.gender}</td>
                                        <td className="px-4 py-3">{user.age}</td>
                                        <td className="px-4 py-3">{user.city}</td>
                                        <td className="px-4 py-3">{user.agreedToTerms ? 'yes' : 'no'}</td>
                                        <td className="px-4 py-3">{user.healthDeclarationId ? 'yes' : 'no'}</td>
                                        <td className="px-4 py-3 flex items-center justify-center">
                                            <button
                                                id="dropdown-button"
                                                onClick={() => toggleDropdown(user.id)}
                                                className="inline-flex items-center p-0.5 text-lg text-gray-500 hover:text-gray-800 rounded-lg focus:outline-none dark:text-gray-400 dark:hover:text-gray-100"
                                                type="button"
                                            >
                                                <HiDotsHorizontal />
                                            </button>
                                            {openDropdown === user.id && (
                                                <div className="absolute mt-40 me-11 z-10 w-44 bg-white rounded divide-y divide-gray-200 shadow dark:bg-gray-800 dark:divide-gray-600">
                                                    <ul className="py-1 text-sm text-gray-700 dark:text-gray-200" aria-labelledby="dropdown-button">
                                                        <li>
                                                            <a href="#" className="block py-2 px-4 font-medium hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">Show</a>
                                                        </li>
                                                        <li>
                                                            <a href="#" className="block py-2 px-4 font-medium hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">Edit</a>
                                                        </li>
                                                    </ul>
                                                    <div className="py-1">
                                                        <a href="#" className="block py-2 px-4 text-sm font-medium text-red-600 hover:bg-gray-100 dark:hover:bg-gray-600 dark:text-red-500 dark:hover:text-red-500">Delete</a>
                                                    </div>
                                                </div>
                                            )}
                                        </td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                    </div>

                </Card>
                : "No users"}
        </div>
    )
}

export default Users