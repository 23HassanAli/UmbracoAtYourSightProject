import React from 'react'
import  { NavLink } from "react-router-dom";
function Navbar() {
  return (
    <nav>
        <NavLink to='/barchart'>Barchart</NavLink>
        <NavLink to='/barchart2'>Barchart 2</NavLink>
    </nav>
  )
}

export default Navbar