using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book_NotMono
{
    private string bookName;
    private int bookPages;
    private string author;
    public float price;

    

    public Book_NotMono(string currBookName, string currAuthor, int currBookPages, float currPrice = 0)
    {
        bookName = currBookName;
        bookPages = currBookPages;
        author = currAuthor;
        price = currPrice;

        
    }


    public void showBook()
    {
        Debug.Log($"The book {bookName}, by {author}, has {bookPages} pages and costs {price}");
    }
}
