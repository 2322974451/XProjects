using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200044E RID: 1102
	[ProtoContract(Name = "GroupChatFindTeamInfoListC2S")]
	[Serializable]
	public class GroupChatFindTeamInfoListC2S : IExtensible
	{
		// Token: 0x170011D8 RID: 4568
		// (get) Token: 0x06003A28 RID: 14888 RVA: 0x0006F404 File Offset: 0x0006D604
		// (set) Token: 0x06003A29 RID: 14889 RVA: 0x0006F430 File Offset: 0x0006D630
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

		// Token: 0x170011D9 RID: 4569
		// (get) Token: 0x06003A2A RID: 14890 RVA: 0x0006F440 File Offset: 0x0006D640
		// (set) Token: 0x06003A2B RID: 14891 RVA: 0x0006F460 File Offset: 0x0006D660
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

		// Token: 0x06003A2C RID: 14892 RVA: 0x0006F4A4 File Offset: 0x0006D6A4
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003A2D RID: 14893 RVA: 0x0006F4BC File Offset: 0x0006D6BC
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06003A2E RID: 14894 RVA: 0x0006F4C8 File Offset: 0x0006D6C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E6C RID: 3692
		private uint? _type;

		// Token: 0x04000E6D RID: 3693
		private IExtension extensionObject;
	}
}
