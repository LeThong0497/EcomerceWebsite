import instance from '../httpClient';

class AccountService {
    static login =  async (username, password) => {
        var urlencoded = new URLSearchParams();
        
        urlencoded.append("client_id", "react_admin");
        urlencoded.append("client_secret", "secret");
        urlencoded.append("grant_type", "password");
        urlencoded.append("scope","ecommerce.customer.api");
        urlencoded.append("username", username);
        urlencoded.append("password", password);


        return await instance.post('/connect/token', urlencoded)
            .then(response => {
                return response.data;
            })
            .catch(error => {
                if (error.response) {
                    return error.response;
                  }
            })
    }

    static CheckRoles = async (token) => {
        console.log(token);
        instance.defaults.headers.common['Authorization'] = `Bearer ${token}`
        return await instance.get('/connect/userinfo');
    }
}

export default AccountService
