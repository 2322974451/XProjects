using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000678 RID: 1656
	[ProtoContract(Name = "HellDropInfo")]
	[Serializable]
	public class HellDropInfo : IExtensible
	{
		// Token: 0x17002178 RID: 8568
		// (get) Token: 0x060069CF RID: 27087 RVA: 0x000CA4C0 File Offset: 0x000C86C0
		// (set) Token: 0x060069D0 RID: 27088 RVA: 0x000CA4EC File Offset: 0x000C86EC
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x17002179 RID: 8569
		// (get) Token: 0x060069D1 RID: 27089 RVA: 0x000CA4FC File Offset: 0x000C86FC
		// (set) Token: 0x060069D2 RID: 27090 RVA: 0x000CA51C File Offset: 0x000C871C
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x060069D3 RID: 27091 RVA: 0x000CA560 File Offset: 0x000C8760
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x060069D4 RID: 27092 RVA: 0x000CA578 File Offset: 0x000C8778
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x1700217A RID: 8570
		// (get) Token: 0x060069D5 RID: 27093 RVA: 0x000CA584 File Offset: 0x000C8784
		// (set) Token: 0x060069D6 RID: 27094 RVA: 0x000CA5B0 File Offset: 0x000C87B0
		[ProtoMember(2, IsRequired = false, Name = "common", DataFormat = DataFormat.TwosComplement)]
		public uint common
		{
			get
			{
				return this._common ?? 0U;
			}
			set
			{
				this._common = new uint?(value);
			}
		}

		// Token: 0x1700217B RID: 8571
		// (get) Token: 0x060069D7 RID: 27095 RVA: 0x000CA5C0 File Offset: 0x000C87C0
		// (set) Token: 0x060069D8 RID: 27096 RVA: 0x000CA5E0 File Offset: 0x000C87E0
		[XmlIgnore]
		[Browsable(false)]
		public bool commonSpecified
		{
			get
			{
				return this._common != null;
			}
			set
			{
				bool flag = value == (this._common == null);
				if (flag)
				{
					this._common = (value ? new uint?(this.common) : null);
				}
			}
		}

		// Token: 0x060069D9 RID: 27097 RVA: 0x000CA624 File Offset: 0x000C8824
		private bool ShouldSerializecommon()
		{
			return this.commonSpecified;
		}

		// Token: 0x060069DA RID: 27098 RVA: 0x000CA63C File Offset: 0x000C883C
		private void Resetcommon()
		{
			this.commonSpecified = false;
		}

		// Token: 0x1700217C RID: 8572
		// (get) Token: 0x060069DB RID: 27099 RVA: 0x000CA648 File Offset: 0x000C8848
		// (set) Token: 0x060069DC RID: 27100 RVA: 0x000CA674 File Offset: 0x000C8874
		[ProtoMember(3, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x1700217D RID: 8573
		// (get) Token: 0x060069DD RID: 27101 RVA: 0x000CA684 File Offset: 0x000C8884
		// (set) Token: 0x060069DE RID: 27102 RVA: 0x000CA6A4 File Offset: 0x000C88A4
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x060069DF RID: 27103 RVA: 0x000CA6E8 File Offset: 0x000C88E8
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x060069E0 RID: 27104 RVA: 0x000CA700 File Offset: 0x000C8900
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x1700217E RID: 8574
		// (get) Token: 0x060069E1 RID: 27105 RVA: 0x000CA70C File Offset: 0x000C890C
		// (set) Token: 0x060069E2 RID: 27106 RVA: 0x000CA738 File Offset: 0x000C8938
		[ProtoMember(4, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x1700217F RID: 8575
		// (get) Token: 0x060069E3 RID: 27107 RVA: 0x000CA748 File Offset: 0x000C8948
		// (set) Token: 0x060069E4 RID: 27108 RVA: 0x000CA768 File Offset: 0x000C8968
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x060069E5 RID: 27109 RVA: 0x000CA7AC File Offset: 0x000C89AC
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x060069E6 RID: 27110 RVA: 0x000CA7C4 File Offset: 0x000C89C4
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x17002180 RID: 8576
		// (get) Token: 0x060069E7 RID: 27111 RVA: 0x000CA7D0 File Offset: 0x000C89D0
		// (set) Token: 0x060069E8 RID: 27112 RVA: 0x000CA7FC File Offset: 0x000C89FC
		[ProtoMember(5, IsRequired = false, Name = "worse", DataFormat = DataFormat.TwosComplement)]
		public uint worse
		{
			get
			{
				return this._worse ?? 0U;
			}
			set
			{
				this._worse = new uint?(value);
			}
		}

		// Token: 0x17002181 RID: 8577
		// (get) Token: 0x060069E9 RID: 27113 RVA: 0x000CA80C File Offset: 0x000C8A0C
		// (set) Token: 0x060069EA RID: 27114 RVA: 0x000CA82C File Offset: 0x000C8A2C
		[XmlIgnore]
		[Browsable(false)]
		public bool worseSpecified
		{
			get
			{
				return this._worse != null;
			}
			set
			{
				bool flag = value == (this._worse == null);
				if (flag)
				{
					this._worse = (value ? new uint?(this.worse) : null);
				}
			}
		}

		// Token: 0x060069EB RID: 27115 RVA: 0x000CA870 File Offset: 0x000C8A70
		private bool ShouldSerializeworse()
		{
			return this.worseSpecified;
		}

		// Token: 0x060069EC RID: 27116 RVA: 0x000CA888 File Offset: 0x000C8A88
		private void Resetworse()
		{
			this.worseSpecified = false;
		}

		// Token: 0x17002182 RID: 8578
		// (get) Token: 0x060069ED RID: 27117 RVA: 0x000CA894 File Offset: 0x000C8A94
		// (set) Token: 0x060069EE RID: 27118 RVA: 0x000CA8C0 File Offset: 0x000C8AC0
		[ProtoMember(6, IsRequired = false, Name = "worst", DataFormat = DataFormat.TwosComplement)]
		public uint worst
		{
			get
			{
				return this._worst ?? 0U;
			}
			set
			{
				this._worst = new uint?(value);
			}
		}

		// Token: 0x17002183 RID: 8579
		// (get) Token: 0x060069EF RID: 27119 RVA: 0x000CA8D0 File Offset: 0x000C8AD0
		// (set) Token: 0x060069F0 RID: 27120 RVA: 0x000CA8F0 File Offset: 0x000C8AF0
		[XmlIgnore]
		[Browsable(false)]
		public bool worstSpecified
		{
			get
			{
				return this._worst != null;
			}
			set
			{
				bool flag = value == (this._worst == null);
				if (flag)
				{
					this._worst = (value ? new uint?(this.worst) : null);
				}
			}
		}

		// Token: 0x060069F1 RID: 27121 RVA: 0x000CA934 File Offset: 0x000C8B34
		private bool ShouldSerializeworst()
		{
			return this.worstSpecified;
		}

		// Token: 0x060069F2 RID: 27122 RVA: 0x000CA94C File Offset: 0x000C8B4C
		private void Resetworst()
		{
			this.worstSpecified = false;
		}

		// Token: 0x060069F3 RID: 27123 RVA: 0x000CA958 File Offset: 0x000C8B58
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400197F RID: 6527
		private uint? _id;

		// Token: 0x04001980 RID: 6528
		private uint? _common;

		// Token: 0x04001981 RID: 6529
		private uint? _count;

		// Token: 0x04001982 RID: 6530
		private uint? _time;

		// Token: 0x04001983 RID: 6531
		private uint? _worse;

		// Token: 0x04001984 RID: 6532
		private uint? _worst;

		// Token: 0x04001985 RID: 6533
		private IExtension extensionObject;
	}
}
