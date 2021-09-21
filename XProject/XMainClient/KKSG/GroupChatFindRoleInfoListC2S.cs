using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200044C RID: 1100
	[ProtoContract(Name = "GroupChatFindRoleInfoListC2S")]
	[Serializable]
	public class GroupChatFindRoleInfoListC2S : IExtensible
	{
		// Token: 0x170011D3 RID: 4563
		// (get) Token: 0x06003A17 RID: 14871 RVA: 0x0006F210 File Offset: 0x0006D410
		// (set) Token: 0x06003A18 RID: 14872 RVA: 0x0006F23C File Offset: 0x0006D43C
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x170011D4 RID: 4564
		// (get) Token: 0x06003A19 RID: 14873 RVA: 0x0006F24C File Offset: 0x0006D44C
		// (set) Token: 0x06003A1A RID: 14874 RVA: 0x0006F26C File Offset: 0x0006D46C
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
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x06003A1B RID: 14875 RVA: 0x0006F2B0 File Offset: 0x0006D4B0
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003A1C RID: 14876 RVA: 0x0006F2C8 File Offset: 0x0006D4C8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06003A1D RID: 14877 RVA: 0x0006F2D4 File Offset: 0x0006D4D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E67 RID: 3687
		private uint? _type;

		// Token: 0x04000E68 RID: 3688
		private IExtension extensionObject;
	}
}
