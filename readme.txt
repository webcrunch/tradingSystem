���️ Användarinstruktioner
Programmet är menybaserat. Följ instruktionerna nedan för att komma igång.

Inloggning och Användarhantering
Start: Vid start läses befintlig data in från users.json och trades.json.

Inloggning/Registrering: Följ menyns instruktioner för att antingen logga in med en befintlig e-postadress eller skapa en ny användare.

Huvudmeny: Efter lyckad inloggning får du tillgång till följande val:

1. Hantera Föremål: Lägg till eller visa dina egna föremål.

2. Hantera Bytesförfrågningar: Skicka nya förfrågningar eller svara på inkommande.

0. Logga ut/Avsluta: Sparar all data och stänger programmet.

Bytesprocessen
Välj alternativet att skicka en bytesförfrågan.

Programmet visar en numrerad lista över alla tillgängliga användare. Välj en användare genom att ange dess nummer.

Välj ett föremål du vill ge bort genom att skriva dess namn.

Välj ett föremål du vill få från den andra användarens inventarium genom att skriva dess namn.

En bytesförfrågan skickas och visas i mottagarens meddelandeflöde.

��� Implementationsval och Resonemang
Här resonerar ni kring er C#-design och de val ni gjort gällande OOP (Objektorienterad Programmering).

1. Struktur och Organisation
Vi valde att separera programlogiken på följande sätt:

Program.cs: Innehåller endast programmets flödeskontroll (huvudmenyn, switch-satserna) och hanterar inläsning/sparande vid start/stopp.

Extra.cs (Statisk Klass): Används för alla hjälpfunktioner såsom utskrift av färgad text (DisplayAlertText), validering av input (GetIntegerInput, GetRequiredInput), och JSON-hantering.

Resonemang: Detta följer principen Single Responsibility Principle (SRP) och gör Program.cs ren och lättläst. Alla vanliga uppgifter centraliseras.

2. Komposition vs. Arv (Inheritance)
Vi har prioriterat Komposition framför Arv i stora delar av designen.

Komposition: Används där klasser "har ett" förhållande. Till exempel:

Klassen User har en lista av Item.

Klassen Trade har referenser till två User och två Item.

Resonemang: Komposition ger större flexibilitet. Om vi hade använt arv (t.ex. om Trade ärvde från User), skulle vi ha låst designen. Att använda komposition skapar tydliga och oberoende objektrelationer.

Arv (Inheritance): Användes inte då det inte fanns något tydligt "är ett" förhållande mellan huvudklasserna (User, Item, Trade). Att införa arv hade sannolikt lett till onödig komplexitet och "klasshierarkier" som var svåra att underhålla (Base Class → Sub Class).

3. Hantering av Användarinput
Istället för att använda den inbyggda Thread.Sleep() eller komplexa if (int.TryParse(...)) logiken, implementerade vi dedikerade hjälpfunktioner.

Extra.WaitForInput(): Används istället för Thread.Sleep().

Resonemang: Detta ger kontroll till användaren och skapar en bättre upplevelse. Användaren kan läsa informationen i sin egen takt.

Extra.GetIntegerInput() / Extra.GetRequiredInput(): Dessa funktioner loopar tills de får ett giltigt val.

Resonemang: Detta garanterar datasäkerhet och följer DRY-principen (Don't Repeat Yourself). All felhantering för ogiltig inmatning centraliseras, vilket gör huvudprogrammets logik ren och robust.

4. Datapersistens (JSON)
Programmet använder System.Text.Json och File.IO för att spara och ladda alla objekt (User och Trade) till JSON-filer vid programstart och avslut.

Resonemang: Detta val säkerställer att data består mellan olika körningar av programmet utan att behöva en fullfjädrad databas. JSON är lättviktigt och enkelt att hantera i C#.
