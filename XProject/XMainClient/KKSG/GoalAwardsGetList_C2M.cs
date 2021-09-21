using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004D3 RID: 1235
	[ProtoContract(Name = "GoalAwardsGetList_C2M")]
	[Serializable]
	public class GoalAwardsGetList_C2M : IExtensible
	{
		// Token: 0x1700139B RID: 5019
		// (get) Token: 0x0600400C RID: 16396 RVA: 0x00079FEC File Offset: 0x000781EC
		// (set) Token: 0x0600400D RID: 16397 RVA: 0x0007A018 File Offset: 0x00078218
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

		// Token: 0x1700139C RID: 5020
		// (get) Token: 0x0600400E RID: 16398 RVA: 0x0007A028 File Offset: 0x00078228
		// (set) Token: 0x0600400F RID: 16399 RVA: 0x0007A048 File Offset: 0x00078248
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

		// Token: 0x06004010 RID: 16400 RVA: 0x0007A08C File Offset: 0x0007828C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06004011 RID: 16401 RVA: 0x0007A0A4 File Offset: 0x000782A4
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06004012 RID: 16402 RVA: 0x0007A0B0 File Offset: 0x000782B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FF2 RID: 4082
		private uint? _type;

		// Token: 0x04000FF3 RID: 4083
		private IExtension extensionObject;
	}
}
