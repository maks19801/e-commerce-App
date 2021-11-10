import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/Pagination';
import { IProductBrand } from '../shared/models/ProductBrand';
import { IProductType } from '../shared/models/ProductType';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/ShopParams';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private readonly httpClient: HttpClient) {}

  getProducts(shopParams: ShopParams) {

    let params = new HttpParams();
    if(shopParams.brandId !==0){
      params = params.append('brandId', shopParams.brandId);
    }
    if (shopParams.typeId !==0) {
      params = params.append('typeId', shopParams.typeId);
    }

    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber);
    params = params.append('pageSize', shopParams.pageSize);

    return this.httpClient.get<IPagination>(
      this.baseUrl + 'products',{observe: 'response', params}
    ).pipe(
      map(response => {
        console.log(response.body)
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
