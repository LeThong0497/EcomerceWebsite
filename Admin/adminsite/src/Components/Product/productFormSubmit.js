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
        images: product.images===undefined?[]:[...product.images],      
    }
    ,

    onSubmit: async (values) => {
      let result = window.confirm("Are you sure?");
      if(!isCreate){
          values.images = [];
          values.images.push(image);
      }
      if (result) {
        if (isCreate) {
          await productService.create(values); 
          history.goBack();
        } else {
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
    setImage(file.secure_url);
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
    <form onSubmit={formik.handleSubmit}>
      <div className="form-group">
        <label htmlFor="name">Product Name</label>
        <input
          id="name"
          name="name"
          className="form-control"
          type="textarea"
          {...formik.getFieldProps('name')}
          value={formik.values.name}
        />
      </div>
      <div className="form-group row">
        <div className="form-group col">
          <label htmlFor="price">Price</label>
          <input
            id="price"
            name="price"
            type="number"
            {...formik.getFieldProps('price')}
            value={formik.values.price}
          />
        </div>

        <div className="form-group col">
          <label htmlFor="cpu">CPU</label>
          <input
            id="cpu"
            name="cpu"
            type="text"
            {...formik.getFieldProps('cpu')}
            value={formik.values.cpu}
          />
        </div>

        <div className="form-group col">
          <label htmlFor="screen">Screen</label>
          <input
            id="screen"
            name="screen"
            type="text"
            {...formik.getFieldProps('screen')}
            value={formik.values.screen}
          />
        </div>

        <div className="form-group col">
          <label htmlFor="hardDrive">HardDrive</label>
          <input
            id="hardDrive"
            name="hardDrive"
            type="text"
            {...formik.getFieldProps('hardDrive')}
            value={formik.values.hardDrive}
          />
        </div>

        <div className="form-group col">
          <label htmlFor="card">Card</label>
          <input
            id="Card"
            name="card"
            type="text"
            {...formik.getFieldProps('card')}
            value={formik.values.card}
          />
        </div>

        <div className="form-group col">
          <label htmlFor="size">Size</label>
          <input
            id="size"
            name="size"
            type="text"
            {...formik.getFieldProps('size')}
            value={formik.values.size}
          />
        </div>

        <div className="form-group col">
          <label htmlFor="gateWay">GateWay</label>
          <input
            id="gateWay"
            name="gateWay"
            type="text"
            {...formik.getFieldProps('gateWay')}
            value={formik.values.gateWay}
          />
        </div>

        <div className="form-group col">
          <label htmlFor="quantity">Quantity</label>
          <input
            id="quantity"
            name="quantity"
            type="number"
            {...formik.getFieldProps('quantity')}
            value={formik.values.quantity}
          />
        </div>

        <div className="form-group col">
          <label htmlFor="brandID">Brand Id</label>
          <input
            id="brandID"
            name="brandID"
            type="number"
            {...formik.getFieldProps('brandID')}
            value={formik.values.brandID}
          />
        </div>
      </div>
      
      <div className="form-group">
        <label htmlFor="images">Upload Image</label>
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
  );
};

export default withRouter(ProductSubmitForm);