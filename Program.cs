/*Hjälpkod för att komma igång
 * Notera att båda klasserna är i samma fil för att det ska underlätta.
 * Om programmet blir större bör man ha klasserna i separata filer såsom jag går genom i filmen
 * Då kan det vara läge att ställa in startvärden som jag gjort.
 * Man kan också skriva ut saker i konsollen i konstruktorn för att se att den "vaknar
 * Denna kod hjälper mest om du siktar mot betyget E och C
 * För högre betyg krävs mer självständigt arbete
 */
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;
//Nedan är namnet på "namespace" - alltså projektet. 
//SKapa ett nytt konsollprojekt med namnet "Bussen" så kan ni kopiera över all koden rakt av från denna fil
namespace Bussen
{
    /*Börja längst ner i dokumentet och klassen "Program".
	Den klassen är liten och har i uppgiften att köra igång programmet genom att skapa en buss och sedan anropa metoden Run().
	I beskrivningen av projektet påpekas vikten av att koda stegvis. I detta fall kan det handla om att ni bara ska skriva
	ut en text i Run()-metoden.
	 */
    class Passenger
    {
        public int age { private set; get; }   //  PASSAGERARENS ÅLDER
        public int id { private set; get; }    //  PASSAGERARENS PLATS I BUSS
        public string name { private set; get; }  //  PASSAGERARENS NAMN
        public char sex { private set; get; }   //  PASSAGERARENS KÖN

        public override string ToString()
        {
            return "Passenger: "+ name.ToString() + "(" + sex.ToString() + "), passenger age: " + age.ToString() + ", ident = " + id.ToString();
        }

        //  CONSTRUCTOR
        public Passenger(int age, int id, string name, char sex)
        {
            this.age = age;
            this.id = id;
            this.name = name;
            this.sex = sex;
        }
    }
    class Buss
    {
        // STATISKA VARIABLER FÖR SLUMPVISA NAMN
        public static string[] RandomPassengerFirstNames = new string[] { "Kalle", "Pelle", "Nisse", "Olle", "Stina", "Anna", "Eva", "Lisa", "Karin", "Sara", "Eva", "Stefan", "Göran", "Bosse" };
        public static string[] RandomPassengerLastNAmes = new string[] { "Johansson", "Nilsson", "Larsson", "Karlsson", "Andersson", "Jansson", "Hansson", "Lindberg", "Lundberg", "Lindström", "Lundström", "Lindqvist", "Lundqvist", "Lindgren", "Lundgren" };

        public Passenger[] passagerare = new Passenger[20];
        public int antalPassagerare;


        public void Run()
        {
            Console.WriteLine("Welcome to the awesome Buss-simulator");
            //Här ska menyn ligga för att göra saker
            //Jag rekommenderar switch och case här
            MenuManager();
            //I filmen nummer 1 för slutprojektet så skapar jag en meny på detta sätt.
            //Film nummer 1) https://youtu.be/GKC1QafdcM0 
            //Film nummer 2 (för elever som siktar mot A)) https://youtu.be/ztW9F8ip2f0
            //Dessutom visar jag hur man anropar metoderna nedan via menyn
            //Börja nu med att köra koden för att se att det fungerar innan ni sätter igång med menyn.
            //Bygg sedan steg-för-steg och testkör koden.
        }

        //Metoder för betyget E

        public void MenuManager()
        {
            bool showPressAnyKeyTxt = false;
            //  BOOL FÖR ATT LOOPA MENYN
            bool continueLoop = true;

            //  LOOP FÖR MENY
            while (continueLoop)
            {
                int choice = -1;
                while (choice == -1 )
                {
                    if (showPressAnyKeyTxt)
                    {
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                    }
                    Console.Clear();
                    //  SKRIV UT MENYN
                    Console.WriteLine("1. Add passenger");
                    Console.WriteLine("2. Print bus");
                    Console.WriteLine("3. Calculate total age");
                    Console.WriteLine("4. Calculate average age");
                    Console.WriteLine("5. Show max age");
                    Console.WriteLine("6. Find age");
                    Console.WriteLine("7. Sort bus");
                    Console.WriteLine("8. Print sex");
                    Console.WriteLine("9. Poke");
                    Console.WriteLine("10. Getting off");
                    Console.WriteLine("11. Fill bus");
                    Console.WriteLine("12. Exit");
                    Console.WriteLine("Enter your choice: ");
                    //  LÄS IN ANVÄNDARENS VAL
                    int.TryParse(Console.ReadLine(), out choice);
                    Console.Clear();
                }
                showPressAnyKeyTxt = true;
                //  SWITCH FÖR MENYVAL
                switch (choice)
                {
                    case 1:
                        addPassenger();
                        break;
                    case 2:
                        printBuss();
                        break;
                    case 3:
                        //  ANROPA METODEN FÖR ATT BERÄKNA TOTAL ÅLDER OCH SKRIV UT RESULTATET
                        Console.WriteLine("The total age of all passengers on the buss is: " + calcTotalAge().ToString());
                        break;
                    case 4:
                        Console.WriteLine("The average age of all passengers on the buss is: " + calcAverageAge().ToString());
                        break;
                    case 5:
                        Console.WriteLine("The oldest passenger on the buss is {0}", showMaxAge());
                        break;
                    case 6:
                        findAge();
                        break;
                    case 7:
                        sortBuss();
                        break;
                    case 8:
                        printSex();
                        break;
                    case 9:
                        Console.WriteLine("Passengers in the buss are the following");
                        Console.WriteLine();
                        foreach (Passenger p in passagerare)
                        {
                            if (p != null)
                            {
                                Console.WriteLine("Name: " + p.name.ToString() +", Position: " + p.id.ToString());
                            }
                        }
                        int posToPoke = -1;
                        while (posToPoke == -1)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter position to poke");
                            int PokePos = int.TryParse(Console.ReadLine(), out posToPoke) ? posToPoke : -1;
                        }
                        Console.WriteLine(poke(posToPoke));

                        break;
                    case 10:
                        gettingOff();
                        break;
                    case 11:
                        FillBuss();
                        break;
                    case 12:
                        Console.WriteLine();
                        continueLoop = false;
                        break;
                    default:
                        choice = -1;
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        public void addPassenger()
        {
            //Lägg till passagerare. Här skriver man då in ålder men eventuell annan information.
            //Om bussen är full kan inte någon passagerare stiga på
            
            //  KOLLA OM BUSSEN ÄR FULL
            if (antalPassagerare < passagerare.Length)
            {
                //  OM BUSSEN INTE ÄR FULL SÅ LÄGG TILL PASSAGERARE

                //  BE ANVÄNDAREN OM NAMNET PÅ PASSAGERAREN OCH SPARA DET
                string name = String.Empty;
                while (name == String.Empty)
                {
                    Console.WriteLine("Enter passenger name");
                    name = Console.ReadLine();
                }

                //  BE ANVÄNDAREN OM ÅLDERN PÅ PASSAGERAREN OCH SPARA DET
                int age = 0;
                while (age == 0)
                {
                    Console.WriteLine("Enter passenger age");
                    age = int.TryParse(Console.ReadLine(), out age) ? age : 0;
                }

                //  BE ANVÄNDAREN OM KÖNET PÅ PASSAGERAREN OCH SPARA DET
                char sex = ' ';
                while (sex == ' ')
                {
                    Console.WriteLine("Enter passenger sex (M/F)");
                    sex = char.TryParse(Console.ReadLine(), out  sex) ? sex : ' ';
                }

                //  LÄS IN PASSAGERARENS PLATS I BUSSEN
                int id = GetNextAvailablePosition();
                //  OM ID INTE HAR LÄSTS IN SÅ SKRIV UT FELMEDDELANDE
                if(id == -1)
                {
                    Console.WriteLine("ERROR: ID IS {0}", id);
                    return;
                }

                //  SKAPA EN NY PASSAGERARE
                Passenger newPassenger = new Passenger(age, id, name, sex);
                //  LÄGG TILL PASSAGERAREN I BUSSARRAYEN
                passagerare[id] = newPassenger;
                //  ÖKA ANTAL PASSAGERARE MED 1
                antalPassagerare++;
            }
        }

        //  METOD FÖR ATT HÄMTA NÄSTA LEDIGA PLATS I BUSSARRAYEN
        private int GetNextAvailablePosition()
        {
            //  LOOPA IGENOM BUSSARRAYEN
            for (int i = 0; i < passagerare.Length; i++)
            {
                //  OM PLATSEN ÄR NULL SÅ ÄR DEN LEDIG
                if (passagerare[i] == null)
                {
                    //  RETURNERA PLATSEN
                    return i;
                }
            }

            //  OM BUSSARRAYEN ÄR FULL SÅ RETURNERA -1
            return -1;
        }

        public void printBuss()
        {
            //Skriv ut alla värden ur vektorn. Alltså - skriv ut alla passagerare

            //  LOOPA IGENOM BUSSARRAYEN
            foreach(Passenger p in passagerare)
            {
                //  OM PLATSEN INTE ÄR NULL SÅ SKRIV UT PASSAGERARENS INFORMATION
                if (p != null)
                    Console.WriteLine("On seat {0} is {1}({2}) seated whom is {3} years old", p.id, p.name, p.sex, p.age);
                else 
                    Console.WriteLine("Seat is vaccant");
            }
        }

        public int calcTotalAge()
        {
            //Beräkna den totala åldern. 
            //För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void

            //  SKAPA EN VARIABEL FÖR TOTAL ÅLDER
            int totalAge = 0;

            //  LOOPA IGENOM BUSSARRAYEN
            foreach (Passenger p in passagerare)
            {
                //  OM PLATSEN INTE ÄR NULL SÅ LÄGG TILL PASSAGERARENS ÅLDER I TOTAL ÅLDER
                if (p != null)
                {
                    totalAge += p.age;
                }
            }
            
            //  RETURNERA TOTAL ÅLDER
            return totalAge;
        }

        //Metoder för betyget C

        public double calcAverageAge()
        {
            //Betyg C
            //Beräkna den genomsnittliga åldern. Kanske kan man tänka sig att denna metod ska returnera något annat värde än heltal?
            //För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void

            //  SKAPA EN VARIABEL FÖR MEDELÅLDER
            double averageAge = 0;
            //  BERÄKNA MEDELÅLDER
            averageAge = (double)calcTotalAge() / antalPassagerare;
            averageAge = Math.Round(averageAge, 2);
            //  SKRIV UT MEDELÅLDER
            return averageAge;
        }

        public int showMaxAge()
        {
            //Betyg C
            //ta fram den passagerare med högst ålder. Detta ska ske med egen kod och är rätt klurigt.
            //För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void

            int maxAge = 0;
            //  LOOPA IGENOM BUSSARRAYEN
            foreach (Passenger p in passagerare)
            {
                //  OM PLATSEN INTE ÄR NULL OCH PASSAGERARENS ÅLDER ÄR STÖRRE ÄN MAXÅLDER
                if (p != null && p.age > maxAge)
                {
                    //  SÄTT MAXÅLDER TILL PASSAGERARENS ÅLDER
                    maxAge = p.age;
                }
            }
            //  SKRIV UT MAXÅLDER
            return maxAge;
        }

        public void findAge()
        {
            //Visa alla positioner med passagerare med en viss ålder
            //Man kan också söka efter åldersgränser - exempelvis 55 till 67
            //Betyg C
            //Beskrivs i läroboken på sidan 147 och framåt (kodexempel på sidan 149)

            //  BE ANVÄNDAREN OM ÅLDERN SOM SKA SÖKAS EFTER
            Console.WriteLine("Enter minimum age to search for");
            int minAge = int.TryParse(Console.ReadLine(), out minAge) ? minAge : 0;

            Console.WriteLine("Enter maximum age to search for");
            int maxAge = int.TryParse(Console.ReadLine(), out maxAge) ? maxAge : 0;

            //  LOOPA IGENOM BUSSARRAYEN
            foreach (Passenger p in passagerare)
            {
                //  OM PLATSEN INTE ÄR NULL OCH PASSAGERARENS ÅLDER ÄR MELLAN MINÅLDER OCH MAXÅLDER
                if (p != null && p.age >= minAge && p.age <= maxAge)
                {
                    //  SKRIV UT PASSAGERARENS INFORMATION
                    Console.WriteLine(p.ToString());
                }
            }

        }

        public void sortBuss()
        {
            //Sortera bussen efter ålder. Tänk på att du inte kan ha tomma positioner "mitt i" vektorn.
            //Beskrivs i läroboken på sidan 147 och framåt (kodexempel på sidan 159)
            //Man ska kunna sortera vektorn med bubble sort

            //  SKRIV UT TEXT OM ATT BUSS ARRAYEN SKA SORTERAS
            Console.WriteLine("Sorting bus by age");

            //  ANROPA METODEN FÖR ATT SORTERA BUSS ARRAYEN
            passagerare = BubbleSort();

            //  SKRIV UT BUSS ARRAYEN SOM NU ÄR SORTERAD
            Console.WriteLine("Bus sorted by age");
            foreach (Passenger p in passagerare)
            {
                if (p != null)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }

        private Passenger[] BubbleSort()
        {
            //  SKAPA EN LISTA FÖR ATT SORTERA BUSS ARRAYEN, FÖR ATT KUNNA SORTERA ARRAYEN ÄVEN OM DET FINNS TOMMA PLATSER I MITTEN
            List<Passenger> passengerList = passagerare.Where(x => x != null).ToList();

            //  BUBBLESORT
            //GÅ IGENOM HELA LISTAN (TVÅ GÅNGER)
            for (int i = 0; i < passengerList.Count; i++)
            {
                // GÅ IGENOM ALLA ELEMENT I LISTAN
                for (int j = 0; j < passengerList.Count - 1; j++)
                {
                    //  OM ELEMENTET ÄR STÖRRE ÄN NÄSTA ELEMENT
                    if (passengerList[j].age > passengerList[j + 1].age)
                    {
                        //  SPARA DET MINDRE ELEMENTET I EN TEMPORÄR VARIABEL
                        Passenger temp = passengerList[j + 1];
                        //  SKRIV ÖVER DET LÄGRE ELEMENTET MED DET HÖGRE
                        passengerList[j + 1] = passengerList[j];
                        //  SKRIV ÖVER DET HÖGRE ELEMENTET MED DET SPARADE VÄRDET
                        passengerList[j] = temp;
                    }
                }
            }

            //  SÄTT PASSAGERARE TILL EN NY TOM ARRAY
            passagerare = new Passenger[20];
            //  LOOPA IGENOM LISTAN OCH LÄGG TILL ELEMENTEN I DEN TOMMA ARRAYEN
            for (int i = 0; i < passengerList.Count; i++)
            {
                //  LÄGG IN ELEMENTET I ARRAYEN
                passagerare[i] = passengerList[i];
            }

            //  RETURNERA DEN NYA ARRAYEN
            return passagerare;
        }

        //Metoder för betyget A
        //NOTERA! För betyget A ska du inte jobba med heltal i vektorn utan objekt av klassen passagerare (som du skapar)


        public void printSex()
        {
            //Betyg A
            //Denna metod är nödvändigtvis inte svårare än andra metoder men kräver att man skapar en klass för passagerare.
            //Skriv ut vilka positioner som har manliga respektive kvinnliga passagerare.

            //  SKAPA TVÅ LISTOR FÖR MANLIGA OCH KVINNLIGA PASSAGERARE
            List<Passenger> male = new List<Passenger>();
            List<Passenger> female = new List<Passenger>();

            //  SKAPA EN VARIABEL FÖR ATT HÅLLA REDA PÅ INDEX
            int index = 0;

            //  LOOPA IGENOM BUSSARRAYEN
            foreach (Passenger p in passagerare)
            {
                //  NULL CHECK
                if (p != null)
                { 
                    //  OM PASSAGERAREN ÄR F
                    if (p.sex == 'F' || p.sex == 'f')
                    {
                        //  LÄGG TILL PASSAGERAREN I KVINNLIGA LISTAN
                        female.Add(p);
                    }
                    //  OM PASSAGERAREN ÄR M
                    else if (p.sex == 'M' || p.sex == 'm')
                    {
                        //  LÄGG TILL PASSAGERAREN I MANLIGA LISTAN
                        male.Add(p);
                    }
                }
            }
            //  SKRIV UT MANLIGA PASSAGERARE OCH DERAS POSITIONER
            Console.WriteLine("Male passengers in the buss are the following");
            foreach (Passenger p in male)
            {
                Console.WriteLine(p.ToString());
            }

            //  SKRIV UT KVINNLIGA PASSAGERARE OCH DERAS POSITIONER
            Console.WriteLine("Female passengers in the buss are the following");
            foreach (Passenger p in female)
            {
                Console.WriteLine(p.ToString());
            }
        }
        public string poke(int posToPoke)
        {
            //Betyg A
            //Vilken passagerare ska vi peta på?
            //Denna metod är valfri om man vill skoja till det lite, men är också bra ur lärosynpunkt.
            //Denna metod ska anropa en passagerares metod för hur de reagerar om man petar på dom (eng: poke)
            //Som ni kan läsa i projektbeskrivningen så får detta beteende baseras på ålder och kön
            
            // SKAPA EN VARIABEL FÖR VILKEN PASSAGERARE SOM SKA PETAS PÅ
            Passenger passengerToPoke = null;

            //  LOOPA IGENOM SAMTLIGA PASSAGERARE
            foreach (Passenger p in passagerare)
            {
                //  NULL CHECK
                if (p != null)
                {
                    //  OM PASSAGERAREN HAR SAMMA ID SOM DEN SOM SKA PETAS PÅ
                    if (p.id == posToPoke)
                    {
                        //  OM PASSAGERAREN ÄR UNDER 10 ÅR
                        if (p.age < 10)
                        {
                            return "The passenger is a child and starts to cry";
                        }
                        //  OM PASSAGERAREN ÄR MELLAN 10 OCH 20 ÅR
                        else if (p.age >= 10 && p.age < 20)
                        {
                            return "The passenger is a teenager and gets angry";
                        }
                        //  OM PASSAGERAREN ÄR MELLAN 20 OCH 60 ÅR
                        else if (p.age >= 20 && p.age < 60)
                        {
                            return "The passenger is an adult and gets annoyed";
                        }
                        //  OM PASSAGERAREN ÄR ÖVER 60 ÅR
                        else if (p.age >= 60)
                        {
                            return "The passenger is an elder and gets scared";
                        }
                    }
                }
            }

            //  OM INGEN PASSAGERARE HITTAS RETURNERA ETT FELMEDDELANDE
            return "No passenger found";

        }

        public void gettingOff()
        {
            //Betyg A
            //En passagerare kan stiga av
            //Detta gör det svårare vid inmatning av nya passagerare (som sätter sig på första lediga plats)
            //Sortering blir också klurigare
            //Den mest lämpliga lösningen (men kanske inte mest realistisk) är att passagerare bakom den plats..
            //.. som tillhörde den som lämnade bussen, får flytta fram en plats.
            //Då finns aldrig någon tom plats mellan passagerare.


            //  SKRIV UT TEXT FÖR ATT VISA ALLA PASSAGERARE
            Console.WriteLine("Passengers in the buss are the following");
            Console.WriteLine();
            //  LOOPA IGENOM BUSSARRAYEN OCH SKRIV UT ALLA PASSAGERARE
            foreach (Passenger p in passagerare)
            {
                if (p != null)
                {
                    Console.WriteLine("Name: " + p.name.ToString() + ", Position: " + p.id.ToString());
                }
            }
            Console.WriteLine();

            //  SKAPA EN VARIABEL FÖR VILKEN PASSAGERARE SOM SKA LÄMNA BUSS
            int posToLeave = -1;
            //  LOOPA TILLS ANVÄNDAREN HAR LÄST IN ETT KORREKT VÄRDE
            while (posToLeave == -1 || posToLeave > 20)
            {
                //  BE ANVÄNDAREN OM VILKEN POSITION SOM SKA LÄMNA BUSS
                Console.WriteLine("Enter position to leave");
                //  LÄS IN VÄRDET
                int LeavePos = int.TryParse(Console.ReadLine(), out posToLeave) ? posToLeave : -1;
            }

            //  SKRIV UT TEXT FÖR ATT VISA ATT PASSAGERAREN LÄMNAR BUSS
            Console.WriteLine("Passenger at position {0} is leaving the buss", posToLeave);
            //  LOOPA IGENOM BUSSARRAYEN
            for (int i = 0; i < passagerare.Length; i++)
            {
                //  NULL CHECK
                if(passagerare[i] != null)
                {
                    //  OM PASSAGERAREN HAR SAMMA ID SOM DEN SOM SKA LÄMNA BUSS
                    if (passagerare[i].id == posToLeave)
                    {
                        //  SÄTT PLATSEN TILL NULL
                        passagerare[i] = null;
                        //  MINSKA ANTAL PASSAGERARE MED 1
                        antalPassagerare--;
                    }
                }
            }

        }

        private void FillBuss()
        {
            //  LOOPA IGENOM BUSSARRAYEN
            for (int i = 0; i < passagerare.Length; i++)
            {
                //  SKAPA EN VARIABEL FÖR PASSAGERAREN
                Passenger p = passagerare[i];

                // OM PLATSEN ÄR NULL
                if (p == null)
                {
                    //  ÖKA ANTAL PASSAGERARE MED 1
                    antalPassagerare++;

                    //  SKAPA EN NY PASSAGERARE
                    //  SKAPA EN NY SLUMPGENERATOR
                    Random r = new Random();
                    //  SLUMPA FRAM ÅLDERN
                    int age = r.Next(1, 100);
                    //  GE PASSAGERAREN ETT ID SOM MOTSVARAR DEN TOMMA POSTIONEN
                    int id = i;
                    //  SLUMPA FRAM ETT NAMN
                    string name = RandomPassengerFirstNames
                        [r.Next(0, RandomPassengerFirstNames.Length)] + " " + 
                        RandomPassengerLastNAmes[r.Next(0, RandomPassengerLastNAmes.Length)];
                    //  SLUMPA FRAM KÖNET, OCH JA. LINDA KAN IDENTIFIERA SIG SOM EN MAN OCH CLAS SOM EN KVINNA OCH DET ÄR OKEJ. BARA DE ÄR GLADA
                    char sex = r.Next(0, 2) == 0 ? 'M' : 'F';

                    //  SKAPA EN NY PASSAGERARE MED DE SLUMPVISA VÄRDERNA
                    Passenger newPassenger = new Passenger(age, id, name, sex);

                    //  LÄGG TILL PASSAGERAREN I BUSSARRAYEN PÅ SAMMA POSITION SOM DESS ID
                    passagerare[id] = newPassenger;
                }
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            //Denna del körs först! 
            //Denna del av koden kan upplevas väldigt förvirrande. Men i sådana fall är det bara att "skriva av".
            //Programmet skapar ett så kallat objekt av klassen "Buss". Det är det objekt vi kommer jobba med.
            //Följande rad skapar en buss:
            var minbuss = new Buss();
            //Följande rad anropar metoden Run() som finns i vårt nya buss-objekt.
            minbuss.Run();
            //När metoden Run() tar slut så kommer koden fortsätta här. Då är programmet slut
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}