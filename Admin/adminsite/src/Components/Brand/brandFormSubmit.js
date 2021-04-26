import React, { useState,useEffect } from "react";
import { useFormik } from "formik";
import { withRouter } from "react-router-dom";
import brandService from '../../Service/brandService.js';
import history from '../../Helpers/history';

const BrandForm = ({ match }) => {
  const [brandId, setBrandId] = useState(match.params.id);
  const [brand, setBrand] = useState({});

  const formik = useFormik({
    enableReinitialize: true,

    initialValues: {
      name: brand.name     
    },

    onSubmit: async (values) => {
      let result = window.confirm("Are you sure?");
      if (result) {
        let isCreate = brandId === undefined ? true : false;
        if (isCreate) {
          await brandService.create(values);
          history.goBack();
        } else {
          await brandService.edit(brandId, values);
          history.goBack();
        }
      }
    },
    
  });

  useEffect(() => {
    async function fetchData() {
      setBrandId(match.params.id);

      if (brandId !== undefined) {
        await fetchBrand(brandId);
      } 
      
    }

    fetchData();
  }, [match.params.id]);

  const fetchBrand = async (id) => {
    setBrand(await (await brandService.get(id)).data);
  };

  return (
    <form onSubmit={formik.handleSubmit}>
      <label htmlFor="name">Brand Name :</label>
      <input
        id="name"
        name="name"
        type="text"
        onChange={formik.handleChange}
        value={formik.values.name}
      />
        <button type="submit">Submit</button>
    </form>
  );
};

export default withRouter(BrandForm);