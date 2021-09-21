using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002A5 RID: 677
	[ProtoContract(Name = "ResWarArg")]
	[Serializable]
	public class ResWarArg : IExtensible
	{
		// Token: 0x17000BC5 RID: 3013
		// (get) Token: 0x060025D7 RID: 9687 RVA: 0x00049AE0 File Offset: 0x00047CE0
		// (set) Token: 0x060025D8 RID: 9688 RVA: 0x00049B0C File Offset: 0x00047D0C
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

		// Token: 0x17000BC6 RID: 3014
		// (get) Token: 0x060025D9 RID: 9689 RVA: 0x00049B1C File Offset: 0x00047D1C
		// (set) Token: 0x060025DA RID: 9690 RVA: 0x00049B3C File Offset: 0x00047D3C
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

		// Token: 0x060025DB RID: 9691 RVA: 0x00049B80 File Offset: 0x00047D80
		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		// Token: 0x060025DC RID: 9692 RVA: 0x00049B98 File Offset: 0x00047D98
		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		// Token: 0x060025DD RID: 9693 RVA: 0x00049BA4 File Offset: 0x00047DA4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000960 RID: 2400
		private uint? _param;

		// Token: 0x04000961 RID: 2401
		private IExtension extensionObject;
	}
}
