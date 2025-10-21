#if UNITY_EDITOR
using UnityEditor; using UnityEngine;
namespace Aim2.AIGG {
  public class PreMergeRouterWindow : EditorWindow {
    string json=""; Vector2 sv; string status="Idle";
    [MenuItem("Window/Aim2/Aigg/Pre-Merge Router")]
    public static void Open(){ var w=GetWindow<PreMergeRouterWindow>(); w.titleContent=new GUIContent("Pre-Merge Router"); w.minSize=new Vector2(520,420); w.Show(); }
    void OnGUI(){
      EditorGUILayout.LabelField("Pre-Merge Router", EditorStyles.boldLabel);
      EditorGUILayout.HelpBox("Paste canonical JSON. Validate then send to Paste & Replace.", MessageType.Info);
      sv=EditorGUILayout.BeginScrollView(sv); json=EditorGUILayout.TextArea(json, GUILayout.MinHeight(180)); EditorGUILayout.EndScrollView();
      using(new EditorGUILayout.HorizontalScope()){
        if(GUILayout.Button("Validate")){
          var t=(json??"").Trim();
          status = (t.StartsWith("{")&&t.EndsWith("}"))||(t.StartsWith("[")&&t.EndsWith("]")) ? "OK" : "Invalid JSON";
        }
 Paste & Replace")){
          if(status=="OK") { SpecPasteMergeWindow.OpenWithJson(json); status="Sent."; } else status="Validate first.";
        }
        if(GUILayout.Button("Clear")){ json=""; status="Cleared."; }
      }
      EditorGUILayout.LabelField("Status:", status);
    }
  }
}
#endif
