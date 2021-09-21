using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000473 RID: 1139
	[ProtoContract(Name = "EnterWeddingSceneArg")]
	[Serializable]
	public class EnterWeddingSceneArg : IExtensible
	{
		// Token: 0x1700123C RID: 4668
		// (get) Token: 0x06003B79 RID: 15225 RVA: 0x00071A64 File Offset: 0x0006FC64
		// (set) Token: 0x06003B7A RID: 15226 RVA: 0x00071A91 File Offset: 0x0006FC91
		[ProtoMember(1, IsRequired = false, Name = "weddingid", DataFormat = DataFormat.TwosComplement)]
		public ulong weddingid
		{
			get
			{
				return this._weddingid ?? 0UL;
			}
			set
			{
				this._weddingid = new ulong?(value);
			}
		}

		// Token: 0x1700123D RID: 4669
		// (get) Token: 0x06003B7B RID: 15227 RVA: 0x00071AA0 File Offset: 0x0006FCA0
		// (set) Token: 0x06003B7C RID: 15228 RVA: 0x00071AC0 File Offset: 0x0006FCC0
		[XmlIgnore]
		[Browsable(false)]
		public bool weddingidSpecified
		{
			get
			{
				return this._weddingid != null;
			}
			set
			{
				bool flag = value == (this._weddingid == null);
				if (flag)
				{
					this._weddingid = (value ? new ulong?(this.weddingid) : null);
				}
			}
		}

		// Token: 0x06003B7D RID: 15229 RVA: 0x00071B04 File Offset: 0x0006FD04
		private bool ShouldSerializeweddingid()
		{
			return this.weddingidSpecified;
		}

		// Token: 0x06003B7E RID: 15230 RVA: 0x00071B1C File Offset: 0x0006FD1C
		private void Resetweddingid()
		{
			this.weddingidSpecified = false;
		}

		// Token: 0x06003B7F RID: 15231 RVA: 0x00071B28 File Offset: 0x0006FD28
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000ECD RID: 3789
		private ulong? _weddingid;

		// Token: 0x04000ECE RID: 3790
		private IExtension extensionObject;
	}
}
