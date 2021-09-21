using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200007A RID: 122
	[ProtoContract(Name = "RemoveBlackListArg")]
	[Serializable]
	public class RemoveBlackListArg : IExtensible
	{
		// Token: 0x17000299 RID: 665
		// (get) Token: 0x06000807 RID: 2055 RVA: 0x00011E60 File Offset: 0x00010060
		// (set) Token: 0x06000808 RID: 2056 RVA: 0x00011E8D File Offset: 0x0001008D
		[ProtoMember(1, IsRequired = false, Name = "otherroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong otherroleid
		{
			get
			{
				return this._otherroleid ?? 0UL;
			}
			set
			{
				this._otherroleid = new ulong?(value);
			}
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x06000809 RID: 2057 RVA: 0x00011E9C File Offset: 0x0001009C
		// (set) Token: 0x0600080A RID: 2058 RVA: 0x00011EBC File Offset: 0x000100BC
		[XmlIgnore]
		[Browsable(false)]
		public bool otherroleidSpecified
		{
			get
			{
				return this._otherroleid != null;
			}
			set
			{
				bool flag = value == (this._otherroleid == null);
				if (flag)
				{
					this._otherroleid = (value ? new ulong?(this.otherroleid) : null);
				}
			}
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x00011F00 File Offset: 0x00010100
		private bool ShouldSerializeotherroleid()
		{
			return this.otherroleidSpecified;
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x00011F18 File Offset: 0x00010118
		private void Resetotherroleid()
		{
			this.otherroleidSpecified = false;
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x00011F24 File Offset: 0x00010124
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000207 RID: 519
		private ulong? _otherroleid;

		// Token: 0x04000208 RID: 520
		private IExtension extensionObject;
	}
}
