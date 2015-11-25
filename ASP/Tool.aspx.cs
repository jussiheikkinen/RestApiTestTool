using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addKeyValuePair_Click(object sender, EventArgs e)
        {
            TableRow row = new TableRow();
            TableCell keyCell = new TableCell(), valueCell = new TableCell();
            TextBox key = new TextBox(), value = new TextBox();

            key.ID = "key[]";
            value.ID = "value[]";

            keyCell.Controls.Add(key);
            valueCell.Controls.Add(value);

            row.Cells.Add(keyCell);
            row.Cells.Add(valueCell);

            keyValuePairTable.Rows.Add(row);
        }
    }
}