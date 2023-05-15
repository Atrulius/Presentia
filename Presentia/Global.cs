using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Presentia {

    internal class Global {

        public static string path;

        public static string appPath;

        public static List <System.Drawing.Image> images = new List<System.Drawing.Image>();

        public static List <int> times = new List <int>();

        public static byte[] sound_bytes;

        public static MemoryStream mp3Stream;
        public static Mp3FileReader reader;
        public static WaveOutEvent output = new WaveOutEvent();

        public partial class Streams {

            public static string Read_File_to_Base64_String( string The_Path_of_the_File ) {
                byte[] arr_Bytes;
                try {
                    arr_Bytes               = Read_File_to_Byte_Array( The_Path_of_the_File );
                    return Convert.ToBase64String( arr_Bytes );
                } catch( Exception iop ) {
                    throw new Exception( "Error in Read_File_to_Base64_String. " + iop.Message );
                }
            }

            public static void Write_Base64_String_to_File( string The_Path_of_the_File, string The_Base64_String ) {
                byte[] arr_Bytes;
                try {
                    arr_Bytes               = Convert.FromBase64String( The_Base64_String );
                    Write_Byte_Array_to_File( arr_Bytes, The_Path_of_the_File );
                } catch( Exception iop ) {
                    throw new Exception( "Error in Write_Base64_String_to_File. " + iop.Message );
                }
            }

            public static void Write_Byte_Array_to_File( byte[] The_Byte_Array, string The_Filename ) {
                MemoryStream            oMemoryStream;
                FileStream              oFileStream;
                try {
                    oMemoryStream                       = new MemoryStream( The_Byte_Array );
                    oFileStream                         = new FileStream( The_Filename, FileMode.Create );
                    oMemoryStream.WriteTo( oFileStream );
                    try {
                        oMemoryStream.Close();
                    } catch { }
                    try {
                        oFileStream.Close();
                    } catch { }
                    oFileStream                         = null;
                    oMemoryStream                       = null;
                } catch( Exception iop ) {
                    throw new Exception( "Error in Write_Byte_Array_to_File. " + iop.Message );
                }
            }

            public static byte[] Read_File_to_Byte_Array( string The_Path_of_the_File ) {
                FileStream      oFileStream;
                if( !File.Exists( The_Path_of_the_File ) ) {
                    throw new Exception( "The file does not exist." );
                }
                try {
                    oFileStream                 = File.OpenRead( The_Path_of_the_File );
                    return Convert_Stream_to_Byte_Array( oFileStream );
                } catch( Exception iop ) {
                    throw new Exception( "Error in Read_File_to_Byte_Array. " + iop.Message );
                }
            }

            public static byte[] Convert_Stream_to_Byte_Array( System.IO.Stream The_Stream_to_Convert ) {
                System.IO.MemoryStream      oStreamTemp;
                int                         arrBytes;
                try {
                    oStreamTemp                 = new System.IO.MemoryStream();
                    while( (arrBytes = The_Stream_to_Convert.ReadByte()) != -1 ) {
                        oStreamTemp.WriteByte( ((byte)arrBytes) );
                    }
                    return oStreamTemp.ToArray();
                } catch( Exception iop ) {
                    throw new Exception( "Error in Convert_Stream_to_Byte_Array. " + iop.Message );
                }
            }

            public static MemoryStream Convert_Byte_Array_to_Memory_Stream( byte[] The_Byte_Array ) {
                try {
                    return new MemoryStream( The_Byte_Array );
                } catch( Exception iop ) {
                    throw new Exception( "Error in Convert_Byte_Array_to_Memory_Stream. " + iop.Message );
                }
            }
        }

        public static void Write_a_String_to_a_File( string The_Path_of_the_File, string The_Text ) {
            Write_a_String_to_a_File( The_Path_of_the_File, The_Text, true, System.Text.Encoding.UTF8, null );
        }

        public static void Write_a_String_to_a_File( string The_Path_of_the_File, string The_Text, bool DoAppend ) {
            Write_a_String_to_a_File( The_Path_of_the_File, The_Text, DoAppend, System.Text.Encoding.UTF8, null );
        }

        public static void Write_a_String_to_a_File( string The_Path_of_the_File, string The_Text, bool DoAppend, System.Text.Encoding The_Encoding ) {
            Write_a_String_to_a_File( The_Path_of_the_File, The_Text, DoAppend, The_Encoding, null );
        }

        private static void Write_a_String_to_a_File( string The_Path_of_the_File, string The_Text, bool Do_Append, System.Text.Encoding The_Encoding, object TheDummy ) {
            StreamWriter sw = null;
            try {
                if( !Do_Append ) {
                    if( File.Exists( The_Path_of_the_File ) ) {
                        try {
                            File.Delete( The_Path_of_the_File );
                        } catch( Exception iop ) {
                            throw new Exception( "Could not delete the file '" + The_Path_of_the_File + "'. " + iop.Message );
                        }
                    }
                }
                sw = new StreamWriter( The_Path_of_the_File, true, The_Encoding );
                sw.Write( The_Text );
            } catch( Exception iop ) {
                throw new Exception( "Could not write string to the file '" + The_Path_of_the_File + "'. " + iop.Message );
            } finally {
                try {
                    sw.Flush();
                } catch {
                }
                try {
                    sw.Close();
                } catch {
                }
            }
        }

        public static string Read_File_to_String( string The_Path_of_File ) {
            StreamReader    oStreamReader   = null;
            FileStream      oFileStream     = null;
            StringBuilder   oStringBuilder;
            string          sTemp;
            bool            bFirstLine      = true;
            try {
                oFileStream                 = new FileStream( The_Path_of_File, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 32768, FileOptions.None );
                oStreamReader               = new StreamReader( oFileStream, Encoding.Default );
                oStringBuilder              = new StringBuilder();
                sTemp                       = String.Empty;
                while( (sTemp = oStreamReader.ReadLine()) != null ) {
                    if( !bFirstLine ) {
                        oStringBuilder.Append( "\r\n" + sTemp );
                    } else {
                        bFirstLine          = false;
                        oStringBuilder.Append( sTemp );
                    }
                }
                return oStringBuilder.ToString();
            } catch( Exception iop ) {
                throw new Exception( "Could not read file '" + Path.GetFileName( The_Path_of_File ) + "'. " + iop.Message );
            } finally {
                try {
                    oFileStream.Flush();
                } catch { }
                try {
                    oFileStream.Close();
                } catch { }
                try {
                    oStreamReader.Close();
                } catch { }
                try {
                    oStreamReader.Dispose();
                } catch { }
            }
        }



        public static void Load_Input( string arg ) {

            path = arg;

            string json_text = File.ReadAllText(path);

            Video presentation = JsonConvert.DeserializeObject<Video>( json_text );

            Load_Images( presentation );
            Load_Sound( presentation );
        }

        public static void Load_Images( Video presentation ) {

            foreach ( Video.Image image in presentation.Images ) {

                MemoryStream ms = new MemoryStream(image.Drawing);
                images.Add( System.Drawing.Image.FromStream( ms ) );
            }
            foreach ( Video.Image image in presentation.Images ) {

                times.Add(image.Time);
            }
        }

        public static void Load_Sound( Video presentation ) {

            sound_bytes = presentation.Sound;

            mp3Stream = new MemoryStream(sound_bytes);
            reader = new Mp3FileReader(mp3Stream);
            output.Init(reader);
        }

        public static string Time_Format( int Seconds ) {

            int Minutes = (int)Math.Floor((float)Seconds / 60);
            int Hours = (int)Math.Floor((float)Minutes / 60);

            Minutes %= 60;
            Hours %= 60;

            string output = "";

            if (Hours > 0) {

                if (Hours < 10) {
                    output += "0";
                }
                output += Hours.ToString() + ":";
            }

            if (Minutes < 10) {
                output += "0";
            }
            output += Minutes.ToString() + ":";

            if (Seconds < 10) {
                output += "0";
            }
            output += Seconds.ToString();

            return output;
        }
    }
}
