import { Link } from 'react-router-dom'
import '../styles/background.scss';


function Home() {

    return (
        <main className="home-bg">
            <div className="flex flex-col text-white w-7/12">
                <h1 className='text-center p-5 text-6xl font-bold'>FitTrack by Avner</h1>
                <div className='p-5 font-light text-lg'>
                    <p>
                        Welcome to FitTrack, your all-in-one fitness platform designed to help you achieve your health goals, no matter your experience level.
                    </p>
                    <p>
                        FitTrack offers personalized workout plans tailored to your objective,
                        along with detailed tracking tools to monitor your progress over time.
                    </p>
                    <p>
                        Our app connects you with an expert trainer who crafts custom routines and nutritional guides to optimize your fitness journey.
                    </p>
                    <p>
                        FitTrack empowers you to take control of your fitness, stay consistent, and reach your full potential.
                    </p>
                </div>
                <Link className='bg-blue-500 rounded-xl text-center self-center px-10 py-1 font-semibold' to="/login">Login</Link>
                <p className='p-5'>Not a member yet? <Link to="/register" className="underline font-medium text-blue-500">Register now</Link></p>
            </div>
        </main>
    )
}

export default Home