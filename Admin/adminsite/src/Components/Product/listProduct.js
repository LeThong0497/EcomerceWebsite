 
import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { Table, Button } from "reactstrap";
import ProductService from "../../Service/productService";

const ListProduct = () => {
  const [products, setProducts] = useState([]);
  useEffect(() => {
    fetchProduct();
  }, []);

  const fetchProduct = () => {
    ProductService.getList().then(({ data }) => {
      setProducts(data);
    });
  };
  //delete and update view
  const handleDelete = (id) => {
    let result = window.confirm("Delete this product?");
    if (result) {
      ProductService.delete(id).then(() => {
        setProducts(products.filter((item) => item.productId !== id));
      });
    }
  };

  return (
    <div>
      <Table>
        <thead>
          <tr>
            <th>STT</th>
            <th>Product Name</th>
            <th>CPU</th>
            <th>Screen</th>
            <th>HardDrive</th>
            <th>Card</th>
            <th>Size</th>
            <th>GateWay</th>
            <th>Price</th>
            <th>Image</th>
            <th className="text-right">
              <Link to={`/updateProduct/`} >
                <Button
                  className="btn btn-success"
                >
                  Create
                </Button>
              </Link>
            </th>
          </tr>
        </thead>
        <tbody>
          {products.map(function (item, i) {
            return (
              <tr>
                <th scope="row">{i+1}</th>
                <td>{item.name}</td>
                <td>{item.cpu}</td>
                <td>{item.screen}</td>
                <td>{item.hardDrive}</td>
                <td>{item.card}</td>
                <td>{item.size}</td>
                <td>{item.gateWay}</td>
                <td>{item.price}</td>
                <td>
                    <img src={item.images[0]} style={{height:"100px"}} alt="product-img" />
                </td>
                <td>
                  <Link to={`/updateProduct/${item.productId}`} >
                    <Button
                      className="btn btn-info"
                    >
                      Edit
                    </Button>
                  </Link>
                  
                  <Button
                    onClick={() => handleDelete(item.productId)}
                    className="btn btn-danger mt-2"
                  >
                    Delete
                  </Button>
                </td>
              </tr>
            );
          })}
        </tbody>
      </Table>
    </div>
  );
};

export default ListProduct;
