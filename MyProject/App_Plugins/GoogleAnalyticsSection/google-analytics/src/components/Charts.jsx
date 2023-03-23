import React from 'react'
import Barchart from '../pages/Barchart'
import Barchart2 from '../pages/Barchart2'
import PagesScreenViews from '../pages/PagesScreenViews'
import UsersPerCountry from '../pages/UsersPerCountry'

function charts() {
  return (
    <div className='grid-container'>
      <div className='grid-item'>
        <UsersPerCountry/>
      </div>
      <div className='grid-item'>
        <PagesScreenViews/>
      </div>
      <div className='grid-item'>
        <Barchart/>
      </div>
      <div className='grid-item'>
        <Barchart2/>
      </div>        
    </div>
  )
}

export default charts