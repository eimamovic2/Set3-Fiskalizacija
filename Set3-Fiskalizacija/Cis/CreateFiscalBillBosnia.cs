using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Timers;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

using System.Threading;

namespace CondorExtreme3_API.Helper
{
    public static class CreateFiscalBillBosnia
    {

        public static int ZaglavljeId { get; set; }
        public static int BrojFiskalni { get; set; } = 0;
        public static int BrojReklamirani { get; set; } = 0;
        public static void MyMethodAsync(int zaglavljeId, bool reclamation = false)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = "C:\\Tring\\Xml\\odgovori\\";
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "*.xml";
            watcher.EnableRaisingEvents = true;

            ZaglavljeId = zaglavljeId;
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "IBM852", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement RacunZahtjev = doc.CreateElement(string.Empty, "RacunZahtjev", string.Empty);
            RacunZahtjev.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            RacunZahtjev.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            doc.AppendChild(RacunZahtjev);

            //treba dodaji vrstu zahtjeva
            XmlElement Brojzahtjeva = doc.CreateElement(string.Empty, "Brojzahtjeva", string.Empty);
            Brojzahtjeva.InnerText = "233";

            RacunZahtjev.AppendChild(Brojzahtjeva);

            XmlElement VrstaZahtjeva = doc.CreateElement(string.Empty, "VrstaZahtjeva", string.Empty);
            VrstaZahtjeva.InnerText = reclamation == false ? "0" : "2";
            RacunZahtjev.AppendChild(VrstaZahtjeva);

            XmlElement NoviObjekat = doc.CreateElement(string.Empty, "NoviObjekat", string.Empty);
            RacunZahtjev.AppendChild(NoviObjekat);

            XmlElement StavkeRacuna = doc.CreateElement(string.Empty, "StavkeRacuna", string.Empty);
            NoviObjekat.AppendChild(StavkeRacuna);

            decimal ukupanIznos = 0;

                XmlElement StavkaRacuna = doc.CreateElement(string.Empty, "RacunStavka", string.Empty);
                StavkeRacuna.AppendChild(StavkaRacuna);

                XmlElement artikal = doc.CreateElement(string.Empty, "artikal", string.Empty);
                StavkaRacuna.AppendChild(artikal);

                XmlElement Sifra = doc.CreateElement(string.Empty, "Sifra", string.Empty);
                Sifra.InnerText = "R-101";
                artikal.AppendChild(Sifra);

                XmlElement JM = doc.CreateElement(string.Empty, "JM", string.Empty);
                JM.InnerText = "kom";
                artikal.AppendChild(JM);

                XmlElement Cijena = doc.CreateElement(string.Empty, "Cijena", string.Empty);
                Cijena.InnerText = String.Format("{0:0.00}", Math.Round(250.50, 2)).Replace(",", ".");
                artikal.AppendChild(Cijena);

                XmlElement Stopa = doc.CreateElement(string.Empty, "Stopa", string.Empty);
                //"E", u sistemu PDVa, "K" je za izvog gdje se ne obračunava PDV, "A" pravna lica koja nisu u sistemu PDVa 
                Stopa.InnerText = "E";
                artikal.AppendChild(Stopa);

                XmlElement Grupa = doc.CreateElement(string.Empty, "Grupa", string.Empty);
                Grupa.InnerText = "0";
                artikal.AppendChild(Grupa);

                XmlElement PLU = doc.CreateElement(string.Empty, "PLU", string.Empty);
                PLU.InnerText = "2";
                artikal.AppendChild(PLU);

                XmlElement Kolicina = doc.CreateElement(string.Empty, "Kolicina", string.Empty);
                double kolicina = 15.50;
                Kolicina.InnerText = String.Format("{0:0.000}", Math.Round(kolicina, 3)).Replace(",", "."); ;
                StavkaRacuna.AppendChild(Kolicina);

                XmlElement Rabat = doc.CreateElement(string.Empty, "Rabat", string.Empty);
                Rabat.InnerText = String.Format("{0:0.00}", 0).Replace(",", ".");
                StavkaRacuna.AppendChild(Rabat);

   

            XmlElement VrstePlacanja = doc.CreateElement(string.Empty, "VrstePlacanja", string.Empty);
            NoviObjekat.AppendChild(VrstePlacanja);


            XmlElement VrstaPlacanja = doc.CreateElement(string.Empty, "VrstaPlacanja", string.Empty);
            VrstePlacanja.AppendChild(VrstaPlacanja);


            XmlElement Oznaka = doc.CreateElement(string.Empty, "Oznaka", string.Empty);
            Oznaka.InnerText = "Gotovina";
            VrstaPlacanja.AppendChild(Oznaka);


            XmlElement Iznos = doc.CreateElement(string.Empty, "Iznos", string.Empty);
            Iznos.InnerText = String.Format("{0:0.00}", ukupanIznos).Replace(",", "."); ;
            VrstaPlacanja.AppendChild(Iznos);

            XmlElement Napomena = doc.CreateElement(string.Empty, "Napomena", string.Empty);
            Napomena.InnerText = "Hvala!";
            NoviObjekat.AppendChild(Napomena);


            XmlElement BrojRacuna = doc.CreateElement(string.Empty, "BrojRacuna", string.Empty);
            BrojRacuna.InnerText = "123456789";
            NoviObjekat.AppendChild(BrojRacuna);


        }
    }
}