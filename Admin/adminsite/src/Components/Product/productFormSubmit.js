import React, { useState, useEffect } from "react";
import { Formik, useFormik } from "formik";
import { withRouter } from "react-router-dom";
import history from '../../Helpers/history';
import productService from "../../Service/productService";

const ProductSubmitForm = ({ match }) => {
  const [productId, setProductId] = useState(match.params.id);
  const [product, setProduct] = useState({});
  const [image, setImage] = useState([]);
  const [isCreate,setIsCreate] = useState(match.params.id===undefined?true:false);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    async function fetchdata() {
      setProductId(match.params.id);
      if (productId !== undefined) {
        productService.get(match.params.id).then((res) => {
            setProduct(res.data); 
            console.log("s",product);
            // setImage(product.images);
            // console.log("s2",image);
              
          });
      }
      
    }
    fetchdata();
  }, [match.params.id]);

  const formik = useFormik({
    enableReinitialize:true,

    initialValues: {
        name: product.name,
        price: product.price,
        cpu: product.cpu,
        screen: product.screen,
        hardDrive: product.hardDrive,
        card: product.card,
        size: product.size,
        gateWay: product.gateWay,
        quantity:product.quantity,
        brandID: product.brandID,
        //images: product.images===undefined?[]:[...product.images],  
        images:image    
    }
    ,

    onSubmit: async (values) => {
      let result = window.confirm("Are you sure?");

      console.log("values",values);
      if (result) {
        if (isCreate) {
          await productService.create(values); 
          history.goBack();
        } else {
          console.log("vl",productId);
          await productService.edit(productId, values);
          history.goBack();
        }
      }
    },
  });
 
 
  const uploadImage = async (e) => {
    const files = e.target.files;
    const data = new FormData();

    data.append("file", files[0]);
    data.append("upload_preset", "ecommerceshop");
    setLoading(true);

    const res = await fetch(
      "https://api.cloudinary.com/v1_1/thong04/image/upload",
      {
        method: "POST",
        body: data,
      }
    );
    const file = await res.json();
    setImage([...image,file.secure_url]);
    setLoading(false);

    if(isCreate){
    formik.values.images = [...formik.values.images,file.secure_url];
    }
    else {
      formik.values.images = [];
      formik.values.images=[...formik.values.images,image];
    }
  };
  return (
    <div className="ml-3 mr-5">
    <form onSubmit={formik.handleSubmit}>
      <div className="form-group">
        <label htmlFor="name">Product Name :</label>
        <input
          id="name"
          name="name"
          className="form-control"
          type="textarea"
          {...formik.getFieldProps('name')}
          value={formik.values.name}
        />
      </div>
        <div className="form-group">
          <label htmlFor="price">Price :</label>
          <input
            id="price"
            name="price"
            className="form-control"
            type="number"
            {...formik.getFieldProps('price')}
            value={formik.values.price}
          />

        <div className="form-group">
          <label htmlFor="cpu">CPU :</label>
          <input
            id="cpu"
            name="cpu"
            className="form-control"
            type="text"
            {...formik.getFieldProps('cpu')}
            value={formik.values.cpu}
          />
        </div>

        <div className="form-group">
          <label htmlFor="screen">Screen :</label>
          <input
            id="screen"
            name="screen"
            className="form-control"
            type="text"
            {...formik.getFieldProps('screen')}
            value={formik.values.screen}
          />
        </div>

        <div className="form-group">
          <label htmlFor="hardDrive">HardDrive :</label>
          <input
            id="hardDrive"
            name="hardDrive"
            className="form-control"
            type="text"
            {...formik.getFieldProps('hardDrive')}
            value={formik.values.hardDrive}
          />
        </div>

        <div className="form-group">
          <label htmlFor="card">Card :</label>
          <input
            id="Card"
            name="card"
            className="form-control"
            type="text"
            {...formik.getFieldProps('card')}
            value={formik.values.card}
          />
        </div>

        <div className="form-group">
          <label htmlFor="size">Size :</label>
          <input
            id="size"
            name="size"
            className="form-control"
            type="text"
            {...formik.getFieldProps('size')}
            value={formik.values.size}
          />
        </div>

        <div className="form-group">
          <label htmlFor="gateWay">GateWay :</label>
          <input
            id="gateWay"
            name="gateWay"
            className="form-control"
            type="text"
            {...formik.getFieldProps('gateWay')}
            value={formik.values.gateWay}
          />
        </div>

        <div className="form-group">
          <label htmlFor="quantity">Quantity :</label>
          <input
            id="quantity"
            name="quantity"
            className="form-control"
            type="number"
            {...formik.getFieldProps('quantity')}
            value={formik.values.quantity}
          />
        </div>

        <div className="form-group">
          <label htmlFor="brandID">Brand ID :</label>
          <input
            id="brandID"
            name="brandID"
            className="form-control"
            type="number"
            {...formik.getFieldProps('brandID')}
            value={formik.values.brandID}
          />
        </div>
      </div>
      
      <div className="form-group">
        <label htmlFor="images">Upload Image :</label>
        <input
          type="file"
          id="images"
          name="images"
          placeholder="Upload an image"
          onChange={uploadImage}
          style={{ display: "block" }}
        />
        {
          loading ? (
            <h3>Loading...</h3>
          ) : (
            <img src={image} style={{ width: "100px" }} alt="product-image" />
          )
        }
      </div>
      <button type="submit">Submit</button>
    </form>
    </div>
  );
};

export default withRouter(ProductSubmitForm);