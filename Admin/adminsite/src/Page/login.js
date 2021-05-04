import React from "react";
import AccountService from "../Service/account.js"
import history from '../Helpers/history';
import { instanceOf } from 'prop-types';
import { withCookies, Cookies } from 'react-cookie';

class Login extends React.Component {
    static propTypes = {
        cookies: instanceOf(Cookies).isRequired
    };

    constructor(props) {
        super(props)

        //Check if user login 
        const { cookies } = this.props;
        if (cookies.get('user') != undefined) {
            history.push('/');
        }

        this.btnLoginClick = this.btnLoginClick.bind(this)
    }

    btnLoginClick(e) {
        e.preventDefault();
        let Email = document.getElementById("txtEmail").value;
        let Password = document.getElementById("txtPassword").value;

        if (Email == '' || Password == '') {
            document.getElementById('error').innerHTML = "Không chừa trống dữ liệu!";
        }
        else {
            AccountService.login(Email, Password).then((res) => {
                console.log(res);
                //Check if email or password invalid       
                if (res.status == 400) {
                    document.getElementById('error').innerHTML = "Email hoặc mật khẩu không chính xác!";

                }
                else {
                    const { cookies } = this.props;
                    cookies.set('user', res);
                    window.location.reload();
                }
                // AccountService.CheckRoles(res.access_token).then((response) => {
                //     if (response.data.role != 'admin') {
                //         document.getElementById('error').innerHTML = "Tài khoản không có quyền quản trị!";
                //     }
                //     else {
                //         const { cookies } = this.props;
                //         cookies.set('user', res);
                //         window.location.reload();
                //     }
                // })
            })
        }
    }

    render() {
        return (
            <div className="container  bg-white" style={{ boxShadow: 'rgba(149, 157, 165, 0.2) 0px 8px 24px', padding: 'unset', width: '35%',marginTop:100, marginBottom: 200 }}>
                <h5 className="text-center text-white bg-primary p-2 mb-3" style={{ borderWidth: 0 }}>Đăng nhập</h5>
                <div className="row  justify-content-md-center">
                    <div className="col-md-10">
                        <form>
                            <div className="input-group mt-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="basic-addon1"><i class="fas fa-envelope-square"/></span>
                                </div>
                                <input type="email" className="form-control" id="txtEmail" placeholder='Email' name='username' />
                            </div>
                            <div className="input-group mt-4">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="basic-addon1"><i class="fas fa-key"/></span>
                                </div>
                                <input type="password" id="txtPassword" className="form-control" placeholder='Mật khẩu' name='password' />
                            </div>
                            <p id="error" className="text-danger"></p>
                            <div className="form-group mt-4">
                                <button className="btn btn-primary btn-block" onClick={this.btnLoginClick}>
                                <i class="fas fa-sign-in-alt"/>&nbsp;Đăng nhập
                                    </button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        )
    }
}

export default withCookies(Login)