using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace pjSQLiteOfl.model
{
    class Livro
    {
       
            public event PropertyChangedEventHandler PropertyChanged;

        private int _id;
            [PrimaryKey, AutoIncrement]

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id == value)
                    return;
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }


            private string _titulo;

            [MaxLength(150)]
            public string Titulo
            {
                get
                {
                    return _titulo;
                }
                set
                {
                    if (_titulo == value)
                        return;

                    _titulo = value;

                    OnPropertyChanged(nameof(Titulo));
                }
            }
            private string _autor;
            [MaxLength(300)]
            public string Autor
            {
                get
                {
                    return _autor;
                }
                set
                {
                    if (_autor == value)
                        return;

                    _titulo = value;
                    OnPropertyChanged(nameof(Autor));
                }
            }

            private string _editora;
            [MaxLength(200)]

            public string Editora
            {
                get
                {
                    return _editora;

                }
                set
                {
                    if (_editora == value)
                        return;

                    _editora = value;
                    OnPropertyChanged(nameof(Editora));
                }
            }

            private string _ano;
            [MaxLength(100)]

            public string Ano
            {
                get
                {
                    return _ano;
                }
                set
                {
                    if (_ano == value)
                        return;

                    _ano = value;
                    OnPropertyChanged(nameof(Ano));
                }
            }

            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }

    }

