using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace Harjoitustyö_WPF
{
    public class ApiCallHandler
    {
        private DataTable dt = new DataTable();

        //Suoritetaan GET tyyppiset http kutsut
        public DataTable getData(String linkki){
                        
            dt.Columns.Add("Data", typeof(string));
            WebClient client = new WebClient();
           
                Stream stream = client.OpenRead(linkki);
                StreamReader reader = new StreamReader(stream);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                dt.Rows.Add(line);
                }
            return dt;
        }

        //Suoritetaan POST tyyppiset http kutsut
        public DataTable postData(String linkki, List<KeyValuePair<String, String>> list)
        {            
            WebClient client = new WebClient();
            NameValueCollection collection = new NameValueCollection();
            
            foreach (var item in list) {
                if (!String.IsNullOrWhiteSpace(item.Key)) collection.Add(item.Key, item.Value);                
            }
            byte[] response = client.UploadValues(linkki, collection);
            String result = System.Text.Encoding.UTF8.GetString(response);
            
            dt.Columns.Add("Data", typeof(string));
            dt.Rows.Add(result);
            return dt;
        }

        public DataTable putData(String linkki, List<KeyValuePair<String, String>> list)
        {            
            String keyvalues = "";
            foreach (var item in list)
            {
                if (!String.IsNullOrWhiteSpace(item.Key)) keyvalues += "&" + item.Key + item.Value;                
            }
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(keyvalues.Substring(1));
            WebClient client = new WebClient();
            byte[] response = client.UploadData(linkki, "PUT", byteArray);
            String result = System.Text.Encoding.UTF8.GetString(response);

            dt.Columns.Add("PUT response", typeof(string));
            dt.Rows.Add(result);            
            return dt;
        }

        public DataTable deleteData(String linkki, List<KeyValuePair<String, String>> list) {
            String keyvalues = "";
            foreach (var item in list)
            {
                if (!String.IsNullOrWhiteSpace(item.Key)) keyvalues += "&" + item.Key + "=" + item.Value;
            }
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(keyvalues.Substring(1));
            WebClient client = new WebClient();
            byte[] response = client.UploadData(linkki, "DELETE", byteArray);
            String result = System.Text.Encoding.UTF8.GetString(response);

            dt.Columns.Add("PUT response", typeof(string));
            dt.Rows.Add(result);
            return dt;
        }
        
    }
}
