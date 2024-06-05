using P_K_accounting.Models;
using System.Text.Json;

namespace P_K_accounting.Service.GridViewServices
{
    public class GridViewBillService
    {
        public async Task<List<PaymentBillAccountantViewModel>> AddRecordToGrid(HttpResponseMessage response, DataGridView currentGrid)
        {
            var currentDataSource = (List<PaymentBillAccountantViewModel>)currentGrid.DataSource;
            var content = await response.Content.ReadAsStringAsync();
            var paymentBillRecord = JsonSerializer.Deserialize<PaymentBillAccountantViewModel>(content);
            var newPaymentRecord = new PaymentBillAccountantViewModel
            {
                PaymentBillId = paymentBillRecord.PaymentBillId,
                ServiceName = paymentBillRecord.ServiceName,
                Amount = paymentBillRecord.Amount,
                IssueDate = paymentBillRecord.IssueDate,
                DueToDate = paymentBillRecord.DueToDate,
                PaymentDate = paymentBillRecord.PaymentDate,
                PaymentStatus = paymentBillRecord.PaymentStatus
            };

            var updatedDataSource = new List<PaymentBillAccountantViewModel>(currentDataSource) { newPaymentRecord };
            return updatedDataSource;

        }

        public async Task<List<PaymentBillAccountantViewModel>> UpdateRecordInGrid(HttpResponseMessage response, DataGridView currentGrid)
        {
            var currentDataSource = (List<PaymentBillAccountantViewModel>)currentGrid.DataSource;
            var content = await response.Content.ReadAsStringAsync();
            var paymentBillUpdatedRecord = JsonSerializer.Deserialize<PaymentBillAccountantViewModel>(content);

            var currentRecord = currentDataSource.FirstOrDefault(record => record.PaymentBillId == paymentBillUpdatedRecord.PaymentBillId);
            if (currentRecord != null)
            {
                currentRecord.ServiceName = paymentBillUpdatedRecord.ServiceName;
                currentRecord.Amount = paymentBillUpdatedRecord.Amount;
                currentRecord.IssueDate = paymentBillUpdatedRecord.IssueDate;
                currentRecord.DueToDate = paymentBillUpdatedRecord.DueToDate;
                currentRecord.PaymentDate = paymentBillUpdatedRecord.PaymentDate;
                currentRecord.PaymentStatus = paymentBillUpdatedRecord.PaymentStatus;
            }

            return currentDataSource;
        }

        public async Task<List<PaymentBillAccountantViewModel>> DeleteRecordFromGrid(int id, DataGridView currentGrid)
        {
            var currentDataSource = (List<PaymentBillAccountantViewModel>)currentGrid.DataSource;
            var paymentBillToRemove = currentDataSource.FirstOrDefault(bill => bill.PaymentBillId == id);
            if (paymentBillToRemove != null)
            {
                currentDataSource.Remove(paymentBillToRemove);
            }

            var updatedDataSource = new List<PaymentBillAccountantViewModel>(currentDataSource);
            return updatedDataSource;
        }
    }
}