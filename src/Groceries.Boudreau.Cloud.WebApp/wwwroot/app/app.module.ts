import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';

import { AppComponent }   from './app.component';
import { ShoppingListDetailComponent} from './shoppinglist-detail.component';

@NgModule({
    imports: [BrowserModule, FormsModule],
    declarations: [AppComponent, ShoppingListDetailComponent ],
    bootstrap: [AppComponent]
})

export class AppModule { }