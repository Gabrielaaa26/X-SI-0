using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security;
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

namespace X_SI_0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

       
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public int player = 2;//numara playeri
        public int turns = 0;//numara randul

        
       private void OnButtonClick(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;

            if (button.Content != " ")
            { //am adaugat un operator pentru a nu se mai schimba  informatia din casuta daca este apelata de 2 ori

                if (player % 2 == 0)
                {
                    button.Content = "X";
                    player++;
                    turns++;
                }
                else
                {
                    button.Content = "0";
                    player++;
                    turns++;
                }

                //verificam daca e remiza 
               
                if (Checkdraw() == true)
                { 
                    MessageBox.Show ("Meci egal!");
                    this.NewGame();
                }

                //am adaugat verificare pentru fiecare castigator in fiecare runda

                if (CheckWinner() == true && turns>4)
                {
                    if (button.Content == "X")
                    {
                        MessageBox.Show("X WIN");
                        this.NewGame();
                    }

                    else if (button.Content == "0")
                    {
                        MessageBox.Show("0 WIN");
                        this.NewGame();
                    }
                }
            }
        }

           

           

            //functie pentru butonul de joc nou

            private void NewGame()
            {
                player = 2;
                turns = 0;
                b11.Content = b12.Content = b13.Content = b21.Content = b22.Content = b23.Content = b31.Content = b32.Content = b33.Content= "";
               
            }



            //o functie care verifica daca a fost facuta remiza

            bool Checkdraw()
            {
            if ((turns == 9) && CheckWinner() == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //functie care verifica daca este vreun castigator

            bool CheckWinner() {

                //verificare pe orizontala

                if (((b11.Content == b12.Content) && (b12.Content == b13.Content)) && b13.Content != " ")
                {
              
                    return true;
                }
                else if (((b21.Content == b22.Content) && (b22.Content == b23.Content)) && b21.Content != "")
                {
                    return true;
                }

                else if (((b31.Content == b32.Content) && (b32.Content == b33.Content)) && b31.Content != "")
                {
                    return true;
                }

                //verificare pe verticala

                if (((b11.Content == b21.Content) && (b21.Content == b31.Content) )&& b11.Content != "")
                {
                    return true;
                }

                else if (((b12.Content == b22.Content) && (b22.Content == b32.Content)) && b32.Content != "")
                {
                    return true;
                }

                else if ((b13.Content == b23.Content) && (b23.Content == b33.Content) && b13.Content != "")
                {
                    return true;
                }

                //verificare pe diagonala

                if (((b11.Content == b22.Content) && (b22.Content == b33.Content) )&& b11.Content != "")
                {
                    return true;
                }

                else if (((b31.Content == b22.Content) && (b22.Content == b13.Content)) && b31.Content != "")
                {
                    return true;

                }

                else return false;
            }

            private void Newg(object sender, RoutedEventArgs e)
            {
                this.NewGame();
            }

            private void resetClick(object sender, RoutedEventArgs e)
            {
                this.NewGame();
            }

            private void exitClick(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
        }
    }

