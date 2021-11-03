using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using pjSQLiteOfl.Droid.AcessoDB;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(AcessoDb))]
namespace pjSQLiteOfl.Droid.AcessoDB
{
    class AcessoDb : IAcessoDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            string nomeDB = "Usuario.db";
            var caminhoPasta =
                System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.MyDocuments);
            var caminho = Path.Combine(caminhoPasta, nomeDB);
            return new SQLiteAsyncConnection(caminho);
        }
    }
}