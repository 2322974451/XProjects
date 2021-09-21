using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000654 RID: 1620
	[ProtoContract(Name = "Buff")]
	[Serializable]
	public class Buff : IExtensible
	{
		// Token: 0x17001FCF RID: 8143
		// (get) Token: 0x060064D1 RID: 25809 RVA: 0x000C06E8 File Offset: 0x000BE8E8
		// (set) Token: 0x060064D2 RID: 25810 RVA: 0x000C0714 File Offset: 0x000BE914
		[ProtoMember(1, IsRequired = false, Name = "buffID", DataFormat = DataFormat.TwosComplement)]
		public int buffID
		{
			get
			{
				return this._buffID ?? 0;
			}
			set
			{
				this._buffID = new int?(value);
			}
		}

		// Token: 0x17001FD0 RID: 8144
		// (get) Token: 0x060064D3 RID: 25811 RVA: 0x000C0724 File Offset: 0x000BE924
		// (set) Token: 0x060064D4 RID: 25812 RVA: 0x000C0744 File Offset: 0x000BE944
		[XmlIgnore]
		[Browsable(false)]
		public bool buffIDSpecified
		{
			get
			{
				return this._buffID != null;
			}
			set
			{
				bool flag = value == (this._buffID == null);
				if (flag)
				{
					this._buffID = (value ? new int?(this.buffID) : null);
				}
			}
		}

		// Token: 0x060064D5 RID: 25813 RVA: 0x000C0788 File Offset: 0x000BE988
		private bool ShouldSerializebuffID()
		{
			return this.buffIDSpecified;
		}

		// Token: 0x060064D6 RID: 25814 RVA: 0x000C07A0 File Offset: 0x000BE9A0
		private void ResetbuffID()
		{
			this.buffIDSpecified = false;
		}

		// Token: 0x17001FD1 RID: 8145
		// (get) Token: 0x060064D7 RID: 25815 RVA: 0x000C07AC File Offset: 0x000BE9AC
		// (set) Token: 0x060064D8 RID: 25816 RVA: 0x000C07D8 File Offset: 0x000BE9D8
		[ProtoMember(2, IsRequired = false, Name = "buffLevel", DataFormat = DataFormat.TwosComplement)]
		public int buffLevel
		{
			get
			{
				return this._buffLevel ?? 0;
			}
			set
			{
				this._buffLevel = new int?(value);
			}
		}

		// Token: 0x17001FD2 RID: 8146
		// (get) Token: 0x060064D9 RID: 25817 RVA: 0x000C07E8 File Offset: 0x000BE9E8
		// (set) Token: 0x060064DA RID: 25818 RVA: 0x000C0808 File Offset: 0x000BEA08
		[XmlIgnore]
		[Browsable(false)]
		public bool buffLevelSpecified
		{
			get
			{
				return this._buffLevel != null;
			}
			set
			{
				bool flag = value == (this._buffLevel == null);
				if (flag)
				{
					this._buffLevel = (value ? new int?(this.buffLevel) : null);
				}
			}
		}

		// Token: 0x060064DB RID: 25819 RVA: 0x000C084C File Offset: 0x000BEA4C
		private bool ShouldSerializebuffLevel()
		{
			return this.buffLevelSpecified;
		}

		// Token: 0x060064DC RID: 25820 RVA: 0x000C0864 File Offset: 0x000BEA64
		private void ResetbuffLevel()
		{
			this.buffLevelSpecified = false;
		}

		// Token: 0x17001FD3 RID: 8147
		// (get) Token: 0x060064DD RID: 25821 RVA: 0x000C0870 File Offset: 0x000BEA70
		// (set) Token: 0x060064DE RID: 25822 RVA: 0x000C089C File Offset: 0x000BEA9C
		[ProtoMember(3, IsRequired = false, Name = "effecttime", DataFormat = DataFormat.TwosComplement)]
		public uint effecttime
		{
			get
			{
				return this._effecttime ?? 0U;
			}
			set
			{
				this._effecttime = new uint?(value);
			}
		}

		// Token: 0x17001FD4 RID: 8148
		// (get) Token: 0x060064DF RID: 25823 RVA: 0x000C08AC File Offset: 0x000BEAAC
		// (set) Token: 0x060064E0 RID: 25824 RVA: 0x000C08CC File Offset: 0x000BEACC
		[XmlIgnore]
		[Browsable(false)]
		public bool effecttimeSpecified
		{
			get
			{
				return this._effecttime != null;
			}
			set
			{
				bool flag = value == (this._effecttime == null);
				if (flag)
				{
					this._effecttime = (value ? new uint?(this.effecttime) : null);
				}
			}
		}

		// Token: 0x060064E1 RID: 25825 RVA: 0x000C0910 File Offset: 0x000BEB10
		private bool ShouldSerializeeffecttime()
		{
			return this.effecttimeSpecified;
		}

		// Token: 0x060064E2 RID: 25826 RVA: 0x000C0928 File Offset: 0x000BEB28
		private void Reseteffecttime()
		{
			this.effecttimeSpecified = false;
		}

		// Token: 0x17001FD5 RID: 8149
		// (get) Token: 0x060064E3 RID: 25827 RVA: 0x000C0934 File Offset: 0x000BEB34
		// (set) Token: 0x060064E4 RID: 25828 RVA: 0x000C0960 File Offset: 0x000BEB60
		[ProtoMember(4, IsRequired = false, Name = "skillID", DataFormat = DataFormat.TwosComplement)]
		public uint skillID
		{
			get
			{
				return this._skillID ?? 0U;
			}
			set
			{
				this._skillID = new uint?(value);
			}
		}

		// Token: 0x17001FD6 RID: 8150
		// (get) Token: 0x060064E5 RID: 25829 RVA: 0x000C0970 File Offset: 0x000BEB70
		// (set) Token: 0x060064E6 RID: 25830 RVA: 0x000C0990 File Offset: 0x000BEB90
		[XmlIgnore]
		[Browsable(false)]
		public bool skillIDSpecified
		{
			get
			{
				return this._skillID != null;
			}
			set
			{
				bool flag = value == (this._skillID == null);
				if (flag)
				{
					this._skillID = (value ? new uint?(this.skillID) : null);
				}
			}
		}

		// Token: 0x060064E7 RID: 25831 RVA: 0x000C09D4 File Offset: 0x000BEBD4
		private bool ShouldSerializeskillID()
		{
			return this.skillIDSpecified;
		}

		// Token: 0x060064E8 RID: 25832 RVA: 0x000C09EC File Offset: 0x000BEBEC
		private void ResetskillID()
		{
			this.skillIDSpecified = false;
		}

		// Token: 0x060064E9 RID: 25833 RVA: 0x000C09F8 File Offset: 0x000BEBF8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001873 RID: 6259
		private int? _buffID;

		// Token: 0x04001874 RID: 6260
		private int? _buffLevel;

		// Token: 0x04001875 RID: 6261
		private uint? _effecttime;

		// Token: 0x04001876 RID: 6262
		private uint? _skillID;

		// Token: 0x04001877 RID: 6263
		private IExtension extensionObject;
	}
}
