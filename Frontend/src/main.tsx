import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import { RouterProvider } from 'react-router-dom'
import { router } from './routes/Router.tsx'
import { AuthProvider } from './contexts/AuthContext.tsx'
import { DarkModeProvider } from './contexts/DarkModeContext.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <AuthProvider>
      <DarkModeProvider>
        <RouterProvider router={router} />
      </DarkModeProvider>
    </AuthProvider>
  </StrictMode>,
)
