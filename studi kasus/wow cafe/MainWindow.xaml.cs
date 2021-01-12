using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Cafe.Model;
using Cafe.Controller;

namespace Cafe

{
    public partial class MainWindow : Window,
         OnMenuChangedListener,
         onKeranjangBelanjaChangedListener,
         OnPromoChangedListener,
         OnPaymentChangedListener
    {
        MainWindowController controller;
        Bayar payment;
        public MainWindow()
        {
            InitializeComponent();
            payment = new Bayar(this);
            KeranjangBelanja keranjangBelanja = new KeranjangBelanja(payment, this);
            controller = new MainWindowController(keranjangBelanja, payment);

            listKeranjangBelanja.ItemsSource = controller.getItems();
            voucher.ItemsSource = controller.getDiskon();

            initializeView();

        }

        public void onPriceUpdated(double subTotal, double total, double promo)
        {
            labelSubTotal.Content = "Rp " + subTotal;
            labelPromo.Content = "Rp" + (total - subTotal);
            labelTotal.Content = "Rp " + total;
        }


        public void addItemSucceed()
        {
            listKeranjangBelanja.Items.Refresh();
        }

        public void OnMenuSelected(Item item)
        {
            controller.addItem(item);
        }

        public void removeItemSucceed()
        {
            listKeranjangBelanja.Items.Refresh();
        }

        public void addPromoSucceed()
        {
            voucher.Items.Refresh();
        }



        private void onDaftarMenuClicked(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.SetOnItemSelectedListener(this);
            menu.Show();
        }

        private void onlistKeranjangBelanjaDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Kamu ingin menghapus item ini?",
                   "Konfirmasi", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ListBox listBox = sender as ListBox;
                Item item = listBox.SelectedItem as Item;
                controller.removeItem(item);
            }
        }

        private void onBtnGantiPromoClicked(object sender, RoutedEventArgs e)
        {
            Promo promo = new Promo();
            promo.SetOnPromoSelectedListener(this);
            promo.Show();

        }

        public void OnPromoSelected(Diskon diskon)
        {
            controller.addDiskon(diskon);
        }

        private void initializeView()
        {
            labelSubTotal.Content = 0;
            labelPromo.Content = 0;
            labelTotal.Content = 0;
        }
    }
}
