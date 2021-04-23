import instance from '../httpClient';

class brandService {
    pathSer = "api/Brands";

    async  getBrands(){
      return await instance.get(this.pathSer);
    }

    async  getBrand(id){
        return await instance.get(this.pathSer+ '/'+id);
    }

   async deleteBrand(id){
        return await instance.delete(this.pathSer+'/'+id);
    }
}

export default new brandService();