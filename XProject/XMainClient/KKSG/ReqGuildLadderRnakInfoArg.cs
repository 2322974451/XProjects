using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200023E RID: 574
	[ProtoContract(Name = "ReqGuildLadderRnakInfoArg")]
	[Serializable]
	public class ReqGuildLadderRnakInfoArg : IExtensible
	{
		// Token: 0x170009F6 RID: 2550
		// (get) Token: 0x06001FEF RID: 8175 RVA: 0x0003E970 File Offset: 0x0003CB70
		// (set) Token: 0x06001FF0 RID: 8176 RVA: 0x0003E99D File Offset: 0x0003CB9D
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x170009F7 RID: 2551
		// (get) Token: 0x06001FF1 RID: 8177 RVA: 0x0003E9AC File Offset: 0x0003CBAC
		// (set) Token: 0x06001FF2 RID: 8178 RVA: 0x0003E9CC File Offset: 0x0003CBCC
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06001FF3 RID: 8179 RVA: 0x0003EA10 File Offset: 0x0003CC10
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06001FF4 RID: 8180 RVA: 0x0003EA28 File Offset: 0x0003CC28
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x06001FF5 RID: 8181 RVA: 0x0003EA34 File Offset: 0x0003CC34
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007F9 RID: 2041
		private ulong? _roleid;

		// Token: 0x040007FA RID: 2042
		private IExtension extensionObject;
	}
}
