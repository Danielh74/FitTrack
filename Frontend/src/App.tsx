import { Outlet } from 'react-router-dom'
import './App.css'
import Navbar from './components/Navbar'
import { ToastContainer } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css';
import Sidebar from './components/Sidebar';
import useAuth from './hooks/useAuth';

function App() {
  const { isLoggedIn } = useAuth();
  return (
    <>
      <Navbar />
      {isLoggedIn ?
        <>
          <Sidebar />
          <div className="pl-32 pt-16">
            <Outlet />
          </div>
        </>
        :
        <Outlet />
      }
      <ToastContainer />
    </>
  )
}

export default App
