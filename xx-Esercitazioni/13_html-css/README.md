# HTML CSS

## Cosa sono i TAG HTML

I tag HTML sono i blocchi di costruzione di tutte le pagine web. I browser non visualizzano i tag HTML, ma li usano per interpretare il contenuto della pagina.
Possiamo interpretare i TAG come delle direttive che dicono al browser come visualizzare il contenuto della pagina.

> Un esempio di TAG potrebbe essere il tag <b>testo in grassetto</b> che serve per rendere il testo in grassetto.

I tag vengono aperti e chiusi con le parentesi angolari `<` e `>`. Il tag di chiusura è identico a quello di apertura, ma include un carattere di barra obliqua `/` prima del nome del tag.

I tag sono da mettere in un ordine specifico, in modo che il browser possa interpretare correttamente il contenuto della pagina.
Nello specifico i tag che rappresentano attributi vengono messi all'interno di un tag che rappresenta un elemento.

Quindi seguono questo schema qui:

```html
<b>scritta</p>
<p><b>scritta</b></p>
<div><p><b>scritta</b></p></div>
```

# La struttura di una pagina HTML

Il file html si compone di due parti principali: il tag `<head>` e il tag `<body>`.
Il tag `<head>` contiene le informazioni riguardanti il documento, come il titolo, il collegamento a fogli di stile esterni, ecc.
Il tag `<body>` contiene il contenuto del documento.

```html
<!DOCTYPE html>
<html>

<head>
    <title>Titolo del documento</title>
</head>

<body>
    <h1>Titolo di primo livello</h1>
</body>

</html>
```

# HEAD cosa contiene

Il tag `<head>` potrebbe contenere:

- `<title>`: il titolo della pagina che viene visualizzato nella barra del browser
```html
<title>Titolo del documento</title>
```
- `<link>`: collegamento a un foglio di stile esterno gestito separatamente
```html
<link rel="stylesheet" type="text/css" href="style.css">
```
- `<style>`: foglio di stile interno nel quale definire le regole di stile
```html
<style>
    body {
        background-color: lightblue;
    }
</style>
```
- `<script>`: collegamento a uno script esterno o script interno
```html
<script src="script.js"></script>
```
- `<meta>`: informazioni sul documento, come l'encoding dei caratteri, la descrizione, le parole chiave, ecc.
```html
<meta charset="UTF-8">
```
# CDN e collegamento a font (https://cdnjs.com)

Questo tipo di collegamento prende il nome di CDN (Content Delivery Network) e permette di collegarsi a risorse esterne come.

- collegamento a font specifici come ad esempio quelli di google font
```html
<link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300&display=swap" rel="stylesheet">
```

- collegamento a librerie javascript come ad esempio jquery
```html
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
```

- collegamento ad icone come ad esempio quelle di fontawesome
```html
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
```

- collegamento a framework css come ad esempio bootstrap
```html
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
```

# BODY cosa contiene

Il tag `<body>` contiene il contenuto del documento, come testo, immagini, link, ecc. cioe quello che possiamo visualizzare

```html
<body>
    <h1>Titolo di primo livello</h1>
    <p>Questo è un paragrafo.</p>
    <img src="immagine.jpg" alt="Testo alternativo">
    <a href="https://www.google.com">Questo è un link</a>
</body>
```

# TAG HTML SPECIFICI

- `<h1>`, `<h2>`, `<h3>`, `<h4>`, `<h5>`, `<h6>`: titoli di primo, secondo, terzo, quarto, quinto e sesto livello
```html
<h1>Titolo di primo livello</h1>
<h2>Titolo di secondo livello</h2>
<h3>Titolo di terzo livello</h3>
<h4>Titolo di quarto livello</h4>
<h5>Titolo di quinto livello</h5>
<h6>Titolo di sesto livello</h6>
```

- `<p>`: paragrafo
```html
<p>Questo è un paragrafo.</p>
```

- `<img>`: immagine
```html
<img src="immagine.jpg" alt="Testo alternativo">
```

- `<a>`: link
```html
<a href="https://www.google.com">Questo è un link</a>
```

- `<ul>`, `<ol>`, `<li>`: elenco non ordinato, elenco ordinato, elemento dell'elenco
```html
<ul>
    <li>Elemento 1</li>
    <li>Elemento 2</li>
</ul>
<ol>
    <li>Elemento 1</li>
    <li>Elemento 2</li>
</ol>
```

- `<table>`, `<tr>`, `<th>`, `<td>`: tabella, riga, intestazione di colonna, cella
```html
<table>
    <tr>
        <th>Intestazione 1</th>
        <th>Intestazione 2</th>
        <th>Intestazione 3</th>
    </tr>
    <tr>
        <td>Cella 1</td>
        <td>Cella 2</td>
        <td>Cella 3</td>
    </tr>
</table>
```

- `<div>`, `<span>`: divisione, span
```html
<div>Questo è un blocco di testo.</div>
<span>Questo è un testo in linea.</span>
```

- collegamenti a sezioni specifiche della pagina come in caso di landing page
```html
<a href="#sezione1">Vai alla sezione 1</a>
<a name="sezione1">Sezione 1</a>
```

La differenza tra `<div>` e `<span>` è che `<div>` è un blocco di testo e `<span>` è un testo in linea.

# TAG HTML PER FORM

- `<form>`, `<input>`, `<textarea>`, `<button>`, `<select>`, `<option> : form, input, textarea, button, select, option
```html
<form action="/action_page.php">
    <label for="fname">Nome:</label>
    <input type="text" id="fname" name="fname"><br><br>
    <label for="lname">Cognome:</label>
    <input type="text" id="lname" name="lname"><br><br>
    <input type="submit" value="Invia">
</form>
```

# IMPOSTAZIONE ATTRIBUTI TRAMITE HTML

Gli attributi sono informazioni aggiuntive sui tag HTML che possono modificare il comportamento o l'aspetto del tag.

- `id`: identificatore univoco per un elemento
```html
<p id="paragrafo">Questo è un paragrafo.</p>
```

- `class`: classe di un elemento
```html
<p class="paragrafo">Questo è un paragrafo.</p>
```

- `style`: stile CSS per un elemento
```html
<p style="color: red;">Questo è un paragrafo rosso.</p>
```

- `src`: per immagini, collegamento a un'immagine
```html
<img src="immagine.jpg" alt="Testo alternativo">
```

- `href`: per link, collegamento a un URL
```html
<a href="https://www.google.com">Questo è un link</a>
```

- `alt`: testo alternativo per immagini
```html
<img src="immagine.jpg" alt="Testo alternativo">
```

- `title`: testo che appare quando si passa il mouse sopra un elemento
```html
<p title="Testo di descrizione">Questo è un paragrafo.</p>
```

- `type`: tipo di input per gli elementi `<input>`
```html
<input type="text">
<input type="password">
<input type="submit">
<input type="checkbox">
<input type="radio">
<input type="file">
<input type="hidden">
<input type="reset">
<input type="button">
```

- `value`: valore di input per gli elementi `<input>`
```html
<input type="text" value="Valore di input">
```

- `name`: nome di input per gli elementi `<input>`
```html
<input type="text" name="nome">
```