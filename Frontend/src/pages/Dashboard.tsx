import { CircularProgressbar } from 'react-circular-progressbar';
import 'react-circular-progressbar/dist/styles.css';
import useAuth from '../hooks/useAuth';
import { useEffect, useState } from 'react';
import { Weight } from '../models/Weight';
import { Plan } from '../models/Plan';
import Card from '../components/Card';
import useTheme from '../hooks/useTheme';
import { LineChart, Line, CartesianGrid, XAxis, YAxis, Tooltip, ResponsiveContainer } from 'recharts';
import CustomTooltip from '../components/CustomTooltip';

const Dashboard = () => {
    const { user } = useAuth();
    const { darkMode, lightColor } = useTheme();
    const plansAmount = user.plans.length;
    const mealsAmount = user.menu === null ? 0 : user.menu.menuDetails.length;
    // const [plansAmount, setPlansAmount] = useState<number>(0);
    const [completedPlans, setCompletedPlans] = useState<number>(0);
    const [completedMeals, setCompletedMeals] = useState<number>(0);
    const [weightList, setWeightList] = useState<Weight[]>([]);

    useEffect(() => {
        const getValues = () => {
            // setPlansAmount(user.plans.length);

            user.plans.forEach((plan: Plan) => {

                if (plan.isCompleted) {
                    setCompletedPlans(prev => prev + 1);
                }
            });

            // user.menu.menuDetails.forEach((meal: MenuDetails) => {

            //     if (meal.isCompleted) {
            //         setCompletedPlans(prev => prev + 1);
            //     }
            // });

            user.weight.slice(user.weight.length - 10).forEach((weight: Weight) => {
                setWeightList(prevWeights => [...prevWeights, weight]);
            });
        };
        getValues();

        return () => {
            // setPlansAmount(0);
            setCompletedMeals(0)
            setCompletedPlans(0);
            setWeightList([]);
        }
    }, [user]);

    return (
        <div className='p-3 h-[calc(100vh-4rem)]'>
            <Card title='' customClass='dashboard-card h-1/3 mb-3'>
                <ResponsiveContainer>
                    <LineChart data={weightList}>
                        <XAxis dataKey="timeStamp" stroke={`${darkMode ? lightColor : 'black'}`} />
                        <YAxis dataKey="value" stroke={`${darkMode ? lightColor : 'black'}`} />
                        <CartesianGrid stroke="#ccc" strokeDasharray="5 5" />
                        <Line type="monotone" dataKey="value" stroke={`${darkMode ? '#2563eb' : '#274C77'}`} />
                        <Tooltip content={<CustomTooltip active={true} payload={weightList.map((w) => w.value)} label={weightList.map((w) => w.timeStamp)} />} />
                    </LineChart>
                </ResponsiveContainer>
            </Card>
            <div className='flex flex-row gap-3'>
                <div className='flex flex-col'>
                    <Card title='Workout progression' customClass='dashboard-card'>
                        <CircularProgressbar
                            className='pt-3'
                            value={plansAmount > 0 ? completedPlans / plansAmount * 100 : 0}
                            text={`${completedPlans}/${plansAmount}`}
                            styles={{
                                path: {
                                    stroke: `${completedPlans / plansAmount === 1 ? '#00ff00' : '#274C77'}`,
                                    strokeLinecap: 'round',
                                },
                                trail: {
                                    stroke: '#8B8C89'
                                },
                                text: {
                                    fill: `${darkMode ? lightColor : 'black'}`,
                                    fontWeight: 'bold',
                                    fontSize: '16px',
                                },
                            }}
                        />
                    </Card>
                </div>
                <div className='flex flex-col'>
                    <Card title='Meals progression' customClass='dashboard-card'>
                        <CircularProgressbar
                            className='pt-3'
                            value={mealsAmount > 0 ? completedMeals / mealsAmount * 100 : 0}
                            text={`${completedMeals}/${mealsAmount}`}
                            styles={{
                                path: {
                                    stroke: `${completedMeals / mealsAmount === 1 ? '#00ff00' : '#274C77'}`,
                                    strokeLinecap: 'round',

                                },
                                trail: {
                                    stroke: '#8B8C89'
                                },
                                text: {
                                    fill: `${darkMode ? lightColor : 'black'}`,
                                    fontWeight: 'bold',
                                    fontSize: '16px',
                                },
                            }}
                        />
                    </Card>
                </div>
                <div className='flex flex-col'>
                    <Card title='water progression' customClass='dashboard-card'>
                        <CircularProgressbar
                            className='pt-3'
                            value={plansAmount > 0 ? completedPlans / plansAmount * 100 : 0}
                            text={`${completedPlans}/${plansAmount}`}
                            styles={{
                                path: {
                                    stroke: `${completedPlans / plansAmount === 1 ? '#00ff00' : '#274C77'}`,
                                    strokeLinecap: 'round',
                                },
                                trail: {
                                    stroke: '#8B8C89'
                                },
                                text: {
                                    fill: `${darkMode ? lightColor : 'black'}`,
                                    fontWeight: 'bold',
                                    fontSize: '16px',
                                },
                            }}
                        />
                    </Card>
                </div>
                <div className='flex flex-row '>
                    <div className='flex flex-col gap-3'>
                        <Card title='Info card' customClass='dashboard-card'>
                            <span>Placeholder text that will be in this card</span>
                        </Card>
                        <Card title='Info card' customClass='dashboard-card'>
                            <span>Placeholder text that will be in this card</span>
                        </Card>
                        <Card title='Info card' customClass='dashboard-card'>
                            <span>Placeholder text that will be in this card</span>
                        </Card>
                    </div>

                </div>
            </div>
        </div>
    )
}

export default Dashboard