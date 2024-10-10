
import useAuth from "../hooks/useAuth";

const Profile = () => {

    const { user } = useAuth();

    return (
        <div className="p-5 h-[calc(100vh-4rem)]">
            <div className="flex flex-row">
                <main className="flex flex-col w-1/2">
                    <div className="flex flex-row font-semibold text-xl justify-center">
                        {user.firstName + " " + user.lastName}
                    </div>
                    <div>
                        Age: {user.age}
                        <br />
                        Gender: {user.gender}
                        <br />
                        City: {user.city}
                        <br />
                        Current weight: {user.weight[user.weight.length - 1]?.value ?? 0}
                        <br />
                        Body fat: {user.bodyFatPrecentage}%
                    </div>
                </main>
                <aside className="flex flex-row w-1/2 justify-center">
                    <div className="flex flex-col">
                        <span className="flex flex-col mt-10 border-b-2 border-black">
                            neck: {user.neckCircumference}
                        </span>
                        <span className="flex flex-col mt-7 border-b-2 border-black">
                            arm: {user.armCircumference}
                        </span>
                        <span className="flex flex-col mt-6 border-b-2 border-black">
                            abdominal: {user.abdominalCircumference}
                        </span>
                        <span className="flex flex-col mt-6 border-b-2 border-black">
                            thighs: {user.thighsCircumference}
                        </span>
                    </div>
                    <div className="flex flex-col">
                        <img src="/src/assets/body.png" alt="body" className="img" />
                    </div>
                    <div className="flex flex-col">
                        <span className="flex flex-row mt-20 border-b-2 border-black">
                            chest: {user.pecsCircumference}
                        </span>
                        <span className="flex flex-row mt-4 border-b-2 border-black">
                            waist:  {user.waistCircumference}
                        </span>
                        <span className="flex flex-row mt-4 border-b-2 border-black">
                            hips: {user.hipsCircumference}
                        </span>
                    </div>
                </aside>
            </div>
            <div className="flex justify-center mt-10">
                <button className="bg-gray-400 border-2 border-black rounded-lg p-2 font-semibold" onClick={() => console.log("Clicked")}>Edit information</button>
            </div>

        </div >
    )
}

export default Profile