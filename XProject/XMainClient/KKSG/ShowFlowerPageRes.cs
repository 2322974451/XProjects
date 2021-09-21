using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000081 RID: 129
	[ProtoContract(Name = "ShowFlowerPageRes")]
	[Serializable]
	public class ShowFlowerPageRes : IExtensible
	{
		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06000857 RID: 2135 RVA: 0x00012870 File Offset: 0x00010A70
		// (set) Token: 0x06000858 RID: 2136 RVA: 0x0001289C File Offset: 0x00010A9C
		[ProtoMember(1, IsRequired = false, Name = "allcount", DataFormat = DataFormat.TwosComplement)]
		public uint allcount
		{
			get
			{
				return this._allcount ?? 0U;
			}
			set
			{
				this._allcount = new uint?(value);
			}
		}

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06000859 RID: 2137 RVA: 0x000128AC File Offset: 0x00010AAC
		// (set) Token: 0x0600085A RID: 2138 RVA: 0x000128CC File Offset: 0x00010ACC
		[XmlIgnore]
		[Browsable(false)]
		public bool allcountSpecified
		{
			get
			{
				return this._allcount != null;
			}
			set
			{
				bool flag = value == (this._allcount == null);
				if (flag)
				{
					this._allcount = (value ? new uint?(this.allcount) : null);
				}
			}
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x00012910 File Offset: 0x00010B10
		private bool ShouldSerializeallcount()
		{
			return this.allcountSpecified;
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x00012928 File Offset: 0x00010B28
		private void Resetallcount()
		{
			this.allcountSpecified = false;
		}

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x0600085D RID: 2141 RVA: 0x00012934 File Offset: 0x00010B34
		// (set) Token: 0x0600085E RID: 2142 RVA: 0x00012960 File Offset: 0x00010B60
		[ProtoMember(2, IsRequired = false, Name = "weekcount", DataFormat = DataFormat.TwosComplement)]
		public uint weekcount
		{
			get
			{
				return this._weekcount ?? 0U;
			}
			set
			{
				this._weekcount = new uint?(value);
			}
		}

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x0600085F RID: 2143 RVA: 0x00012970 File Offset: 0x00010B70
		// (set) Token: 0x06000860 RID: 2144 RVA: 0x00012990 File Offset: 0x00010B90
		[XmlIgnore]
		[Browsable(false)]
		public bool weekcountSpecified
		{
			get
			{
				return this._weekcount != null;
			}
			set
			{
				bool flag = value == (this._weekcount == null);
				if (flag)
				{
					this._weekcount = (value ? new uint?(this.weekcount) : null);
				}
			}
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x000129D4 File Offset: 0x00010BD4
		private bool ShouldSerializeweekcount()
		{
			return this.weekcountSpecified;
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x000129EC File Offset: 0x00010BEC
		private void Resetweekcount()
		{
			this.weekcountSpecified = false;
		}

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x06000863 RID: 2147 RVA: 0x000129F8 File Offset: 0x00010BF8
		// (set) Token: 0x06000864 RID: 2148 RVA: 0x00012A24 File Offset: 0x00010C24
		[ProtoMember(3, IsRequired = false, Name = "weekrank", DataFormat = DataFormat.TwosComplement)]
		public uint weekrank
		{
			get
			{
				return this._weekrank ?? 0U;
			}
			set
			{
				this._weekrank = new uint?(value);
			}
		}

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x06000865 RID: 2149 RVA: 0x00012A34 File Offset: 0x00010C34
		// (set) Token: 0x06000866 RID: 2150 RVA: 0x00012A54 File Offset: 0x00010C54
		[XmlIgnore]
		[Browsable(false)]
		public bool weekrankSpecified
		{
			get
			{
				return this._weekrank != null;
			}
			set
			{
				bool flag = value == (this._weekrank == null);
				if (flag)
				{
					this._weekrank = (value ? new uint?(this.weekrank) : null);
				}
			}
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x00012A98 File Offset: 0x00010C98
		private bool ShouldSerializeweekrank()
		{
			return this.weekrankSpecified;
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x00012AB0 File Offset: 0x00010CB0
		private void Resetweekrank()
		{
			this.weekrankSpecified = false;
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x06000869 RID: 2153 RVA: 0x00012ABC File Offset: 0x00010CBC
		// (set) Token: 0x0600086A RID: 2154 RVA: 0x00012AE8 File Offset: 0x00010CE8
		[ProtoMember(4, IsRequired = false, Name = "cansendcount", DataFormat = DataFormat.TwosComplement)]
		public uint cansendcount
		{
			get
			{
				return this._cansendcount ?? 0U;
			}
			set
			{
				this._cansendcount = new uint?(value);
			}
		}

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x0600086B RID: 2155 RVA: 0x00012AF8 File Offset: 0x00010CF8
		// (set) Token: 0x0600086C RID: 2156 RVA: 0x00012B18 File Offset: 0x00010D18
		[XmlIgnore]
		[Browsable(false)]
		public bool cansendcountSpecified
		{
			get
			{
				return this._cansendcount != null;
			}
			set
			{
				bool flag = value == (this._cansendcount == null);
				if (flag)
				{
					this._cansendcount = (value ? new uint?(this.cansendcount) : null);
				}
			}
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x00012B5C File Offset: 0x00010D5C
		private bool ShouldSerializecansendcount()
		{
			return this.cansendcountSpecified;
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x00012B74 File Offset: 0x00010D74
		private void Resetcansendcount()
		{
			this.cansendcountSpecified = false;
		}

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x0600086F RID: 2159 RVA: 0x00012B80 File Offset: 0x00010D80
		[ProtoMember(5, Name = "cansendstate", DataFormat = DataFormat.TwosComplement)]
		public List<uint> cansendstate
		{
			get
			{
				return this._cansendstate;
			}
		}

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x06000870 RID: 2160 RVA: 0x00012B98 File Offset: 0x00010D98
		[ProtoMember(6, Name = "recordroleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> recordroleid
		{
			get
			{
				return this._recordroleid;
			}
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06000871 RID: 2161 RVA: 0x00012BB0 File Offset: 0x00010DB0
		[ProtoMember(7, Name = "recordcount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> recordcount
		{
			get
			{
				return this._recordcount;
			}
		}

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06000872 RID: 2162 RVA: 0x00012BC8 File Offset: 0x00010DC8
		[ProtoMember(8, Name = "recordtime", DataFormat = DataFormat.TwosComplement)]
		public List<uint> recordtime
		{
			get
			{
				return this._recordtime;
			}
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06000873 RID: 2163 RVA: 0x00012BE0 File Offset: 0x00010DE0
		[ProtoMember(9, Name = "recordname", DataFormat = DataFormat.Default)]
		public List<string> recordname
		{
			get
			{
				return this._recordname;
			}
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x06000874 RID: 2164 RVA: 0x00012BF8 File Offset: 0x00010DF8
		// (set) Token: 0x06000875 RID: 2165 RVA: 0x00012C19 File Offset: 0x00010E19
		[ProtoMember(10, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x06000876 RID: 2166 RVA: 0x00012C24 File Offset: 0x00010E24
		// (set) Token: 0x06000877 RID: 2167 RVA: 0x00012C40 File Offset: 0x00010E40
		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x00012C70 File Offset: 0x00010E70
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x00012C88 File Offset: 0x00010E88
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x0600087A RID: 2170 RVA: 0x00012C94 File Offset: 0x00010E94
		// (set) Token: 0x0600087B RID: 2171 RVA: 0x00012CC0 File Offset: 0x00010EC0
		[ProtoMember(11, IsRequired = false, Name = "roleprofession", DataFormat = DataFormat.TwosComplement)]
		public uint roleprofession
		{
			get
			{
				return this._roleprofession ?? 0U;
			}
			set
			{
				this._roleprofession = new uint?(value);
			}
		}

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x0600087C RID: 2172 RVA: 0x00012CD0 File Offset: 0x00010ED0
		// (set) Token: 0x0600087D RID: 2173 RVA: 0x00012CF0 File Offset: 0x00010EF0
		[XmlIgnore]
		[Browsable(false)]
		public bool roleprofessionSpecified
		{
			get
			{
				return this._roleprofession != null;
			}
			set
			{
				bool flag = value == (this._roleprofession == null);
				if (flag)
				{
					this._roleprofession = (value ? new uint?(this.roleprofession) : null);
				}
			}
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x00012D34 File Offset: 0x00010F34
		private bool ShouldSerializeroleprofession()
		{
			return this.roleprofessionSpecified;
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x00012D4C File Offset: 0x00010F4C
		private void Resetroleprofession()
		{
			this.roleprofessionSpecified = false;
		}

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x06000880 RID: 2176 RVA: 0x00012D58 File Offset: 0x00010F58
		[ProtoMember(12, Name = "otherroleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> otherroleid
		{
			get
			{
				return this._otherroleid;
			}
		}

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x06000881 RID: 2177 RVA: 0x00012D70 File Offset: 0x00010F70
		[ProtoMember(13, Name = "othername", DataFormat = DataFormat.Default)]
		public List<string> othername
		{
			get
			{
				return this._othername;
			}
		}

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06000882 RID: 2178 RVA: 0x00012D88 File Offset: 0x00010F88
		[ProtoMember(14, Name = "othercount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> othercount
		{
			get
			{
				return this._othercount;
			}
		}

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000883 RID: 2179 RVA: 0x00012DA0 File Offset: 0x00010FA0
		[ProtoMember(15, Name = "otherprofession", DataFormat = DataFormat.TwosComplement)]
		public List<uint> otherprofession
		{
			get
			{
				return this._otherprofession;
			}
		}

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000884 RID: 2180 RVA: 0x00012DB8 File Offset: 0x00010FB8
		[ProtoMember(16, Name = "updegreelevel", DataFormat = DataFormat.TwosComplement)]
		public List<uint> updegreelevel
		{
			get
			{
				return this._updegreelevel;
			}
		}

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000885 RID: 2181 RVA: 0x00012DD0 File Offset: 0x00010FD0
		[ProtoMember(17, Name = "sendFlowersTotal", DataFormat = DataFormat.Default)]
		public List<MapIntItem> sendFlowersTotal
		{
			get
			{
				return this._sendFlowersTotal;
			}
		}

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06000886 RID: 2182 RVA: 0x00012DE8 File Offset: 0x00010FE8
		[ProtoMember(18, Name = "sendLog", DataFormat = DataFormat.Default)]
		public List<FlowerInfo2Client> sendLog
		{
			get
			{
				return this._sendLog;
			}
		}

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06000887 RID: 2183 RVA: 0x00012E00 File Offset: 0x00011000
		[ProtoMember(19, Name = "receiveFlowersTotal", DataFormat = DataFormat.Default)]
		public List<MapIntItem> receiveFlowersTotal
		{
			get
			{
				return this._receiveFlowersTotal;
			}
		}

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06000888 RID: 2184 RVA: 0x00012E18 File Offset: 0x00011018
		[ProtoMember(20, Name = "receiveRank", DataFormat = DataFormat.Default)]
		public List<ReceiveRoleFlowerInfo2Client> receiveRank
		{
			get
			{
				return this._receiveRank;
			}
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06000889 RID: 2185 RVA: 0x00012E30 File Offset: 0x00011030
		// (set) Token: 0x0600088A RID: 2186 RVA: 0x00012E5C File Offset: 0x0001105C
		[ProtoMember(21, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x0600088B RID: 2187 RVA: 0x00012E6C File Offset: 0x0001106C
		// (set) Token: 0x0600088C RID: 2188 RVA: 0x00012E8C File Offset: 0x0001108C
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x00012ED0 File Offset: 0x000110D0
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x00012EE8 File Offset: 0x000110E8
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x00012EF4 File Offset: 0x000110F4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000223 RID: 547
		private uint? _allcount;

		// Token: 0x04000224 RID: 548
		private uint? _weekcount;

		// Token: 0x04000225 RID: 549
		private uint? _weekrank;

		// Token: 0x04000226 RID: 550
		private uint? _cansendcount;

		// Token: 0x04000227 RID: 551
		private readonly List<uint> _cansendstate = new List<uint>();

		// Token: 0x04000228 RID: 552
		private readonly List<ulong> _recordroleid = new List<ulong>();

		// Token: 0x04000229 RID: 553
		private readonly List<uint> _recordcount = new List<uint>();

		// Token: 0x0400022A RID: 554
		private readonly List<uint> _recordtime = new List<uint>();

		// Token: 0x0400022B RID: 555
		private readonly List<string> _recordname = new List<string>();

		// Token: 0x0400022C RID: 556
		private string _rolename;

		// Token: 0x0400022D RID: 557
		private uint? _roleprofession;

		// Token: 0x0400022E RID: 558
		private readonly List<ulong> _otherroleid = new List<ulong>();

		// Token: 0x0400022F RID: 559
		private readonly List<string> _othername = new List<string>();

		// Token: 0x04000230 RID: 560
		private readonly List<uint> _othercount = new List<uint>();

		// Token: 0x04000231 RID: 561
		private readonly List<uint> _otherprofession = new List<uint>();

		// Token: 0x04000232 RID: 562
		private readonly List<uint> _updegreelevel = new List<uint>();

		// Token: 0x04000233 RID: 563
		private readonly List<MapIntItem> _sendFlowersTotal = new List<MapIntItem>();

		// Token: 0x04000234 RID: 564
		private readonly List<FlowerInfo2Client> _sendLog = new List<FlowerInfo2Client>();

		// Token: 0x04000235 RID: 565
		private readonly List<MapIntItem> _receiveFlowersTotal = new List<MapIntItem>();

		// Token: 0x04000236 RID: 566
		private readonly List<ReceiveRoleFlowerInfo2Client> _receiveRank = new List<ReceiveRoleFlowerInfo2Client>();

		// Token: 0x04000237 RID: 567
		private ErrorCode? _errorcode;

		// Token: 0x04000238 RID: 568
		private IExtension extensionObject;
	}
}
