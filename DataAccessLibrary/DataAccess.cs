using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using Windows.Storage;

namespace DataAccessLibrary
{
    public static class DataAccess
    {
        public async static void InitializeDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("archeologicCatalog.db", CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "archeologicCatalog.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                //String tableCommand = "CREATE TABLE IF NOT EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY, Text_Entry NVARCHAR(2048) NULL)";

                String ArcheoObjectTableCommand = "CREATE TABLE IF NOT EXISTS ArcheoObjects (Id INTEGER PRIMARY KEY, Code NVARCHAR(2048) NULL, Coordinates NVARCHAR (2048) NULL, TypOfBuild NVARCHAR (2048) NULL, Height NVARCHAR (2048) NULL, Width NVARCHAR (2048) NULL, Depth NVARCHAR (2048) NULL, Description NVARCHAR (2048) NULL, SpecialFeatures NVARCHAR (2048) NULL, PictureLink NVARCHAR (2048) NULL, RockType NVARCHAR (2048) NULL)";

                String ArcheoCatalogTypOfBuildCommand = "CREATE TABLE IF NOT EXISTS ArcheoObjects (TypOfBuild NVARCHAR(2048) NULL)";

                SqliteCommand ArcheoObjectTableCommandTable = new SqliteCommand(ArcheoObjectTableCommand, db);
                SqliteCommand ArcheoCatalogTypOfBuildTable = new SqliteCommand(ArcheoCatalogTypOfBuildCommand, db);

                ArcheoObjectTableCommandTable.ExecuteReader();
                ArcheoCatalogTypOfBuildTable.ExecuteReader();

                db.Close();
            }
        }

        public static void AddData(String[] ArcheoObject)
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO ArcheoObjects VALUES (@Id, @Code, @Coordinates, @TypOfBuild, @Height, @Width, @Depth, @Description, @SpecialFeatures, @PictureLink, @RockType);";
                insertCommand.Parameters.AddWithValue("@Id", ArcheoObject[0]);
                insertCommand.Parameters.AddWithValue("@Code", ArcheoObject[1]);
                insertCommand.Parameters.AddWithValue("@Coordinates", ArcheoObject[2]);
                insertCommand.Parameters.AddWithValue("@Height", ArcheoObject[3]);
                insertCommand.Parameters.AddWithValue("@Width", ArcheoObject[4]);
                insertCommand.Parameters.AddWithValue("@Depth", ArcheoObject[5]);
                insertCommand.Parameters.AddWithValue("@Description", ArcheoObject[6]);
                insertCommand.Parameters.AddWithValue("@SpecialFeatures", ArcheoObject[7]);
                insertCommand.Parameters.AddWithValue("@PictureLink", ArcheoObject[8]);
                insertCommand.Parameters.AddWithValue("@RockType", ArcheoObject[9]);

                insertCommand.ExecuteReader();

                db.Close();
            }

        }

        public static List<String> GetData()
        {
            List<String> entries = new List<string>();

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Text_Entry from MyTable", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }

                db.Close();
            }

            return entries;
        }

    }
}

