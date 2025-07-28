using UnityEngine;
using UnityEngine.Pool;

namespace Cf.CCard
{
    public interface ICardSpawn 
    {
        IObjectPool<ICard> Pool { get; }

        ICard Get();
        
        ICard OnCreate();

        void OnGet(ICard card);
        
        void OnRelease(ICard card);
        
        void OnDestroy(ICard card);
    }
}
