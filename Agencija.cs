using System;
using System.Collections.Generic;
using System.Linq;

// Klasa koja predstavlja agenciju za nekretnine
class Agencija
{
    public List<Stan> Stanovi { get; private set; } // Lista stanova dostupnih agenciji
    public List<Osoblje> Osoblje { get; private set; } // Lista osoblja u agenciji

    // Konstruktor klase Agencija
    public Agencija()
    {
        Stanovi = new List<Stan>(); // Inicijalizacija liste stanova
        Osoblje = new List<Osoblje>(); // Inicijalizacija liste osoblja
    }

    // Metoda za dodavanje novog stana u agenciju
    public void DodajStan(Stan noviStan)
    {
        Stanovi.Add(noviStan); // Dodavanje novog stana u listu stanova agencije
    }

    // Metoda za dodavanje novog osoblja u agenciju
    public void DodajOsoblje(Osoblje novoOsoblje)
    {
        Osoblje.Add(novoOsoblje); // Dodavanje novog osoblja u listu osoblja agencije
    }

    // Metoda za ispis svih stanova sortiranih po cijeni najma
    public void IspisiSveStanovePoCijeni()
    {
        var sortiraniStanovi = Stanovi.OrderBy(stan => stan.ObracunajCijenuNajma()); // Sortiranje stanova po cijeni najma
        foreach (var stan in sortiraniStanovi)
        {
            stan.Ispisi(); // Ispis informacija o stanu
            Console.WriteLine($"Ukupna cijena najma stana je {stan.ObracunajCijenuNajma():F2}."); // Ispis ukupne cijene najma stana
        }
    }

    // Metoda za ispis svog osoblja sortiranog po plati
    public void IspisiSvoOsobljePoPlati()
    {
        var sortiranoOsoblje = Osoblje.OrderBy(osoba => osoba.Plata); // Sortiranje osoblja po plati
        foreach (var osoba in sortiranoOsoblje)
        {
            osoba.Ispisi(); // Ispis informacija o osoblju
        }
    }

    // Metoda za brisanje stana iz liste stanova agencije
    public void ObrisiStan(Stan stan)
    {
        Stanovi.Remove(stan); // Brisanje stana iz liste stanova agencije
    }
}
