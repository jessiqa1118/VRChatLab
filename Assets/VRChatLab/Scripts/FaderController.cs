using System.Collections;
using System.Collections.Generic;

namespace FaderController
{
    public class Fader
    {
        byte statusByte;
        byte[] dataByte;

        public Fader(byte statusByte, byte firstDataByte, byte secondDataByte)
        {
            this.statusByte = statusByte;
            this.dataByte = new byte[2];
            this.dataByte[0] = firstDataByte;
            this.dataByte[1] = secondDataByte;
        }
    }
}