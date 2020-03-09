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

namespace varazslo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Ember> emberek = new List<Ember>();
        Random rnd = new Random();
        int csata = 0;
        Ember harcos1;
        Ember harcos2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            int szam = rnd.Next(0, 100);
            int ero = rnd.Next(0, 10);

            /*if (rnd.Next(0, 2) == 1)
            {*/
                emberek.Add( new Ember( "John-" + szam, ero, rnd.Next(-1,10) ) );
            /*}
            else {
                int varazsero = rnd.Next(0,20);
                Ember ujember = new Ember("Don-" + szam, ero);
                emberek.Add(new Varazslo(ujember, varazsero));
            }*/


            listaFrissit();
        }

        private void delet_Click(object sender, RoutedEventArgs e)
        {
            emberek.RemoveAt( katalogus.SelectedIndex );

            listaFrissit();
        }

        private void listaFrissit() {

            katalogus.ItemsSource = null;
            katalogus.ItemsSource = emberek;
        }

        private void fight_Click(object sender, RoutedEventArgs e)
        {
            csata++;
            if (csata % 2 == 1){
                harcos1 = emberek.ElementAt(katalogus.SelectedIndex);
                harcos1Nev.Text = harcos1.Nev;
            }
            else{
                harcos2 = emberek.ElementAt(katalogus.SelectedIndex);
                harcos2Nev.Text = harcos2.Nev;

                harc();
            }
        }
        public void harc() {
            int kor = 0;
            do{
                kor++;
                harcos2.Sebzodott( rnd.Next( 0, harcos1.MaxEro) );

                harcos1.Sebzodott( rnd.Next( 0,  harcos2.MaxEro) );

                korSzam.Text ="Kör száma: "+kor.ToString();

                harcos1Elet.Value = harcos1.Elet;
                harcos2Elet.Value = harcos2.Elet;

            } while ( harcos1.Elet > 0 && harcos2.Elet > 0 );
        }
    }
}
