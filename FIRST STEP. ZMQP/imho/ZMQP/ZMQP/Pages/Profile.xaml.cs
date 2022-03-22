using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Interop;
using System.Windows.Threading;

namespace ZMQP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        Bitmap _bitmap;
        BitmapSource _source;
        public Profile()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Page_Loaded);
        }


        private void ProfileNickName(object sender, EventArgs e)
        {
           /*(sender as TextBlock).Text = Classes.DataBase.Login;*/
        }

        private void ProfileIDs(object sender, EventArgs e)
        {
            /*(sender as TextBlock).Text = "#" + Classes.DataBase.ID.ToString();*/
        }
        private void GameProfileBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.Library());
        }

        private void FriendProfileBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.Friends());
        }

        private void AchivProfileBar_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AboutProfileBar_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void EditProfileBar_MouseDown(object sender, MouseButtonEventArgs e)
        {


        }

        private void WrapPanel_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _source = GetSource();
            GifDanilprofile.Source = _source;
            ImageAnimator.Animate(_bitmap, OnFrameChanged);
        }

        private void OnFrameChanged(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                                    new Action(FrameUpdatedCallback));
        }

        private void FrameUpdatedCallback()
        {
            ImageAnimator.UpdateFrames();
            if (_source != null)
                _source.Freeze();
            _source = GetSource();
            GifDanilprofile.Source = _source;
            InvalidateVisual();
        }

        private BitmapSource GetSource()
        {
            if (_bitmap == null)
            {
                _bitmap = new Bitmap("C:/Gagaev/WordSkills/FIRST STEP. ZMQP/imho/ZMQP/ZMQP/Resources/gifdaniil.gif");
            }
            IntPtr handle = IntPtr.Zero;
            handle = _bitmap.GetHbitmap();
            return Imaging.CreateBitmapSourceFromHBitmap(
                    handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
