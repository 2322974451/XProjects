using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000102 RID: 258
	[ProtoContract(Name = "BuyTeamSceneCountP")]
	[Serializable]
	public class BuyTeamSceneCountP : IExtensible
	{
		// Token: 0x17000556 RID: 1366
		// (get) Token: 0x0600108D RID: 4237 RVA: 0x00021F00 File Offset: 0x00020100
		// (set) Token: 0x0600108E RID: 4238 RVA: 0x00021F2C File Offset: 0x0002012C
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public int type
		{
			get
			{
				return this._type ?? 0;
			}
			set
			{
				this._type = new int?(value);
			}
		}

		// Token: 0x17000557 RID: 1367
		// (get) Token: 0x0600108F RID: 4239 RVA: 0x00021F3C File Offset: 0x0002013C
		// (set) Token: 0x06001090 RID: 4240 RVA: 0x00021F5C File Offset: 0x0002015C
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
					this._type = (value ? new int?(this.type) : null);
				}
			}
		}

		// Token: 0x06001091 RID: 4241 RVA: 0x00021FA0 File Offset: 0x000201A0
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06001092 RID: 4242 RVA: 0x00021FB8 File Offset: 0x000201B8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06001093 RID: 4243 RVA: 0x00021FC4 File Offset: 0x000201C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000424 RID: 1060
		private int? _type;

		// Token: 0x04000425 RID: 1061
		private IExtension extensionObject;
	}
}
