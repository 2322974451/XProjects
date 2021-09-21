using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000460 RID: 1120
	[ProtoContract(Name = "NotifyStartUpTypeToClient")]
	[Serializable]
	public class NotifyStartUpTypeToClient : IExtensible
	{
		// Token: 0x17001205 RID: 4613
		// (get) Token: 0x06003AC7 RID: 15047 RVA: 0x0007060C File Offset: 0x0006E80C
		// (set) Token: 0x06003AC8 RID: 15048 RVA: 0x00070638 File Offset: 0x0006E838
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public StartUpType type
		{
			get
			{
				return this._type ?? StartUpType.StartUp_Normal;
			}
			set
			{
				this._type = new StartUpType?(value);
			}
		}

		// Token: 0x17001206 RID: 4614
		// (get) Token: 0x06003AC9 RID: 15049 RVA: 0x00070648 File Offset: 0x0006E848
		// (set) Token: 0x06003ACA RID: 15050 RVA: 0x00070668 File Offset: 0x0006E868
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
					this._type = (value ? new StartUpType?(this.type) : null);
				}
			}
		}

		// Token: 0x06003ACB RID: 15051 RVA: 0x000706AC File Offset: 0x0006E8AC
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003ACC RID: 15052 RVA: 0x000706C4 File Offset: 0x0006E8C4
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06003ACD RID: 15053 RVA: 0x000706D0 File Offset: 0x0006E8D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E98 RID: 3736
		private StartUpType? _type;

		// Token: 0x04000E99 RID: 3737
		private IExtension extensionObject;
	}
}
