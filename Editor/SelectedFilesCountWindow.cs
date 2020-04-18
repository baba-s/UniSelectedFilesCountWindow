using UnityEditor;
using UnityEngine;

namespace UniSelectedFilesCountWindow
{
	internal sealed class SelectedFilesCountWindow : EditorWindow
	{
		private int m_count;

		[MenuItem( "Window/UniSelectedFilesCountWindow" )]
		private static void Init()
		{
			var win = GetWindow<SelectedFilesCountWindow>( "UniSelectedFilesCountWindow" );
			win.minSize = new Vector2( 32, 16 );
		}

		private void OnEnable()
		{
			Selection.selectionChanged += OnChanged;
		}

		private void OnDisable()
		{
			Selection.selectionChanged -= OnChanged;
		}

		private void OnChanged()
		{
			m_count = Selection.objects.Length;
			Repaint();
		}

		private void OnGUI()
		{
			GUILayout.Label( $"Selected Files: {m_count.ToString()}" );
		}
	}
}