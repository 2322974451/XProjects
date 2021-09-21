using System;
using System.IO;
using System.Text;

namespace XUtliPoolLib
{
	// Token: 0x020001E4 RID: 484
	public class XFile
	{
		// Token: 0x06000B05 RID: 2821 RVA: 0x0003AB68 File Offset: 0x00038D68
		public static void AppendAllText(string path, string contents)
		{
			File.AppendAllText(path, contents);
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x0003AB73 File Offset: 0x00038D73
		public static void AppendAllText(string path, string contents, Encoding encoding)
		{
			File.AppendAllText(path, contents, encoding);
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x0003AB80 File Offset: 0x00038D80
		public static StreamWriter AppendText(string path)
		{
			return File.AppendText(path);
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x0003AB98 File Offset: 0x00038D98
		public static void Copy(string sourceFileName, string destFileName)
		{
			File.Copy(sourceFileName, destFileName);
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x0003ABA3 File Offset: 0x00038DA3
		public static void Copy(string sourceFileName, string destFileName, bool overwrite)
		{
			File.Copy(sourceFileName, destFileName, overwrite);
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x0003ABB0 File Offset: 0x00038DB0
		public static FileStream Create(string path)
		{
			return File.Create(path);
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x0003ABC8 File Offset: 0x00038DC8
		public static FileStream Create(string path, int bufferSize)
		{
			return File.Create(path, bufferSize);
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x0003ABE4 File Offset: 0x00038DE4
		public static StreamWriter CreateText(string path)
		{
			return File.CreateText(path);
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x0003ABFC File Offset: 0x00038DFC
		public static void Decrypt(string path)
		{
			File.Decrypt(path);
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x0003AC06 File Offset: 0x00038E06
		public static void Delete(string path)
		{
			File.Delete(path);
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x0003AC10 File Offset: 0x00038E10
		public static void Encrypt(string path)
		{
			File.Encrypt(path);
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x0003AC1C File Offset: 0x00038E1C
		public static bool Exists(string path)
		{
			return File.Exists(path);
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x0003AC34 File Offset: 0x00038E34
		public static FileAttributes GetAttributes(string path)
		{
			return File.GetAttributes(path);
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x0003AC4C File Offset: 0x00038E4C
		public static DateTime GetCreationTime(string path)
		{
			return File.GetCreationTime(path);
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x0003AC64 File Offset: 0x00038E64
		public static DateTime GetCreationTimeUtc(string path)
		{
			return File.GetCreationTimeUtc(path);
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x0003AC7C File Offset: 0x00038E7C
		public static DateTime GetLastAccessTime(string path)
		{
			return File.GetLastAccessTime(path);
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x0003AC94 File Offset: 0x00038E94
		public static DateTime GetLastWriteTime(string path)
		{
			return File.GetLastWriteTime(path);
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x0003ACAC File Offset: 0x00038EAC
		public static DateTime GetLastWriteTimeUtc(string path)
		{
			return File.GetLastWriteTimeUtc(path);
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x0003ACC4 File Offset: 0x00038EC4
		public static void Move(string sourceFileName, string destFileName)
		{
			File.Move(sourceFileName, destFileName);
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x0003ACD0 File Offset: 0x00038ED0
		public static FileStream Open(string path, FileMode mode)
		{
			return File.Open(path, mode);
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x0003ACEC File Offset: 0x00038EEC
		public static FileStream OpenRead(string path)
		{
			return File.OpenRead(path);
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x0003AD04 File Offset: 0x00038F04
		public static StreamReader OpenText(string path)
		{
			return File.OpenText(path);
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x0003AD1C File Offset: 0x00038F1C
		public static FileStream OpenWrite(string path)
		{
			return File.OpenWrite(path);
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x0003AD34 File Offset: 0x00038F34
		public static byte[] ReadAllBytes(string path)
		{
			return File.ReadAllBytes(path);
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x0003AD4C File Offset: 0x00038F4C
		public static string[] ReadAllLines(string path)
		{
			return File.ReadAllLines(path);
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x0003AD64 File Offset: 0x00038F64
		public static string[] ReadAllLines(string path, Encoding encoding)
		{
			return File.ReadAllLines(path, encoding);
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x0003AD80 File Offset: 0x00038F80
		public static string ReadAllText(string path)
		{
			return File.ReadAllText(path);
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0003AD98 File Offset: 0x00038F98
		public static string ReadAllText(string path, Encoding encoding)
		{
			return File.ReadAllText(path, encoding);
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x0003ADB1 File Offset: 0x00038FB1
		public static void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName)
		{
			File.Replace(sourceFileName, destinationFileName, destinationBackupFileName);
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x0003ADBD File Offset: 0x00038FBD
		public static void WriteAllBytes(string path, byte[] bytes)
		{
			File.WriteAllBytes(path, bytes);
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x0003ADC8 File Offset: 0x00038FC8
		public static void WriteAllLines(string path, string[] contents)
		{
			File.WriteAllLines(path, contents);
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x0003ADD3 File Offset: 0x00038FD3
		public static void WriteAllLines(string path, string[] contents, Encoding encoding)
		{
			File.WriteAllLines(path, contents, encoding);
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x0003ADDF File Offset: 0x00038FDF
		public static void WriteAllText(string path, string contents)
		{
			File.WriteAllText(path, contents);
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x0003ADEA File Offset: 0x00038FEA
		public static void WriteAllText(string path, string contents, Encoding encoding)
		{
			File.WriteAllText(path, contents, encoding);
		}
	}
}
