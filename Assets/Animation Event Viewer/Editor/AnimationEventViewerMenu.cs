using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LuviKunG.AnimationEventViewer.Editor
{
    public static class AnimationEventViewerMenu
    {
        private static List<AnimationClip> selection;

        [MenuItem("Assets/LuviKunG/Animation Event Viewer", validate = true)]
        public static bool ValidateAnimationEventViewer()
        {
            selection = selection ?? new List<AnimationClip>();
            selection.Clear();
            if (Selection.objects.Length > 0)
            {
                for (int i = 0; i < Selection.objects.Length; i++)
                    if (Selection.objects[i] is AnimationClip)
                        selection.Add(Selection.objects[i] as AnimationClip);
                return selection.Count > 0;
            }
            else
            {
                return false;
            }
        }

        [MenuItem("Assets/LuviKunG/Animation Event Viewer", validate = false)]
        public static void OpenAnimationEventViewerWithSelection()
        {
            if (selection != null && selection.Count > 0)
            {
                AnimationEventViewerWindow.OpenWindow(selection);
            }
        }
    }
}