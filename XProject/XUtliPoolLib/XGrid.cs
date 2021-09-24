

using System.IO;
using UnityEngine;

namespace XUtliPoolLib
{
    public sealed class XGrid
    {
        public int Width;
        public int Height;
        public float XMin;
        public float ZMin;
        public float XMax;
        public float ZMax;
        public float Side;
        public int[] IdxData = (int[])null;
        public float[] ValueData = (float[])null;

        public bool LoadFile(string FileName)
        {
            XBinaryReader reader = XSingleton<XResourceLoaderMgr>.singleton.ReadBinary(FileName, ".bytes", false);
            try
            {
                this.Height = reader.ReadInt32();
                this.Width = reader.ReadInt32();
                this.XMin = reader.ReadSingle();
                this.ZMin = reader.ReadSingle();
                this.XMax = reader.ReadSingle();
                this.ZMax = reader.ReadSingle();
                this.Side = reader.ReadSingle();
                int length = reader.ReadInt32();
                this.IdxData = new int[length];
                for (int index = 0; index < length; ++index)
                    this.IdxData[index] = reader.ReadInt32();
                this.ValueData = new float[length];
                for (int index = 0; index < length; ++index)
                {
                    short num1 = reader.ReadInt16();
                    if (num1 < (short)0)
                    {
                        this.ValueData[index] = -100f;
                        if (index + 1 < length)
                        {
                            short num2 = num1 != short.MinValue ? (short)-num1 : (short)0;
                            this.ValueData[index + 1] = (float)num2;
                            ++index;
                        }
                    }
                    else
                        this.ValueData[index] = (float)num1;
                }
            }
            catch (EndOfStreamException ex)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("read file ", FileName, " not complete :", ex.Message);
                return false;
            }
            finally
            {
                XSingleton<XResourceLoaderMgr>.singleton.ClearBinary(reader, false);
            }
            return true;
        }

        public bool TryGetHeight(Vector3 pos, out float y)
        {
            y = 0.0f;
            int index = this.GetIndex((int)(((double)pos.z - (double)this.ZMin) / (double)this.Side) * this.Width + (int)(((double)pos.x - (double)this.XMin) / (double)this.Side));
            if (index < 0 || index >= this.ValueData.Length)
                return false;
            y = this.ValueData[index] / 100f;
            return true;
        }

        public float GetHeight(Vector3 pos)
        {
            int index = this.GetIndex((int)(((double)pos.z - (double)this.ZMin) / (double)this.Side) * this.Width + (int)(((double)pos.x - (double)this.XMin) / (double)this.Side));
            if (index >= 0 && index < this.ValueData.Length)
                return this.ValueData[index] / 100f;
            XSingleton<XDebug>.singleton.AddErrorLog2("error grid index:{0} pos:{1}", (object)index, (object)pos);
            return -1f;
        }

        private int GetIndex(int key)
        {
            int length = this.IdxData.Length;
            int num1 = 0;
            int num2 = length - 1;
            while (num1 <= num2)
            {
                int index = num1 + num2 >> 1;
                int num3 = this.IdxData[index];
                if (key == num3)
                    return index;
                if (key < num3)
                    num2 = index - 1;
                else if (key > num3)
                    num1 = index + 1;
            }
            return num2;
        }

        public void Update()
        {
        }
    }
}
