using System;
using System.Collections.Generic;
using SQLite;

namespace book3
{
    //テーブル名を指定
    [Table("BookDB")]
    public class BookDB
    {
        //プライマリキー
        [PrimaryKey]
        //ISBN列
        public string ISBN { get; set; }
        //Title列
        public string Title { get; set; }
        //TitleKana列
        public string TitleKana { get; set; }
        //ItemCaption列
        public string ItemCaption { get; set; }


        //--------------------------insert文的なの--------------------------
        public static void insertBook(string isbn, string title, string titleKana, string itemCaption)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにBookテーブルを作成する
                    db.CreateTable<BookDB>();
                    
                    db.Insert(new BookDB() { ISBN = isbn, Title = title, TitleKana = titleKana, ItemCaption = itemCaption });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        //BookテーブルのBookを削除するメソッド
        //--------------------------delete文的なの--------------------------
        public static void deleteBook(string isbn)
        {

            //データベースに接続
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                //db.BeginTransaction();  //このサイト https://qiita.com/alzybaad/items/9356b5a651603a548278
                try
                {
                    db.CreateTable<BookDB>();
                    db.DropTable<BookDB>(); //dropテーブル

                    //db.Delete(isbn);
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }

        }


        //Bookテーブルの行データを取得します
        //--------------------------select文的なの--------------------------
        public static List<BookDB> select_all()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    return db.Query<BookDB>("SELECT * FROM [BookDB] order by [Title] desc limit 15");

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }
    }
}
