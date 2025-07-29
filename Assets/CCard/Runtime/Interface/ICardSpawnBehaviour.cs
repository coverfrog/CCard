using System;

namespace Cf.CCard
{
    public interface ICardSpawnBehaviour
    {
        bool IsInitialized { get; }
        
        void Initialize();
        
        ICard Get();
    }
}