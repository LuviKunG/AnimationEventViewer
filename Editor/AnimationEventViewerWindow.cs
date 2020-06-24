using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LuviKunG.AnimationEventViewer.Editor
{
    public sealed class AnimationEventViewerWindow : EditorWindow
    {
        private static readonly GUIContent CONTENT_NAME = new GUIContent("Name");
        private static readonly GUIContent CONTENT_EVENT_FUNCTION_NAME = new GUIContent("Event Name");
        private static readonly GUIContent CONTENT_EVENT_TIME = new GUIContent("Time");
        private static readonly GUIContent CONTENT_EVENT_PARAMETER_STRING = new GUIContent("String Parameter");
        private static readonly GUIContent CONTENT_EVENT_PARAMETER_FLOAT = new GUIContent("Float Parameter");
        private static readonly GUIContent CONTENT_EVENT_PARAMETER_INT = new GUIContent("Integer Parameter");
        private static readonly GUIContent CONTENT_EVENT_PARAMETER_OBJECT = new GUIContent("Object Reference");

        private List<AnimationClip> currentClips = new List<AnimationClip>();
        private Vector2 scrollPosition;

        public static AnimationEventViewerWindow OpenWindow()
        {
            AnimationEventViewerWindow window = GetWindow<AnimationEventViewerWindow>(false, "Animation Event Viewer", true);
            window.Show();
            return window;
        }

        public static AnimationEventViewerWindow OpenWindow(params AnimationClip[] clips)
        {
            AnimationEventViewerWindow window = OpenWindow();
            window.Load(clips);
            return window;
        }

        public static AnimationEventViewerWindow OpenWindow(IList<AnimationClip> clips)
        {
            AnimationEventViewerWindow window = OpenWindow();
            window.Load(clips);
            return window;
        }

        public void Load(IList<AnimationClip> clips)
        {
            currentClips = currentClips ?? new List<AnimationClip>();
            currentClips.Clear();
            currentClips.AddRange(clips);
        }

        public void Load(params AnimationClip[] clips)
        {
            currentClips = currentClips ?? new List<AnimationClip>();
            currentClips.Clear();
            currentClips.AddRange(clips);
        }

        private void OnGUI()
        {
            using (var verticalScope = new EditorGUILayout.ScrollViewScope(scrollPosition))
            {
                scrollPosition = verticalScope.scrollPosition;
                for (int i = 0; i < currentClips.Count; i++)
                {
                    if (currentClips[i] == null)
                        continue;
                    using (var propertyScope = new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
                    {
                        EditorGUILayout.LabelField(CONTENT_NAME, new GUIContent(currentClips[i].name));
                        for (int j = 0; j < currentClips[i].events.Length; j++)
                        {
                            using (var eventScope = new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
                            {
                                var time = TimeSpan.FromSeconds(currentClips[i].events[j].time);
                                var timeString = string.Format("{0:0}:{1:00}", time.Seconds, time.Milliseconds / 1000.0f * 60.0f);
                                EditorGUILayout.LabelField(CONTENT_EVENT_FUNCTION_NAME, new GUIContent(currentClips[i].events[j].functionName));
                                EditorGUILayout.LabelField(CONTENT_EVENT_TIME, new GUIContent(timeString));
                                EditorGUILayout.LabelField(CONTENT_EVENT_PARAMETER_STRING, new GUIContent(currentClips[i].events[j].stringParameter));
                                EditorGUILayout.LabelField(CONTENT_EVENT_PARAMETER_FLOAT, new GUIContent(currentClips[i].events[j].floatParameter.ToString()));
                                EditorGUILayout.LabelField(CONTENT_EVENT_PARAMETER_INT, new GUIContent(currentClips[i].events[j].intParameter.ToString()));
                                currentClips[i].events[j].objectReferenceParameter = EditorGUILayout.ObjectField(CONTENT_EVENT_PARAMETER_OBJECT, currentClips[i].events[j].objectReferenceParameter, typeof(UnityEngine.Object), false);
                            }
                        }
                    }
                }
            }
        }
    }
}