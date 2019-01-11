using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CASInterfaceService.Pages.Models
{
    public class CASAPTransaction
    {
        String operatingUnit;
        public String OperatingUnit
        {
            get { return operatingUnit; }
            set { operatingUnit = value; }
        }

        String invoiceType;
        [Required]
        [MaxLength(25)]
        public String InvoiceType 
        {
            get { return invoiceType;  }
            set { invoiceType = value; } 
        }

        String poNumber; // Must be NULL
        public String PONumber
        {
            get { return poNumber;  }
            set { poNumber = null; }
        }

        String supplierName;
        public String SupplierName
        {
            get { return supplierName;  }
            set { supplierName = value; }
        }

        String supplierNumber;
        [Required]
        [MaxLength(30)]
        public String SupplierNumber
        {
            get { return supplierNumber;  }
            set { supplierNumber = value; }
        }

        DateTime invoiceDate; // Format: 21-FEB-2017
        [Required]
        public DateTime InvoiceDate
        {
            get { return invoiceDate; }
            set { invoiceDate = value; }
        }

        String invoiceNumber;
        [Required]
        [MaxLength(40)]
        public String InvoiceNumber
        {
            get { return invoiceNumber; }
            set { invoiceNumber = value; }
        }

        Decimal invoiceAmount; // Format: 9(12).99
        [Required]
        public Decimal InvoiceAmount
        {
            get { return invoiceAmount; }
            set { invoiceAmount = value; }
        }

        String payGroup;
        [Required]
        [MaxLength(7)]
        public String PayGroup
        {
            get { return payGroup; }
            set { payGroup = value; }
        }

        DateTime dateInvoiceReceived; // Format: 21-FEB-2017
        [Required]
        public DateTime DateInvoiceReceived
        {
            get { return dateInvoiceReceived; }
            set { dateInvoiceReceived = value; }
        }

        DateTime dateGoodsReceived; // Format: 21-FEB-2017
        public DateTime DateGoodsReceived
        {
            get { return dateGoodsReceived; }
            set { dateGoodsReceived = value; }
        }

        String remittanceCode;
        [Required]
        [MaxLength(2)]
        public String RemittanceCode
        {
            get { return remittanceCode; }
            set { remittanceCode = value; }
        }

        String specialHandling;
        [Required]
        [MaxLength(1)]
        public String SpecialHandling
        {
            get { return specialHandling; }
            set { specialHandling = value; }
        }

        String nameLine1;
        [MaxLength(40)]
        public String NameLine1
        {
            get { return nameLine1; }
            set { nameLine1 = value; }
        }

        String nameLine2;
        [MaxLength(40)]
        public String NameLine2
        {
            get { return nameLine2; }
            set { nameLine2 = value; }
        }

        String addressLine1;
        [MaxLength(40)]
        public String AddressLine1
        {
            get { return addressLine1; }
            set { addressLine1 = value; }
        }

        String addressLine2;
        [MaxLength(40)]
        public String AddressLine2
        {
            get { return addressLine2; }
            set { addressLine2 = value; }
        }

        String addressLine3;
        [MaxLength(40)]
        public String AddressLine3
        {
            get { return addressLine3; }
            set { addressLine3 = value; }
        }

        String city;
        [MaxLength(25)]
        public String City
        {
            get { return city; }
            set { city = value; }
        }

        String country;
        [MaxLength(2)]
        public String Country
        {
            get { return country; }
            set { country = value; }
        }

        String province;
        [MaxLength(2)]
        public String Province
        {
            get { return province; }
            set { province = value; }
        }

        String postalCode;
        [MaxLength(10)]
        public String PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        String qualifiedReceiver;
        [MaxLength(150)]
        public String QualifiedReceiver
        {
            get { return qualifiedReceiver; }
            set { qualifiedReceiver = value; }
        }

        String terms;
        [Required]
        [MaxLength(50)]
        public String Terms
        {
            get { return terms; }
            set { terms = value; }
        }

        String payAloneFlag;
        [Required]
        [MaxLength(1, ErrorMessage = "payAlone must be 'Y' or 'N'")]
        public String PayAloneFlag
        {
            get { return payAloneFlag; }
            set {
                if (value == "")
                {
                    payAloneFlag = "N";
                }
                else
                {
                    payAloneFlag = value;
                }
            }
        }

        String paymentAdviceComments;
        [MaxLength(40)]
        public String PaymentAdviceComments
        {
            get { return paymentAdviceComments; }
            set { paymentAdviceComments = value; }
        }

        String remittanceMessage1;
        [MaxLength(150)]
        public String RemittanceMessage1
        {
            get { return remittanceMessage1; }
            set { remittanceMessage1 = value; }
        }

        String remittanceMessage2;
        [MaxLength(150)]
        public String RemittanceMessage2
        {
            get { return remittanceMessage2; }
            set { remittanceMessage2 = value; }
        }

        String remittanceMessage3;
        [MaxLength(150)]
        public String RemittanceMessage3
        {
            get { return remittanceMessage3; }
            set { remittanceMessage3 = value; }
        }

        DateTime termsDate; // Format: 21-FEB-2017
        public DateTime TermsDate
        {
            get { return termsDate; }
            set { termsDate = value; }
        }

        DateTime glDate; // Format: 21-FEB-2017
        [Required]
        public DateTime GLDate
        {
            get { return glDate; }
            set { glDate = value; }
        }

        String invoiceBatchName;
        [Required]
        [MaxLength(50)]
        public String InvoiceBatchName
        {
            get { return invoiceBatchName; }
            set { invoiceBatchName = value; }
        }

        String currencyCode;
        [Required]
        [MaxLength(3)]
        public String CurrencyCode
        {
            get { return currencyCode; }
            set { currencyCode = "CAD"; }
        }

        List<InvoiceLineDetail> invoiceLineDetails;
        public List<InvoiceLineDetail> InvoiceLineDetails
        {
            get { return invoiceLineDetails; }
            set { invoiceLineDetails = value; }
        }





        //DateTime glDate; // Format: 21-FEB-2017
        //public DateTime GLDate
        //{
        //    get { return glDate; }
        //    set { glDate = value; }
        //}

        String poReference; 
        public String POReference
        {
            get { return poReference; }
            set { poReference = value; }
        }

        String t4aReportingCode;
        public String T4aReportingCode
        {
            get { return t4aReportingCode; }
            set { t4aReportingCode = value; }
        }

        DateTime t4aInvoiceDate; // Format: 21-FEB-2017
        public DateTime T4aInvoiceDate
        {
            get { return t4aInvoiceDate; }
            set { t4aInvoiceDate = value; }
        }

        String lineSource;
        public String LineSource
        {
            get { return lineSource; }
            set { lineSource = value; }
        }

        String approvalStatus;
        public String ApprovalStatus
        {
            get { return approvalStatus; }
            set { approvalStatus = value; }
        }

        //String poNumber;
        //public String PONumber
        //{
        //    get { return poNumber; }
        //    set { poNumber = value; }
        //}

        String poLine;
        public String POLine
        {
            get { return poLine; }
            set { poLine = value; }
        }

        String poShipment;
        public String POShipment
        {
            get { return poShipment; }
            set { poShipment = value; }
        }

        String poDistribution;
        public String PODistribution
        {
            get { return poDistribution; }
            set { poDistribution = value; }
        }

        String trackAsAsset;
        public String TrackAsAsset
        {
            get { return trackAsAsset; }
            set { trackAsAsset = value; }
        }

        String assetBook;
        public String AssetBook
        {
            get { return assetBook; }
            set { assetBook = value; }
        }

        String quantityInvoiced;
        public String QuantityInvoiced
        {
            get { return quantityInvoiced; }
            set { quantityInvoiced = value; }
        }

        //String lineSource;
        //public String LineSource
        //{
        //    get { return lineSource; }
        //    set { lineSource = value; }
        //}

        DateTime expenditureItemDate; // Format: 21-FEB-2017
        public DateTime ExpenditureItemDate
        {
            get { return expenditureItemDate; }
            set { expenditureItemDate = value; }
        }

        String uom;
        public String UOM
        {
            get { return uom; }
            set { uom = value; }
        }

        Decimal unitPrice; // Format: 9(12).99
        public Decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        String itemDescription;
        public String ItemDescription
        {
            get { return itemDescription; }
            set { itemDescription = value; }
        }

        //String approvalStatus;
        //public String ApprovalStatus
        //{
        //    get { return approvalStatus; }
        //    set { approvalStatus = value; }
        //}
    }




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

    public class UpdateCASAPTransaction
    {
        String invoiceNumber;
        [Required]
        [MaxLength(40)]
        public String InvoiceNumber
        {
            get { return invoiceNumber; }
            set { invoiceNumber = value; }
        }

        String invoiceStatus;
        public string InvoiceStatus
        {
            get { return invoiceStatus; }
            set { invoiceStatus = value; }
        }

        String paymentStatus;
        public string PaymentStatus
        {
            get { return paymentStatus; }
            set { paymentStatus = value; }
        }

        Double paymentNumber;
        public Double PaymentNumber
        {
            get { return paymentNumber;  }
            set { paymentNumber = value; }
        }

        DateTime paymentDate;
        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }
    }
}
