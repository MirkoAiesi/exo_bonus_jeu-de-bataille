namespace exo_bonus_Jeu_de_bataille;

public class Bataille
{
    List<Cartes> paquet = new List<Cartes>();
    private Queue<Cartes> joueur1;
    private Queue<Cartes> joueur2;
    private Stack<Cartes> combat = new Stack<Cartes>();
    public Bataille()
    {
        StartGame();
    }

    public void StartGame()
    {
        foreach (ValeurCartes valeur in Enum.GetValues(typeof(ValeurCartes))) // typeof récupère toutes les constantes de l’énumération ValeurCartes
        {
            foreach (CouleurCartes couleur in CouleurCartes.GetValues<CouleurCartes>())
            {
                paquet.Add(new Cartes{Valeur= valeur, Couleur = couleur});
            }
        }
        paquet = paquet.OrderBy(x => Guid.NewGuid()).ToList();
        joueur1 = new Queue<Cartes>(paquet.Take(26).ToList());
        joueur2 = new Queue<Cartes>(paquet.Skip(26).ToList());
        Jouer();
    }

    public void Jouer()
    {
        do
        {
            Cartes carte1 = joueur1.Dequeue();
            Cartes carte2 = joueur2.Dequeue();
            if (carte1.Valeur > carte2.Valeur)
            {
                joueur1.Enqueue(carte1);
                joueur1.Enqueue(carte2);
                Console.WriteLine($"Joueur 1 joue {carte1.Valeur}");
                Console.WriteLine($"Joueur 2 joue {carte2.Valeur}");
                Console.WriteLine($"J1 gagne");
            }
            else if (carte2.Valeur > carte1.Valeur)
            {
                joueur2.Enqueue(carte1);
                joueur2.Enqueue(carte2);
                Console.WriteLine($"Joueur 1 joue {carte1.Valeur}");
                Console.WriteLine($"Joueur 2 joue {carte2.Valeur}");
                Console.WriteLine($"J2 gagne");
            }
            else
            {
                combat.Push(carte1);
                combat.Push(carte2);
                Cartes carte3 = joueur1.Dequeue();
                Cartes carte4 = joueur2.Dequeue();
                combat.Push(carte3);
                combat.Push(carte4);
                
                if (carte3.Valeur > carte4.Valeur)
                {
                    while (combat.Count>0)
                    {
                        joueur1.Enqueue(combat.Pop());
                    }

                    Console.WriteLine($"------------------JOUEUR 1 RAMASSE TOUT----------------------------");
                }
                else if (carte4.Valeur > carte3.Valeur)
                {
                    while (combat.Count>0)
                    {
                        joueur2.Enqueue(combat.Pop());
                    }
                    Console.WriteLine($"------------------JOUEUR 2 RAMASSE TOUT----------------------------");
                }
                
                
            }

            if (joueur1.Count < 2)
            {
                Console.WriteLine($"JOUEUR 2 GAGNE LA BATAILLE");
                Console.WriteLine("---CARTES DU JOUEUR 1-----------------");
                foreach (Cartes carte in joueur1)
                {
                    Console.WriteLine($"{carte.Valeur} de {carte.Couleur}");
                }
                Console.WriteLine("---CARTES DU JOUEUR 2-----------------");
                foreach (Cartes carte in joueur2)
                {
                    Console.WriteLine($"{carte.Valeur} de {carte.Couleur}");
                }
                break;
            }
            if (joueur2.Count < 2)
            {
                Console.WriteLine($"JOUEUR 1 GAGNE LA BATAILLE");
                Console.WriteLine("---CARTES DU JOUEUR 1-----------------");
                foreach (Cartes carte in joueur1)
                {
                    Console.WriteLine($"{carte.Valeur} de {carte.Couleur}");
                }
                Console.WriteLine("---CARTES DU JOUEUR 2-----------------");
                foreach (Cartes carte in joueur2)
                {
                    Console.WriteLine($"{carte.Valeur} de {carte.Couleur}");
                }
                break;
            }
        } while (joueur1.Count !=0 || joueur2.Count !=0 );
    }
    
}