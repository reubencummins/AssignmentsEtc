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

namespace Hospital_Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Ward> Wards = new List<Ward>();
        Ward selectedWard;
        Patient selectedPatient;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Wards.Add(new Ward("Monty Python Memorial Ward", 7));
            Wards.Add(new Ward("Boring Ward", 15));
            PopulateWards(Wards);
            lbxWards.ItemsSource = Wards;
            Wards[0].Patients.Add(new Patient());
            Wards[1].Patients.Add(new Patient("Dexter Morgan"));
            

            }

        private void btnNewWard_Click(object sender, RoutedEventArgs e)
        {
            Wards.Add(new Ward(txtWardName.Text, (int)sldWardCap.Value));
            txtWardName.Text = "";
            sldWardCap.Value = 0;
            lbxWards.ItemsSource = null;
            lbxWards.ItemsSource = Wards;
        }

        private void PopulateWards(List<Ward> list)
        {
            int n = 0;
            foreach (Ward w in list)
            {
                w.Patients.Add(new Patient("James Doakes", 20 + n, BloodType.AB));
                w.Patients.Add(new Patient("Harry Morgan", 59 - n, BloodType.B));
                w.Patients.Add(new Patient("Faith Summers", 17 + n/2, BloodType.AB));
                n += 20;
            }
        }

        private BloodType getBloodType(UIElementCollection radioButtonList)
        {
            BloodType b = BloodType.O;
            foreach (RadioButton r in radioButtonList)
            {
                if (r.IsChecked == true)
                    b = (BloodType)Enum.Parse(typeof(BloodType), r.Content.ToString());
            }
            return b;

        }

        private void lbxWards_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedWard = (Ward)lbxWards.SelectedItem;
            if (selectedWard != null)
                lbxPatients.ItemsSource = selectedWard.Patients;
        }

        private void lbxPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPatient = (Patient)lbxPatients.SelectedItem;
            if (lbxPatients.SelectedItem != null)
            {
                BitmapImage bloodImage = new BitmapImage();
                bloodImage.BeginInit();
                bloodImage.UriSource = new Uri(String.Format("pack://application:,,,/image/" + selectedPatient.Blood + ".png"));
                bloodImage.EndInit();
                imgPatientBT.Source = bloodImage;
                lblPatientName.Content = selectedPatient.Name;
            }
            else
            {
                lblPatientName.Content = "";
                BitmapImage bloodImage = new BitmapImage();
                bloodImage.BeginInit();
                bloodImage.UriSource = new Uri(String.Format("pack://application:,,,/image/blank.png"));
                bloodImage.EndInit();
            }

            //imgPatientBT.Source = //"image/" + selectedPatient.Blood.ToString();
        }

        private void btnAddPatient_Click(object sender, RoutedEventArgs e)
        {
            int patientAge = (DateTime.Today.Year - Convert.ToDateTime(datDob.Text).Year);
            selectedWard.Patients.Add(new Patient(txtPatientName.Text,patientAge,getBloodType(stkBloodButton.Children)));
            lbxPatients.ItemsSource = null;
            lbxPatients.ItemsSource = selectedWard.Patients;
        }
    }
}
