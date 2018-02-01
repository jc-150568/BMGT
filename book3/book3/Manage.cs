using System;
using System.Collections.Generic;
using SQLite;

namespace book3
{
    [Table("Manage")]
    class Manage
    {
        [PrimaryKey]
        public int No { get; set; }

        public int camera_bool { get; set; }


        public static void camera()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    db.Execute("UPDATE [Manage] SET camera_bool = 1");
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        public static void camera2()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    db.Execute("UPDATE [Manage] SET camera_bool = 0");
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        public static List<Manage> _camera()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    return db.Query<Manage>("SELECT [camera_bool] FROM [Manage]");

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        public static void insertCamera()
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにUserテーブルを作成する
                    db.CreateTable<Manage>();

                    db.Insert(new Manage() { camera_bool = 0 });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }
    }
}
