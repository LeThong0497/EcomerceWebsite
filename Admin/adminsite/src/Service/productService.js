import instance from '../httpClient';

class ProductService {
  pathSer = "api/Products";

  getList() {
    return instance.get(this.pathSer);
  }

  get(id) {
    return instance.get(this.pathSer + "/Product/" + id);
  }

  edit(id, objectEdit) {
    return instance.put(this.pathSer + "/" + id, objectEdit);
  }

  delete(id) {
    return instance.delete(this.pathSer + "/" + id);
  }

  create(objectNew) {
    return instance.post(this.pathSer, objectNew);
  }
}

export default new ProductService();