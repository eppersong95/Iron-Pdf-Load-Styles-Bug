using HandlebarsDotNet;
using IronPdf;
using IronPdf.Rendering;
using IronPdfConsoleApp.Classes.CustomerInvoice;
using System.Reflection;

var currentDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

//Get key from email
IronPdf.License.LicenseKey = "";
IronPdf.Logging.Logger.EnableDebugging = true;
IronPdf.Logging.Logger.LogFilePath = $"{currentDirectory}\\Logs\\Logs-{DateTime.UtcNow.Ticks}.txt";
IronPdf.Logging.Logger.LoggingMode = IronPdf.Logging.Logger.LoggingModes.All;


GeneratePdf();

static void GeneratePdf()
{
    var customerInvoiceModel = GetCustomerInvoiceModel();
    var customerInvoiceHtml = GetCustomerInvoiceHtml(customerInvoiceModel);
    var customerInvoiceHeaderHtml = GetCustomerInvoiceHeaderHtml(customerInvoiceModel);
    var customerInvoiceFooterHtml = GetCustomerInvoiceFooterHtml();

    var options = new ChromePdfRenderOptions
    {
        HtmlHeader = new HtmlHeaderFooter
        {
            HtmlFragment = customerInvoiceHeaderHtml,
            MaxHeight = 35,
            LoadStylesAndCSSFromMainHtmlDocument = true,
        },
        HtmlFooter = new HtmlHeaderFooter
        {
            HtmlFragment = customerInvoiceFooterHtml,
            MaxHeight = 35,
            LoadStylesAndCSSFromMainHtmlDocument = true
        },
        PaperSize = PdfPaperSize.A4,
        MarginBottom = 20,
        MarginLeft = 10,
        MarginRight = 10,
        MarginTop = 20,
        CustomCssUrl = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Css\\bootstrap-4.00.min.css"),
        PaperOrientation = PdfPaperOrientation.Portrait,
        CreatePdfFormsFromHtml = false,
        FitToPaperWidth = false,
        PrintHtmlBackgrounds = true
    };

    var pdf = ChromePdfRenderer.StaticRenderHtmlAsPdf(customerInvoiceHtml, options);

    var currentDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
    File.WriteAllBytes($"{currentDirectory}\\Output\\CustomerInvoice-{DateTime.UtcNow.Ticks}.pdf", pdf.BinaryData);
}

static string GetCustomerInvoiceHtml(CustomerInvoiceModel model)
{
    return MergeHtml("CustomerInvoice", new { model = model });
}

static string GetCustomerInvoiceHeaderHtml(CustomerInvoiceModel invoiceModel)
{
    var model = new
    {
        InvoiceNumber = invoiceModel.InvoiceNumber,
        InvoiceDateFormatted = invoiceModel.InvoiceDateFormatted,
        InvoiceTotalFormatted = invoiceModel.InvoiceTotalFormatted,
        DueDateFormatted = invoiceModel.DueDateFormatted,
        invoiceModel.CustomerNumber,
        invoiceModel.PaymentTermsFormatted,
        SalesGroupName = invoiceModel.SalesGroupName
    };

    return MergeHtml("CustomerInvoiceHeader", new { model = model });
}

static string GetCustomerInvoiceFooterHtml()
{
    var path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), $"Html\\CustomerInvoiceFooter.html");
    return File.ReadAllText(path);
}

static CustomerInvoiceModel GetCustomerInvoiceModel()
{
    return new CustomerInvoiceModel
    {
        AgingCurrent = 0,
        Aging1To30 = 1000,
        Aging31To60 = 2000,
        Aging61To90 = 3000,
        Aging90Plus = 4000,
        BillToAddress = new AddressModel
        {
            Name = "Test Billing Company",
            LineOne = "Test Bill St",
            LineTwo = "Apt 1",
            City = "Little Rock",
            State = "AR",
            Zip = "72210",
            Country = "US",
            PhoneNumberFormatted = "(111) 111-1111"
        },
        CarrierCode = "TSTC",
        CarrierName = "Test Carrier",
        Charges = new List<ShipmentChargeModel>
    {
        new ShipmentChargeModel
        {
            Code = "TST1",
            Description = "Test Charge 1",
            Rate = 100,
            Total = 100
        },
        new ShipmentChargeModel
        {
            Code = "TST2",
            Description = "Test Charge 2",
            Rate = 200,
            Total = 200
        }
    },
        CustomerBalance = 10000,
        CustomerName = "Test Customer",
        CustomerNumber = "TEST-CUSTOMER-1",
        DefaultSpecialInstructions = "Special Instructions",
        DeliveryDate = DateTime.Now,
        DestinationAddress = new AddressModel
        {
            Name = "Test Destination Company",
            LineOne = "Test Destination St",
            LineTwo = "Apt 3",
            City = "Los Angeles",
            State = "CA",
            Zip = "90210",
            Country = "US",
            PhoneNumberFormatted = "(333) 333-3333"
        },
        DestinationNote = "Destination Note",
        DueDate = DateTime.Now.AddDays(15),
        Identifiers = new List<ShipmentIdentifierModel>
    {
        new ShipmentIdentifierModel
        {
            CustomTypeName = "BOL",
            Value = "TestBOL"
        },
        new ShipmentIdentifierModel
        {
            CustomTypeName = "PRO",
            Value = "TestPRO"
        },
        new ShipmentIdentifierModel
        {
            CustomTypeName = "Pickup Number",
            Value = "TestPickupNumber"
        },
        new ShipmentIdentifierModel
        {
            CustomTypeName = "Customer Reference",
            Value = "TestCustomerReference"
        }
    },
        InvoiceDate = DateTime.Now,
        InvoiceNumber = "12345",
        InvoiceTotal = 200,
        IsStackable = false,
        Items = new List<ShipmentItemModel>
    {
        new ShipmentItemModel
        {
            Class = "100",
            Description = "Cabinet",
            Height = 60,
            Width = 40,
            Length = 50,
            NMFC = "BXS",
            FreightClassHumanized = "100",
            Quantity = 1,
            PieceCount = 1,
            Weight = 200,
            TypeHumanized = "Pallet"
        }
    },
        Memo = "Test Memo",
        OriginAddress = new AddressModel
        {
            Name = "Test Origin Company",
            LineOne = "Test Origin St",
            LineTwo = "Apt 2",
            City = "Little Rock",
            State = "AR",
            Zip = "72205",
            Country = "US",
            PhoneNumberFormatted = "(222) 222-2222"
        },
        OriginNote = "Origin Note",
        PaymentTermsFormatted = "Net 15",
        PickupDate = DateTime.Now.AddDays(-3),
        SalesGroupName = "Test Group",
        ShipmentAccessorialsFormatted = "Test Accessorials",
        ShowCharges = true,
        SpecialInstructions = "Special Instructions"
    };
}

static string MergeHtml(string fileName, object model)
{
    var path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), $"Html\\{fileName}.html");
    var html = File.ReadAllText(path);
    var template = Handlebars.Compile(html);
    return template(model);
}