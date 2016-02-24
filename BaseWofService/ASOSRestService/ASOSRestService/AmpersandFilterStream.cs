using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NCDC.RestService.v1
{
    namespace Filter
    {
        public class AmpersandFilterStream : Stream
        // This filter changes all characters passed through it to uppercase.
        {
            private const string encodedAmpersand = "&amp;";

            private Stream strSink;
            private long lngPosition;
            private bool closeAmpersand = false;

            public AmpersandFilterStream(Stream sink)
            {
                strSink = sink;
            }

            // The following members of Stream must be overriden.
            public override bool CanRead
            {
                get { return strSink.CanRead; }
            }

            public override bool CanSeek
            {
                get { return strSink.CanSeek; }
            }

            public override bool CanWrite
            {
                get { return strSink.CanWrite; }
            }

            public override long Length
            {
                get { return strSink.Length; }
            }

            public override long Position
            {
                get { return strSink.Position; }
                set { strSink.Position = value; }
            }

            public override long Seek(long offset, System.IO.SeekOrigin direction)
            {
                return strSink.Seek(offset, direction);
            }

            public override void SetLength(long length)
            {
                 strSink.SetLength(length);
            }

            public override int ReadTimeout
            {
                get
                {
                    return strSink.ReadTimeout;
                }
                set
                {
                    strSink.ReadTimeout = value;
                }
            }
            public override bool CanTimeout
            {
                get
                {
                    return strSink.CanTimeout;
                }
            }
            public override int WriteTimeout
            {
                get
                {
                    return strSink.WriteTimeout;
                }
                set
                {
                    strSink.WriteTimeout = value;
                }
            }

            public override void Close()
            {
                strSink.Close();
            }

            public override void Flush()
            {
                strSink.Flush();
            }
            public override int ReadByte()
            {
               //return strSink.ReadByte();
                throw new NotSupportedException("NotSupported");
            }
            public override int Read(byte[] buffer, int offset, int count)
            {
                 byte[] data = new byte[count];
                 strSink.Read(data, 0, count);

               // Buffer.BlockCopy(buffer, offset, data, 0, count);
                
                string inputstring = Encoding.UTF8.GetString(data);
                int indexPosition = inputstring.IndexOf("&");
                while (indexPosition > -1)
                {
                    int indexSemicolon = inputstring.IndexOf(";", indexPosition, 6);
                    if (indexSemicolon <= indexPosition)
                    {
                        inputstring.Remove(indexPosition, 1);
                        inputstring.Insert(indexPosition, encodedAmpersand);
                        indexSemicolon = indexPosition + encodedAmpersand.Length;
                    }
                    indexPosition = inputstring.IndexOf("&", indexSemicolon);
                }
               // buffer = Encoding.UTF8.GetBytes(inputstring.);
                 buffer = Encoding.ASCII.GetBytes(inputstring);
                
                return buffer.Length;
            

             //   return strSink.Read(buffer, offset, count);
            }

            // The Write method actually does the filtering.
            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException("Writing not support"); 
                //byte[] data = new byte[count];
                //Buffer.BlockCopy(buffer, offset, data, 0, count);
                //string inputstring = Encoding.ASCII.GetString(data).ToUpper();
                //int indexPosition = inputstring.IndexOf('&');
                //while (indexPosition > -1)
                //{
                //    int indexSemicolon = inputstring.IndexOf(';', indexPosition, 6);
                //    if (indexSemicolon <= indexPosition)
                //    {
                //        inputstring.Remove(indexPosition, 1);
                //        inputstring.Insert(indexPosition, encodedAmpersand);
                //        indexSemicolon = indexPosition + encodedAmpersand.Length;
                //    }
                //    indexPosition = inputstring.IndexOf('&', indexSemicolon);
                //}
                //data = Encoding.ASCII.GetBytes(inputstring);
                //strSink.Write(data, 0, count);

            }


        }
    }
}
