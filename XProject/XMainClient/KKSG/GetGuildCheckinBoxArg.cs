using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000B1 RID: 177
	[ProtoContract(Name = "GetGuildCheckinBoxArg")]
	[Serializable]
	public class GetGuildCheckinBoxArg : IExtensible
	{
		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x06000C2E RID: 3118 RVA: 0x00019C4C File Offset: 0x00017E4C
		// (set) Token: 0x06000C2F RID: 3119 RVA: 0x00019C78 File Offset: 0x00017E78
		[ProtoMember(1, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public uint index
		{
			get
			{
				return this._index ?? 0U;
			}
			set
			{
				this._index = new uint?(value);
			}
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x06000C30 RID: 3120 RVA: 0x00019C88 File Offset: 0x00017E88
		// (set) Token: 0x06000C31 RID: 3121 RVA: 0x00019CA8 File Offset: 0x00017EA8
		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new uint?(this.index) : null);
				}
			}
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x00019CEC File Offset: 0x00017EEC
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x00019D04 File Offset: 0x00017F04
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x00019D10 File Offset: 0x00017F10
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000305 RID: 773
		private uint? _index;

		// Token: 0x04000306 RID: 774
		private IExtension extensionObject;
	}
}
