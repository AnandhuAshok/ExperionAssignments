using System;
using System.Collections.Generic;
using System.Text;

namespace xmlparsing
{
    class Transaction
    {
        public String TransactionID { get; set; }
        public long Acnumber { get; set; }
        public string TransactionType { get; set; }
        public int Amount { get; set; }
        public String Remarks { get; set; }

        
    }
}
