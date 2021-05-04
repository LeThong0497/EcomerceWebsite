import instance from '../httpClient';

class UserService {
  pathSer = "api/Users";

  getList() {
    return instance.get(this.pathSer);
  }
}

export default new UserService();