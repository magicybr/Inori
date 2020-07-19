import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NotificationService } from 'src/app/services/share/notification.services';

@Component({
  selector: 'app-catalog-list',
  templateUrl: './catalog-list.component.html',
  styleUrls: ['./catalog-list.component.scss']
})
export class CatalogListComponent implements OnInit {
  dataSource: any;
  displayedColumns: string[] = ['Id', 'ProductName', 'CatalogBrand', 'CatalogType', 'Description', 'Price', 'AvailableStock', 'action'];
  constructor(private route: ActivatedRoute, private notification: NotificationService) {
    this.route.data.subscribe({
      next: (data) => {
        // console.log(data.CatalogItems);
        this.dataSource = data.CatalogItems;
      }
    });
  }

  ngOnInit(): void {
  }

  Update(item: any) {
    console.log(item);
  }

  Delete(item: any) {
    console.log(item);
    this.notification.ShowNotification(
      'top',
      'right',
      'danger',
      '这里是测试消息弹出',
      'notifications'
    );
  }
}
