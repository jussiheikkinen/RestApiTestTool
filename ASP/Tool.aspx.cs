using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Harjoitustyö_WPF;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ASP
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Page.ClientScript.RegisterClientScriptInclude("skriptit", "Scripts/skriptit.js");

        }

        protected void callApi_Click(object sender, EventArgs e)
        {

            string uri = requestUri.Text.Trim();//Request.Form["uri"];

            String[] keys = (Request.Form["key[]"] ?? "").Split(','), values = (Request.Form["value[]"] ?? "").Split(',');
            List<KeyValuePair<String, String>> param = new List<KeyValuePair<String, String>>();
            for (int i = 0; i < keys.Length; i++)
            {
                param.Add(new KeyValuePair<string, string>(keys[i], values[i]));
            }

            String[] headerKeys = (Request.Form["headerKey[]"] ?? "").Split(','), headerValues = (Request.Form["headerValue[]"] ?? "").Split(',');
            List<KeyValuePair<String, String>> headers = new List<KeyValuePair<String, String>>();
            for (int i = 0; i < headerKeys.Length; i++)
            {
                headers.Add(new KeyValuePair<string, string>(headerKeys[i], headerValues[i]));
            }

            ApiCallHandler handler = new ApiCallHandler();
            string res = "";
            try {
                switch (method.Text) {
                    case "post":
                        res = handler.postData(uri, param, headers);
                        break;

                    case "get":
                        String query = string.Join("&", param.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value)));
                        res = handler.getData(uri + '?' + query, headers);
                        break;

                    case "put":
                        res = handler.putData(uri, param, headers);
                        break;

                    case "delete":
                        res = handler.deleteData(uri, param, headers);
                        break;
                }

                result.Text = JValue.Parse(res).ToString(Formatting.Indented);
                //resultStatus.InnerText = 
                resultSize.InnerText = result.Text.Length + " b";
            }
            catch (Exception ex) { result.Text = ex.Message; result.CssClass = "form-control has-error"; }

            //System.Diagnostics.Debug.WriteLine("uri=" + uri);
            //System.Diagnostics.Debug.WriteLine("query=" + query);
            //System.Diagnostics.Debug.WriteLine("method=" + method);

        }
    }
}