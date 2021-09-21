using System;
using System.IO;

namespace XUtliPoolLib
{
	// Token: 0x020001E5 RID: 485
	public class XDirectory
	{
		// Token: 0x06000B28 RID: 2856 RVA: 0x0003ADF8 File Offset: 0x00038FF8
		public static DirectoryInfo CreateDirectory(string path)
		{
			return Directory.CreateDirectory(path);
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x0003AE10 File Offset: 0x00039010
		public static void Delete(string path)
		{
			Directory.Delete(path);
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x0003AE1C File Offset: 0x0003901C
		public static bool Exists(string path)
		{
			return Directory.Exists(path);
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x0003AE34 File Offset: 0x00039034
		public static DateTime GetCreationTime(string path)
		{
			return Directory.GetCreationTime(path);
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x0003AE4C File Offset: 0x0003904C
		public static string GetCurrentDirectory()
		{
			return Directory.GetCurrentDirectory();
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x0003AE64 File Offset: 0x00039064
		public static string[] GetDirectories(string path)
		{
			return Directory.GetDirectories(path);
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x0003AE7C File Offset: 0x0003907C
		public static string[] GetDirectories(string path, string searchPattern)
		{
			return Directory.GetDirectories(path, searchPattern);
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x0003AE98 File Offset: 0x00039098
		public static string[] GetDirectories(string path, string searchPattern, SearchOption searchOption)
		{
			return Directory.GetDirectories(path, searchPattern, searchOption);
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x0003AEB4 File Offset: 0x000390B4
		public static string GetDirectoryRoot(string path)
		{
			return Directory.GetDirectoryRoot(path);
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x0003AECC File Offset: 0x000390CC
		public static string[] GetFiles(string path)
		{
			return Directory.GetFiles(path);
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x0003AEE4 File Offset: 0x000390E4
		public static string[] GetFiles(string path, string searchPattern)
		{
			return Directory.GetFiles(path, searchPattern);
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x0003AF00 File Offset: 0x00039100
		public static string[] GetFileSystemEntries(string path)
		{
			return Directory.GetFileSystemEntries(path);
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x0003AF18 File Offset: 0x00039118
		public static string[] GetFileSystemEntries(string path, string searchPattern)
		{
			return Directory.GetFileSystemEntries(path, searchPattern);
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x0003AF34 File Offset: 0x00039134
		public static DirectoryInfo GetParent(string path)
		{
			return Directory.GetParent(path);
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x0003AF4C File Offset: 0x0003914C
		public static void Move(string sourceDirName, string destDirName)
		{
			Directory.Move(sourceDirName, destDirName);
		}
	}
}
