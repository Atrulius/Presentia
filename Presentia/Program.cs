using System;
using System.IO;
using System.Windows.Forms;

namespace Presentia {

    internal static class Program {

        [STAThread]
        static void Main( string[] args ) {

            if( args.Length < 1 )
                return;

            Global.appPath = Path.GetDirectoryName( Application.ExecutablePath );

            Global.Load_Input( args[0] );

            Application.Run( new Form_Main() );
        }
    }
}
