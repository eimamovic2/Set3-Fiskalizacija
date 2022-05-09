
//POPRAVITI
/*
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Cis;
namespace Set3_Fiskalizacija.Cis
{
    public class CreateFiscalBill
    {

        // Kreiranje računa za za fiskalizaciju
        private var invoice = new RacunType()
        {
            BrRac = new BrojRacunaType()
            {
                BrOznRac = "1",
                OznPosPr = "1",
                OznNapUr = "1"
            },
            DatVrijeme = DateTime.Now.ToString(Fiscalization.DATE_FORMAT_LONG),
            IznosUkupno = 3.ToString("N2", CultureInfo.InvariantCulture),
            NacinPlac = NacinPlacanjaType.G,
            NakDost = false,
            Oib = oib,
            OibOper = "98642375382",
            OznSlijed = OznakaSlijednostiType.N,
            Pdv = new[]
            {
        new PorezType
        {
            Stopa = 25.ToString("N2", CultureInfo.InvariantCulture),
            Osnovica = 2.34.ToString("N2", CultureInfo.InvariantCulture),
            Iznos = .56.ToString("N2", CultureInfo.InvariantCulture)
        }
    },
            USustPdv = true
        };

        Byte[] cerFileRead = await File.ReadAllBytesAsync(@"Cis\\CertifikatFiskalizacija.cer");
        X509Certificate2 certificate = new X509Certificate2(cerFileRead);

        // Generiraj ZKI, potpiši, pošalji račun i provjeri potpis CIS odgovora
        RacunOdgovor response = await Fiscalization.SendInvoiceAsync(invoice, certificate);

        // Odgovor sa JIR-om i zahtjevom (sa header podacima, potpisom) i poslanim računom
        string jir = response.Jir;
        RacunZahtjev request = (RacunZahtjev)response.Request; // ICisRequest
        var isTrue = request.Racun == invoice;

        // ili dodatno sa postavljanjem opcija
        // fs == instanca generirane proxy klase FiskalizacijaService
        private readonly RacunOdgovor response = await Fiscalization.SendInvoiceAsync(invoice, certificate, fs =>
        {
            // SOAP service settings
            // Change service URL
            // default = Fiscalization.SERVICE_URL_PRODUCTION
            fs.Url = Fiscalization.SERVICE_URL_DEMO;

            // Set request timeout in miliseconds
            // default = 100s
            fs.Timeout = 2000;

            // Set response signature checking
            // default = true
            fs.CheckResponseSignature = true;
        });
    }
}
*/