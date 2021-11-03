using System;

namespace pjSQLiteOfl.Model
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
