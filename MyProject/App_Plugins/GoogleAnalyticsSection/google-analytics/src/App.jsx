import React from 'react'
import  { BrowserRouter,  Route, Routes, Router } from "react-router-dom";
import Barchart2 from './pages/Barchart2'
import Barchart from './pages/Barchart'
import Navbar from './components/Navbar'
import './index.css'
import Charts from './components/Charts';

function App() { 
  return (
    <div className='navigation'>   
      <Charts></Charts>            
    </div>   
  )
}
export default App