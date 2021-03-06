﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

            try
            {
                if (rbGET.IsChecked == true)
                {

                    txtResponse.Text = JValue.Parse(handler.getData(getParams(), httpHeaders())).ToString(Formatting.Indented);
                }

                else if (rbPOST.IsChecked == true)
                {

                    txtResponse.Text = handler.postData(address, postParams(),httpHeaders());
                }

                else if (rbPUT.IsChecked == true)
                {

                    txtResponse.Text = handler.putData(address, postParams(),httpHeaders());
                }

                else if (rbDELETE.IsChecked == true)
                {
                    txtResponse.Text = handler.deleteData(address, postParams(),httpHeaders());
                }

            }
            catch (Exception ex)
            {
                changeStatus(ex);
            }
        }
        
        private void btnNewValue_Click(object sender, RoutedEventArgs e)
        {
               /*    
             TextBox txtKey = new TextBox();           
             txtKey.PreviewKeyUp += new KeyEventHandler(btnNewValue_Click);
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
                        address += (i == 0 ? "?" : "&") + item.Key + "=" + item.Value;    
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

        protected List<KeyValuePair<String, String>> httpHeaders(){
            var list = new List<KeyValuePair<String, String>>();
            list.Add(new KeyValuePair<String, String>(headerKey1.Text.ToString(), headerVal1.Text.ToString()));
            list.Add(new KeyValuePair<String, String>(headerKey2.Text.ToString(), headerVal2.Text.ToString()));
            list.Add(new KeyValuePair<String, String>(headerKey3.Text.ToString(), headerVal3.Text.ToString()));
            return list;
        }



        //Status barin ilmoitukset
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
