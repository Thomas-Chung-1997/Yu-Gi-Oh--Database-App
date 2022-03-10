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
using System.Diagnostics;
using Newtonsoft.Json;
using System.Data;

namespace YuGiOhDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    // CHANGE ask user on exit if the saved collection is not the same as current.
    public partial class MainWindow : Window
    {
        public CardCollection database;
        public Dictionary<int,int> collection;
        public bool isCollectionTab = false;
        public bool isFiltered = false;

        // ==============================================================================================
        // BUILT IN WPF EVENTS
        // ==============================================================================================

        public MainWindow()
        {
            InitializeComponent();
        }

        // Setup app by getting database, displaying database, and reading in collection.
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            database = await YugiohAPI.InitializeDatabase();

            DisplayCards(tbx_Search.Text);

            collection = FileController.ReadCollection();
        }

        // On exit, if the user has not saved their collection, open dialog to prompt user to save.
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dictionary<int, int> onSaveCollection = FileController.ReadCollection();
            MessageBoxResult result;

            if (!(collection.Count == onSaveCollection.Count &&
                collection.Keys.All(k => onSaveCollection.ContainsKey(k) && collection[k] == onSaveCollection[k]) &&
                onSaveCollection.Keys.All(k => collection.ContainsKey(k) && collection[k] == onSaveCollection[k])))
            {
                result = MessageBox.Show("Collection has not been saved. Do you want to save changes?", "Yu-Gi-Oh! Database", MessageBoxButton.YesNoCancel);

                if (result == MessageBoxResult.Yes)
                {
                    FileController.WriteCollection(collection);
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        // ==============================================================================================
        // CONTROL EVENTS
        // ==============================================================================================

        // Will populate datagrid depending on filter provided in search textbox, shows collection or database accordingly
        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            isFiltered = true;

            DisplayCards(tbx_Search.Text);
        }

        // If "Enter" key is pressed in textbox, apply filter. If "Escape" key is pressed, clear textbox and turn off filter
        private void tbx_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                isFiltered = true;

                DisplayCards(tbx_Search.Text);
            }
            else if(e.Key == Key.Escape)
            {
                isFiltered = false;

                tbx_Search.Text = "";

                DisplayCards(tbx_Search.Text);
            }
        }

        // Change to database display, hide count column, turn off filter
        private void btn_Database_Click(object sender, RoutedEventArgs e)
        {
            isCollectionTab = false;
            isFiltered = false;

            dtg_Cards.Columns[1].Visibility = Visibility.Hidden;

            DisplayCards();
        }

        // Change to collection display, display count column, turn off filter
        private void btn_Collection_Click(object sender, RoutedEventArgs e)
        {
            isCollectionTab = true;
            isFiltered = false;

            dtg_Cards.Columns[1].Visibility = Visibility.Visible;

            DisplayCards();
        }

        //Saves current iteration of collection.
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            FileController.WriteCollection(collection);
        }

        // Increment count of selected datagrid row card, properly adding card to collection dictionary if needed.
        private void btn_IncrementCard(object sender, RoutedEventArgs e)
        {
            DataGridCardModel card = dtg_Cards.SelectedItem as DataGridCardModel;

            if (collection.ContainsKey(card.id))
            {
                collection[card.id]++;
            }
            else
            {
                collection[card.id] = 1;
            }

            // Update after change if in collection tab
            if (isCollectionTab)
            {
                DisplayCards(tbx_Search.Text);
            }

            Trace.WriteLine($"Increment :{card.name}");
        }
        // Decrement count of selected datagrid row card, properly remove card from collection dictionary if needed.
        private void btn_DecrementCard(object sender, RoutedEventArgs e)
        {
            DataGridCardModel card = dtg_Cards.SelectedItem as DataGridCardModel;

            if (collection.ContainsKey(card.id))
            {
                collection[card.id]--;

                if (collection[card.id] <= 0)
                {
                    collection.Remove(card.id);
                }
            }

            // Update after change if in collection tab
            if (isCollectionTab)
            {
                DisplayCards(tbx_Search.Text);
            }

            Trace.WriteLine($"Decrement :{card.name}");
        }

        // ==============================================================================================
        // SUPPLIMENTARY EVENTS
        // ==============================================================================================

        // Will pull correct set of cards if its in collection or database tab, will filter accordingly. Then display those cards in datagrid.
        private void DisplayCards(string text = "")
        {
            List<CardModel> query;

            dtg_Cards.Items.Clear();

            if(isCollectionTab)
            {
                query = database.data.Where(c => collection.ContainsKey(c.id)).ToList();
            }
            else
            {
                query = database.data;
            }

            if (isFiltered)
            {
                text = text.ToLower();
                query = query.Where(c => c.name.ToLower().Contains(text) || c.type.ToLower().Contains(text) || c.desc.ToLower().Contains(text)).ToList();
            }

            foreach (var i in query)
            {
                dtg_Cards.Items.Add(new DataGridCardModel { id = i.id, count = isCollectionTab ? collection[i.id] : 0, name = i.name, type = i.type, race = i.race, desc = i.desc });
            }

            Trace.WriteLine($"{(isFiltered ? $"filter :[{text}]" : "")} Cards {(isCollectionTab ? "collection" : "database" )} displayed.");
        }

    }
}
