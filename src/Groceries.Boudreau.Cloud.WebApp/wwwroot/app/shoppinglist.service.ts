import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import { ShoppingList } from './shoppinglist';
import { SHOPPINGLISTS } from './mock-shoppinglist';

@Injectable()
export class ShoppingListService {

    constructor(private http: Http) { }

    getShoppingLists(): Promise<ShoppingList[]> {
        return Promise.resolve(SHOPPINGLISTS);
    }
}