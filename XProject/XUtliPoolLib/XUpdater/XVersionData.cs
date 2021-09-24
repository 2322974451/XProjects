using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using XUtliPoolLib;

namespace XUpdater
{

	[Serializable]
	public class XVersionData : IComparable<XVersionData>
	{

		public XVersionData()
		{
			this._major_version = XUpdater.Major_Version;
		}

		public XVersionData(uint major)
		{
			this._major_version = major;
		}

		public XVersionData(XVersionData rhs) : this()
		{
			this.VersionCopy(rhs);
		}

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

		public void RC()
		{
			bool hasRCVersion = this.HasRCVersion;
			if (!hasRCVersion)
			{
				this.rc_Build_Version = 1U;
			}
		}

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

		public bool HasRCVersion
		{
			get
			{
				return this.rc_Build_Version > 0U || this.rc_Minor_Version > 0U;
			}
		}

		public bool IsNewly
		{
			get
			{
				return this.Build_Version == 0U && this.Minor_Version == 0U;
			}
		}

		public uint Major_Version
		{
			get
			{
				return this._major_version;
			}
		}

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

		private static readonly string pattern = "^(\\d+).(\\d+).(\\d+)(.(\\d+)p(\\d+))?\\b";

		private static Regex r = new Regex(XVersionData.pattern);

		private uint _major_version;

		public uint Build_Version = 0U;

		public uint Minor_Version = 0U;

		public uint rc_Build_Version = 0U;

		public uint rc_Minor_Version = 0U;

		public uint MD5_Size = 1048576U;

		public BuildTarget Target_Platform = BuildTarget.Unknown;

		public List<XBundleData> Bundles = new List<XBundleData>();

		public List<XResPackage> Res = new List<XResPackage>();

		public List<XMetaResPackage> AB = new List<XMetaResPackage>();

		public List<XMetaResPackage> Scene = new List<XMetaResPackage>();

		public List<XMetaResPackage> FMOD = new List<XMetaResPackage>();
	}
}
