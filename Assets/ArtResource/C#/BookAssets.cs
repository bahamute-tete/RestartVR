using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BookAssets : ScriptableObject
{
    public List<Books> books = new List<Books>();
   
}

[Serializable]
public class Books
{
    public int bookID;
    public Texture2D bookCover;
    public string bookContent;
    public string author;
}
