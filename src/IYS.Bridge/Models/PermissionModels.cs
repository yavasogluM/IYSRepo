using System;
namespace IYS.Bridge.Models
{
    public class PermissionRequestModel
    {
        public string recipient { get; set; }
        public string recipientType { get; set; }
        public string type { get; set; }
    }

    public class PermissionResponseModel
    {
        public string consentDate { get; set; }
        public string source { get; set; }
        public string recipientType { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string recipient { get; set; }
        public string retailerCode { get; set; }
        public string creationDate { get; set; }
        public string retailerTitle { get; set; }
        public int retailerAccessCount { get; set; }
        public string transactionId { get; set; }
    }
}
