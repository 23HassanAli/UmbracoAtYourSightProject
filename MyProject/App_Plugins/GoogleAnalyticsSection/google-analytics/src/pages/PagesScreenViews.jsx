import React,{useState, useEffect} from 'react'
import { Chart } from "react-google-charts";
import axios from 'axios'


function PagesScreenViews() {

    console.log("Page screen views");
    const options = {
      title: "Population of Largest U.S. Cities",
      chartArea: { width: "50%" },
      hAxis: {
        title: "Total Population",
        minValue: 0,
      },
      vAxis: {
        title: "City",
      },
    };
    const [data, setData] = useState([]);
  
    useEffect(() => {
        const interval = setInterval(() => {
            axios.get('http://localhost:3000/us-population')
            .then(res => {
                console.log("table")
                console.log(res.data)
                setData(res.data.map(x => x));
              })
            .catch(err => {
                console.log(err)
            })       
        }, 10000);
        return () => clearInterval(interval);
    },[])
  return (
    <div>
        <Chart
      chartType="BarChart"
      width="100%"
      height="400px"
      data={data}
      options={options}
    />
    </div>
  )
}

export default PagesScreenViews
