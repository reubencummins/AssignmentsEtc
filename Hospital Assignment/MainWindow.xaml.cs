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
            Wards[0].Patients.Add(new Patient());
            Wards[1].Patients.Add(new Patient("Dexter Morgan"));

            lbxWards.ItemsSource = Wards;

            }

        private void btnNewWard_Click(object sender, RoutedEventArgs e)
        {
            Wards.Add(new Ward(txtWardName.Text, (int)sldWardCap.Value));
            txtWardName.Text = "";
            sldWardCap.Value = 1;
            lbxWards.ItemsSource = null;
            lbxWards.ItemsSource = Wards;
        }

        private void PopulateWards(List<Ward> list)
        {
            //add some patients to the wards
            Random rand = new Random(System.Environment.TickCount);
            foreach (Ward w in list)
            {
                w.Patients.Add(new Patient("James Doakes", rand.Next(99), BloodType.AB));
                w.Patients.Add(new Patient("Harry Morgan", rand.Next(99), BloodType.B));
                w.Patients.Add(new Patient("Faith Summers", rand.Next(99), BloodType.AB));
            }
        }

        private BloodType getBloodType(UIElementCollection radioButtonList)
        {
            //convert the selected radioButton to a BloodType
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
            //update selectedWard and the patients pane
            selectedWard = (Ward)lbxWards.SelectedItem;
            if (selectedWard != null)
                lbxPatients.ItemsSource = selectedWard.Patients;
        }

        private void lbxPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //update selectedPatient and the details pane
            selectedPatient = (Patient)lbxPatients.SelectedItem;
            if (lbxPatients.SelectedItem != null)
            {
                //load the new image and put the patient's name in the label
                BitmapImage bloodImage = new BitmapImage();
                bloodImage.BeginInit();
                bloodImage.UriSource = new Uri(String.Format("pack://application:,,,/image/" + selectedPatient.Blood + ".png"));
                bloodImage.EndInit();
                imgPatientBT.Source = bloodImage;
                imgPatientBT.Visibility = Visibility.Visible;
                lblPatientName.Content = selectedPatient.Name;
            }
            else
            {
                //clear the details pane
                lblPatientName.Content = "";
                imgPatientBT.Visibility = Visibility.Hidden;
            }

            //imgPatientBT.Source = //"image/" + selectedPatient.Blood.ToString();
        }

        private void btnAddPatient_Click(object sender, RoutedEventArgs e)
        {
            
            if (selectedWard != null)
            //add a patient to the selected ward
            {
                int patientAge = (DateTime.Today.Year - Convert.ToDateTime(datDob.Text).Year);
                selectedWard.Patients.Add(new Patient(txtPatientName.Text, patientAge, getBloodType(stkBloodButton.Children)));
                lbxPatients.ItemsSource = null;
                lbxPatients.ItemsSource = selectedWard.Patients;

                txtPatientName.Text = "";
                datDob.Text = "1/1/2000";
                
            }
            else
                //tell the user to select a ward
                MessageBox.Show("You must select a ward to add the new patient to.");
            //is there a better message box?
        }

        private void sldWardCap_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //set the slider label as the value changes
            lblWardCap.Content = (int)sldWardCap.Value;
        }
    }
}
