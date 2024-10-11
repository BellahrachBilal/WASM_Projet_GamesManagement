namespace DemoWASM.Pages.Demos
{
    public partial class Demo3
    {
        public List<Guid> Liste { get; set; }

        public Demo3()
        {
            Liste = new List<Guid>();
            for(int i = 0; i < 50; i++) 
            { 
                Liste.Add(Guid.NewGuid());
            }
        }
    }
}
