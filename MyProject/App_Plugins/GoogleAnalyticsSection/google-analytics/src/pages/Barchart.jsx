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
function Barchart() {
    const [labels, setLabel] = useState([]);
        const [data, setData] = useState([])
        useEffect(() => {
            axios.get('https://63f629b7ab76703b15b97dd7.mockapi.io/api/data/data')
            .then(res => {
                console.log("Barchart")
                setData(res.data.map(x => x.searched))
                setLabel(res.data.map(x => x.term))
              })
            .catch(err => {
                console.log(err)
            })
        },[])

        const object = {
            labels,
            datasets: [
              {
                label: 'Most searched terms',
                data: data,
                backgroundColor: 'rgba(255, 99, 132, 0.5)',
              }
              
            ],
          };
        
  return (
    <div>
        <h1>Most searched terms</h1>
        <div className='chart'>
        <Bar data={object} ></Bar>
        </div>
        
     
    </div>
  )
}

export default Barchart