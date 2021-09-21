using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006FC RID: 1788
	[ProtoContract(Name = "CareerData")]
	[Serializable]
	public class CareerData : IExtensible
	{
		// Token: 0x17002643 RID: 9795
		// (get) Token: 0x060078CA RID: 30922 RVA: 0x000E706C File Offset: 0x000E526C
		// (set) Token: 0x060078CB RID: 30923 RVA: 0x000E7098 File Offset: 0x000E5298
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public CarrerDataType type
		{
			get
			{
				return this._type ?? CarrerDataType.CARRER_DATA_LEVEL;
			}
			set
			{
				this._type = new CarrerDataType?(value);
			}
		}

		// Token: 0x17002644 RID: 9796
		// (get) Token: 0x060078CC RID: 30924 RVA: 0x000E70A8 File Offset: 0x000E52A8
		// (set) Token: 0x060078CD RID: 30925 RVA: 0x000E70C8 File Offset: 0x000E52C8
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new CarrerDataType?(this.type) : null);
				}
			}
		}

		// Token: 0x060078CE RID: 30926 RVA: 0x000E710C File Offset: 0x000E530C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060078CF RID: 30927 RVA: 0x000E7124 File Offset: 0x000E5324
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17002645 RID: 9797
		// (get) Token: 0x060078D0 RID: 30928 RVA: 0x000E7130 File Offset: 0x000E5330
		// (set) Token: 0x060078D1 RID: 30929 RVA: 0x000E715C File Offset: 0x000E535C
		[ProtoMember(2, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002646 RID: 9798
		// (get) Token: 0x060078D2 RID: 30930 RVA: 0x000E716C File Offset: 0x000E536C
		// (set) Token: 0x060078D3 RID: 30931 RVA: 0x000E718C File Offset: 0x000E538C
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

		// Token: 0x060078D4 RID: 30932 RVA: 0x000E71D0 File Offset: 0x000E53D0
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x060078D5 RID: 30933 RVA: 0x000E71E8 File Offset: 0x000E53E8
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x17002647 RID: 9799
		// (get) Token: 0x060078D6 RID: 30934 RVA: 0x000E71F4 File Offset: 0x000E53F4
		// (set) Token: 0x060078D7 RID: 30935 RVA: 0x000E7220 File Offset: 0x000E5420
		[ProtoMember(3, IsRequired = false, Name = "para1", DataFormat = DataFormat.TwosComplement)]
		public uint para1
		{
			get
			{
				return this._para1 ?? 0U;
			}
			set
			{
				this._para1 = new uint?(value);
			}
		}

		// Token: 0x17002648 RID: 9800
		// (get) Token: 0x060078D8 RID: 30936 RVA: 0x000E7230 File Offset: 0x000E5430
		// (set) Token: 0x060078D9 RID: 30937 RVA: 0x000E7250 File Offset: 0x000E5450
		[XmlIgnore]
		[Browsable(false)]
		public bool para1Specified
		{
			get
			{
				return this._para1 != null;
			}
			set
			{
				bool flag = value == (this._para1 == null);
				if (flag)
				{
					this._para1 = (value ? new uint?(this.para1) : null);
				}
			}
		}

		// Token: 0x060078DA RID: 30938 RVA: 0x000E7294 File Offset: 0x000E5494
		private bool ShouldSerializepara1()
		{
			return this.para1Specified;
		}

		// Token: 0x060078DB RID: 30939 RVA: 0x000E72AC File Offset: 0x000E54AC
		private void Resetpara1()
		{
			this.para1Specified = false;
		}

		// Token: 0x060078DC RID: 30940 RVA: 0x000E72B8 File Offset: 0x000E54B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C8B RID: 7307
		private CarrerDataType? _type;

		// Token: 0x04001C8C RID: 7308
		private uint? _time;

		// Token: 0x04001C8D RID: 7309
		private uint? _para1;

		// Token: 0x04001C8E RID: 7310
		private IExtension extensionObject;
	}
}
