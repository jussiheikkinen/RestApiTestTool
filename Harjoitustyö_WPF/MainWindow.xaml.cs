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

namespace Harjoitustyö_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
       TextBox txtKey = new TextBox();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ApiCallHandler handler = new ApiCallHandler();
            String address = txtURL.Text.ToString(); 
            clearStatus();                       
            
            if (rbGET.IsChecked == true)
            {
                try
                {
                    dgView.ItemsSource = handler.getData(getParams()).DefaultView;
                }
                catch (Exception ex)
                {
                    changeStatus(ex);
                }
            }

            if (rbPOST.IsChecked == true)
            {
                try
                {
                    dgView.ItemsSource = handler.postData(address, postParams()).DefaultView;
                }
                catch (Exception ex)
                {

                    changeStatus(ex);
                }               
            }

            if (rbPUT.IsChecked == true)
            {
                try
                {                    
                    dgView.ItemsSource = handler.putData(address,postParams()).DefaultView;
                }
                catch (Exception ex)
                {

                    changeStatus(ex);
                }
            }

            if (rbDELETE.IsChecked == true) {
                try
                {
                    dgView.ItemsSource = handler.deleteData(address, postParams()).DefaultView;
                }
                catch (Exception ex)
                {

                    changeStatus(ex);
                }
            }
        }
        
        private void btnNewValue_Click(object sender, RoutedEventArgs e)
        {
             /*       
             TextBox txtKey = new TextBox();           
             txtKey.PreviewKeyUp += new KeyEventHandler(uusiKey);
             txtKey.Text = "key";
             TextBox txtVal = new TextBox();
             txtVal.Text = "val";
             keyStackPanel.Children.Add(txtKey);
             valStackPanel.Children.Add(txtVal);          
                     */
        }

        protected String getParams() {
            String address = txtURL.Text.ToString();

            var list = new List<KeyValuePair<String, String>>();
            list.Add(new KeyValuePair<String, String>(txtKey1.Text.ToString(), txtVal1.Text.ToString()));
            list.Add(new KeyValuePair<String, String>(txtKey2.Text.ToString(), txtVal2.Text.ToString()));
            list.Add(new KeyValuePair<String, String>(txtKey3.Text.ToString(), txtVal3.Text.ToString()));
            list.Add(new KeyValuePair<String, String>(txtKey4.Text.ToString(), txtVal4.Text.ToString()));
            list.Add(new KeyValuePair<String, String>(txtKey5.Text.ToString(), txtVal5.Text.ToString()));
           
                int i = 0;
                foreach (var item in list)
                {
                    if (!String.IsNullOrWhiteSpace(item.Key))
                    {
                        if (i == 0)
                        {
                            address += "?" + item.Key + "=" + item.Value;
                        }
                        else
                        {
                            address += "&" + item.Key + "=" + item.Value;
                        }
                    }
                    i++;
                } 
            return address;
        }

        protected List<KeyValuePair<String, String>> postParams(){
            var list = new List<KeyValuePair<String, String>>();
                        
            list.Add(new KeyValuePair<String, String>(txtKey1.Text.ToString(), txtVal1.Text.ToString()));
            list.Add(new KeyValuePair<String, String>(txtKey2.Text.ToString(), txtVal2.Text.ToString()));
            list.Add(new KeyValuePair<String, String>(txtKey3.Text.ToString(), txtVal3.Text.ToString()));
            list.Add(new KeyValuePair<String, String>(txtKey4.Text.ToString(), txtVal4.Text.ToString()));
            list.Add(new KeyValuePair<String, String>(txtKey5.Text.ToString(), txtVal5.Text.ToString())); 
                      
            return list;
        }

        public void changeStatus(Exception e) {
            lblStatus.Background = Brushes.Red;
            lblStatus.Content = e;
        }
        public void clearStatus()
        {
            lblStatus.Background = Brushes.WhiteSmoke;
            lblStatus.Content = "ready";
        }

    }
}
