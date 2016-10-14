import { Component } from '@angular/core';


const SHOPPINGLISTS: ShoppingList[] = [
    { id: 11, name: 'Test Shopping List One' },
    { id: 12, name: 'Test List 2' }
];


@Component({
    selector: 'my-app',
    template: `
    <h2>My Shopping Lists</h2>
    <ul class="lists">
        <li *ngFor="let list of shoppingLists" (click)="onSelect(list)">
            <span class="badge">{{list.id}}</span> {{list.name}}
        </li>
    </ul>
    <div *ngIf="selectedShoppingList">
      <h2>{{selectedShoppingList.name}} details!</h2>
      <div><label>id: </label>{{selectedShoppingList.id}}</div>
      <div>
        <label>name: </label>
        <input [(ngModel)]="selectedShoppingList.name" placeholder="name"/>
      </div>
    </div>
  `
})

export class AppComponent {
    title = 'Groceries Lists';
    shoppingLists = SHOPPINGLISTS;
    selectedShoppingList: ShoppingList;
    onSelect(shoppinglist: ShoppingList): void {
        this.selectedShoppingList = shoppinglist;
    }

}

export class ShoppingList {
    id: number;
    name: string;
}