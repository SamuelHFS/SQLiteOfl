using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace pjSQLiteOfl
{
    
    public partial class MainPage : ContentPage
    {
        public class Livro : INotifyPropertyChanged

        {
            

            public event PropertyChangedEventHandler PropertyChanged;

            

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

            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }

        private SQLiteAsyncConnection _dbContext;
        private Livro usuarioSelecionado;
        private ObservableCollection<Livro> _usuarios;
        private Boolean toque = false;

        public MainPage()
        {
            InitializeComponent();
            _dbContext = DependencyService.Get<IAcessoDB>().GetConnection();
        }

        //private void lstvUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    toque = true;
        //    usuarioSelecionado = e.SelectedItem as Usuario;
        //    txtNome.Text = usuarioSelecionado.Nome;
        //}

        protected async override void OnAppearing()
        {
            await _dbContext.CreateTableAsync<Livro>();
            var usuarios = await _dbContext.Table<Livro>().ToListAsync();
            _usuarios = new ObservableCollection<Livro>(usuarios);
            lstvUsuarios.ItemsSource = _usuarios;

            base.OnAppearing();
        }

        private async void IncluirClicked(object sender, System.EventArgs e)
        {
            toque = false;
            Livro livro = new Livro();
            livro.titulo = txtTitulo.Text.Trim();

            if (!string.IsNullOrEmpty(txtNome.Text))
            {
                await _dbContext.InsertAsync(usuario);
                _usuarios.Add(usuario);
                txtNome.Text = "";
            }
            else
            {
                await DisplayAlert("Aviso", "Preencha o campo Nome", "Ok");
                txtNome.Focus();
            }

        }

        private async void AlterarClicked(object sender, System.EventArgs e)
        {
            if (toque == true)
            {
                usuarioSelecionado.Nome = txtNome.Text.Trim();
                if (!string.IsNullOrEmpty(txtNome.Text))
                {
                    await _dbContext.UpdateAsync(usuarioSelecionado);
                    txtNome.Text = "";
                    toque = false;
                }
                else
                {
                    await DisplayAlert("Aviso", "Preencha o campo Nome", "Ok");
                    toque = false;
                }

            }
            else
            {
                await DisplayAlert("Aviso", "Selecione um nome da lista", "Ok");
            }

        }

        private async void ExcluirClicked(object sender, System.EventArgs e)
        {
            if (toque == true)
            {
                if (!string.IsNullOrEmpty(txtNome.Text))
                {
                    await _dbContext.DeleteAsync(usuarioSelecionado);
                    _usuarios.Remove(usuarioSelecionado);
                    txtNome.Text = "";
                    toque = false;
                }
                else
                {
                    await DisplayAlert("Aviso", "Selecione um nome da lista", "Ok");
                    toque = false;
                }
            }
            else
            {
                await DisplayAlert("Aviso", "Selecione um nome da lista", "Ok");
            }

        }

        private void lstvUsuarios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            toque = true;
            usuarioSelecionado = e.Item as Usuario;
            txtNome.Text = usuarioSelecionado.Nome;

        }
    }
}
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLite01
{
    public partial class MainPage : ContentPage
    {
        public class Usuario : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }

            private string _nome;

            [MaxLength(150)]
            public string Nome
            {
                get
                {
                    return _nome;
                }
                set
                {
                    if (_nome == value)
                        return;

                    _nome = value;

                    OnPropertyChanged(nameof(Nome));
                }
            }

            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }

        private SQLiteAsyncConnection _dbContext;
        private Usuario usuarioSelecionado;
        private ObservableCollection<Usuario> _usuarios;
        private Boolean toque = false;

        public MainPage()
        {
            InitializeComponent();
            _dbContext = DependencyService.Get<IAcessoDB>().GetConnection();
        }

        //private void lstvUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    toque = true;
        //    usuarioSelecionado = e.SelectedItem as Usuario;
        //    txtNome.Text = usuarioSelecionado.Nome;
        //}

        protected async override void OnAppearing()
        {
            await _dbContext.CreateTableAsync<Usuario>();
            var usuarios = await _dbContext.Table<Usuario>().ToListAsync();
            _usuarios = new ObservableCollection<Usuario>(usuarios);
            lstvUsuarios.ItemsSource = _usuarios;

            base.OnAppearing();
        }

        private async void IncluirClicked(object sender, System.EventArgs e)
        {
            toque = false;
            Usuario usuario = new Usuario();
            usuario.Nome = txtNome.Text.Trim();

            if (!string.IsNullOrEmpty(txtNome.Text))
            {
                await _dbContext.InsertAsync(usuario);
                _usuarios.Add(usuario);
                txtNome.Text = "";
            }
            else
            {
                await DisplayAlert("Aviso", "Preencha o campo Nome", "Ok");
                txtNome.Focus();
            }

        }

        private async void AlterarClicked(object sender, System.EventArgs e)
        {
            if (toque == true)
            {
                usuarioSelecionado.Nome = txtNome.Text.Trim();
                if (!string.IsNullOrEmpty(txtNome.Text))
                {
                    await _dbContext.UpdateAsync(usuarioSelecionado);
                    txtNome.Text = "";
                    toque = false;
                }
                else
                {
                    await DisplayAlert("Aviso", "Preencha o campo Nome", "Ok");
                    toque = false;
                }

            }
            else
            {
                await DisplayAlert("Aviso", "Selecione um nome da lista", "Ok");
            }

        }

        private async void ExcluirClicked(object sender, System.EventArgs e)
        {
            if (toque == true)
            {
                if (!string.IsNullOrEmpty(txtNome.Text))
                {
                    await _dbContext.DeleteAsync(usuarioSelecionado);
                    _usuarios.Remove(usuarioSelecionado);
                    txtNome.Text = "";
                    toque = false;
                }
                else
                {
                    await DisplayAlert("Aviso", "Selecione um nome da lista", "Ok");
                    toque = false;
                }
            }
            else
            {
                await DisplayAlert("Aviso", "Selecione um nome da lista", "Ok");
            }

        }

        private void lstvUsuarios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            toque = true;
            usuarioSelecionado = e.Item as Usuario;
            txtNome.Text = usuarioSelecionado.Nome;

        }
    }
}


