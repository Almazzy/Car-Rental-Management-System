﻿SELECT f.nr_faktury, w.nr_zlecenia, n.najemca, f.data_wystawienia, f.sposob_platnosci, f.termin_platnosci, f.usluga, f.suma_dni, p.imie_nazwisko FROM Faktury f, Wynajmy w, Klienci k, Pracownicy p WHERE f.Id_Wynajmu=w.Id_Wynajmu AND f.Id_Pracownika=p.Id_Pracownika AND w.Id_Klienta=k.Id_Klienta