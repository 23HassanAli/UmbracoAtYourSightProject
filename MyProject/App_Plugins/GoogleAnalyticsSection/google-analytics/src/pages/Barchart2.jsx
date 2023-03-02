import React, {useState, useEffect} from 'react'
import axios from 'axios'
import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    BarElement,
    Title,
    Tooltip,
    Legend,
  } from 'chart.js';
import { Bar } from 'react-chartjs-2';
ChartJS.register(
    CategoryScale,
    LinearScale,
    BarElement,
    Title,
    Tooltip,
    Legend
  );
  export const options = {
    responsive: true,
    plugins: {
      legend: {
        position: 'top',
      },
      title: {
        display: true,
        text: 'Chart.js Bar Chart',
      },
    },
  };
function Barchart2() {
  
        const [labels, setLabel] = useState([]);
        const [data, setData] = useState([])
        useEffect(() => {
            axios.get('https://63f629b7ab76703b15b97dd7.mockapi.io/api/data/data')
            .then(res => {
                console.log("Barkschart")
                setLabel(res.data.map(x => x.cities))
                setData(res.data.map(x => x.searches))
              })
            .catch(err => {
                console.log(err)
            })
        },[])

        const object = {
            labels,
            datasets: [
              {
                label: 'Most searched terms per city',
                data: data,
                backgroundColor: 'rgba(53, 162, 235, 0.5)',
              }
              
            ],
          };
        
  return (
    <div>
        <h1>Most searched terms per city</h1>
        <div className='chart'>
         <Bar data={object} ></Bar>
        </div>
        
     
    </div>
    
  )
}

export default Barchart2