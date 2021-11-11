import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { PaginationHeaderComponent } from './components/pagination-header/pagination-header.component';
import { PaginationComponent } from './components/pagination/pagination.component';



@NgModule({
  declarations: [PaginationHeaderComponent, PaginationComponent],
  imports: [CommonModule, NgbPaginationModule],
  exports: [
    NgbPaginationModule,
    PaginationHeaderComponent,
    PaginationComponent,
  ]
})
export class SharedModule {}
