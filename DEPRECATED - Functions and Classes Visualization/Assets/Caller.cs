using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caller : MonoBehaviour
{
    Book_NotMono newBook_NotMono;

    Book_Mono newBook2_Mono;
    // Start is called before the first frame update
    void Start()
    {
        newBook_NotMono = new Book_NotMono("Ready Player One", "Ernest Cline", 374, 129.95f);
        newBook_NotMono.showBook();


        newBook2_Mono = gameObject.AddComponent<Book_Mono>();
        newBook2_Mono.CreateBook("The Sirens of Titan", "Kurt Vonnegut", 319, 189.95f);
        newBook2_Mono.showBook();


    }

}
