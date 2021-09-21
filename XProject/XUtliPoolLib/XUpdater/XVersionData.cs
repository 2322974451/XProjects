using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using XUtliPoolLib;

namespace XUpdater
{
	// Token: 0x02000009 RID: 9
	[Serializable]
	public class XVersionData : IComparable<XVersionData>
	{
		// Token: 0x06000013 RID: 19 RVA: 0x0000234C File Offset: 0x0000054C
		public XVersionData()
		{
			this._major_version = XUpdater.Major_Version;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000023D4 File Offset: 0x000005D4
		public XVersionData(uint major)
		{
			this._major_version = major;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002455 File Offset: 0x00000655
		public XVersionData(XVersionData rhs) : this()
		{
			this.VersionCopy(rhs);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002468 File Offset: 0x00000668
		public void VersionCopy(XVersionData rhs)
		{
			bool flag = rhs == null;
			if (flag)
			{
				this.Build_Version = 0U;
				this.Minor_Version = 0U;
				this.rc_Build_Version = 0U;
				this.rc_Minor_Version = 0U;
			}
			else
			{
				this.Build_Version = rhs.Build_Version;
				this.Minor_Version = rhs.Minor_Version;
				this.rc_Build_Version = rhs.rc_Build_Version;
				this.rc_Minor_Version = rhs.rc_Minor_Version;
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000024D0 File Offset: 0x000006D0
		public void RC()
		{
			bool hasRCVersion = this.HasRCVersion;
			if (!hasRCVersion)
			{
				this.rc_Build_Version = 1U;
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000024F4 File Offset: 0x000006F4
		public XVersionData Increment(bool rebuild)
		{
			XVersionData xversionData = new XVersionData(this);
			if (rebuild)
			{
				bool hasRCVersion = this.HasRCVersion;
				if (hasRCVersion)
				{
					xversionData.rc_Build_Version += 1U;
					xversionData.rc_Minor_Version = 0U;
				}
				else
				{
					xversionData.Build_Version += 1U;
					xversionData.Minor_Version = 0U;
					xversionData.rc_Build_Version = 0U;
					xversionData.rc_Minor_Version = 0U;
				}
			}
			else
			{
				bool hasRCVersion2 = this.HasRCVersion;
				if (hasRCVersion2)
				{
					xversionData.rc_Minor_Version += 1U;
				}
				else
				{
					xversionData.Minor_Version += 1U;
					xversionData.rc_Build_Version = 0U;
					xversionData.rc_Minor_Version = 0U;
				}
			}
			return xversionData;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000259C File Offset: 0x0000079C
		public override string ToString()
		{
			return this.HasRCVersion ? string.Format("{0}.{1}.{2}.{3}p{4}", new object[]
			{
				this._major_version,
				this.Build_Version,
				this.Minor_Version,
				this.rc_Build_Version,
				this.rc_Minor_Version
			}) : string.Format("{0}.{1}.{2}", this._major_version, this.Build_Version, this.Minor_Version);
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600001A RID: 26 RVA: 0x0000263C File Offset: 0x0000083C
		public bool HasRCVersion
		{
			get
			{
				return this.rc_Build_Version > 0U || this.rc_Minor_Version > 0U;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600001B RID: 27 RVA: 0x00002664 File Offset: 0x00000864
		public bool IsNewly
		{
			get
			{
				return this.Build_Version == 0U && this.Minor_Version == 0U;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001C RID: 28 RVA: 0x0000268C File Offset: 0x0000088C
		public uint Major_Version
		{
			get
			{
				return this._major_version;
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000026A4 File Offset: 0x000008A4
		public static XVersionData Convert2Version(string version)
		{
			Match match = XVersionData.r.Match(version);
			bool success = match.Success;
			XVersionData result;
			if (success)
			{
				XVersionData xversionData = new XVersionData(uint.Parse(match.Groups[1].Value));
				xversionData.Build_Version = uint.Parse(match.Groups[2].Value);
				xversionData.Minor_Version = uint.Parse(match.Groups[3].Value);
				bool flag = !string.IsNullOrEmpty(match.Groups[4].Value);
				if (flag)
				{
					xversionData.rc_Build_Version = uint.Parse(match.Groups[5].Value);
					xversionData.rc_Minor_Version = uint.Parse(match.Groups[6].Value);
				}
				result = xversionData;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002784 File Offset: 0x00000984
		public int CompareTo(XVersionData other)
		{
			bool flag = other == null;
			int result;
			if (flag)
			{
				result = 1;
			}
			else
			{
				bool flag2 = this._major_version == other.Major_Version;
				if (flag2)
				{
					bool flag3 = this.Build_Version == other.Build_Version;
					if (flag3)
					{
						bool flag4 = this.Minor_Version == other.Minor_Version;
						if (flag4)
						{
							bool flag5 = this.rc_Build_Version == other.rc_Build_Version;
							if (flag5)
							{
								bool flag6 = this.rc_Minor_Version == other.rc_Minor_Version;
								if (flag6)
								{
									result = 0;
								}
								else
								{
									result = (int)(this.rc_Minor_Version - other.rc_Minor_Version);
								}
							}
							else
							{
								result = (int)(this.rc_Build_Version - other.rc_Build_Version);
							}
						}
						else
						{
							result = (int)(this.Minor_Version - other.Minor_Version);
						}
					}
					else
					{
						result = (int)(this.Build_Version - other.Build_Version);
					}
				}
				else
				{
					result = (int)(this._major_version - other.Major_Version);
				}
			}
			return result;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002860 File Offset: 0x00000A60
		public bool CanUpdated(XVersionData other)
		{
			bool flag = this._major_version == other.Major_Version;
			if (flag)
			{
				bool flag2 = this.Build_Version == other.Build_Version;
				if (flag2)
				{
					bool flag3 = this.Minor_Version == other.Minor_Version;
					if (!flag3)
					{
						return !this.HasRCVersion && !other.HasRCVersion;
					}
					bool flag4 = this.rc_Build_Version == other.rc_Build_Version;
					if (flag4)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000028E4 File Offset: 0x00000AE4
		public bool NeedDownload(string version)
		{
			XVersionData xversionData = XVersionData.Convert2Version(version);
			bool flag = xversionData == null;
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Error bundle with name ", version, null, null, null, null);
				result = false;
			}
			else
			{
				result = (this.CompareTo(xversionData) < 0);
			}
			return result;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000292C File Offset: 0x00000B2C
		public XBundleData GetSpecificBundle(string name)
		{
			for (int i = 0; i < this.Bundles.Count; i++)
			{
				bool flag = name == this.Bundles[i].Name;
				if (flag)
				{
					return this.Bundles[i];
				}
			}
			return null;
		}

		// Token: 0x0400000E RID: 14
		private static readonly string pattern = "^(\\d+).(\\d+).(\\d+)(.(\\d+)p(\\d+))?\\b";

		// Token: 0x0400000F RID: 15
		private static Regex r = new Regex(XVersionData.pattern);

		// Token: 0x04000010 RID: 16
		private uint _major_version;

		// Token: 0x04000011 RID: 17
		public uint Build_Version = 0U;

		// Token: 0x04000012 RID: 18
		public uint Minor_Version = 0U;

		// Token: 0x04000013 RID: 19
		public uint rc_Build_Version = 0U;

		// Token: 0x04000014 RID: 20
		public uint rc_Minor_Version = 0U;

		// Token: 0x04000015 RID: 21
		public uint MD5_Size = 1048576U;

		// Token: 0x04000016 RID: 22
		public BuildTarget Target_Platform = BuildTarget.Unknown;

		// Token: 0x04000017 RID: 23
		public List<XBundleData> Bundles = new List<XBundleData>();

		// Token: 0x04000018 RID: 24
		public List<XResPackage> Res = new List<XResPackage>();

		// Token: 0x04000019 RID: 25
		public List<XMetaResPackage> AB = new List<XMetaResPackage>();

		// Token: 0x0400001A RID: 26
		public List<XMetaResPackage> Scene = new List<XMetaResPackage>();

		// Token: 0x0400001B RID: 27
		public List<XMetaResPackage> FMOD = new List<XMetaResPackage>();
	}
}
