using System;
using System.Collections.Generic;
using System.Text;

namespace JackalopePDFTester
{
    public class InvoiceItem
    {
        public int No { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        public InvoiceItem(int no, string description, int quantity, string unit, decimal unitPrice)
        {
            No = no;
            Description = description;
            Quantity = quantity;
            Unit = unit;
            UnitPrice = unitPrice;
        }
        public InvoiceItem()
        {
        }

        public List<InvoiceItem> GetSampleInvoiceItems()
        {
            return new List<InvoiceItem>()
            {
                new InvoiceItem( 1,"Medison Bag - Black", 2, "pcs", 3500 ),
                new InvoiceItem(2, "Esme Bag - Gold",1,"pcs", 4900 ),
                new InvoiceItem(3, "Celeste Bag - Midnight Blue",1,"pcs", 7200 ),
                new InvoiceItem(4, "Gift Box - Premium",1,"set", 500 ),
                new InvoiceItem(5, "Leather Wallet - Compact",3,"pcs", 950 ),
                new InvoiceItem(6, "Card Holder - Gold Edge",2,"pcs", 750 ),
                new InvoiceItem(7, "Surlan Keychain",5,"pcs", 150 ),
                new InvoiceItem(8, "Limited Edition Strap",1,"pcs", 1290 ),
                new InvoiceItem(9, "Scented Leather Spray",2,"bottle", 350 ),
                new InvoiceItem(10, "Mini Tote - Beige",1,"pcs", 2800 ),
                new InvoiceItem(11, "Crossbody Chain Strap",1,"pcs", 590 ),
                new InvoiceItem(12, "Surlan Sticker Set",2,"set", 120 ),
                new InvoiceItem(13, "Esme Bag - Silver",1,"pcs", 4900 ),
                new InvoiceItem(14, "Limited Packaging Box",1,"set", 300 ),
                new InvoiceItem(15, "Medison Bag - Wine Red",1,"pcs", 3700 ),
                new InvoiceItem(16, "Silk Dust Bag",2,"pcs", 200 ),
                new InvoiceItem(17, "Celeste Bag - Pearl White",1,"pcs", 7600 ),
                new InvoiceItem(18, "Charm Pendant - Snake",1,"pcs", 490 ),
                new InvoiceItem(19, "Zipper Repair Kit",1,"pcs", 150 ),
                new InvoiceItem(20, "Custom Engraving Service",1,"job", 350 ),
               /* new InvoiceItem(21, "Velvet Bag Insert - Black", 2, "pcs", 320),
                new InvoiceItem(22, "Limited Edition Dust Cover", 1, "pcs", 650),
                new InvoiceItem(23, "Surlan Travel Tag", 3, "pcs", 220),
                new InvoiceItem(24, "Signature Lining Fabric", 1, "yard", 890),
                new InvoiceItem(25, "Polishing Cloth Set", 2, "set", 180),
                new InvoiceItem(26, "Custom Leather Patch", 1, "pcs", 410),
                new InvoiceItem(27, "Esme Bag - Emerald Green", 1, "pcs", 5100),
                new InvoiceItem(28, "Surlan Scarf - Noir Pattern", 1, "pcs", 1100),
                new InvoiceItem(29, "Medison Mini - Blush Pink", 1, "pcs", 2990),
                new InvoiceItem(30, "Gift Ribbon Roll - Black Gold", 1, "roll", 150),*/
            };
        }
    }
}
