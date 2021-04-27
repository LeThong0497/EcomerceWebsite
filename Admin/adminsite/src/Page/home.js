import { BrowserRouter ,Route } from 'react-router-dom';
import {
    Link,
    Router,
    Switch
    } from  'react-router-dom';

import ListBrand from '../Components/Brand/listbrand'
import BrandSubmitForm from '../Components/Brand/brandFormSubmit';
import ListProduct from '../Components/Product/listProduct';
import ProductSubmitForm from '../Components/Product/productFormSubmit';
import history from "../Helpers/history";

import {
    LIST_BRAND,
    UPDATE_BRAND,
    CREATE_BRAND,
    LIST_USER,
    LIST_PRODUCT,
    UPDATE_PRODUCT,
    CREATE_PRODUCT,
  } from "../Configure/routerConfig.js";
  
  const Home = () => {
    // const { user, isAuthenticated, isLoading } = useAuth0();
    // console.log("login",user);
    return (
      <Router history={history}>
        <div>
          <div className="d-flex" id="wrapper">
            <div className="bg-light border-right" id="sidebar-wrapper">
              <div className="sidebar-heading">Gear </div>
              <div className="list-group list-group-flush">
                {/* <Link
                  to={LIST_USER}
                  className="list-group-item list-group-item-action bg-light"
                >
                  Users
                </Link> */}
                <Link
                  to={LIST_BRAND}
                  className="list-group-item list-group-item-action bg-light"
                >
                  Brands
                </Link>
                <Link
                  to={LIST_PRODUCT}
                  className="list-group-item list-group-item-action bg-light"
                >
                  Products
                </Link>
              </div>
            </div>
            <div id="page-content-wrapper">
              <nav className="navbar navbar-expand-lg navbar-light bg-light border-bottom">
                <button
                  className="navbar-toggler"
                  type="button"
                  data-toggle="collapse"
                  data-target="#navbarSupportedContent"
                  aria-controls="navbarSupportedContent"
                  aria-expanded="false"
                  aria-label="Toggle navigation"
                >
                  <span className="navbar-toggler-icon"></span>
                </button>

                <div
                  className="collapse navbar-collapse"
                  id="navbarSupportedContent"
                >
                  <ul className="navbar-nav ml-auto mt-2 mt-lg-0">
                    <li className="nav-item">
                      {/* {isAuthenticated&&<a>Welcome, {user.nickname}!</a>} */}
                    </li>
                    {/* <li className="nav-item">
                      <LoginButton />
                    </li>
                    <li className="nav-item">
                      <LogoutButton />
                    </li> */}
                  </ul>
                </div>
              </nav>
              <div>
                <Switch>
                  {/* <Route path={DASHBOARD_PAGE}>
                    <h2>Welcome back, my admin!</h2>
                    <Profile /> 
                  </Route> */}
                  <Route path={LIST_BRAND}>
                    <ListBrand />
                  </Route>
                  <Route path={UPDATE_BRAND}>
                    <BrandSubmitForm />
                  </Route>
                  <Route path={CREATE_BRAND}>
                    <BrandSubmitForm />
                  </Route>
                  <Route path={LIST_PRODUCT}>
                    <ListProduct />
                  </Route>
                  <Route path={UPDATE_PRODUCT}>
                    <ProductSubmitForm />
                  </Route>
                  <Route path={CREATE_PRODUCT}>
                    <ProductSubmitForm />
                  </Route>
                  {/* <Route path={LIST_USER}>
                    <ListUser />
                  </Route> */}
                </Switch>
              </div>
            </div>
          </div>
        </div>
      </Router>
    );
  };
  
  export default Home;
  