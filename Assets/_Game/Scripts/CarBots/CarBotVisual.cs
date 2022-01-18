using Sirenix.OdinInspector;
using UnityEngine;

namespace RoofRace.Bots
{
    public class CarBotVisual : MonoBehaviour
    {
        [SerializeField] private GameObject[] _meshes;

        #region EDITOR TOOLS
#if UNITY_EDITOR

        [Button]
        private void SelectGreen() => SelectByName("Green");

        [Button]
        private void SelectBlack() => SelectByName("Black");

        [Button]
        private void SelectBlue() => SelectByName("Blue");

#endif
        #endregion

        private void SelectByName(string name)
        {
            foreach (GameObject mesh in _meshes)
                mesh.SetActive(mesh.name == name);
        }
    }
}