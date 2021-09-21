using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200035F RID: 863
	[ProtoContract(Name = "UpdateStartUpType")]
	[Serializable]
	public class UpdateStartUpType : IExtensible
	{
		// Token: 0x17000E9F RID: 3743
		// (get) Token: 0x06002F32 RID: 12082 RVA: 0x0005B1CC File Offset: 0x000593CC
		// (set) Token: 0x06002F33 RID: 12083 RVA: 0x0005B1F8 File Offset: 0x000593F8
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

		// Token: 0x17000EA0 RID: 3744
		// (get) Token: 0x06002F34 RID: 12084 RVA: 0x0005B208 File Offset: 0x00059408
		// (set) Token: 0x06002F35 RID: 12085 RVA: 0x0005B228 File Offset: 0x00059428
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

		// Token: 0x06002F36 RID: 12086 RVA: 0x0005B26C File Offset: 0x0005946C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06002F37 RID: 12087 RVA: 0x0005B284 File Offset: 0x00059484
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06002F38 RID: 12088 RVA: 0x0005B290 File Offset: 0x00059490
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BB4 RID: 2996
		private StartUpType? _type;

		// Token: 0x04000BB5 RID: 2997
		private IExtension extensionObject;
	}
}
