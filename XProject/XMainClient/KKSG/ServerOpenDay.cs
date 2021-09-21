using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002C9 RID: 713
	[ProtoContract(Name = "ServerOpenDay")]
	[Serializable]
	public class ServerOpenDay : IExtensible
	{
		// Token: 0x17000C3C RID: 3132
		// (get) Token: 0x0600275B RID: 10075 RVA: 0x0004C834 File Offset: 0x0004AA34
		// (set) Token: 0x0600275C RID: 10076 RVA: 0x0004C860 File Offset: 0x0004AA60
		[ProtoMember(1, IsRequired = false, Name = "openday", DataFormat = DataFormat.TwosComplement)]
		public int openday
		{
			get
			{
				return this._openday ?? 0;
			}
			set
			{
				this._openday = new int?(value);
			}
		}

		// Token: 0x17000C3D RID: 3133
		// (get) Token: 0x0600275D RID: 10077 RVA: 0x0004C870 File Offset: 0x0004AA70
		// (set) Token: 0x0600275E RID: 10078 RVA: 0x0004C890 File Offset: 0x0004AA90
		[XmlIgnore]
		[Browsable(false)]
		public bool opendaySpecified
		{
			get
			{
				return this._openday != null;
			}
			set
			{
				bool flag = value == (this._openday == null);
				if (flag)
				{
					this._openday = (value ? new int?(this.openday) : null);
				}
			}
		}

		// Token: 0x0600275F RID: 10079 RVA: 0x0004C8D4 File Offset: 0x0004AAD4
		private bool ShouldSerializeopenday()
		{
			return this.opendaySpecified;
		}

		// Token: 0x06002760 RID: 10080 RVA: 0x0004C8EC File Offset: 0x0004AAEC
		private void Resetopenday()
		{
			this.opendaySpecified = false;
		}

		// Token: 0x17000C3E RID: 3134
		// (get) Token: 0x06002761 RID: 10081 RVA: 0x0004C8F8 File Offset: 0x0004AAF8
		// (set) Token: 0x06002762 RID: 10082 RVA: 0x0004C924 File Offset: 0x0004AB24
		[ProtoMember(2, IsRequired = false, Name = "week", DataFormat = DataFormat.TwosComplement)]
		public uint week
		{
			get
			{
				return this._week ?? 0U;
			}
			set
			{
				this._week = new uint?(value);
			}
		}

		// Token: 0x17000C3F RID: 3135
		// (get) Token: 0x06002763 RID: 10083 RVA: 0x0004C934 File Offset: 0x0004AB34
		// (set) Token: 0x06002764 RID: 10084 RVA: 0x0004C954 File Offset: 0x0004AB54
		[XmlIgnore]
		[Browsable(false)]
		public bool weekSpecified
		{
			get
			{
				return this._week != null;
			}
			set
			{
				bool flag = value == (this._week == null);
				if (flag)
				{
					this._week = (value ? new uint?(this.week) : null);
				}
			}
		}

		// Token: 0x06002765 RID: 10085 RVA: 0x0004C998 File Offset: 0x0004AB98
		private bool ShouldSerializeweek()
		{
			return this.weekSpecified;
		}

		// Token: 0x06002766 RID: 10086 RVA: 0x0004C9B0 File Offset: 0x0004ABB0
		private void Resetweek()
		{
			this.weekSpecified = false;
		}

		// Token: 0x17000C40 RID: 3136
		// (get) Token: 0x06002767 RID: 10087 RVA: 0x0004C9BC File Offset: 0x0004ABBC
		// (set) Token: 0x06002768 RID: 10088 RVA: 0x0004C9E8 File Offset: 0x0004ABE8
		[ProtoMember(3, IsRequired = false, Name = "daybeginsecdiff", DataFormat = DataFormat.TwosComplement)]
		public uint daybeginsecdiff
		{
			get
			{
				return this._daybeginsecdiff ?? 0U;
			}
			set
			{
				this._daybeginsecdiff = new uint?(value);
			}
		}

		// Token: 0x17000C41 RID: 3137
		// (get) Token: 0x06002769 RID: 10089 RVA: 0x0004C9F8 File Offset: 0x0004ABF8
		// (set) Token: 0x0600276A RID: 10090 RVA: 0x0004CA18 File Offset: 0x0004AC18
		[XmlIgnore]
		[Browsable(false)]
		public bool daybeginsecdiffSpecified
		{
			get
			{
				return this._daybeginsecdiff != null;
			}
			set
			{
				bool flag = value == (this._daybeginsecdiff == null);
				if (flag)
				{
					this._daybeginsecdiff = (value ? new uint?(this.daybeginsecdiff) : null);
				}
			}
		}

		// Token: 0x0600276B RID: 10091 RVA: 0x0004CA5C File Offset: 0x0004AC5C
		private bool ShouldSerializedaybeginsecdiff()
		{
			return this.daybeginsecdiffSpecified;
		}

		// Token: 0x0600276C RID: 10092 RVA: 0x0004CA74 File Offset: 0x0004AC74
		private void Resetdaybeginsecdiff()
		{
			this.daybeginsecdiffSpecified = false;
		}

		// Token: 0x17000C42 RID: 3138
		// (get) Token: 0x0600276D RID: 10093 RVA: 0x0004CA80 File Offset: 0x0004AC80
		// (set) Token: 0x0600276E RID: 10094 RVA: 0x0004CAAC File Offset: 0x0004ACAC
		[ProtoMember(4, IsRequired = false, Name = "nowTime", DataFormat = DataFormat.TwosComplement)]
		public uint nowTime
		{
			get
			{
				return this._nowTime ?? 0U;
			}
			set
			{
				this._nowTime = new uint?(value);
			}
		}

		// Token: 0x17000C43 RID: 3139
		// (get) Token: 0x0600276F RID: 10095 RVA: 0x0004CABC File Offset: 0x0004ACBC
		// (set) Token: 0x06002770 RID: 10096 RVA: 0x0004CADC File Offset: 0x0004ACDC
		[XmlIgnore]
		[Browsable(false)]
		public bool nowTimeSpecified
		{
			get
			{
				return this._nowTime != null;
			}
			set
			{
				bool flag = value == (this._nowTime == null);
				if (flag)
				{
					this._nowTime = (value ? new uint?(this.nowTime) : null);
				}
			}
		}

		// Token: 0x06002771 RID: 10097 RVA: 0x0004CB20 File Offset: 0x0004AD20
		private bool ShouldSerializenowTime()
		{
			return this.nowTimeSpecified;
		}

		// Token: 0x06002772 RID: 10098 RVA: 0x0004CB38 File Offset: 0x0004AD38
		private void ResetnowTime()
		{
			this.nowTimeSpecified = false;
		}

		// Token: 0x06002773 RID: 10099 RVA: 0x0004CB44 File Offset: 0x0004AD44
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009CA RID: 2506
		private int? _openday;

		// Token: 0x040009CB RID: 2507
		private uint? _week;

		// Token: 0x040009CC RID: 2508
		private uint? _daybeginsecdiff;

		// Token: 0x040009CD RID: 2509
		private uint? _nowTime;

		// Token: 0x040009CE RID: 2510
		private IExtension extensionObject;
	}
}
