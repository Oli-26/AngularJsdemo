import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import {MatSort} from '@angular/material/sort';
import { User } from '../user';
import { AppState } from '../app.state';

export interface TableItem {
  name: string;
  age: number;
  gender: string;
}

@Component({
  selector: 'app-example-table',
  templateUrl: './example-table.component.html',
  styleUrls: ['./example-table.component.css']
})
export class TableComponent implements OnInit {
  displayedColumns: string[] = ['name', 'age', 'registered','email','balance'];

  appStateInstance = new AppState();
  userData = this.appStateInstance.users;

  dataSource!: MatTableDataSource<User>;

  @ViewChild(MatSort, { static: true }) sort!: MatSort;

  ngOnInit() {
    this.dataSource = new MatTableDataSource(this.userData);
    this.dataSource.sort = this.sort;
    this.dataSource.filterPredicate = (data: User, filter: string) => {
      return data.name.toLowerCase().includes(filter.toLowerCase());
    }
  }

  applyFilter(event: KeyboardEvent){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  formatDate(date: string){
    return date.slice(0, 10) + " " + date.slice(11, 19);
  }

  resetBalances(){
    console.log("reset");
    this.userData.map(user => user.balance = "0")
  }
}