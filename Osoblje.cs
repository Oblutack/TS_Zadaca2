using System;
using System.Collections.Generic;


// Apstraktna klasa koja predstavlja osoblje u agenciji
abstract class Osoblje
{
    // Svojstva koja opisuju osnovne karakteristike osoblja
    public string? Ime { get; set; } // Postavljanje stringa kao nullable (dozvoljava null vrijednosti)
    public string? Prezime { get; set; } // Postavljanje stringa kao nullable
    public decimal Plata { get; set; }

    // Virtualna metoda za ispis informacija o osoblju
    public virtual void Ispisi()
    {
        Console.WriteLine($"Ime: {Ime}, Prezime: {Prezime}, Plata: {Plata:C}");
    }
}

// Podklasa koja predstavlja batlera
class Batler : Osoblje
{
    // Dodatno svojstvo koje opisuje godine iskustva batlera
    public int GodineIskustva { get; set; }

    // Override metode Ispisi za dodavanje informacija o godinama iskustva batlera
    public override void Ispisi()
    {
        base.Ispisi(); // Pozivanje Ispisi metode iz bazne klase
        Console.WriteLine($"Godine iskustva: {GodineIskustva}");
    }
}

// Podklasa koja predstavlja kuhara
class Kuhar : Osoblje
{
    // Lista jela koja kuhar priprema, postavljena kao nullable
    public List<string>? Jela { get; set; }

    // Override metode Ispisi za ispisivanje informacija o kuharu i jelima koje priprema
    public override void Ispisi()
    {
        base.Ispisi(); // Pozivanje Ispisi metode iz bazne klase
        Console.WriteLine("Jela koja priprema:");
        if (Jela != null)
        {
            foreach (var jelo in Jela)
            {
                Console.WriteLine(jelo);
            }
        }
    }
}

// Podklasa koja predstavlja vrtlara
class Vrtlar : Osoblje
{
    // Stan u vlasništvu vrtlara, postavljen kao nullable
    public Stan? Stan { get; set; }

    // Override metode Ispisi za ispisivanje informacija o vrtlaru i stanu koji posjeduje
    public override void Ispisi()
    {
        base.Ispisi(); // Pozivanje Ispisi metode iz bazne klase
        Console.WriteLine("Stan u vlasništvu vrtlara:");
        if (Stan != null)
        {
            Console.WriteLine($"Broj kvadrata: {Stan.BrojKvadrata}, Lokacija: {Stan.Lokacija}");
        }
    }
}

