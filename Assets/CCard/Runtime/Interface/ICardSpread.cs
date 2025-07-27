using System.Collections.Generic;
using UnityEngine;

namespace Cf.CCard
{
    public interface ICardSpread
    {
        List<CardTransformData> Spread(Transform origin, bool isLocal, int count);
    }
}
