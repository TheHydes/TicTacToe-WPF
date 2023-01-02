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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string X ="X"; //elhagyható, felhasznált helyeken elég lenne helyette "X"
        private string O = "O"; //elhagyható, felhasznált helyeken elég lenne helyette "O"
        private int counter = 0;
        private int counter2 = 0;
        private string[] tomb;// = new string[9]; //esetleg érdemes lehet egy mátrixos megvalósításon elgondolkodni                                      
                              //a dinamikusság érdekében egy foreach-el megszámolom a myGrid gyerekelemeit és ezt adom meg a tömb méretének
        public MainWindow()
        {
            InitializeComponent();
            foreach (var item in myGrid.Children)
            {
                if (item is Label)
                {
                    counter2++;
                }
            }
            tomb = new string[counter2];
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TombFeltoltes(e);
            Vizsgalat();
        }
        private void TombFeltoltes(MouseButtonEventArgs e)
        {
            if (counter <= 8)
            {
                if (counter % 2 == 0)
                {
                    if ((e.Source is Label) && (e.Source as Label).Content == null)
                    {
                        (e.Source as Label).Content = X;
                        tomb[int.Parse((e.Source as Label).Tag.ToString())] = (e.Source as Label).Content.ToString();
                        counter++;
                    }
                }
                else
                {
                    if ((e.Source is Label) && (e.Source as Label).Content == null)
                    {
                        (e.Source as Label).Content = O;
                        tomb[int.Parse((e.Source as Label).Tag.ToString())] = (e.Source as Label).Content.ToString();
                        counter++;
                    }
                }
            }
        }
        private void Vizsgalat()
        {
            if (counter >= 5) //innentől van értelme elkezdeni vizsgálni, hiszen ezelőtt még nem lehet nyerni
                              //, azért döntöttem a kézi eredménymegadás mellet, mert egyrészt kevés esetről van szó, másrészt a szomszédsági vizsgálatoknál hármassával, elakartam kerülni azon eseteket
                              //, mint például a tomb[2]=tomb[3]=tomb[4], hiszen ez egy kivételes eset ahol a szomszédok ugyanazok, viszont a játék szabályai szerint ez nem győzelem
                              //javítási lehetőség, hogy dinamikusabb legyen: valamilyen Backtrack algoritmus használata
            {
                if ((tomb[0] == tomb[1] && tomb[0] == tomb[2] && tomb[0] == X) || (tomb[0] == tomb[3] && tomb[0] == tomb[6] && tomb[0] == X) || (tomb[0] == tomb[4] && tomb[0] == tomb[8] && tomb[0] == X)
                    || (tomb[2] == tomb[4] && tomb[2] == tomb[6] && tomb[2] == X) || (tomb[1] == tomb[4] && tomb[1] == tomb[7] && tomb[1] == X) || (tomb[2] == tomb[5] && tomb[2] == tomb[8] && tomb[2] == X)
                    || (tomb[3] == tomb[4] && tomb[3] == tomb[5] && tomb[3] == X) || (tomb[6] == tomb[7] && tomb[6] == tomb[8] && tomb[6] == X))
                {
                    MessageBox.Show("X nyert!");
                    this.Close();
                }
                else if ((tomb[0] == tomb[1] && tomb[0] == tomb[2] && tomb[0] == O) || (tomb[0] == tomb[3] && tomb[0] == tomb[6] && tomb[0] == O) || (tomb[0] == tomb[4] && tomb[0] == tomb[8] && tomb[0] == O)
                    || (tomb[2] == tomb[4] && tomb[2] == tomb[6] && tomb[2] == O) || (tomb[1] == tomb[4] && tomb[1] == tomb[7] && tomb[1] == O) || (tomb[2] == tomb[5] && tomb[2] == tomb[8] && tomb[2] == O)
                    || (tomb[3] == tomb[4] && tomb[3] == tomb[5] && tomb[3] == O) || (tomb[6] == tomb[7] && tomb[6] == tomb[8] && tomb[6] == O))
                {
                    MessageBox.Show("O nyert!");
                    this.Close();
                }
                else if (counter == 9)
                {
                    MessageBox.Show("Döntetlen!");
                    this.Close();
                }
            }
        }
    }
}
