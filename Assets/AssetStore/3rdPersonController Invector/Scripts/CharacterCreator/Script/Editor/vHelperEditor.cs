using UnityEngine;
using UnityEditor;

namespace Invector
{
    class vHelperEditor : EditorWindow
    {
        [MenuItem("Tools/Third Person/Help/Forum")]
        public static void Forum()
        {
            Application.OpenURL("http://invector.proboards.com/");
        }

        [MenuItem("Tools/Third Person/Help/FAQ")]
        public static void FAQMenu()
        {
            Application.OpenURL("http://inv3ctor.wix.com/invector#!faq/cnni7");
        }
       
        [MenuItem("Tools/Third Person/Help/Release Notes")]
        public static void ReleaseNotes()
        {
            Application.OpenURL("http://inv3ctor.wix.com/invector#!release-notes/eax8d");
        }

        [MenuItem("Tools/Third Person/Help/Youtube Tutorials")]
        public static void Youtube()
        {
            Application.OpenURL("https://www.youtube.com/playlist?list=PLvgXGzhT_qehYG_Kzl5P6DuIpHynZP9Ju");
        }

        [MenuItem("Tools/Third Person/Help/Online Documentation")]
        public static void Documentation()
        {
            Application.OpenURL("http://www.invector.xyz/thirdpersondocumentation");
        }       
    }
}