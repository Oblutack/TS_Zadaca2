using Moq;
// Interfejs koji definira ugovor o najmu hotelske sobe
public interface INajamHotelskeSobe
{
    decimal IzracunajCijenuNajma(); // Metoda koja se mora implementirati za izračunavanje cijene najma
    // Dodajte ostale potrebne metode i svojstva prema potrebama vašeg sustava
}

// Konkretna implementacija interfejsa za najam hotelske sobe
public class NajamHotelskeSobe : INajamHotelskeSobe
{
    // Implementacija metode za izračunavanje cijene najma hotelske sobe
    public decimal IzracunajCijenuNajma()
    {
        // Implementacija iznajmljivanja hotelske sobe
        return 100.00m; // Samo primjer, zamijenite sa stvarnom implementacijom
    }

    // Mogućnost dodavanja ostalih metoda i svojstava prema potrebama vašeg sustava
    // Implementirajte ih ovdje ili dodajte dodatne klase koje nasljeđuju ovu klasu.
}
