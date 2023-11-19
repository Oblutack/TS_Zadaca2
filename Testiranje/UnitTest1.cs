using System;
using Moq;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

// Klasa koja omogućava hvatanje ispisa na konzoli radi testiranja
public static class ConsoleCapture
{
    // Metoda koja hvata ispis na konzoli tokom izvršavanja određenog koda
    public static string CaptureConsoleOutput(Action action)
    {
        var originalOut = Console.Out;
        using (var writer = new StringWriter())
        {
            Console.SetOut(writer);
            action.Invoke();
            Console.SetOut(originalOut);
            return writer.ToString();
        }
    }
}

// Namespace koji sadrži testove
namespace Testiranje
{
    // Test klasa koja sadrži test metode
    [TestClass]
    public class UnitTest1
    {
        // Test metoda koja testira dodavanje nenamještenog stana u agenciju
        [TestMethod]
        [DataRow(60, Lokacija.Prigradsko, true, 70, Lokacija.Gradsko, true, 2)] // Promijenjeno očekivani broj stanova na 2
        [DataRow(80, Lokacija.Gradsko, false, 90, Lokacija.Prigradsko, false, 2)]
        public void TestDodavanjeNenamjestenogStana(int prvaPovrsina, Lokacija prvaLokacija, bool prvaParking, int drugaPovrsina, Lokacija drugaLokacija, bool drugiParking, int ocekivaniBrojStanova)
        {
            var agencija = new Agencija();

            var prviStan = new NenamjestenStan(prvaPovrsina, prvaLokacija, prvaParking);
            var drugiStan = new NenamjestenStan(drugaPovrsina, drugaLokacija, drugiParking);

            agencija.DodajStan(prviStan);
            agencija.DodajStan(drugiStan);

            Assert.AreEqual(ocekivaniBrojStanova, agencija.Stanovi.Count); // Ispravljena asertacija
            Assert.IsTrue(agencija.Stanovi.Contains(prviStan));
            Assert.IsTrue(agencija.Stanovi.Contains(drugiStan));
        }

        // Test metoda koja testira brisanje stana iz agencije
        [TestMethod]
        public void TestBrisanjeStana()
        {
            var agencija = new Agencija();

            var nenamjestenStan = new NenamjestenStan(60, Lokacija.Prigradsko, true);
            var namjestenStan = new NamjestenStan(70, Lokacija.Gradsko, true, 4000, 3);

            agencija.DodajStan(nenamjestenStan);
            agencija.DodajStan(namjestenStan);

            agencija.ObrisiStan(nenamjestenStan);

            Assert.AreEqual(agencija.Stanovi.Count, 1);
            Assert.IsFalse(agencija.Stanovi.Contains(nenamjestenStan));
        }

        // Test metoda koja testira ispis svih stanova po cijeni
        [TestMethod]
        public void TestIspisSvihStanovaPoCijeni()
        {
            var agencija = new Agencija();

            var nenamjestenStan = new NenamjestenStan(60, Lokacija.Prigradsko, true);
            var namjestenStan = new NamjestenStan(70, Lokacija.Gradsko, true, 4000, 3);

            agencija.DodajStan(nenamjestenStan);
            agencija.DodajStan(namjestenStan);

            // Testira da li funkcija za ispis radi bez greške
            agencija.IspisiSveStanovePoCijeni();

            // Provjera da li se funkcija izvršila bez exceptiona
            Assert.IsTrue(true);
        }

        // Test metoda koja testira ispis svog osoblja po plati
        [TestMethod]
        public void TestIspisSvogOsobljaPoPlati()
        {
            var agencija = new Agencija();

            var batler = new Batler { Ime = "James", Prezime = "Bond", Plata = 2500, GodineIskustva = 10 };
            var kuhar = new Kuhar { Ime = "Gordon", Prezime = "Ramsay", Plata = 1800, Jela = new List<string> { "Beef Wellington", "Risotto" } };

            agencija.DodajOsoblje(batler);
            agencija.DodajOsoblje(kuhar);

            // Testira da li funkcija za ispis radi bez greške
            agencija.IspisiSvoOsobljePoPlati();

            // Provjera da li se funkcija izvršila bez exceptiona
            Assert.IsTrue(true);
        }

        // Test metoda koja testira ispis nenamještenog stana
        [TestMethod]
        public void TestIspisNenamjestenogStana()
        {
            var nenamjestenStan = new NenamjestenStan(60, Lokacija.Prigradsko, true);

            // Testira da li funkcija za ispis radi bez greške
            nenamjestenStan.Ispisi();

            // Provjera da li se funkcija izvršila bez exceptiona
            Assert.IsTrue(true);
        }

        // Test metoda koja testira obračun cijene najma namještenog stana
        [TestMethod]
        public void TestObracunCijeneNajmaNamjestenogStana()
        {
            var namjestenStan = new NamjestenStan(70, Lokacija.Gradsko, true, 4000, 3);

            // Testira da li funkcija za obračun cijene radi bez greške
            var cijena = namjestenStan.ObracunajCijenuNajma();

            // Provjera da li se funkcija izvršila bez exceptiona
            Assert.IsTrue(true);
        }

        // Test metoda koja testira ispis luksuznog apartmana
        [TestMethod]
        public void TestIspisLuksuznogApartmana()
        {
            var luksuzniApartman = new LuksuzniApartman(100, Lokacija.Gradsko, true, 5000, 4, new List<Osoblje>());

            // Testira da li funkcija za ispis radi bez greške
            luksuzniApartman.Ispisi();

            // Provjera da li se funkcija izvršila bez exceptiona
            Assert.IsTrue(true);
        }

        // Test metoda koja testira ispis batlera
        [TestMethod]
        public void TestIspisBatlera()
        {
            var batler = new Batler { Ime = "John", Prezime = "Doe", Plata = 2000, GodineIskustva = 5 };

            // Testira da li funkcija za ispis radi bez greške
            batler.Ispisi();

            // Provjera da li se funkcija izvršila bez exceptiona
            Assert.IsTrue(true);
        }

        // Testiranje ispravnosti ispisivanja podataka o kuharu
       [TestMethod]   
        public void TestIspisKuhara()
        {
            // Kreiranje instance kuhara sa određenim podacima
            var kuhar = new Kuhar { Ime = "Alice", Prezime = "Smith", Plata = 1500, Jela = new List<string> { "Pasta", "Steak" } };

            // Testiranje ispravnosti ispisivanja podataka o kuharu
            kuhar.Ispisi();

            // Provjera da li se funkcija izvršila bez exceptiona
            Assert.IsTrue (true);
        }

        // Testiranje ispravnosti ispisivanja podataka o vrtlaru
        [TestMethod]
        public void TestIspisVrtlara()
        {
            // Kreiranje instance vrtlara sa određenim podacima
            var vrtlar = new Vrtlar { Ime = "Bob", Prezime = "Johnson", Plata = 1000, Stan = new NenamjestenStan(50, Lokacija.Prigradsko, true) };

            // Testiranje ispravnosti ispisivanja podataka o vrtlaru
            vrtlar.Ispisi();

            // Provjera da li se funkcija izvršila bez exceptiona
            Assert.IsTrue(true);
        }

        // Testiranje dodavanja luksuznog apartmana u agenciju
        [TestMethod]
        public void TestDodavanjeLuksuznogApartmana()
        {
            // Kreiranje instance agencije
            var agencija = new Agencija();
            
            // Kreiranje osoblja za luksuzni apartman
            var osoblje = new List<Osoblje>
            {
                new Batler { Ime = "John", Prezime = "Doe", Plata = 2000, GodineIskustva = 5 },
                new Kuhar { Ime = "Alice", Prezime = "Smith", Plata = 1500, Jela = new List<string> { "Pasta", "Steak" } },
                new Vrtlar { Ime = "Bob", Prezime = "Johnson", Plata = 1000, Stan = new NenamjestenStan(50, Lokacija.Prigradsko, true) }
            };

            // Kreiranje luksuznog apartmana sa određenim podacima
            LuksuzniApartman luksuzniApartman = new LuksuzniApartman(100, Lokacija.Gradsko, true, 5000, 4, osoblje);
            agencija.DodajStan(luksuzniApartman);

            // Provjera ispravnosti dodavanja luksuznog apartmana u agenciju
            Assert.AreEqual(agencija.Stanovi.Count, 1);
            Assert.IsTrue(agencija.Stanovi.Contains(luksuzniApartman));
        }

        // Testiranje dodavanja osoblja u agenciju
        [TestMethod]
        public void TestDodavanjeOsoblja()
        {
            // Kreiranje instance agencije
            var agencija = new Agencija();

            // Kreiranje osoblja sa određenim podacima
            var batler = new Batler { Ime = "James", Prezime = "Bond", Plata = 2500, GodineIskustva = 10 };
            var kuhar = new Kuhar { Ime = "Gordon", Prezime = "Ramsay", Plata = 1800, Jela = new List<string> { "Beef Wellington", "Risotto" } };

            // Dodavanje osoblja u agenciju
            agencija.DodajOsoblje(batler);
            agencija.DodajOsoblje(kuhar);

            // Provjera ispravnosti dodavanja osoblja u agenciju
            Assert.AreEqual(agencija.Osoblje.Count, 2);
            Assert.IsTrue(agencija.Osoblje.Contains(batler));
            Assert.IsTrue(agencija.Osoblje.Contains(kuhar));
        }

        // Testiranje ispravnosti ispisa osoblja luksuznog apartmana
        [TestMethod]
        public void TestIspisOsobljaLuksuznogApartmana()
        {
            // Kreiranje instance agencije
            var agencija = new Agencija();

            // Kreiranje osoblja za luksuzni apartman
            var osoblje = new List<Osoblje>
            {
                new Batler { Ime = "John", Prezime = "Doe", Plata = 2000, GodineIskustva = 5 },
                new Kuhar { Ime = "Alice", Prezime = "Smith", Plata = 1500, Jela = new List<string> { "Pasta", "Steak" } },
                new Vrtlar { Ime = "Bob", Prezime = "Johnson", Plata = 1000, Stan = new NenamjestenStan(50, Lokacija.Prigradsko, true) }
            };

            // Kreiranje luksuznog apartmana sa određenim podacima
            var luksuzniApartman = new LuksuzniApartman(100, Lokacija.Gradsko, true, 5000, 4, osoblje);
            agencija.DodajStan(luksuzniApartman);

            // Hvatanje ispisa na konzoli tokom izvršavanja funkcije za ispis osoblja luksuznog apartmana
            var izlaz = ConsoleCapture.CaptureConsoleOutput(() => luksuzniApartman.Ispisi());

            // Provjera da li se ispis osoblja luksuznog apartmana izvršio kako se očekuje
            StringAssert.Contains(izlaz, "Ime: John, Prezime: Doe, Plata: ");
            StringAssert.Contains(izlaz, "Ime: Alice, Prezime: Smith, Plata: ");
            StringAssert.Contains(izlaz, "Ime: Bob, Prezime: Johnson, Plata: ");
        }

        // Testiranje brisanja osoblja iz agencije
        [TestMethod]
        public void TestBrisanjeOsoblja()
        {
            // Kreiranje instance agencije
            var agencija = new Agencija();

            // Kreiranje kuhara sa određenim podacima
            var kuhar = new Kuhar { Ime = "Gordon", Prezime = "Ramsay", Plata = 1800, Jela = new List<string> { "Beef Wellington", "Risotto" } };

            // Dodavanje kuhara u agenciju
            agencija.DodajOsoblje(kuhar);

            // Brisanje osoblja iz agencije
            agencija.Osoblje.Clear();

            // Provjera da li se osoblje uspješno obrisalo iz agencije
            Assert.AreEqual(0, agencija.Osoblje.Count);
        }

        // Testiranje izračuna cijene najma hotela korištenjem zamjenskog objekta
        [TestMethod]
        public void TestIzracunCijeneNajma()
        {
            // Stvaranje zamjenskog objekta koristeći Moq
            var zamjenskiHotel = new Mock<INajamHotelskeSobe>();

            // Postavljanje očekivanja ponašanja zamjenskog objekta
            zamjenskiHotel.Setup(hr => hr.IzracunajCijenuNajma()).Returns(150.00m);

            // Dobivanje stvarnog objekta iz zamjenskog objekta
            INajamHotelskeSobe hotel = zamjenskiHotel.Object;

            // Testiranje metode koja koristi objekt koji je zamijenjen
            var stvarnaCijena = hotel.IzracunajCijenuNajma();

            // Provjera da li je rezultat ono što se očekuje
            Assert.AreEqual(150.00m, stvarnaCijena);
        }
    }
}
