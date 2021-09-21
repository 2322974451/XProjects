using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002C4 RID: 708
	[ProtoContract(Name = "KillEnemyScoreData")]
	[Serializable]
	public class KillEnemyScoreData : IExtensible
	{
		// Token: 0x17000C33 RID: 3123
		// (get) Token: 0x06002738 RID: 10040 RVA: 0x0004C458 File Offset: 0x0004A658
		// (set) Token: 0x06002739 RID: 10041 RVA: 0x0004C484 File Offset: 0x0004A684
		[ProtoMember(1, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public int score
		{
			get
			{
				return this._score ?? 0;
			}
			set
			{
				this._score = new int?(value);
			}
		}

		// Token: 0x17000C34 RID: 3124
		// (get) Token: 0x0600273A RID: 10042 RVA: 0x0004C494 File Offset: 0x0004A694
		// (set) Token: 0x0600273B RID: 10043 RVA: 0x0004C4B4 File Offset: 0x0004A6B4
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
					this._score = (value ? new int?(this.score) : null);
				}
			}
		}

		// Token: 0x0600273C RID: 10044 RVA: 0x0004C4F8 File Offset: 0x0004A6F8
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x0600273D RID: 10045 RVA: 0x0004C510 File Offset: 0x0004A710
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x0600273E RID: 10046 RVA: 0x0004C51C File Offset: 0x0004A71C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009C0 RID: 2496
		private int? _score;

		// Token: 0x040009C1 RID: 2497
		private IExtension extensionObject;
	}
}
