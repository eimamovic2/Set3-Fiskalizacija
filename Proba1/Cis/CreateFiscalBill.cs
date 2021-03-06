
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Cis;
using Newtonsoft.Json;
namespace Set3_Fiskalizacija.Cis


{
    public class CreateFiscalBill
    {
        public static async Task<String> CreateBill(String invoice) {
            // Kreiranje računa za za fiskalizaciju
        RacunType probaConvert = JsonConvert.DeserializeObject<RacunType>(invoice);
        /*
        RacunType invoicee = new RacunType()
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
            // Oib = oib,
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
        */
        Byte[] cerFileRead = File.ReadAllBytes(@"CertifikatFiskalizacija.cer");
        X509Certificate2 certificate = new X509Certificate2(cerFileRead);

        // Generiraj ZKI, potpiši, pošalji račun i provjeri potpis CIS odgovora
        RacunOdgovor response = await Fiscalization.SendInvoiceAsync(probaConvert, certificate);

        // Odgovor sa JIR-om i zahtjevom (sa header podacima, potpisom) i poslanim računom
        string jir = response.Jir;
        Console.WriteLine(jir);
        return jir;

        }
    }

}


