# Landing page
## Obiettivo

Creazione di una landing page con HTML e CSS.
La pagina (landing page resume CV) deve contenere:

    - un'intestazione con il nome e cognome;
    - un menù con il link alle sezioni della pagina (Home, About me, Skills, portfolio, Contact)
   - Le varie sezioni con le info personali, le competenze, il portfolio e i contatti
   - un footer con il copyright e i loghi social

   ## specifiche

    - La pagina deve avere un design responsive
    - La pagina deve avere un file CSS associato
    - La pagina deve contenere i google fonts
    - la pagina deve contenere qualche icona fontawesome o google bootstrap icons
    - La pagina deve contenere un unica `call to action` CTA ben visibile
    

# Versione 1

```html
<!DOCTYPE html>

<head>
    <title>Curriculum Vitae</title>
    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap" rel="stylesheet">

    <!-- FontAwesome Icons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">

    <!-- Link al file CSS -->
    <link rel="stylesheet" href="styles.css">
</head>

<body>
    <!-- Intestazione -->
    <header>
        <div class="container">
            <h1>Andrea Paris</h1>
            <br><br>
            <nav>
                <ul>
                    <li><a href="#home">Home</a></li>
                    <li><a href="#about">About Me</a></li>
                    <li><a href="#skills">Skills</a></li>
                    <li><a href="#portfolio">Portfolio</a></li>
                    <li><a href="#contact">Contact</a></li>
                </ul>
            </nav>
        </div>
    </header>
    <br>

    <div style='margin:25px; padding:20px; background-color:#f4f4f4'>

        <!-- Sezione Home -->
        <section id="home" class="section">
            <div class="container">
                <h2>Benvenuto</h2>
                <br>
                <p>Questa è la pagina ufficiale del mio Curriculum Vitae, se vuoi saperene di più</p>
                <a href="#contact" class="home">Contattami</a>
            </div>
        </section>

        <!-- Sezione About Me -->
        <section id="about" class="section">
            <div class="container">
                <h2>About Me</h2>
                <br>
                <p>Mi chiamo Andrea Paris,<br> sono un Ragazzo che attualmente sta seguendo un corso di programmazione
                    Full stack.<br>
                    In possesso di diploma di programmatore informatico.
                    <br>Interessato a lavorare nel settore della programmazione.
                </p>
            </div>
        </section>
        <!-- Sezione Skills -->
        <section id="skills" class="section">
            <div class="container">
                <h2>Le mie competenze in ambito informatico</h2>
                <br>
                <ul>
                    <li><i class="c"></i>- Linguaggio C</li>
                    <li><i class="c++"></i>- Linguaggio C++</li>
                    <li><i class="java"></i>- Linguaggio Java</li>
                    <li><i class="javascript"></i>- Javascript</li>
                    <li><i class="css"></i>- CSS</li>
                    <li><i class="html"></i>- HTML</li>
                    <li><i class="p"></i>- Photoshop</li>
                </ul>
                <br>
                <br>
                <h2>Le mie passioni:</h2>
                <br>
                <ul>
                    <li><i class="fotografia"></i>- Fotografia</li>
                    <li><i class="musica"></i>- Musica</li>
                    <li><i class="palestra"></i>- Palestra</li>
                </ul>
            </div>
        </section>

        <!-- Sezione Portfolio -->
        <section id="portfolio" class="section">
            <div class="container">
                <h2>Il mio Portfolio</h2>
                <div class="portfolio">
                </div>
            </div>
        </section>
        <br>
        <br>

        <!-- Sezione Contact -->
        <section id="contact" class="section">
            <div class="container">
                <h2>Contattami</h2>
                <form action="mailto:email@example.com" method="post" enctype="text/plain">
                    <table>
                        <td><input type="text" name="name" placeholder="Nome" required></td>
                        <td><input type="email" name="email" placeholder="Email" required></td>
                        <td><textarea name="message" placeholder="Messaggio" required></textarea></td>
                        <td><button type="submit" class="cta">Invia Messaggio</button></td>
                    </table>

                </form>
            </div>
        </section>
    </div>

    <!-- Footer -->
    <footer>
        
        <div class="social">
            
            <div class="social-icons">
                <a href="https://www.linkedin.com" target="_blank"><i class="fab fa-linkedin"></i></a>
                <a href="https://github.com" target="_blank"><i class="fab fa-github"></i></a>
                <a href="https://www.instagram.com" target="_blank"><i class="fab fa-instagram"></i></a>
                
                <p>
                <h5>&copy; 2024 Andrea Paris</h5>
                </p>
            </div>
        </div>
    </footer>
    </div>
</body>

</html>
```

```css
* {
    margin: auto;
    padding: auto;
    box-sizing: border-box;
}

body {
    font-family: 'Roboto', sans-serif;
    background-color: #f4f4f4;
    color: #333;
}

/* Stile Header*/
header {
    background-color: #333;
    color: #fff;
    padding: 20px 0;
}

header h1 {
    text-align: center;
    font-size: 2;
}

header nav ul {
    list-style-type: none;
    text-align: center;
}

header nav ul li {
    display: inline-block;
    margin: 0 15px;
}

header nav ul li a {
    color: #fff;
    text-decoration: none;
    font-size: 1.2rem;
}

.section {
    padding: 50px 20px;
}

.container {
    width: 90%;
    max-width: 1200px;
    margin: 0 auto;
}

h2 {
    font-size: 2rem;
    margin-bottom: 20px;
}

p {
    font-size: 1.1rem;
    line-height: 1.6;
}

.home {
    display: inline-block;
    background-color: #333;
    color: #fff;
    padding: 10px 20px;
    text-decoration: none;
    border-radius: 5px;
    font-weight: bold;
    margin-top: 20px;
}
footer {
    background-color: #333;
    color: #fff;
    padding: 20px 0;
    text-align: center;
}

footer .social-icons a {
    color: #fff;
    font-size: 1.5rem;
    margin: 0 10px;
    text-decoration: none;
}

footer .social-icons a:hover {
    color: #007bff;
}
```


