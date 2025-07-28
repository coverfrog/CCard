using UnityEngine;

namespace Cf.CCard
{
    [CreateAssetMenu(fileName = "Card", menuName = "Cf/CCard/Card")]
    
    public class CardData : ScriptableObject
    {
        [Header("[ String ]")]
        
        [SerializeField] 
        private string mCodeName;
        
        [SerializeField] 
        private string mDisplayName;
        
        [SerializeField][TextArea] 
        private string mDescription;

        [Header("[ Texture ]")]
        
        [SerializeField] 
        private Texture2D mTexture;
        
        #region Get

        public string CodeName => mCodeName;
        public string DisplayName => mDisplayName;
        public string Description => mDescription;
        
        public Texture2D Texture => mTexture;

        #endregion
    }
}
