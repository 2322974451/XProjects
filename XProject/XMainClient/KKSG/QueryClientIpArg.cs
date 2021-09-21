using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200035B RID: 859
	[ProtoContract(Name = "QueryClientIpArg")]
	[Serializable]
	public class QueryClientIpArg : IExtensible
	{
		// Token: 0x17000E97 RID: 3735
		// (get) Token: 0x06002F12 RID: 12050 RVA: 0x0005AE64 File Offset: 0x00059064
		// (set) Token: 0x06002F13 RID: 12051 RVA: 0x0005AE90 File Offset: 0x00059090
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

		// Token: 0x17000E98 RID: 3736
		// (get) Token: 0x06002F14 RID: 12052 RVA: 0x0005AEA0 File Offset: 0x000590A0
		// (set) Token: 0x06002F15 RID: 12053 RVA: 0x0005AEC0 File Offset: 0x000590C0
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

		// Token: 0x06002F16 RID: 12054 RVA: 0x0005AF04 File Offset: 0x00059104
		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		// Token: 0x06002F17 RID: 12055 RVA: 0x0005AF1C File Offset: 0x0005911C
		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		// Token: 0x06002F18 RID: 12056 RVA: 0x0005AF28 File Offset: 0x00059128
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BAC RID: 2988
		private uint? _param;

		// Token: 0x04000BAD RID: 2989
		private IExtension extensionObject;
	}
}
