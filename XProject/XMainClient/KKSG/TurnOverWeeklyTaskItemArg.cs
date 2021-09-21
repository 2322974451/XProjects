using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004EE RID: 1262
	[ProtoContract(Name = "TurnOverWeeklyTaskItemArg")]
	[Serializable]
	public class TurnOverWeeklyTaskItemArg : IExtensible
	{
		// Token: 0x170013EB RID: 5099
		// (get) Token: 0x0600411F RID: 16671 RVA: 0x0007BFDC File Offset: 0x0007A1DC
		// (set) Token: 0x06004120 RID: 16672 RVA: 0x0007C008 File Offset: 0x0007A208
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

		// Token: 0x170013EC RID: 5100
		// (get) Token: 0x06004121 RID: 16673 RVA: 0x0007C018 File Offset: 0x0007A218
		// (set) Token: 0x06004122 RID: 16674 RVA: 0x0007C038 File Offset: 0x0007A238
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

		// Token: 0x06004123 RID: 16675 RVA: 0x0007C07C File Offset: 0x0007A27C
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06004124 RID: 16676 RVA: 0x0007C094 File Offset: 0x0007A294
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x170013ED RID: 5101
		// (get) Token: 0x06004125 RID: 16677 RVA: 0x0007C0A0 File Offset: 0x0007A2A0
		[ProtoMember(2, Name = "itemuid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> itemuid
		{
			get
			{
				return this._itemuid;
			}
		}

		// Token: 0x06004126 RID: 16678 RVA: 0x0007C0B8 File Offset: 0x0007A2B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400103A RID: 4154
		private uint? _index;

		// Token: 0x0400103B RID: 4155
		private readonly List<ulong> _itemuid = new List<ulong>();

		// Token: 0x0400103C RID: 4156
		private IExtension extensionObject;
	}
}
