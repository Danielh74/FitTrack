import Card from "../components/Card"
import useAuth from "../hooks/useAuth";

function AdminDashboard() {
    const { currentUser } = useAuth();
    return (
        <div className="inline-flex w-full gap-3 p-3 ">
            <Card title="App Users" customClass="dashboard-card text-center">
                {currentUser?.plans?.length ?? 0}
            </Card>
            <Card title="Income" customClass="dashboard-card text-center">
                {currentUser?.plans?.length ?? 0}
            </Card>
            <Card title="Messages" customClass="dashboard-card text-center">
                {currentUser?.plans?.length ?? 0}
            </Card>
        </div>
    )
}

export default AdminDashboard