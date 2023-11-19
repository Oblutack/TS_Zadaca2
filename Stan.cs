using System;
using System.Collections.Generic;
using System.Linq;

// Enumeracija koja definira moguće lokacije stanova
public enum Lokacija
{
    Gradsko,
    Prigradsko
}

// Apstraktna klasa koja predstavlja opću strukturu stanova
abstract class Stan
{
    // Svojstva koja opisuju osnovne karakteristike svakog stana
    public int BrojKvadrata { get; }
    public Lokacija Lokacija { get; }
    public bool Namjesten { get; }
    public bool Internet { get; }

    // Konstruktor koji postavlja osnovne karakteristike stana
    public Stan(int brojKvadrata, Lokacija lokacija, bool namjesten, bool internet)
    {
        BrojKvadrata = brojKvadrata;
        Lokacija = lokacija;
        Namjesten = namjesten;
        Internet = internet;
    }

    // Apstraktne metode koje će biti implementirane u podklasama
    public abstract void Ispisi();
    public abstract decimal ObracunajCijenuNajma();
}

// Konkretna podklasa koja predstavlja nenamješten stan
class NenamjestenStan : Stan
{
    // Konstruktor koji poziva konstruktor bazne klase i postavlja dodatne karakteristike nenamještenog stana
    public NenamjestenStan(int brojKvadrata, Lokacija lokacija, bool internet)
        : base(brojKvadrata, lokacija, false, internet)
    {
    }

    // Implementacija apstraktne metode Ispisi za nenamješten stan
    public override void Ispisi()
    {
        Console.WriteLine($"{BrojKvadrata} {Lokacija} Nenamjesten {Internet}");
    }

    // Implementacija apstraktne metode ObracunajCijenuNajma za nenamješten stan
    public override decimal ObracunajCijenuNajma()
    {
        decimal osnovnaCijena = Lokacija == Lokacija.Gradsko ? 200 : 150;
        decimal cijenaKvadrata = 1;
        decimal cijena = osnovnaCijena + BrojKvadrata * cijenaKvadrata;
        if (Internet)
        {
            cijena *= 1.02m;
        }
        return cijena;
    }
}

// Konkretna podklasa koja predstavlja namješten stan
class NamjestenStan : Stan
{
    // Dodatna svojstva koja opisuju namješteni stan
    public decimal VrijednostNamjestaja { get; }
    public int BrojAparata { get; }

    // Konstruktor koji poziva konstruktor bazne klase i postavlja dodatne karakteristike namještenog stana
    public NamjestenStan(int brojKvadrata, Lokacija lokacija, bool internet, decimal vrijednostNamjestaja, int brojAparata)
        : base(brojKvadrata, lokacija, true, internet)
    {
        VrijednostNamjestaja = vrijednostNamjestaja;
        BrojAparata = brojAparata;
    }

    // Implementacija apstraktne metode Ispisi za namješteni stan
    public override void Ispisi()
    {
        Console.WriteLine($"{BrojKvadrata} {Lokacija} Namjesten {Internet} {VrijednostNamjestaja} {BrojAparata}");
    }

    // Implementacija apstraktne metode ObracunajCijenuNajma za namješteni stan
    public override decimal ObracunajCijenuNajma()
    {
        decimal osnovnaCijena = Lokacija == Lokacija.Gradsko ? 200 : 150;
        decimal cijenaKvadrata = 1;
        decimal cijena = osnovnaCijena + BrojKvadrata * cijenaKvadrata;
        if (Internet)
        {
            cijena *= 1.02m;
        }

        // Dodatno povećanje cijene ovisno o broju aparata u stanu
        if (BrojAparata < 3)
        {
            cijena += 0.01m * VrijednostNamjestaja;
        }
        else
        {
            cijena += 0.02m * VrijednostNamjestaja;
        }
        return cijena;
    }
}

// Dodatna klasa koja predstavlja luksuzni apartman, naslijeđuje od namještenog stana
class LuksuzniApartman : NamjestenStan
{
    // Lista osoblja koje radi u apartmanu
    public List<Osoblje> Osoblje { get; set; }

    // Konstruktor koji poziva konstruktor bazne klase i postavlja dodatne karakteristike luksuznog apartmana
    public LuksuzniApartman(int brojKvadrata, Lokacija lokacija, bool internet, decimal vrijednostNamjestaja, int brojAparata, List<Osoblje> osoblje)
        : base(brojKvadrata, lokacija, internet, vrijednostNamjestaja, brojAparata)
    {
        Osoblje = osoblje;
    }

    // Implementacija apstraktne metode Ispisi za luksuzni apartman
    public override void Ispisi()
    {
        // Ispisuje osnovne informacije o stanu i zatim ispisuje osoblje u apartmanu
        base.Ispisi();
        Console.WriteLine("Osoblje:");
        foreach (var osoba in Osoblje)
        {
            osoba.Ispisi();
        }
    }
}
 
