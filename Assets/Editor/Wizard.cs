using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Wizard : ScriptableWizard
{
    public List<GameObject> AllPrefabsList = new List<GameObject>();
    public List<Texture> textures = new List<Texture>();

    private void OnSelectionChange()
    {
        Debug.Log("Select");
        //foreach(var path in AssetDatabase.FindAssets("t:Prefab"))
        //{
        //    string prefabPath = AssetDatabase.GUIDToAssetPath(path);
        //    GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        //    if (prefab != null)
        //    {
        //        AllPrefabsList.Add(prefab);
        //    }
        //}

        errorString = "";
        //获取选择物体的路径
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (!string.IsNullOrEmpty(path))
        {
            //无论是否有子文件，直接遍历所有.png文件
            string[] files = Directory.GetFiles(path, ".png", SearchOption.AllDirectories);
            if (files.Length == 0)
            {
                //errorString也是ScriptableWizard自带的
                errorString = "当前选中目录及其子目录均无搜寻类型的文件";
                return;
            }

            foreach (string file in files)
            {
                Texture tex = AssetDatabase.LoadAssetAtPath<Texture>(file);
                if (tex != null)
                {
                    textures.Add(tex);
                }
                helpString = "获取到了" + textures.Count;
            }
        }
    }

    [MenuItem("Tools/窗口")]
    static void CreateToolsWindow()
    {
        DisplayWizard<Wizard>("窗口", "更新且关闭", "更新");
    }
    private void OnWizardCreate()
    {
        Debug.Log("Create");
    }
    private void OnWizardOtherButton()
    {
        Debug.Log("OtherButton");
    }
}
