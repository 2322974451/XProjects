using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004EB RID: 1259
	[ProtoContract(Name = "PayScoreData")]
	[Serializable]
	public class PayScoreData : IExtensible
	{
		// Token: 0x170013E6 RID: 5094
		// (get) Token: 0x0600410C RID: 16652 RVA: 0x0007BDB4 File Offset: 0x00079FB4
		// (set) Token: 0x0600410D RID: 16653 RVA: 0x0007BDE0 File Offset: 0x00079FE0
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

		// Token: 0x170013E7 RID: 5095
		// (get) Token: 0x0600410E RID: 16654 RVA: 0x0007BDF0 File Offset: 0x00079FF0
		// (set) Token: 0x0600410F RID: 16655 RVA: 0x0007BE10 File Offset: 0x0007A010
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

		// Token: 0x06004110 RID: 16656 RVA: 0x0007BE54 File Offset: 0x0007A054
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x06004111 RID: 16657 RVA: 0x0007BE6C File Offset: 0x0007A06C
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x06004112 RID: 16658 RVA: 0x0007BE78 File Offset: 0x0007A078
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001034 RID: 4148
		private uint? _score;

		// Token: 0x04001035 RID: 4149
		private IExtension extensionObject;
	}
}
