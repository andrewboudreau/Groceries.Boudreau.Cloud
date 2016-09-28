using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Groceries.Boudreau.Cloud.WebApp.Migrations
{
    public partial class nc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingItems_ShoppingLists_ShoppingListId",
                table: "ShoppingItems");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingItems_ShoppingLists_ShoppingListId",
                table: "ShoppingItems",
                column: "ShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingItems_ShoppingLists_ShoppingListId",
                table: "ShoppingItems");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingItems_ShoppingLists_ShoppingListId",
                table: "ShoppingItems",
                column: "ShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
