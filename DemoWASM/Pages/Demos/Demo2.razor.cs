namespace DemoWASM.Pages.Demos
{
    public partial class Demo2
    {
        public int Valeur { get; set; }

        public string Reponse { get; set; }
        public void TraitementReponseEnfant(string rep)
        {
            Reponse = rep;
        }

        public void Increment()
        {
            Valeur++;
        }
    }
}
