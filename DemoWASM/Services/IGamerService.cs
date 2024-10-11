using DemoWASM.Models;

namespace DemoWASM.Services
{
    public interface IGamerService
    {
        List<Gamer> GetAll();
        Gamer GetById(int id);
        void Save(Gamer gamer);
        void Update(Gamer gamer);
    }
}