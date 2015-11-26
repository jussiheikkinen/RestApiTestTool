using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            string uri = Request.Form["uri"], method = Request.Form["method"];

            String[] keys = Request.Form["key[]"].Split(','), values = Request.Form["value[]"].Split(',');
            List<KeyValuePair<String,String>> param = new List<KeyValuePair<String,String>>();
            for(int i = 0; i < keys.Length; i++)
            {
                param.Add(new KeyValuePair<string, string>(keys[i], values[i]));
            }

            String query = string.Join("&", param.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value)));

            System.Diagnostics.Debug.WriteLine("uri=" + uri);
            System.Diagnostics.Debug.WriteLine("query=" + query);
            System.Diagnostics.Debug.WriteLine("method=" + method);

        }
    }
}