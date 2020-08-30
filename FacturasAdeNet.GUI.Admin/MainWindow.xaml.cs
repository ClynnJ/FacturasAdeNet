using FacturasAdeNet.BIZ;
using FacturasAdeNet.COMMON.Entities;
using FacturasAdeNet.COMMON.Interfaces;
using FacturasAdeNet.DAL;
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

namespace FacturasAdeNet.GUI.Admin
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum action
        {
            New,
            Edit
        }

        IClientsHandler clientHandler;

        action clientsAction;
        public MainWindow()
        {
            InitializeComponent();
            ClientButtonsEditMode(false);
            ClearClientFields();
            ActivateFields(false);
            clientHandler = new ClientHandler(new ClientsRepository());
            UpdateClientsTable();
        }

        private void ActivateFields(bool value)
        {
            txbClientDNI.IsEnabled = value;
            txbClientId.IsEnabled = value;
            txbClientIP.IsEnabled = value;
            txbClientLastName.IsEnabled = value;
            txbClientMAC.IsEnabled = value;
            txbClientName.IsEnabled = value;
            txbClientNetSpeed.IsEnabled = value;
            txbClientPhone.IsEnabled = value;
            txbClientTariff.IsEnabled = value;
            chkbClientJanuary.IsEnabled = value;
            chkbClientFebruary.IsEnabled = value;
            chkbClientMarch.IsEnabled = value;
            chkbClientApril.IsEnabled = value;
            chkbClientMay.IsEnabled = value;
            chkbClientJune.IsEnabled = value;
            chkbClientJuly.IsEnabled = value;
            chkbClientAugust.IsEnabled = value;
            chkbClientSeptember.IsEnabled = value;
            chkbClientOctober.IsEnabled = value;
            chkbClientNovember.IsEnabled = value;
            chkbClientDecember.IsEnabled = value;     
        }

        private void UpdateClientsTable()
        {
            dtgClients.ItemsSource = null;
            dtgClients.ItemsSource = clientHandler.ToList;
        }

        private void ClearClientFields()
        {
            txbClientDNI.Clear();
            txbClientId.Text = "";
            txbClientIP.Clear();
            txbClientMAC.Clear();
            txbClientLastName.Clear();
            txbClientName.Clear();
            txbClientNetSpeed.Clear();
            txbClientPhone.Clear();
            txbClientTariff.Text = "0";
            chkbClientJanuary.IsChecked = false;
            chkbClientFebruary.IsChecked = false;
            chkbClientMarch.IsChecked = false;
            chkbClientApril.IsChecked = false;
            chkbClientMay.IsChecked = false;
            chkbClientJune.IsChecked = false;
            chkbClientJuly.IsChecked = false;
            chkbClientAugust.IsChecked = false;
            chkbClientSeptember.IsChecked = false;
            chkbClientOctober.IsChecked = false;
            chkbClientNovember.IsChecked = false;
            chkbClientDecember.IsChecked = false;
        }

        private void ClientButtonsEditMode(bool value)
        {
            btnCancelClient.IsEnabled = value;
            btnDeleteClient.IsEnabled = !value;
            btnEditClient.IsEnabled = !value;
            btnNewClient.IsEnabled = !value;
            btnSaveClient.IsEnabled = value;
            ActivateFields(value);
        }

        private void btnNewClient_Click(object sender, RoutedEventArgs e)
        {
            ActivateFields(true);
            ClearClientFields();
            ClientButtonsEditMode(true);
            clientsAction = action.New;
        }

        private void btnEditClient_Click(object sender, RoutedEventArgs e)
        {
            Client clnt = dtgClients.SelectedItem as Client;
            if(clnt != null) 
            {
                txbClientDNI.Text = clnt.DNI;
                txbClientId.Text = clnt.Id;
                txbClientIP.Text = clnt.IPAddress;
                txbClientMAC.Text = clnt.MACAddress;
                txbClientName.Text = clnt.Name;
                txbClientLastName.Text = clnt.LastName;
                txbClientNetSpeed.Text = clnt.NetSpeed;
                txbClientPhone.Text = clnt.Phone;
                txbClientTariff.Text = clnt.Tariff.ToString();
                chkbClientJanuary.IsChecked = clnt.E == 'P' ? true : false;
                chkbClientFebruary.IsChecked = clnt.F == 'P' ? true : false;
                chkbClientMarch.IsChecked = clnt.M == 'P' ? true : false;
                chkbClientApril.IsChecked = clnt.A == 'P' ? true : false;
                chkbClientMay.IsChecked = clnt.MY == 'P' ? true : false;
                chkbClientJune.IsChecked = clnt.J == 'P' ? true : false;
                chkbClientJuly.IsChecked = clnt.JL == 'P' ? true : false;
                chkbClientAugust.IsChecked = clnt.AG == 'P' ? true : false;
                chkbClientSeptember.IsChecked = clnt.S == 'P' ? true : false;
                chkbClientOctober.IsChecked = clnt.O == 'P' ? true : false;
                chkbClientNovember.IsChecked = clnt.N == 'P' ? true : false;
                chkbClientDecember.IsChecked = clnt.D == 'P' ? true : false;



                clientsAction = action.Edit;

                ClientButtonsEditMode(true);
            }
            
        }

        private void btnSaveClient_Click(object sender, RoutedEventArgs e)
        {
            if(clientsAction == action.New)
            {
                Client clnt = new Client()
                {
                    DNI = txbClientDNI.Text,
                    IPAddress = txbClientIP.Text,
                    MACAddress = txbClientMAC.Text,
                    Name = txbClientName.Text,
                    LastName = txbClientLastName.Text,
                    NetSpeed = txbClientNetSpeed.Text,
                    Tariff = Int32.Parse(txbClientTariff.Text),
                    Phone = txbClientPhone.Text,
                    
                };

                if (chkbClientJanuary.IsChecked == true) 
                {
                    clnt.E = 'P'; 
                }
                else 
                {
                    clnt.E = 'X';
                }

                if (chkbClientFebruary.IsChecked == true)
                {
                    clnt.F = 'P';
                }
                else
                {
                    clnt.F = 'X';
                }

                if (chkbClientMarch.IsChecked == true)
                {
                    clnt.M = 'P';
                }
                else
                {
                    clnt.M = 'X';
                }

                if (chkbClientApril.IsChecked == true)
                {
                    clnt.A = 'P';
                }
                else
                {
                    clnt.A = 'X';
                }

                if (chkbClientMay.IsChecked == true)
                {
                    clnt.MY = 'P';
                }
                else
                {
                    clnt.MY = 'X';
                }

                if (chkbClientJune.IsChecked == true)
                {
                    clnt.J = 'P';
                }
                else
                {
                    clnt.J = 'X';
                }

                if (chkbClientJuly.IsChecked == true)
                {
                    clnt.JL = 'P';
                }
                else
                {
                    clnt.JL = 'X';
                }

                if (chkbClientAugust.IsChecked == true)
                {
                    clnt.AG = 'P';
                }
                else
                {
                    clnt.AG = 'X';
                }

                if (chkbClientSeptember.IsChecked == true)
                {
                    clnt.S = 'P';
                }
                else
                {
                    clnt.S = 'X';
                }

                if (chkbClientOctober.IsChecked == true)
                {
                    clnt.O = 'P';
                }
                else
                {
                    clnt.O = 'X';
                }

                if (chkbClientNovember.IsChecked == true)
                {
                    clnt.N = 'P';
                }
                else
                {
                    clnt.N = 'X';
                }

                if (chkbClientDecember.IsChecked == true)
                {
                    clnt.D = 'P';
                }
                else
                {
                    clnt.D = 'X';
                }

                if (clientHandler.Add(clnt))
                {
                    MessageBox.Show("Cliente agregado correctamente.", "Facturas Ade.Net", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearClientFields();
                    ActivateFields(false);
                    UpdateClientsTable();
                    ClientButtonsEditMode(false);
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el cliente.", "Facturas Ade.Net", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Client clnt = dtgClients.SelectedItem as Client;
                clnt.DNI = txbClientDNI.Text;
                clnt.Id = txbClientId.Text;
                clnt.IPAddress = txbClientIP.Text;
                clnt.MACAddress = txbClientMAC.Text;
                clnt.Name = txbClientName.Text;
                clnt.LastName = txbClientLastName.Text;
                clnt.NetSpeed = txbClientNetSpeed.Text;
                clnt.Tariff = Int32.Parse(txbClientTariff.Text);
                clnt.Phone = txbClientPhone.Text;

                if (chkbClientJanuary.IsChecked == true)
                {
                    clnt.E = 'P';
                }
                else
                {
                    clnt.E = 'X';
                }

                if (chkbClientFebruary.IsChecked == true)
                {
                    clnt.F = 'P';
                }
                else
                {
                    clnt.F = 'X';
                }

                if (chkbClientMarch.IsChecked == true)
                {
                    clnt.M = 'P';
                }
                else
                {
                    clnt.M = 'X';
                }

                if (chkbClientApril.IsChecked == true)
                {
                    clnt.A = 'P';
                }
                else
                {
                    clnt.A = 'X';
                }

                if (chkbClientMay.IsChecked == true)
                {
                    clnt.MY = 'P';
                }
                else
                {
                    clnt.MY = 'X';
                }

                if (chkbClientJune.IsChecked == true)
                {
                    clnt.J = 'P';
                }
                else
                {
                    clnt.J = 'X';
                }

                if (chkbClientJuly.IsChecked == true)
                {
                    clnt.JL = 'P';
                }
                else
                {
                    clnt.JL = 'X';
                }

                if (chkbClientAugust.IsChecked == true)
                {
                    clnt.AG = 'P';
                }
                else
                {
                    clnt.AG = 'X';
                }

                if (chkbClientSeptember.IsChecked == true)
                {
                    clnt.S = 'P';
                }
                else
                {
                    clnt.S = 'X';
                }

                if (chkbClientOctober.IsChecked == true)
                {
                    clnt.O = 'P';
                }
                else
                {
                    clnt.O = 'X';
                }

                if (chkbClientNovember.IsChecked == true)
                {
                    clnt.N = 'P';
                }
                else
                {
                    clnt.N = 'X';
                }

                if (chkbClientDecember.IsChecked == true)
                {
                    clnt.D = 'P';
                }
                else
                {
                    clnt.D = 'X';
                }


                if (clientHandler.Edit(clnt))
                {
                    MessageBox.Show("Cliente actualizado correctamente.", "facturas Ade.Net", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearClientFields();
                    UpdateClientsTable();
                    ClientButtonsEditMode(false);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el cliente.", "Facturas Ade.Net", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnCancelClient_Click(object sender, RoutedEventArgs e)
        {
            ClearClientFields();
            ClientButtonsEditMode(false);
        }

        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            Client clnt = dtgClients.SelectedItem as Client;

            if(clnt != null)
            {
                if(MessageBox.Show("¿Realmente desea eliminar este cliente?", "Facturas Ade.Net", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (clientHandler.Delete(clnt.Id))
                    {
                        MessageBox.Show("Cliente eliminado.", "Facturas Ade.Net", MessageBoxButton.OK, MessageBoxImage.Information);
                        UpdateClientsTable();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el cliente", "Facturas Ade.Net", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
