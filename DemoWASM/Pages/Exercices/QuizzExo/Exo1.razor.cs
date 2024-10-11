namespace DemoWASM.Pages.Exercices.QuizzExo
{
    public partial class Exo1
    {
        public string Prenom { get; set; }

        public List<string> Questions { get; set; }
        public List<string> Reponses { get; set; }
        public int Compteur { get; set; } = 0;
        public bool GameIsOver { get; set; }
        public Exo1()
        {
            Questions = new List<string>();
            Questions.AddRange(new string[] {"Avez vous bien dormi ?", "Parer pour le weekend ?", "Blazor c'est bien ?" });
            Reponses = new List<string>();
        }

        public void ReceptionReponse(string rep)
        {
            Reponses.Add(rep);
            if (Compteur >= Questions.Count()-1) GameIsOver = true;
            Compteur++;
        }
    }
}
