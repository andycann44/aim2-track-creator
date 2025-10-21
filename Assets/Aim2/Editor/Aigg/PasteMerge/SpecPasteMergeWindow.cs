#if UNITY_EDITOR
using UnityEditor; using UnityEngine; using System.IO;
namespace Aim2.AIGG {
  public class SpecPasteMergeWindow : EditorWindow {
    string pasted=""; string target="intents.json"; Vector2 sv;
    static string SpecPath => "Assets/Aim2/Spec";
    [MenuItem("Window/Aim2/Aigg/Paste & Replace")]
    public static void Open(){ var w=GetWindow<SpecPasteMergeWindow>(); w.titleContent=new GUIContent("Paste & Replace"); w.minSize=new Vector2(560,460); w.Show(); }
    public static void OpenWithJson(string j){ var w=GetWindow<SpecPasteMergeWindow>(); w.pasted=j??""; w.Show(); }
    void OnGUI(){
      EditorGUILayout.LabelField("Paste & Replace", EditorStyles.boldLabel);
      using(new EditorGUILayout.HorizontalScope()){ EditorGUILayout.LabelField("Target:", GUILayout.Width(60)); target=EditorGUILayout.TextField(target); }
      sv=EditorGUILayout.BeginScrollView(sv); pasted=EditorGUILayout.TextArea(pasted, GUILayout.MinHeight(220)); EditorGUILayout.EndScrollView();
      using(new EditorGUILayout.HorizontalScope()){
        if(GUILayout.Button("Apply (Replace)")) {
          var t=(pasted??"").Trim();
          if(!((t.StartsWith("{")&&t.EndsWith("}"))||(t.StartsWith("[")&&t.EndsWith("]")))){ Debug.LogError("Invalid JSON"); }
          else { var p=Path.Combine(SpecPath, target); Directory.CreateDirectory(Path.GetDirectoryName(p)!); File.WriteAllText(p, pasted); AssetDatabase.Refresh(); }
        }
        if(GUILayout.Button("Clear")) pasted="";
      }
    }
  }
}
#endif
