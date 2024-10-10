
import useAuth from "../hooks/useAuth";

const Profile = () => {

    const { user } = useAuth();

    return (
        <div className="p-5 h-[calc(100vh-4rem)]">
            <div className="flex flex-col">
                {user.weight}
                {user.bodyFatPrecentage}
                {user.firstName}
                {user.lastName}
                {user.age}
                {user.city}
                {user.gender}
            </div>
            <div className="flex flex-row justify-end">

                <div className="flex flex-col">
                    <div className="flex flex-row mt-10">
                        neck: {user.neckCircumference}
                    </div>
                    <div className="flex flex-row mt-9">
                        arm: {user.armCircumference}
                    </div>
                    <div className="flex flex-row mt-7">
                        abdominal: {user.abdominalCircumference}
                    </div>
                    <div className="flex flex-row mt-8">
                        thighs: {user.thighsCircumference}
                    </div>
                </div>
                <div className="flex flex-col">
                    <img src="/src/assets/body.png" alt="body" className="w-64 h-96" />
                </div>
                <div className="flex flex-col">
                    <div className="flex flex-row mt-20">
                        chest: {user.pecsCircumference}
                    </div>
                    <div className="flex flex-row mt-7">
                        waist:  {user.waistCircumference}
                    </div>
                    <div className="flex flex-row mt-5">
                        hips: {user.hipsCircumference}
                    </div>
                </div>
            </div>
        </div >
    )
}

export default Profile