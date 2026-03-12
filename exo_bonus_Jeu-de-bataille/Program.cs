
List<Cartes> tasDeCarte = new List<Cartes>();
foreach (ValeurCartes valeur in Enum.GetValues(typeof(ValeurCartes)))
{
    foreach (CouleurCartes couleur in Enum.GetValues(typeof(CouleurCartes)))
    {
        tasDeCarte.Add(new Cartes{Valeur= valeur, Couleur = couleur});
    }
}

foreach (Cartes carte in tasDeCarte)
{
    Console.WriteLine($"{carte.Valeur} de {carte.Couleur}");
}
public enum ValeurCartes
{
    Deux,
    Trois,
    Quatre,
    Cinq,
    Six,
    Sept,
    Huit,
    Neuf,
    Dix,
    Valet,
    Dame,
    Roi, 
    As
}

public enum CouleurCartes
{
    Coeur,
    Carreau,
    Trefle,
    Pique
}

class Cartes
{
    public 
        
        ValeurCartes Valeur;
    public CouleurCartes Couleur;
}
