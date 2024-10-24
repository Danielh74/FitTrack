import { useEffect, useState } from "react"
import useAuth from "../hooks/useAuth"
import { Menu } from "../models/Menu";

function MenuPage() {
    const { currentUser } = useAuth();
    const [menu, setMenu] = useState<Menu | null>(null);
    useEffect(() => {
        setMenu(currentUser.menu);
    }, [currentUser.menu])

    return (
        <div className="p-3 h-[calc(100vh-4rem)]">
            {menu ? <>menu</> : <>no menu</>}
        </div>
    )
}

export default MenuPage