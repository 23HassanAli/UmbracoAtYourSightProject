import React from 'react'
import  { Route, Routes } from "react-router-dom";
import Barchart2 from './pages/Barchart2'
import Barchart from './pages/Barchart'
import Navbar from './components/Navbar'
import './index.css'

function App() {

    console.log(window.location.pathname);
 
  return (
    <div className='navigation'>
         <Navbar/>
        <Routes>
        <Route path='/barchart' element={<Barchart/>}>Barchart</Route>
        <Route path='/barchart2' element={<Barchart2/>}>Barchart 2</Route>
        </Routes>       
    </div>   
  )
}
export default App