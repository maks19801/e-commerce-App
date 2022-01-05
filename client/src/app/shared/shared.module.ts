import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbCarouselModule, NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { PaginationHeaderComponent } from './components/pagination-header/pagination-header.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { OrderTotalsComponent } from './components/order-totals/order-totals.component';



@NgModule({
  declarations: [
    PaginationHeaderComponent,
    PaginationComponent,
    OrderTotalsComponent,
  ],
  imports: [CommonModule, NgbPaginationModule, NgbCarouselModule],
  exports: [
    NgbPaginationModule,
    PaginationHeaderComponent,
    PaginationComponent,
    NgbCarouselModule,
    OrderTotalsComponent,
  ],
})
export class SharedModule {}
