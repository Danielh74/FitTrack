import { Link } from 'react-router-dom'
import '../styles/background.scss';


function Home() {

    return (
        <>
            <div className="home-bg flex pl-10 pt-20 flex-col h-screen bg-slate-200 dark:bg-blue-900 text-white">

                <h1>Fit Track</h1>
                <p>This is the home page of Fit Track</p>
                <button className="bg-blue-500 rounded-lg w-16 border-2 border-black"><Link to="/login">Login</Link></button>
                <p>Still not a member yet? <Link to="/register" className="underline">Register</Link></p>
            </div>
        </>
    )
}

export default Home