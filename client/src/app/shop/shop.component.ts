import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/Product';
import { IProductBrand } from '../shared/models/ProductBrand';
import { IProductType } from '../shared/models/ProductType';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  products: IProduct[];
  brands: IProductBrand[];
  types: IProductType[];
  brandIdSelected = 0;
  typeIdSelected = 0;
  sortSelected = 'name';
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price:Low to High', value: 'priceAcs'},
    {name: 'Price:High to Low', value: 'priceDesc'}
  ];

  constructor(private readonly shopService: ShopService) {}

  ngOnInit() {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected, this.sortSelected).subscribe(
      (response) => {
        this.products = response.data;
      },
      (error) => {
        console.log(error);
      }
    );
  }
  getBrands() {
    this.shopService.getBrands().subscribe(
      (response) => {
        this.brands = [{id: 0, name: 'All'}, ...response];
      },
      (error) => {
        console.log(error);
      }
    );
  }
  getTypes() {
    this.shopService.getTypes().subscribe(
      (response) => {
        this.types = [{ id: 0, name: 'All' }, ...response];
      },
      (error) => {
        console.log(error);
      }
    );
  }
  onBrandSelected(brandId: number) {
    this.brandIdSelected = brandId;
    this.getProducts();
  }

  onTypeSelected(typeId: number){
    this.typeIdSelected = typeId;
    this.getProducts();
  }

  onSortSelected(sort: string){
    this.sortSelected = sort;
    this.getProducts();
  }
}
