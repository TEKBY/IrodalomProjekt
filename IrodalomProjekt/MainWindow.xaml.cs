﻿using IrodalomProjekt.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using System.IO;
using System.Linq.Expressions;
using Microsoft.Win32;


namespace IrodalomProjekt
{

    public partial class MainWindow : Window
    {
        private static List<Kerdes> kerdesek = new List<Kerdes>();
        private static int aktualisIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private static void KerdeseketFeltolt(string fileName)
        {
            kerdesek.Clear();
            try
            {
                using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
                {
                    while (!sr.EndOfStream)
                    {
                        string kerdesSzovege = sr.ReadLine();
                        string valaszA = sr.ReadLine();
                        string valaszB = sr.ReadLine();
                        string valaszC = sr.ReadLine();
                        string[] utolsoSor = sr.ReadLine().Split(' ');

                        if (utolsoSor.Length < 3)
                            continue;

                        string helyesValasz = utolsoSor[2];

                        kerdesek.Add(new Kerdes(kerdesSzovege, valaszA, valaszB, valaszC, helyesValasz));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a fájl beolvasása közben: " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BetoltesClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TXT Fájlok (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    KerdeseketFeltolt(openFileDialog.FileName);
                    MessageBox.Show("Sikeres Betöltés!", "Információ", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (kerdesek.Count > 0)
                    {
                        aktualisIndex = 0;
                        MutatKerdes(aktualisIndex);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void MutatKerdes(int aktualisIndex)
        {
            throw new NotImplementedException();
        }

        private void KiertekelesClick(object sender, RoutedEventArgs e)
        {

        }

        private void KilepesClick(object sender, RoutedEventArgs e)
        {

        }

        private void ElozoClick(object sender, RoutedEventArgs e)
        {

        }

        private void ValaszMenteseClick(object sender, RoutedEventArgs e)
        {

        }

        private void KovetkezoClick(object sender, RoutedEventArgs e)
        {

        }
    }
}