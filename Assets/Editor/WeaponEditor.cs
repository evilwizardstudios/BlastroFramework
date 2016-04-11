using UnityEngine;
using System.Collections;
using UnityEditor;

public class WeaponEditor : EditorWindow
{
    [MenuItem("Blastro/Weapon Editor")]
    private static void Init()
    {
        //WeaponEditor window = GetWindow<WeaponEditor>();
        var window = GetWindow(typeof (WeaponEditor), true);

        window.minSize = new Vector2(Screen.currentResolution.width - 150, Screen.currentResolution.height - 100);
        window.ShowUtility();
    }

    void OnGui()
    {
        EditorGUILayout.LabelField("test", "Test");
    }
}
