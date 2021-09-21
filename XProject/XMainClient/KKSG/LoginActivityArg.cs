using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003CE RID: 974
	[ProtoContract(Name = "LoginActivityArg")]
	[Serializable]
	public class LoginActivityArg : IExtensible
	{
		// Token: 0x17000FFF RID: 4095
		// (get) Token: 0x060033F3 RID: 13299 RVA: 0x00063B28 File Offset: 0x00061D28
		// (set) Token: 0x060033F4 RID: 13300 RVA: 0x00063B54 File Offset: 0x00061D54
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

		// Token: 0x17001000 RID: 4096
		// (get) Token: 0x060033F5 RID: 13301 RVA: 0x00063B64 File Offset: 0x00061D64
		// (set) Token: 0x060033F6 RID: 13302 RVA: 0x00063B84 File Offset: 0x00061D84
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

		// Token: 0x060033F7 RID: 13303 RVA: 0x00063BC8 File Offset: 0x00061DC8
		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		// Token: 0x060033F8 RID: 13304 RVA: 0x00063BE0 File Offset: 0x00061DE0
		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		// Token: 0x060033F9 RID: 13305 RVA: 0x00063BEC File Offset: 0x00061DEC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CE7 RID: 3303
		private uint? _param;

		// Token: 0x04000CE8 RID: 3304
		private IExtension extensionObject;
	}
}
