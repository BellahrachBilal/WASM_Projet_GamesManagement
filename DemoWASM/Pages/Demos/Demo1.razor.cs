using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.Demos
{
    public partial class Demo1
    {
        public int Valeur { get; set; } = 42;

        public void Ajouter()
        {
            Valeur++;
        }

        public void Ajouter5(string val)
        {
            Valeur += int.Parse(val);
        }
    }
}
