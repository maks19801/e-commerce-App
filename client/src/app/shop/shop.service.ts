import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/Pagination';
import { IProductBrand } from '../shared/models/ProductBrand';
import { IProductType } from '../shared/models/ProductType';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private readonly httpClient: HttpClient) {}

  getProducts(brandId?: number, typeId?: number) {

    let params = new HttpParams();
    if(brandId){
      params = params.append('brandId', brandId);
    }
    if(typeId){
      params = params.append('typeId', typeId);
    }
    return this.httpClient.get<IPagination>(
      this.baseUrl + 'products',{observe: 'response', params}
    ).pipe(
      map(response => {
        return response.body;
      })
    )
  }

  getBrands() {
    return this.httpClient.get<IProductBrand[]>(this.baseUrl + 'products/brands');
  }
  getTypes() {
    return this.httpClient.get<IProductType[]>(this.baseUrl + 'products/types');
  }
}
