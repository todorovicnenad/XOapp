X-O aplikacija:

Projekat je radjen u programu Visual Studio 2017 Comunity.
Startovanjem programa se dolazi do Windows forme preko koje 
je radjena aplikacija.U srediji je tabla veličine 10*10, a 
oko nje nekoliko dugmeta, text polja i jedan listbox.
Forma ima nekoliko svojstava, a sva su pomoćni alat za
rad igrača koji se bavi nekom misaonom igrom.U ovom slučaju,
to je igra X-O sa tablom veličine 10*10, gde je za pobedu 
potreban niz od 5 jednakih znakova horizontalno, vertikalno ili 
ukoso.

Prvo svojstvo je unos partije u "bazu".Ovde se ne radi o pravoj 
bazi, jer se svaka uneta partija smešta u fajl "partije.txt".
Ovo se omogućava klikom na dugme "Pocni".Od tog trenutka pa 
na dalje klikom na tablu pojavljivaće se "X" ili "O" simboli, zavisno 
od toga da li je parni ili neparni klik.To će trajati sve dok partija 
ne bude gotova, odnostno dok program ne registruje da je jedan od
igrača napravio niz od 5 znakova.Sve vreme povlačenja ovih poteza, u 
fajl se upisuje partija na sledeći način.U prvom slobodnom redu 
stoje razmaknuti ime i prezime X igrača, pa siimbol "&", pa onda 
ime i prezime O igrača, razmaknuti.Ta imenu su iz text polja koja treba 
da se popune pre nego što se klikne na dugme "Pocni".Potezi se unose u 
formatu a1,a2-b1,b2(tako izgleda red u fajlu), i prelazi se u sledeći red.
U poslednjem redu partije stoji rezultat u obliku "1:0","1/2:1/2" ili "0:1".
Partija je neresena ako je tabla popunjena i ni jedan od igrača nije napravio niz
od 5 simbola.

Drugo svojstvo je da se trenutno stanje ponisti klikom na dugme "Obrisi".Bilo 
da je do datog trenutka izvrsen unos partije, analiza, neka vrsta pretrage, to se prekida 
i nastavlja se sa radom klikom na sledeće željeno dugme.
U listboxu su sve do sada unete partije, i pri svakom startovanju programa, u listbox ce
se smestiti sve partije citanjem iz fajla.U većini slučajeva nemoguće je preći sa jednog na
drugi režim samo klikom na željeno dugme, ako prethodno nije kliknuto na dugme "Obrisi".

Klikom na dugme "Analiza" ulazi se u rezim analize partije.Nakon toga, posle svakog klika
korisnika na tablu pojavljivaće se na datom polju X ili O, kao i kod režima unosa partije.
Razlika je u tome što se sada partija neće unositi u fajl, a biće dozvoljena još jedna opcija.
Naime, dok je aplikacija u režimu analize, biće omogućena pretraga po poziciji.Klikom na dugme
"Pretraga po poziciji", u listboxu će ostati samo one partije kod kojih je u nekom trenutku 
došlo do pozicije iz datog trenutka u analizi.

Klikom na neku partiju u listboxu, prvo što će se promeniti su text polja za ime i prezime 
X i O igrača-text u njima biće odgovarajuće ime i prezime igrača koji su igrali datu partiju.
Aplikacija je onda u režimu pregleda partije.Partija se gleda klikom na dugme "<<" ili dugme ">>".
Klikom na ">>" na tabli će se prikazati stanje u datoj partiji posle sledećeg poteza, a klikom na "<<"
prikazaće se stanje potez pre datog trenutka.Dugme "<<" ima svojstvo i u režimu analize, kada
će poslednji potez biti izbrisan(smatra se da je korisnik napravio grešku u odigravanju i želi da promeni potez).

Klikom na dugme "Pretraga", u listboxu će ostati samo partije koje je igrao igrač čije ime počinje 
stringom koji je unet u polje za ime, i čije prezime počinje stringom koji je unet u polje za 
prezime.Kod ove i prethodno opisane pretrage, nakon što se u listboxu promeni broj partija, klikom na
drugme "Obrisi", stanje u listboxu će se vratiti na početno, odnosno sve partije će biti tu.


	