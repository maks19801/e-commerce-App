import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/Pagination';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = 'https://localhost:5001/api/';

  constructor(private readonly httpClient: HttpClient) { }

  getProducts(){
    return this.httpClient.get<IPagination>(this.baseUrl + 'products?pageSize=50');
  }
}
