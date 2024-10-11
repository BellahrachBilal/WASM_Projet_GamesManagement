using DemoWASM.Models;

namespace DemoWASM.Services
{
    public class GamerService : IGamerService
    {
        private Dictionary<int, Gamer> gamers;
        public GamerService()
        {
            gamers = new Dictionary<int, Gamer>();
            gamers.Add(1, new Gamer
            {
                Id = 1,
                Pseudo = "Arthur",
                Password = "Test1234",
                BirthDate = DateTime.Now,
                Email = "arthur@bretagne.com"
            });
        }

        public List<Gamer> GetAll() { return gamers.Values.ToList(); }

        public Gamer GetById(int id)
        {
            return gamers[id];
        }

        public void Save(Gamer gamer)
        {
            gamer.Id = gamers.Values.Max(g => g.Id) + 1;

            gamers.Add(gamer.Id, gamer);
        }

        public void Update(Gamer gamer)
        {
            gamers[gamer.Id] = gamer;
        }
    }
}
