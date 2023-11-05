using System;
using System.Runtime.InteropServices;

namespace Project_Zero_EU
{

    public static class CheckSumUtility
    {
        public unsafe static void MakeSaveFileValid(string input= "BESLES-50821zero0", string output= "BESLES-50821zero0")
        {

            byte[] filebuffor = File.ReadAllBytes(input);

            fixed (byte* fileStart = filebuffor)
            {
                CheckSumUtility.MakeVertCheckSum(fileStart, filebuffor.Length);
            }

            File.WriteAllBytes(output, filebuffor);
        }

        private unsafe static void MakeVertCheckSum(byte* data_ptr, int data_size)
        {
            byte bVar1;
            int iVar2;
            byte* pbVar3;
            int iVar4;

            iVar4 = data_size + -0x10;
            iVar2 = 0;
            pbVar3 = data_ptr + 0x10;
            if (0 < iVar4)
            {
                do
                {
                    bVar1 = *pbVar3;
                    iVar4 = iVar4 + -1;
                    pbVar3 = pbVar3 + 1;
                    iVar2 = (int)(iVar2 + (uint)bVar1);
                } while (iVar4 != 0);
            }
            *(int*)data_ptr = iVar2;
        }
    }
}