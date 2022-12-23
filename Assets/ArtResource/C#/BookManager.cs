using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;



public class BookManager : MonoBehaviour
{
    [SerializeField] BookAssets bookAssets;
    [SerializeField] GameObject bookCover;
    [SerializeField] TextMeshProUGUI bookContentUI;
    [SerializeField] TextMeshProUGUI bookAuthorUI;
    [SerializeField] int bookID;

    [SerializeField] public TextAlignmentOptions alignmentOptions = TextAlignmentOptions.Left;

    static int texID = Shader.PropertyToID("_BaseMap");
    // Start is called before the first frame update
    void Start()
    {
        int index = bookAssets.books.FindIndex(x => x.bookID.Equals(bookID));

       // Debug.Log(string.Format("index =={0}", index));
        bookCover.GetComponent<MeshRenderer>().material.SetTexture(texID, bookAssets.books[index].bookCover);

        bookContentUI.text = bookAssets.books[index].bookContent;

        bookAuthorUI.text = bookAssets.books[index].author;


        bookContentUI.alignment = alignmentOptions;


        //TextAsset json_txt = Resources.Load<TextAsset>("BooksData");
        //BooksRoot data = JsonUtility.FromJson<BooksRoot>(json_txt.text);

        //foreach (var temp in data.bookList)
        //{
        //    Debug.Log(string.Format("作者:{0} 书ID{1} 书内容{2}", temp.bookAuthor, temp.bookID, temp.Intro));
        //}


    }

    



}
