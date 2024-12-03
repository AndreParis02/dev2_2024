# ESERCITAZIONE 17: Supermercato completo

## Obiettivo:

- implementare un programma che simuli il funzionamento di un supermercato.
- Il programma deve peremettere di:
    - Gestire un catalogo di prodotti (Aggiungere prodotti al catalogo. Salvare e caricare il catalogo dei prodotti da un file JSON).
- Il programma deve permettere a un cliente di riempire il proprio carrello della spesa.
- Calcolare il totale del carrello e stampare uno scontrino.

## Funzionalita':

Gestione catalogo prodotti (operazione CRUD ovvero Creazione, Lettura, Modifica e Eliminazione):
- ID codice prodotto;
- Nome prodotto;
- Prezzo;
- Quantita' disponibile (in magazzino che viene decrementata quando un cliente acquista un prodotto);

Gestione del carrello e dello scontrino del cliente:
- Data di acquisto;
- Lista dei prodotti acquistati;
- Quantità per prodotto;
- Totale spesa;

Gestione dello store:
- Salvare il catalogo su un file;  
- Caricare il catalogo su un file;
- Salvare lo scontrino su file;
- Caricare lo scontrino su file;
- Visualizzare il catalogo dei prodotti;
- Visualizzare gli scontrini;
- Implementare alcuni filtri (es. prodotti con prezzo minore di un certo valore, prodotti acquisrati in una certa data, ecc.);

## implementazioni future:

- Gestione operatori del supermercato (anagrafica, ruoli, ecc.)
- Gestione dei clienti (anagrafica, storico acquisti, ecc.)
- Gestione punti fedeltà (es. sconti, premi, ecc.)
- Gestione magazzino (funzionalità di rifornimento, gestione sottoscorta, ecc.)
