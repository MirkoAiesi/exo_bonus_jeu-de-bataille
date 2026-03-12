using exo_bonus_Jeu_de_bataille;
Random r = new Random();

List<Cartes> tasDeCarte = new List<Cartes>();
foreach (ValeurCartes valeur in Enum.GetValues(typeof(ValeurCartes))) // typeof récupère toutes les constantes de l’énumération ValeurCartes
{
    foreach (CouleurCartes couleur in CouleurCartes.GetValues<CouleurCartes>())
    {
        tasDeCarte.Add(new Cartes{Valeur= valeur, Couleur = couleur});
    }
}
tasDeCarte = tasDeCarte.OrderBy(x => Guid.NewGuid()).ToList();
List<Cartes> joueur1 = tasDeCarte.Take(26).ToList();
List<Cartes> joueur2 = tasDeCarte.Skip(26).ToList();
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