using System.Runtime.InteropServices;

namespace WWE_SmackDown_Shut_Your_Mouth_EU
{

    public static class CheckSumUtility
    {
        public unsafe static void MakeSaveFileValid(string input= "BESLES-51283SD4", string output= "Valid-BESLES-51283SD4")
        {

            byte[] filebuffor = File.ReadAllBytes(input);

            fixed (byte* fileStart = filebuffor)
            {
                CheckSumUtility.MakeVertCheckSum(new IntPtr((uint)fileStart + 0x10), filebuffor.Length - 0x10, new IntPtr(fileStart), 0x10);
            }

            File.WriteAllBytes(output, filebuffor);
        }

        private unsafe static byte* MakeVertCheckSum(IntPtr FileBuffor, int FileSize, IntPtr CRCBuffor, int CrcSize)
        {
            byte* pvVar1;
            int iVar2;
            IntPtr pcVar3;
            int iVar4;
            IntPtr pcVar5;
            int iVar6;

            pvVar1 = (byte*)CRCBuffor.ToPointer();
            for (int i = 0; i < 0x10; i++)
                pvVar1[i] = 0x0;

            iVar2 = 0;
            if (FileSize > 0)
            {
                iVar6 = (int)CrcSize;
                if (FileSize > 8)
                {
                    do
                    {
                        pcVar3 = (IntPtr)(FileBuffor + iVar2);
                        if (CrcSize == 0)
                        {
                            throw new Exception("Trap(7) exception or error handling");
                        }
                        pcVar5 = (IntPtr)((int)CRCBuffor + iVar2 % iVar6);
                        Marshal.WriteByte(pcVar5, (byte)(Marshal.ReadByte(pcVar5) + Marshal.ReadByte(pcVar3)));
                        if (CrcSize == 0)
                        {
                            throw new Exception("Trap(7) exception or error handling");
                        }
                        pcVar5 = (IntPtr)((int)CRCBuffor + (iVar2 + 1) % iVar6);
                        Marshal.WriteByte(pcVar5, (byte)(Marshal.ReadByte(pcVar5) + Marshal.ReadByte(pcVar3, 1)));
                        if (CrcSize == 0)
                        {
                            throw new Exception("Trap(7) exception or error handling");
                        }
                        pcVar5 = (IntPtr)((int)CRCBuffor + (iVar2 + 2) % iVar6);
                        Marshal.WriteByte(pcVar5, (byte)(Marshal.ReadByte(pcVar5) + Marshal.ReadByte(pcVar3, 2)));
                        if (CrcSize == 0)
                        {
                            throw new Exception("Trap(7) exception or error handling");
                        }
                        pcVar5 = (IntPtr)((int)CRCBuffor + (iVar2 + 3) % iVar6);
                        Marshal.WriteByte(pcVar5, (byte)(Marshal.ReadByte(pcVar5) + Marshal.ReadByte(pcVar3, 3)));
                        if (CrcSize == 0)
                        {
                            throw new Exception("Trap(7) exception or error handling");
                        }
                        pcVar5 = (IntPtr)((int)CRCBuffor + (iVar2 + 4) % iVar6);
                        Marshal.WriteByte(pcVar5, (byte)(Marshal.ReadByte(pcVar5) + Marshal.ReadByte(pcVar3, 4)));
                        if (CrcSize == 0)
                        {
                            throw new Exception("Trap(7) exception or error handling");
                        }
                        pcVar5 = (IntPtr)((int)CRCBuffor + (iVar2 + 5) % iVar6);
                        Marshal.WriteByte(pcVar5, (byte)(Marshal.ReadByte(pcVar5) + Marshal.ReadByte(pcVar3, 5)));
                        if (CrcSize == 0)
                        {
                            throw new Exception("Trap(7) exception or error handling");
                        }
                        iVar4 = iVar2 + 7;
                        pcVar5 = (IntPtr)((int)CRCBuffor + (iVar2 + 6) % iVar6);
                        Marshal.WriteByte(pcVar5, (byte)(Marshal.ReadByte(pcVar5) + Marshal.ReadByte(pcVar3, 6)));
                        if (CrcSize == 0)
                        {
                            throw new Exception("Trap(7) exception or error handling");
                        }
                        iVar2 += 8;
                        pcVar5 = (IntPtr)((int)CRCBuffor + iVar4 % iVar6);
                        Marshal.WriteByte(pcVar5, (byte)(Marshal.ReadByte(pcVar5) + Marshal.ReadByte(pcVar3, 7)));

                    } while (iVar2 < FileSize - 8);
                }
                for (; iVar2 < FileSize; iVar2++)
                {
                    if (CrcSize == 0)
                    {
                        throw new Exception("Trap(7) exception or error handling");
                    }
                    pcVar3 = (IntPtr)((int)CRCBuffor + iVar2 % iVar6);
                    Marshal.WriteByte(pcVar3, (byte)(Marshal.ReadByte(pcVar3) + Marshal.ReadByte((IntPtr)(FileBuffor + iVar2))));
                }
            }
            return pvVar1;
        }
    }
}