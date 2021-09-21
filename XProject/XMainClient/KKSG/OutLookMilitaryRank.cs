using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000578 RID: 1400
	[ProtoContract(Name = "OutLookMilitaryRank")]
	[Serializable]
	public class OutLookMilitaryRank : IExtensible
	{
		// Token: 0x17001621 RID: 5665
		// (get) Token: 0x06004838 RID: 18488 RVA: 0x000892E8 File Offset: 0x000874E8
		// (set) Token: 0x06004839 RID: 18489 RVA: 0x00089314 File Offset: 0x00087514
		[ProtoMember(1, IsRequired = false, Name = "military_rank", DataFormat = DataFormat.TwosComplement)]
		public uint military_rank
		{
			get
			{
				return this._military_rank ?? 0U;
			}
			set
			{
				this._military_rank = new uint?(value);
			}
		}

		// Token: 0x17001622 RID: 5666
		// (get) Token: 0x0600483A RID: 18490 RVA: 0x00089324 File Offset: 0x00087524
		// (set) Token: 0x0600483B RID: 18491 RVA: 0x00089344 File Offset: 0x00087544
		[XmlIgnore]
		[Browsable(false)]
		public bool military_rankSpecified
		{
			get
			{
				return this._military_rank != null;
			}
			set
			{
				bool flag = value == (this._military_rank == null);
				if (flag)
				{
					this._military_rank = (value ? new uint?(this.military_rank) : null);
				}
			}
		}

		// Token: 0x0600483C RID: 18492 RVA: 0x00089388 File Offset: 0x00087588
		private bool ShouldSerializemilitary_rank()
		{
			return this.military_rankSpecified;
		}

		// Token: 0x0600483D RID: 18493 RVA: 0x000893A0 File Offset: 0x000875A0
		private void Resetmilitary_rank()
		{
			this.military_rankSpecified = false;
		}

		// Token: 0x0600483E RID: 18494 RVA: 0x000893AC File Offset: 0x000875AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400120E RID: 4622
		private uint? _military_rank;

		// Token: 0x0400120F RID: 4623
		private IExtension extensionObject;
	}
}
