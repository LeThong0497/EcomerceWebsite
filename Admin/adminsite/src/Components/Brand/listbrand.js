import React, { useState,useEffect} from 'react';
import 
{ Table,
  button 
} from 'reactstrap';
import brandService from '../../Service/brandService.js'




const ListBrand = () => {
  const [data, setData] = useState([]);
  useEffect(() => {
    fetchCategory();
  }, []);

  const fetchCategory = () => {
    brandService.getBrands().then((res) => {
      setData(res.data);
    });
  };

  const  deleteBrand = (id)=>{
    brandService.deleteBrand(id);
    window.location.reload();
  };
  return (
    <Table>
      <thead>
        <tr>
          <th>STT</th>
          <th>Id</th>
          <th>Name</th>
          <th><a className='btn btn-success' href=''>Create</a></th>
        </tr>
      </thead>
      <tbody>
        {data?.map(function (item,i) {
          return (
            <tr>
              <th scope="row">{i+1}</th>
              <td>{item.brandId}</td>       
              <td>{item.name}</td>
              <th>
                <a className='btn btn-primary mr-2' href=''>Edit</a>
                <button className='btn btn-danger mr-2' onClick={()=>{deleteBrand(item.brandId);console.log("hello")}}>Delete</button>

              </th>
           </tr>
          )
        })}             
      </tbody>
    </Table>
  );
}

export default ListBrand;