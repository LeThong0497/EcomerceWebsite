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

    async create(brandNew){
        return await instance.post(this.pathSer,brandNew);
    }

    async edit(id,brandUpdate){
        return await instance.put(this.pathSer+"/"+id,brandUpdate);
    }
}

export default new brandService();