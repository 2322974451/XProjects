using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200057A RID: 1402
	[ProtoContract(Name = "OutLookConsumePre")]
	[Serializable]
	public class OutLookConsumePre : IExtensible
	{
		// Token: 0x17001628 RID: 5672
		// (get) Token: 0x0600484F RID: 18511 RVA: 0x000895B4 File Offset: 0x000877B4
		// (set) Token: 0x06004850 RID: 18512 RVA: 0x000895E0 File Offset: 0x000877E0
		[ProtoMember(1, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		// Token: 0x17001629 RID: 5673
		// (get) Token: 0x06004851 RID: 18513 RVA: 0x000895F0 File Offset: 0x000877F0
		// (set) Token: 0x06004852 RID: 18514 RVA: 0x00089610 File Offset: 0x00087810
		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		// Token: 0x06004853 RID: 18515 RVA: 0x00089654 File Offset: 0x00087854
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x06004854 RID: 18516 RVA: 0x0008966C File Offset: 0x0008786C
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x1700162A RID: 5674
		// (get) Token: 0x06004855 RID: 18517 RVA: 0x00089678 File Offset: 0x00087878
		[ProtoMember(2, Name = "setid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> setid
		{
			get
			{
				return this._setid;
			}
		}

		// Token: 0x06004856 RID: 18518 RVA: 0x00089690 File Offset: 0x00087890
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001214 RID: 4628
		private uint? _score;

		// Token: 0x04001215 RID: 4629
		private readonly List<uint> _setid = new List<uint>();

		// Token: 0x04001216 RID: 4630
		private IExtension extensionObject;
	}
}
