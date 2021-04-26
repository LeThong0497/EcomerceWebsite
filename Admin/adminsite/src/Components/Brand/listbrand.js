import React, { useState, useEffect } from 'react';
import {
Table,
button,
} from 'reactstrap';
import {
  Link,
  
  useHistory
} from 'react-router-dom'
import brandService from '../../Service/brandService.js';




const ListBrand = () => {
  const [data, setData] = useState([]);
  const history = useHistory()
  useEffect(() => {
    fetchCategory();
  }, []);

  const fetchCategory = () => {
    brandService.getBrands().then((res) => {
      setData(res.data);
    });
  };

  const deleteBrand = (id) => {
    brandService.deleteBrand(id);
    setTimeout(() => {
      history.go(0);
    }, 1000);
  };

  const edit = (item) => {
    <Link to={"/brand:item"}></Link>
  };
  return (
    <Table>
      <thead>
        <tr>
          <th>STT</th>
          <th>Id</th>
          <th>Name</th>
          <th><Link to={"/brand"} className='btn btn-success mr-2'>Create</Link></th>
        </tr>
      </thead>
      <tbody>
        {data?.map(function (item, i) {
          return (
            <tr key={item.brandId}>
              <th scope="row">{i + 1}</th>
              <td>{item.brandId}</td>
              <td>{item.name}</td>
              <th>
                <Link to={"/brand/"+item.brandId} className='btn btn-primary mr-2'>Edit</Link>
                <button className='btn btn-danger mr-2' onClick={() => { deleteBrand(item.brandId) }}>Delete</button>
              </th>
            </tr>
          )
        })}
      </tbody>
    </Table>
  );
}

export default ListBrand;