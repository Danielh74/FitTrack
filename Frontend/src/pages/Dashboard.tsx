import { CircularProgressbar } from 'react-circular-progressbar';
import 'react-circular-progressbar/dist/styles.css';
import useAuth from '../hooks/useAuth';
import { useEffect, useState } from 'react';
import { Weight } from '../models/Weight';
import { Plan } from '../models/Plan';
import 'chart.js/auto';
import { Line } from "react-chartjs-2"
import { FaDumbbell } from 'react-icons/fa';
import Card from '../components/Card';

const Dashboard = () => {
    const { user } = useAuth();
    const [plansAmount, setPlansAmount] = useState<number>(0);
    const [completedPlans, setCompletedPlans] = useState<number>(0);
    const [weightList, setWeightList] = useState<number[]>([]);
    const [timeStamps, setTimeStamps] = useState<string[]>([]);

    useEffect(() => {
        const getValues = () => {
            setPlansAmount(user.plans.length);

            user.plans.forEach((plan: Plan) => {

                if (plan.isCompleted) {
                    setCompletedPlans(prev => prev + 1);
                }
            });

            user.weight.slice(user.weight.length - 10).forEach((weight: Weight) => {
                setWeightList(prevWeights => [...prevWeights, weight.value]);
                setTimeStamps(prevTimeStamps => [...prevTimeStamps, weight.timeStamp]);
            });
        };
        getValues();

        return () => {
            setPlansAmount(0);
            setCompletedPlans(0);
            setWeightList([]);
            setTimeStamps([]);
        }
    }, [user]);

    return (
        <div className='p-3 h-[calc(100vh-4rem)]'>
            <Card title='' customClass=' h-1/3 bg-white mb-3'>
                <Line
                    data={{
                        labels: timeStamps,
                        datasets: [{
                            label: `${weightList.length === 0 ? 'no data' : 'Weight progress'}`,
                            data: weightList,
                            backgroundColor: `${weightList.length === 0 ? 'white' : '#274C77'}`,
                            borderColor: `${weightList.length === 0 ? 'white' : '#274C77'}`,
                        }],
                    }}
                    options={{
                        responsive: true,
                        maintainAspectRatio: false,

                    }}
                />
            </Card>
            <div className='flex flex-row h-1/2'>
                <div className='flex flex-col h-64 w-64'>
                    <p className='flex flex-row items-center text-lg font-semibold gap-2 bg-white rounded-t-xl fixed ps-4'><FaDumbbell />Workout progression <FaDumbbell /> </p>
                    <Card title='' customClass='bg-white'>
                        <CircularProgressbar
                            className='pt-5 px-3'
                            value={plansAmount > 0 ? completedPlans / plansAmount * 100 : 0}
                            text={`${completedPlans}/${plansAmount}`}
                            styles={{
                                path: {
                                    stroke: `${completedPlans / plansAmount === 1 ? '#00ff00' : '#274C77'}`,
                                    strokeLinecap: 'round',
                                },
                                text: {
                                    fill: 'black',
                                    fontWeight: 'bold',
                                    fontSize: '16px',
                                },
                            }}
                        />
                    </Card>
                </div>

            </div>

            {/* <div className='flex flex-row h-1/2 mt-20 p-3'>
                <div className='bg-white flex flex-col h-64 w-64 rounded-xl'>
                    <div className=' flex felx-row text-center text-lg justify-center font-medium pt-1'>
                        <p className='flex items-center text-center flex-col'>Workout progression </p>
                        <div className='flex flex-col justify-center ps-1'><FaDumbbell /></div>

                    </div>
                    <CircularProgressbar
                        className='p-3'
                        value={plansAmount > 0 ? completedPlans / plansAmount * 100 : 0}
                        text={`${completedPlans}/${plansAmount}`}
                        styles={{
                            path: {
                                stroke: `${completedPlans / plansAmount === 1 ? '#00ff00' : '#274C77'}`,
                                strokeLinecap: 'round',
                            },
                            text: {
                                fill: 'black',
                                fontWeight: 'bold',
                                fontSize: '16px',
                            },
                        }}
                    />
                </div>

            </div> */}

        </div>
    )
}

export default Dashboard