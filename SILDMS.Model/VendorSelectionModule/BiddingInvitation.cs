using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.VendorSelectionModule
{
    public class BiddingInvitation
    {
    }


    public class InvitationMasterViewModel
    {
        public string BiddingProcessNumber { get; set; }
        public DateTime BiddingProcessDate { get; set; }
        public string BiddingProcessDateString { get; set; }
        public string InvitationNumber { get; set; }
        public DateTime InvitationSendingDate { get; set; }
        public string InvitationSendingDateString { get; set; }
        public DateTime QuotationSendingLastDate { get; set; }
        public string QuotationSendingLastDateString { get; set; }
        public DateTime QuotationRevealDate { get; set; }
        public string QuotationRevealDateString { get; set; }
        public string Note { get; set; }
        public string InvitationSendingPerson { get; set; }
        public string ProposalType { get; set; }
        public int BiddingItemVendorID { get; set; }
        public string DeliveryLocation { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryDateString { get; set; }
        public Decimal DeliveryQty { get; set; }
        public string PaymentMode { get; set; }
        public string ShipmentMode { get; set; }
        public string Transport { get; set; }
        public Decimal Price { get; set; }
        public string Currency { get; set; }
        public Decimal VAT { get; set; }
        public string Incoterms { get; set; }
        public string EmailID { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
    }
    public class InvitationDetailViewModel
    {
        public int BiddingItemVendorID { get; set; }
        
        public string VendorTitle { get; set; }
        public string ItemNo { get; set; }
        public string MaterialName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialCategory { get; set; }
        public string MaterialType { get; set; }
        public string MaterialGroup { get; set; }
        public Decimal RequestQty { get; set; }
        public Decimal Unit { get; set; }
        public int DocumentID { get; set; }
    }
    public class InvitationMaster
    {
        public string InvitationNumber { get; set; }
        public DateTime InvitationSendingDate { get; set; }
        public DateTime QuotationSendingLastDate { get; set; }
        public DateTime QuotationRevealDate { get; set; }
        public string Note { get; set; }
        public string InvitationSendingPerson { get; set; }
        public string ProposalType { get; set; }
        public string EmailID { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
    }
    public class InvitationDetail
    {
        public string BiddingProcessNumber { get; set; }
        public int BiddingItemVendorID { get; set; }
        public string DeliveryLocation { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Decimal DeliveryQty { get; set; }
        public string PaymentMode { get; set; }
        public string ShipmentMode { get; set; }
        public string Transport { get; set; }
        public Decimal Price { get; set; }
        public string Currency { get; set; }
        public Decimal VAT { get; set; }
        public string Incoterms { get; set; }
        public string VendorTitle { get; set; }
        public string PhoneNo { get; set;}
        public string Email { get; set; }
        public int DocumentID { get; set; }
        public string MaterialName { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialCategory { get; set; }
        public string MaterialType { get; set; }
        public string MaterialGroup { get; set; }
        public Decimal RequestQty { get; set; }
        public Decimal Unit { get; set; }
        public string ItemNo { get; set; }
    }

}
