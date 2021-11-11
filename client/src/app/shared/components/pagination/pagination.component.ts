import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss'],
})
export class PaginationComponent implements OnInit {
  @Input() totalProductsCount: number;
  @Input() pageSize: number;
  @Output() pageChange = new EventEmitter<number>();
  page = 1;

  constructor() {}

  ngOnInit(): void {}

  onPaginationChange(page) {
    this.pageChange.emit(page);
  }
}
