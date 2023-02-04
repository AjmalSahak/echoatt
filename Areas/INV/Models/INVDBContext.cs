using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlphaTechMIS.Areas.INV.Models
{
    public class INVDBContext : DbContext
    {
        public INVDBContext() : base("ATSConnection") { }
        public DbSet<ChartOfAccount> ChartOfAccounts { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationDetail> QuotationDetails { get; set; }
        public DbSet<QuotationProduct> QuotationProducts { get; set; }
        public DbSet<StockSetting> StockSettings { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<TransactionProduct> TransactionProducts { get; set; }
        public DbSet<z_Unit> z_Units { get; set; }
        public DbSet<zCountry> zCountrys { get; set; }
        public DbSet<zCurrency> zCurrencys { get; set; }
        public DbSet<zDealType> zDealTypes { get; set; }
        public DbSet<zProCategory> zProCategorys { get; set; }
        public DbSet<zProduct> zProducts { get; set; }
        public DbSet<zProductType> zProductTypes { get; set; }
        public DbSet<zProvince> zProvinces { get; set; }
        public DbSet<zStockType> zStockTypes { get; set; }
        public DbSet<zTransactionType> zTransactionTypes { get; set; }
    }
}