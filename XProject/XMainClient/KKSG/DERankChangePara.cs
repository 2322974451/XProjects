using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000235 RID: 565
	[ProtoContract(Name = "DERankChangePara")]
	[Serializable]
	public class DERankChangePara : IExtensible
	{
		// Token: 0x170009C7 RID: 2503
		// (get) Token: 0x06001F61 RID: 8033 RVA: 0x0003D848 File Offset: 0x0003BA48
		// (set) Token: 0x06001F62 RID: 8034 RVA: 0x0003D874 File Offset: 0x0003BA74
		[ProtoMember(1, IsRequired = false, Name = "oldrank", DataFormat = DataFormat.TwosComplement)]
		public int oldrank
		{
			get
			{
				return this._oldrank ?? 0;
			}
			set
			{
				this._oldrank = new int?(value);
			}
		}

		// Token: 0x170009C8 RID: 2504
		// (get) Token: 0x06001F63 RID: 8035 RVA: 0x0003D884 File Offset: 0x0003BA84
		// (set) Token: 0x06001F64 RID: 8036 RVA: 0x0003D8A4 File Offset: 0x0003BAA4
		[XmlIgnore]
		[Browsable(false)]
		public bool oldrankSpecified
		{
			get
			{
				return this._oldrank != null;
			}
			set
			{
				bool flag = value == (this._oldrank == null);
				if (flag)
				{
					this._oldrank = (value ? new int?(this.oldrank) : null);
				}
			}
		}

		// Token: 0x06001F65 RID: 8037 RVA: 0x0003D8E8 File Offset: 0x0003BAE8
		private bool ShouldSerializeoldrank()
		{
			return this.oldrankSpecified;
		}

		// Token: 0x06001F66 RID: 8038 RVA: 0x0003D900 File Offset: 0x0003BB00
		private void Resetoldrank()
		{
			this.oldrankSpecified = false;
		}

		// Token: 0x170009C9 RID: 2505
		// (get) Token: 0x06001F67 RID: 8039 RVA: 0x0003D90C File Offset: 0x0003BB0C
		// (set) Token: 0x06001F68 RID: 8040 RVA: 0x0003D938 File Offset: 0x0003BB38
		[ProtoMember(2, IsRequired = false, Name = "newrank", DataFormat = DataFormat.TwosComplement)]
		public int newrank
		{
			get
			{
				return this._newrank ?? 0;
			}
			set
			{
				this._newrank = new int?(value);
			}
		}

		// Token: 0x170009CA RID: 2506
		// (get) Token: 0x06001F69 RID: 8041 RVA: 0x0003D948 File Offset: 0x0003BB48
		// (set) Token: 0x06001F6A RID: 8042 RVA: 0x0003D968 File Offset: 0x0003BB68
		[XmlIgnore]
		[Browsable(false)]
		public bool newrankSpecified
		{
			get
			{
				return this._newrank != null;
			}
			set
			{
				bool flag = value == (this._newrank == null);
				if (flag)
				{
					this._newrank = (value ? new int?(this.newrank) : null);
				}
			}
		}

		// Token: 0x06001F6B RID: 8043 RVA: 0x0003D9AC File Offset: 0x0003BBAC
		private bool ShouldSerializenewrank()
		{
			return this.newrankSpecified;
		}

		// Token: 0x06001F6C RID: 8044 RVA: 0x0003D9C4 File Offset: 0x0003BBC4
		private void Resetnewrank()
		{
			this.newrankSpecified = false;
		}

		// Token: 0x06001F6D RID: 8045 RVA: 0x0003D9D0 File Offset: 0x0003BBD0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007D4 RID: 2004
		private int? _oldrank;

		// Token: 0x040007D5 RID: 2005
		private int? _newrank;

		// Token: 0x040007D6 RID: 2006
		private IExtension extensionObject;
	}
}
