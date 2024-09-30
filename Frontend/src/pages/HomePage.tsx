import { Link } from 'react-router-dom'


function HomePage() {

    return (
        <>
            <div className="flex flex-col">
                <h1>Fit Track</h1>
                <p>This is the home page of Fit Track</p>
                <button className="bg-blue-500 rounded-lg w-1/12 border-2 border-black"><Link to="/login"></Link>Login</button>
                <p>Still not a member yet? <Link to="/register" className="underline">Register</Link></p>
            </div>
        </>
    )
}

export default HomePage