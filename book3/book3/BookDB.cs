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
        //ISBN列 主キー
        public string ISBN { get; set; }

        //タイトル列
        public string Title { get; set; }

        //タイトルカナ列
        public string TitleKana { get; set; }

        //サブタイトル列
        public string SubTitle { get; set; }

        //サブタイトルカナ列
        public string SubTitleKana { get; set; }

        //著者列
        public string Author { get; set; }

        //著者カナ列
        public string AuthorKana { get; set; }

        //出版社列
        public string Publisher { get; set; }

        //種類列(コミック、文庫、etc..)
        public string Type { get; set; }

        //アイテム説明列
        public string ItemCaption { get; set; }

        //発売日列
        public string SalesDate { get; set; }

        //登録日列
        public DateTime Date { get; set; }

        //金額列
        public int Price { get; set; }

        //ImageUrl
        public string largeImageUrl { get; set; }

        //GenreId列
        public string booksGenreId { get; set; }
        

        //--------------------------insert文的なの--------------------------
        public static void insertBook(string isbn, string title, string titleKana,string subTitle,string subTitleKana,
            string author, string authorKana,string publisher,string type, string itemCaption,
            string salesDate, int price, string image,string genreId)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにBookテーブルを作成する
                    db.CreateTable<BookDB>();
                    
                    db.Insert(new BookDB() { ISBN = isbn, Title = title, TitleKana = titleKana,SubTitle = subTitle,SubTitleKana = subTitleKana, Author = author,AuthorKana = authorKana,
                        Publisher = publisher,Type = type,ItemCaption = itemCaption,SalesDate = salesDate,Date = DateTime.Now, Price = price, largeImageUrl = image,booksGenreId = genreId });

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

                    db.Delete(isbn);
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }

        }

        //dropTableメソッド
        public static void dropBook()
        {

            //データベースに接続
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                //db.BeginTransaction();  //このサイト https://qiita.com/alzybaad/items/9356b5a651603a548278
                try
                {
                    db.CreateTable<BookDB>();

                    db.DropTable<BookDB>();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }

        }

        //-----------------------以下selectメソッド--------------------------
        //全部表示
        public static List<BookDB> select_all()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    return db.Query<BookDB>("SELECT * FROM [BookDB] order by [Title] desc limit 30");

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        //titleのみ表示
        public static List<BookDB> select_title()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    return db.Query<BookDB>("SELECT [Title] FROM [BookDB] order by [Title] desc limit 30");

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        //titleをcountする
        public static List<BookDB> select_title_count()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    return db.Query<BookDB>("SELECT count([Title]) FROM [BookDB] desc limit 30");

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
