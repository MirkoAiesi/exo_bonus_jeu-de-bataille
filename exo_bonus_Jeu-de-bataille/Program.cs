
using exo_bonus_Jeu_de_bataille;

List<Cartes> tasDeCarte = new List<Cartes>();
foreach (ValeurCartes valeur in Enum.GetValues(typeof(ValeurCartes))) // typeof récupère toutes les constantes de l’énumération ValeurCartes
{
    foreach (CouleurCartes couleur in CouleurCartes.GetValues<CouleurCartes>())
    {
        tasDeCarte.Add(new Cartes{Valeur= valeur, Couleur = couleur});
    }
}

foreach (Cartes carte in tasDeCarte)
{
    Console.WriteLine($"{carte.Valeur} de {carte.Couleur}");
}
