using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class BookDataMode
{
    public int bookID;
    public string Intro;
    public string bookAuthor;
}


[Serializable]
public class BooksRoot
{
    public List<BookDataMode> bookList;
}

