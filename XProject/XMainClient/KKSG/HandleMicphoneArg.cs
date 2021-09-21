using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002F7 RID: 759
	[ProtoContract(Name = "HandleMicphoneArg")]
	[Serializable]
	public class HandleMicphoneArg : IExtensible
	{
		// Token: 0x17000CEF RID: 3311
		// (get) Token: 0x060029B1 RID: 10673 RVA: 0x00050E64 File Offset: 0x0004F064
		// (set) Token: 0x060029B2 RID: 10674 RVA: 0x00050E90 File Offset: 0x0004F090
		[ProtoMember(1, IsRequired = false, Name = "param", DataFormat = DataFormat.Default)]
		public bool param
		{
			get
			{
				return this._param ?? false;
			}
			set
			{
				this._param = new bool?(value);
			}
		}

		// Token: 0x17000CF0 RID: 3312
		// (get) Token: 0x060029B3 RID: 10675 RVA: 0x00050EA0 File Offset: 0x0004F0A0
		// (set) Token: 0x060029B4 RID: 10676 RVA: 0x00050EC0 File Offset: 0x0004F0C0
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
					this._param = (value ? new bool?(this.param) : null);
				}
			}
		}

		// Token: 0x060029B5 RID: 10677 RVA: 0x00050F04 File Offset: 0x0004F104
		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		// Token: 0x060029B6 RID: 10678 RVA: 0x00050F1C File Offset: 0x0004F11C
		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		// Token: 0x060029B7 RID: 10679 RVA: 0x00050F28 File Offset: 0x0004F128
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A5A RID: 2650
		private bool? _param;

		// Token: 0x04000A5B RID: 2651
		private IExtension extensionObject;
	}
}
