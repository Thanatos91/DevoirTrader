using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ModelObjet;
using Windows.UI.Popups;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace projectTrader
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Dictionary<string, List<ActionAchetee>> dico;
        List<ActionReelle> lesActionsReelles;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dico = new Dictionary<string, List<ActionAchetee>>();
            lesActionsReelles = new List<ActionReelle>();  

            #region jeu d'essais pour la liste de toutes les actions réelles
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "AAPL",
                    NomAction = "Apple",
                    ValeurAction = 200
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "MSFT",
                    NomAction = "Microsoft",
                    ValeurAction = 14
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "TWTR",
                    NomAction = "Twitter",
                    ValeurAction = 40
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "IBM",
                    NomAction = "International Business Machines",
                    ValeurAction = 140
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "FB",
                    NomAction = "Facebook",
                    ValeurAction = 180
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "AXA",
                    NomAction = "Axa assurances",
                    ValeurAction = 25
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "SAP",
                    NomAction = "SAP SE",
                    ValeurAction = 120
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "INTC",
                    NomAction = "Intel Corporation",
                    ValeurAction = 50
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "VMW",
                    NomAction = "VMware",
                    ValeurAction = 145
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "TXN",
                    NomAction = "Texas Instrument Incorporated",
                    ValeurAction = 130
                }
            );
            #endregion
            //On remplit la ListView des Actions
            lvAchat.ItemsSource = lesActionsReelles;

            //Pour le dico

            #region jeu d'essais pour le dico
            dico.Add
            ("Karim", new List<ActionAchetee>()
            {
                new ActionAchetee()
                {
                    CodeAction = "AAPL",
                    NomAction = "Apple",
                    ValeurAction = 200,
                    PrixAchat = 210,
                    Quantite = 10
                },
                new ActionAchetee()
                {
                    CodeAction = "MSFT",
                    NomAction = "Microsoft",
                    ValeurAction = 140,
                    PrixAchat = 100,
                    Quantite = 50
                },
                new ActionAchetee()
                {
                    CodeAction = "TWTR",
                    NomAction = "Twitter",
                    ValeurAction = 40,
                    PrixAchat = 35,
                    Quantite = 20
                },
                new ActionAchetee()
                {
                    CodeAction = "IBM",
                    NomAction = "International Business Machines",
                    ValeurAction = 140,
                    PrixAchat = 110,
                    Quantite = 40
                }
            }
            );
            dico.Add
            ("Massoud", new List<ActionAchetee>()
                {
                new ActionAchetee()
                {
                    CodeAction = "FB",
                    NomAction = "Facebook",
                    ValeurAction = 180,
                    PrixAchat = 210,
                    Quantite = 10
                },
                new ActionAchetee()
                {
                    CodeAction = "AXA",
                    NomAction = "Axa assurances",
                    ValeurAction = 25,
                    PrixAchat = 15,
                    Quantite = 20
                },
                new ActionAchetee()
                {
                    CodeAction = "SAP",
                    NomAction = "SAP SE",
                    ValeurAction = 120,
                    PrixAchat = 100,
                    Quantite = 30
                }
            }
            );
            dico.Add
            ("Djamel", new List<ActionAchetee>()
                {
                new ActionAchetee()
                {
                    CodeAction = "TWTR",
                    NomAction = "Twitter",
                    ValeurAction = 40,
                    PrixAchat = 25,
                    Quantite = 50
                },
                new ActionAchetee()
                {
                    CodeAction = "INTC",
                    NomAction = "Intel Corporation",
                    ValeurAction = 50,
                    PrixAchat = 35,
                    Quantite = 15
                },
                new ActionAchetee()
                {
                    CodeAction = "VMW",
                    NomAction = "VMware",
                    ValeurAction = 145,
                    PrixAchat = 150,
                    Quantite = 30
                },
                new ActionAchetee()
                {
                    CodeAction = "TXN",
                    NomAction = "Texas Instrument Incorporated",
                    ValeurAction = 130,
                    PrixAchat = 140,
                    Quantite = 25
                }
            }
            );
            #endregion
            lvTraders.ItemsSource = dico.Keys;
            //lvActions.ItemsSource = dico.Values;


        }

        //private void LvActions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
            
        //}

        private void LvTraders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvTraders.SelectedItem != null)
            {
                lvActions.ItemsSource = null;
                lvActions.ItemsSource = dico[lvTraders.SelectedItem.ToString()];
            }
            //affichage du montant du portefeuille
            double montant = 0;
            foreach (ActionAchetee a in dico[lvTraders.SelectedItem.ToString()])
            {
                montant += a.Quantite * a.PrixAchat;
            }
            txtMontant.Text = montant.ToString();
        }

        private async void BtnVendre_Click(object sender, RoutedEventArgs e)
        {
            if (lvTraders.SelectedItem != null)
            {
                if (lvActions.SelectedItem == null){
                    var message = new MessageDialog("Sélectionner une action :");
                    await message.ShowAsync();
                } else if (txtQuantiteVendue.Text == ""){
                    var message = new MessageDialog("Saisir la quantité vendue :");
                    await message.ShowAsync();
                } else if (Convert.ToInt32(txtQuantiteAchetee.Text) < Convert.ToInt32(txtQuantiteVendue.Text)){
                    var message = new MessageDialog("Vous ne pouvez pas vendre au-delà de ce que vous possédez :");
                    await message.ShowAsync();
                }
                else
                {
                    // si quantité achetée = quantité vendue => on retire l'action de la liste
                    if (Convert.ToInt32(txtQuantiteAchetee.Text) == Convert.ToInt32(txtQuantiteVendue.Text))
                    {
                        dico[lvTraders.SelectedItem.ToString()].Remove(lvActions.SelectedItem as ActionAchetee);
                    }
                    else if (Convert.ToInt32(txtQuantiteAchetee.Text) < Convert.ToInt32(txtQuantiteVendue.Text))
                    {
                        (lvActions.SelectedItem as ActionAchetee).Quantite = ((lvActions.SelectedItem as ActionAchetee).Quantite) - Convert.ToInt32(txtQuantiteVendue.Text);
                    }
                    // ainsi, actualisation de la liste 
                    lvActions.ItemsSource = null;
                    lvActions.ItemsSource = dico[lvTraders.SelectedItem.ToString()];
                    // et du montant du portefeuille
                    double montant = 0;
                    foreach (ActionAchetee actionA in dico[lvTraders.SelectedItem.ToString()])
                    {
                        montant += actionA.Quantite * actionA.PrixAchat;
                    }
                    txtMontant.Text = montant.ToString();

                    // remise à blanc du TextBox de Quantité Vendue 
                    //txtQuantiteVendue.Text = "";
                }
            }
        }

        private async void BtnAcheter_Click(object sender, RoutedEventArgs e)
        {
            if (lvAchat.SelectedItem == null){
                var message = new MessageDialog("Sélectionner une action !");
                await message.ShowAsync();
            } else if (txtPrixAcheter.Text == ""){
                var message = new MessageDialog("Saisir le prix d'achat !");
                await message.ShowAsync();
            } else if (txtQuantiteAcheter.Text == ""){
                var message = new MessageDialog("Saisir la quantité !");
                await message.ShowAsync();
            }
            else
            {
                if (lvTraders.SelectedItem != null)
                {
                    if (lvAchat.SelectedItem != null)
                    {
                        ActionAchetee a = new ActionAchetee()
                        {
                            CodeAction = (lvAchat.SelectedItem as ActionReelle).CodeAction,
                            NomAction = (lvAchat.SelectedItem as ActionReelle).NomAction,
                            ValeurAction = (lvAchat.SelectedItem as ActionReelle).ValeurAction,
                            PrixAchat = Convert.ToInt32(txtPrixAcheter.Text),
                            Quantite = Convert.ToInt32(txtQuantiteAcheter.Text)
                        };
                        dico[lvTraders.SelectedItem.ToString()].Add(a);

                        //actualisation de LvActions
                        lvActions.ItemsSource = null;
                        lvActions.ItemsSource = dico[lvTraders.SelectedItem.ToString()];

                        //actualisation du montant du portefeuille
                        double montant = 0;
                        foreach (ActionAchetee actionA in dico[lvTraders.SelectedItem.ToString()])
                        {
                            montant += actionA.Quantite * actionA.PrixAchat;
                        }
                        txtMontant.Text = montant.ToString();
                    }
                }
            }
        }

        private void LvActions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvActions.SelectedItem != null && lvTraders.SelectedItem != null)
            {
                txtNomAction.Text = (lvActions.SelectedItem as ActionAchetee).NomAction.ToString();
                txtValeurAction.Text = (lvActions.SelectedItem as ActionAchetee).ValeurAction.ToString();
                txtPrixAchat.Text = (lvActions.SelectedItem as ActionAchetee).PrixAchat.ToString();
                txtQuantiteAchetee.Text = (lvActions.SelectedItem as ActionAchetee).Quantite.ToString();
            }
            else{ //si on ne fait pas .Text, l'appli bug
                txtNomAction.Text = "";
                txtValeurAction.Text = "";
                txtPrixAchat.Text = "";
                txtQuantiteAchetee.Text = "";
            } //les valeurs ne changent pas ...

        }
    }
}
