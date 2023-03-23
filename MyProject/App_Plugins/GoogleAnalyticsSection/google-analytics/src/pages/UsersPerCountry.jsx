import React,{useState, useEffect} from 'react'
import axios from 'axios'

function ObjectRow(props){
    return <tr className='border-bottom'>
            <td>{props.country}</td>
            <td>{props.users}</td>
            </tr>
}

function UsersPerCountry() {

    var topFive;
    const [data, setData] = useState([]);
    const [users, setUsers] = useState();
    useEffect(() => {
        const interval = setInterval(() => {
            axios.get('http://localhost:3000/current-users')
            .then(res => {
                setData(res.data.map(x => x));
              })
            .catch(err => {
                console.log(err)
            })       
        }, 1000);
        return () => clearInterval(interval);
    },[])
    //sort the object by users
    data.sort((a, b) => {
        return b.users - a.users;   
    })
    // select the top 5   
    topFive = data.slice(0, 5);

  return (
    <div>
        <table>
        <caption style={{fontWeight : "bold", color: "green", fontSize: "30px"}}>Current users on the page</caption>
        <thead>
            <tr className='border-bottom'>
                <th>Top Countries</th>
                <th>Users</th>
            </tr>  
            </thead>  
            <tbody>
                {topFive.map( x => <ObjectRow key={x.country} country={x.country} users={x.users}/>)}
              
            </tbody>  
        </table> 
    </div>
  )
}

export default UsersPerCountry