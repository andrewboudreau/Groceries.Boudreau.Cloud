import { Component, Input } from '@angular/core';
import { ShoppingList } from './shoppinglist';

@Component({
    selector: 'shoppinglist-detail',
    template: `
      <div *ngIf="shoppingList">
        <h2>{{shoppingList.name}} details!</h2>
        <div><label>id: </label>{{shoppingList.id}}</div>
        <div>
          <label>name: </label>
          <input [(ngModel)]="shoppingList.name" placeholder="name"/>
        </div>
      </div>
    `
})

export class ShoppingListDetailComponent {
    @Input()
    shoppingList: ShoppingList;
}