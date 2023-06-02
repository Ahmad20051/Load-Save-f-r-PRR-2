using System;
using System.Collections.Generic;
using System.IO;
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

namespace Save_för_PRR_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string FileName = "G:/Min enhet/A/SaveProgCode.csv";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.S)
            {
                SaveDataToCsv();
            }
            //När "L" trycks ner kommer istället "LoadDataFromCsv" att köras
            else if (e.Key == Key.L)
            {
                LoadDataFromCsv();
            }
        }
        private void SaveDataToCsv()
        {
            try
            {
                using(StreamWriter writer = new StreamWriter(FileName))
                {
                    // i första cellen kommeer name och syskon skrivas in
                    writer.WriteLine("Namn, Syskon");
                    //i cellen under kommer den mer personliga datan att skrivas in.
                    writer.WriteLine("Ahmad, 18");
                }
                //när datan är sparad poppar en ruta upp där det står data saved
                MessageBox.Show("Datan Sparad");
            }
            catch(Exception ex)
            {
                //ifall något fel händer kommer det komma upp en ruta där det står att något gått fel
                MessageBox.Show($"Kunde inte spara data: {ex.Message}");
            }
        }
        private void LoadDataFromCsv()
        {
            try
            {
                //kollar om datafilen existerar
                if (!File.Exists(FileName))
                {
                    //om det inte finns en fil kommer felmeddelande komma up
                    MessageBox.Show("Kunde inte hitta datan");
                    return;
                }
                //läser data från filen och separerar datan med ett kommatecken
                using (StreamReader reader = new StreamReader(FileName))
                {
                    string headerLine = reader.ReadLine();
                    string dataLine = reader.ReadLine();
                    string[] dataValues = dataLine.Split(',');

                    string name = dataValues[0];
                    int syskon = int.Parse(dataValues[1]);

                    MessageBox.Show($"name: {name}\nAhmad: {syskon}");
                }
            }
            catch (Exception ex)
            {
                //ifall något fel händer kommer det komma upp ett felmeddelande
                MessageBox.Show($"Kunde inte ladda datan: {ex.Message}");
            }
        }
    }
}