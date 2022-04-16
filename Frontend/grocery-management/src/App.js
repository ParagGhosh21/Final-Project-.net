import axios from 'axios';
import { useEffect, useState } from 'react';
import './App.css';

function App() {
  
  const [doctors,setDoctors]= useState([]);

  useEffect(function () {
    axios.get("https://localhost:44346/api/sellerList")
        .then(function (rsp) {
            //console.log(rsp)
             setDoctors(rsp.data);
        }, function (err) {

        });
}, []);

console.log(doctors);

  return (
    <div className="App">
      hello
    </div>
  );
}

export default App;
