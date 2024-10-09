import { Outlet } from 'react-router-dom'
import './App.css'
import Navbar from './components/Navbar'
import { ToastContainer } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css';
import Sidebar from './components/Sidebar';

function App() {

  return (
    <>
      <Navbar />
      <div>
        <Sidebar />
        <div>
          <Outlet />
        </div>
      </div>
      <ToastContainer />
    </>
  )
}

export default App
