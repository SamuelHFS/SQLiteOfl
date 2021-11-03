using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace pjSQLiteOfl.model
{
    class Livro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string titulo { get; set; }

        public string autor { get; set; }

        public string editora { get; set; }

        public string ano { get; set; }
    }
}
