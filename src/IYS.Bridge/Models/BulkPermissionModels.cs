using System;
using System.Collections.Generic;

namespace IYS.Bridge.Models
{
    public class TransasctionListModel
    {
        public string consentDate { get; set; }
        public string creationDate { get; set; }
        public string source { get; set; }
        public string recipient { get; set; }
        public string recipientType { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string transactionId { get; set; }
    }

    public class BulkPermissionResponseModel
    {
        public string after { get; set; }
        public List<TransasctionListModel> list { get; set; }
    }
}
