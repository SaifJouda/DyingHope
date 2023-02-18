 
using Parallax2D.Modules.Background.Code.Settings;
using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
#endif

namespace Parallax2D.Modules.Background.Code.Editor
{
    [CustomEditor(typeof(BackgroundSettings))]
    public class BackGroundEditor : UnityEditor.Editor
    {
        private BackgroundSettings targetInfo;

        public void OnEnable() {
            if (targetInfo == null) 
                targetInfo = target as BackgroundSettings;
        }
        public override void OnInspectorGUI() 
        {
            if (GUILayout.Button("Create background prefab")) 
                targetInfo.Create();
            base.OnInspectorGUI();
        }
    }
}
