using Microsoft.Win32;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using NxShort.Helpers;
using NxShort.Domain.Menu.Services;
using NxShort.Domain.Menu;
using NxShort.Domain.Menu.Enums;

namespace NxShort
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IMenuService _menuService;
        private EntryType? _type;
        private MenuEntry _entity = new MenuEntry();
        public MainWindow(IMenuService menuService)
        {
            InitializeComponent();
            _menuService = menuService;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!Validate())
                return;

            _entity.SetName(txtNome.Text);
            _entity.SetDescription(txtDescricao.Text);

            _menuService.Register(_entity, _type.Value);
        }

        private void btnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                _entity.SetPath(openFileDialog.FileName);
                SetContent(btnSelectFile, _entity.Path);
            }
        }

        private void btnAllUsers_Click(object sender, RoutedEventArgs e)
        {
            _type = EntryType.AllUsers;
            SetButtonActive(btnAllUsers);
            SetButtonDeactive(btnCurrentUser);
        }

        private void btnCurrentUser_Click(object sender, RoutedEventArgs e)
        {
            _type = EntryType.CurrentUser;
            SetButtonActive(btnCurrentUser);
            SetButtonDeactive(btnAllUsers);
        }

        private void btnSelectFile_Drop(object sender, DragEventArgs e)
        {
            if (e.Data is DataObject && ((DataObject)e.Data).ContainsFileDropList())
            {
                var filePath = ((DataObject)e.Data)
                                    .GetFileDropList()
                                    .OfType<string>()
                                    .FirstOrDefault();

                _entity.SetPath(filePath);
                SetContent(btnSelectFile, _entity.Path);
            }
        }

        private bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                SetInvalid(txtNome);
                isValid = false;
            }

            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                SetInvalid(txtDescricao);
                isValid = false;
            }

            if (string.IsNullOrEmpty(_entity.Path))
            {
                SetInvalid(btnSelectFile);
                isValid = false;
            }

            if (_type == null)
            {
                SetInvalid(btnAllUsers);
                SetInvalid(btnCurrentUser);
                isValid = false;
            }

            return isValid;
        }

        //UI Internals
        private void SetButtonActive(Button control)
        {
            var colorActive = ColorFactory.FromHex("#FF196DE6");
            control.BorderBrush = new SolidColorBrush(colorActive);
        }

        private void SetButtonDeactive(Button control)
        {
            var colorDeactive = ColorFactory.FromHex("#8c8b8b");
            control.BorderBrush = new SolidColorBrush(colorDeactive);
        }

        private void SetInvalid(Control control)
        {
            var colorInvalid = ColorFactory.FromHex("#ff5d52");
            control.BorderBrush = new SolidColorBrush(colorInvalid);
        }

        private void SetContent(Button button, string text) => button.Content = text;
    }
}
