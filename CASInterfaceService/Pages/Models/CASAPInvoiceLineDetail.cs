using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CASInterfaceService.Pages.Models
{
    public class InvoiceLineDetail:IValidatableObject
    {
        Int32 invoiceLineNumber;
        [Required]
        public Int32 InvoiceLineNumber
        {
            get { return invoiceLineNumber; }
            set { invoiceLineNumber = value; }
        }

        String invoiceLineType;
        [Required]
        [MaxLength(4, ErrorMessage = "invoiceLineType must be 'Item'")]
        public String InvoiceLineType
        {
            get { return invoiceLineType; }
            set { invoiceLineType = "Item"; }
        }

        String distributionTotal; // Must be NULL
        public String DistributionTotal
        {
            get { return distributionTotal; }
            set { distributionTotal = null; }
        }

        String lineCode;
        [Required]
        [MaxLength(2, ErrorMessage = "lineCode must be 'DR' or 'CR'")]
        public String LineCode
        {
            get { return lineCode; }
            set { lineCode = value; }
        }

        Decimal invoiceLineAmount; // Format: 9(12).99
        [Required]
        public Decimal InvoiceLineAmount
        {
            get { return invoiceLineAmount; }
            set { invoiceLineAmount = value; }
        }

        String defaultDistributionAccount;
        [Required]
        [MaxLength(40)]
        public String DefaultDistributionAccount
        {
            get { return defaultDistributionAccount; }
            set { defaultDistributionAccount = value; }
        }

        String description;
        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        String taxClassificationCode;
        [MaxLength(30)]
        public String TaxClassificationCode
        {
            get { return taxClassificationCode; }
            set { taxClassificationCode = value; }
        }

        String distributionSupplier;
        [MaxLength(30)]
        public String DistributionSupplier
        {
            get { return distributionSupplier; }
            set { distributionSupplier = value; }
        }

        String info1;
        [MaxLength(25)]
        public String Info1
        {
            get { return info1; }
            set { info1 = value; }
        }

        String info2;
        [MaxLength(10)]
        public String Info2
        {
            get { return info2; }
            set { info2 = value; }
        }

        String info3;
        [MaxLength(8)]
        public String Info3
        {
            get { return info3; }
            set { info3 = value; }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!(LineCode == "DR" || LineCode == "CR"))
            {
                yield return new ValidationResult("Invalid LineCode");
            }
        }
    }
}
