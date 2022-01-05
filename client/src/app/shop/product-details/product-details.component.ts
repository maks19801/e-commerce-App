import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasketItem } from 'src/app/shared/models/Basket';
import { IProduct } from 'src/app/shared/models/Product';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss'],
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  quantity = 1;

  constructor(
    private readonly shopService: ShopService,
    private readonly activatedRoute: ActivatedRoute,
    private readonly basketService: BasketService
  ) {}

  ngOnInit(): void {
    this.getProduct();
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.product, this.quantity);
  }

  incrementItemQuantity() {
    this.quantity++;
  }

  decrementItemQuantity() {
    if(this.quantity > 1)
    this.quantity--;
  }
  getProduct() {
    this.shopService
      .getProduct(+this.activatedRoute.snapshot.paramMap.get('id'))
      .subscribe(
        (product) => {
          this.product = product;
        },
        (error) => {
          console.log(error);
        }
      );
  }
}
