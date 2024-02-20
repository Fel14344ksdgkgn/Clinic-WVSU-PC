using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Clinic_WVSU_PC
{
    internal class DataGridViewPrinter
    {
        private DataGridView dataGridView;
        private PrintDocument printDocument;

        public DataGridViewPrinter(DataGridView dataGridView, PrintDocument printDocument)
        {
            this.dataGridView = dataGridView;
            this.printDocument = printDocument;
            // Hook up PrintPage event handler
            printDocument.PrintPage += PrintDocument_PrintPage;
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Define variables for layout
            int rowHeight = dataGridView.RowTemplate.Height;
            int rowsPerPage = e.MarginBounds.Height / rowHeight;
            int rowIndex = 0;
            int columnLeft = e.MarginBounds.Left;
            int top = e.MarginBounds.Top; // Store the initial top position

            // Loop through rows to print
            while (rowIndex < dataGridView.Rows.Count && rowsPerPage > 0)
            {
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                // Loop through columns to print
                for (int columnIndex = 0; columnIndex < dataGridView.Columns.Count; columnIndex++)
                {
                    DataGridViewCell cell = row.Cells[columnIndex];
                    Rectangle cellBounds = new Rectangle(columnLeft, top, cell.Size.Width, rowHeight);
                    // Draw cell content
                    e.Graphics.DrawString(cell.FormattedValue.ToString(), dataGridView.Font, Brushes.Black, cellBounds);
                    columnLeft += cell.Size.Width;
                }
                columnLeft = e.MarginBounds.Left;
                top += rowHeight; // Update the top position
                rowIndex++;
                rowsPerPage--;
            }
            // Check if there are more rows to print
            e.HasMorePages = (rowIndex < dataGridView.Rows.Count);
        }

    }
}
