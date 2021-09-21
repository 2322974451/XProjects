using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002FA RID: 762
	[ProtoContract(Name = "GuildBuffCDParam")]
	[Serializable]
	public class GuildBuffCDParam : IExtensible
	{
		// Token: 0x17000CF7 RID: 3319
		// (get) Token: 0x060029CF RID: 10703 RVA: 0x000511AC File Offset: 0x0004F3AC
		// (set) Token: 0x060029D0 RID: 10704 RVA: 0x000511D8 File Offset: 0x0004F3D8
		[ProtoMember(1, IsRequired = false, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public uint param
		{
			get
			{
				return this._param ?? 0U;
			}
			set
			{
				this._param = new uint?(value);
			}
		}

		// Token: 0x17000CF8 RID: 3320
		// (get) Token: 0x060029D1 RID: 10705 RVA: 0x000511E8 File Offset: 0x0004F3E8
		// (set) Token: 0x060029D2 RID: 10706 RVA: 0x00051208 File Offset: 0x0004F408
		[XmlIgnore]
		[Browsable(false)]
		public bool paramSpecified
		{
			get
			{
				return this._param != null;
			}
			set
			{
				bool flag = value == (this._param == null);
				if (flag)
				{
					this._param = (value ? new uint?(this.param) : null);
				}
			}
		}

		// Token: 0x060029D3 RID: 10707 RVA: 0x0005124C File Offset: 0x0004F44C
		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		// Token: 0x060029D4 RID: 10708 RVA: 0x00051264 File Offset: 0x0004F464
		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		// Token: 0x060029D5 RID: 10709 RVA: 0x00051270 File Offset: 0x0004F470
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A61 RID: 2657
		private uint? _param;

		// Token: 0x04000A62 RID: 2658
		private IExtension extensionObject;
	}
}
