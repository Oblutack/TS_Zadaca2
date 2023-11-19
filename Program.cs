using System;
using System.Linq;
using System.Collections.Generic;

// Glavna klasa koja sadrži ulaznu tačku programa
class Program
{
    // Metoda koja se poziva prilikom pokretanja programa
    static void Main(string[] args)
    {
        // Kreiranje instance agencije za iznajmljivanje stanova
        Agencija agencija = new Agencija();

        // Dodavanje različitih tipova stanova u agenciju
        Stan nenamjestenStan = new NenamjestenStan(60, Lokacija.Prigradsko, true);
        Stan namjestenStan = new NamjestenStan(70, Lokacija.Gradsko, true, 4000, 3);
        agencija.DodajStan(nenamjestenStan);
        agencija.DodajStan(namjestenStan);

        // Dodavanje različitog osoblja u agenciju
        Osoblje batler = new Batler { Ime = "James", Prezime = "Bond", Plata = 2500, GodineIskustva = 10 };
        Osoblje kuhar = new Kuhar { Ime = "Gordon", Prezime = "Ramsay", Plata = 1800, Jela = new List<string> { "Beef Wellington", "Risotto" } };
        agencija.DodajOsoblje(batler);
        agencija.DodajOsoblje(kuhar);

        // Ispis svih stanova po cijeni
        Console.WriteLine("Stanovi sortirani po cijeni:");
        agencija.IspisiSveStanovePoCijeni();

        // Ispis osoblja po plati
        Console.WriteLine("\nOsoblje sortirano po plati:");
        agencija.IspisiSvoOsobljePoPlati();

        // Testiranje funkcije za iznajmljivanje luksuznog apartmana
        TestIznajmljivanjeLuksuznogApartmana(agencija);

        // Čekanje korisničkog unosa prije zatvaranja programa
        Console.ReadLine();
    }

    // Dodatna testna funkcija za iznajmljivanje luksuznog apartmana
    static void TestIznajmljivanjeLuksuznogApartmana(Agencija agencija)
    {
        // Simulacija dodavanja osoblja u luksuzni apartman
        List<Osoblje> osoblje = new List<Osoblje>
        {
            new Batler { Ime = "John", Prezime = "Doe", Plata = 2000, GodineIskustva = 5 },
            new Kuhar { Ime = "Alice", Prezime = "Smith", Plata = 1500, Jela = new List<string> { "Pasta", "Steak" } },
            new Vrtlar { Ime = "Bob", Prezime = "Johnson", Plata = 1000, Stan = new NenamjestenStan(50, Lokacija.Prigradsko, true) }
        };

        // Kreiranje luksuznog apartmana sa dodatnim osobljem
        LuksuzniApartman luksuzniApartman = new LuksuzniApartman(100, Lokacija.Gradsko, true, 5000, 4, osoblje);
        agencija.DodajStan(luksuzniApartman);

        // Očekivana cijena najma luksuznog apartmana
        var ocekivanaCijena = luksuzniApartman.ObracunajCijenuNajma();

        // Dohvatanje stanova iz agencije
        var stanovi = agencija.Stanovi;
        var iznajmljenApartman = stanovi.FirstOrDefault(s => s is LuksuzniApartman) as LuksuzniApartman;

        // Ispis rezultata testa iznajmljivanja luksuznog apartmana
        Console.WriteLine("\nTest iznajmljivanja luksuznog apartmana:");
        if (iznajmljenApartman != null)
        {
            Console.WriteLine("Luksuzni apartman uspješno iznajmljen.");
            Console.WriteLine($"Očekivana cijena: {ocekivanaCijena:C}");
            Console.WriteLine($"Izračunata cijena: {iznajmljenApartman.ObracunajCijenuNajma():C}");
        }
        else
        {
            Console.WriteLine("Iznajmljivanje luksuznog apartmana nije uspjelo.");
        }
    }
}
