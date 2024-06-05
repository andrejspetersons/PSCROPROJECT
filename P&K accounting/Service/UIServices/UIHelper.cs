using System.Net;
using System.Text.Json;

namespace P_K_accounting.Service.UIServices
{
    public class UIHelper
    {
        public void DropDownLoadingMode(ComboBox dropDownOnLoad)
        {
            dropDownOnLoad.Text = "Loading...";
            dropDownOnLoad.Enabled = false;
        }

        public void DropDownLoaded(ComboBox dropDownLoaded)
        {
            dropDownLoaded.Text = "";
            dropDownLoaded.Enabled = true;
        }

        public void DropDownFailToLoad(ComboBox failLoad)
        {
            failLoad.Text = "No items available";
            failLoad.Enabled = false;
        }

        public void TogglePanels(Panel visiblePanel, Panel hidePanel)
        {
            Point location = new Point(12, 75);
            visiblePanel.Visible = true;
            hidePanel.Visible = false;
            visiblePanel.Location = location;
        }

        public void HighlightLatePayments(DataGridViewRow row)
        {
            if (row.Cells[5].Value == null) return;
            if (DateTime.TryParse(row.Cells[4].Value.ToString(), out var dueToDate) &&
                DateTime.TryParse(row.Cells[5].Value.ToString(), out var paymentDate) &&
                paymentDate > dueToDate)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 87, 87);
            }
        }

        public async Task<DialogResult> GetDialogByResponse(HttpResponseMessage response)
        {
            var message = string.Empty;
            var title = string.Empty;
            var buttons = MessageBoxButtons.OK;

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    message = "Operation was successfull";
                    title = "Info";
                    break;
                case HttpStatusCode.Conflict:
                    var conflictMessage = await response.Content.ReadAsStringAsync();
                    var conflicts= JsonSerializer.Deserialize<List<string>>(conflictMessage);
                    message = string.Join("\n\n", conflicts);
                    title = "Warn";
                    break;
                case HttpStatusCode.BadRequest:
                    var errorsMessage = await response.Content.ReadAsStringAsync();
                    var errors = JsonSerializer.Deserialize<List<string>>(errorsMessage);
                    message = string.Join("\n\n", errors);
                    title = "Entered data is incorrect";
                    break;
                case HttpStatusCode.NotFound:
                    message = "Item not found";
                    title = "Error";
                    break;
                default:
                    message = "Unhandled error appears {response.StatusCode}";
                    title = "Error";
                    buttons = MessageBoxButtons.OKCancel;
                    break;
            }

            return MessageBox.Show(message, title, buttons);
        }
    }
}
