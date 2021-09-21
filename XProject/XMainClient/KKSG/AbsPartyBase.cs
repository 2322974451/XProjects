using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005F1 RID: 1521
	[ProtoContract(Name = "AbsPartyBase")]
	[Serializable]
	public class AbsPartyBase : IExtensible
	{
		// Token: 0x17001C44 RID: 7236
		// (get) Token: 0x06005A6B RID: 23147 RVA: 0x000AC234 File Offset: 0x000AA434
		// (set) Token: 0x06005A6C RID: 23148 RVA: 0x000AC260 File Offset: 0x000AA460
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

		// Token: 0x17001C45 RID: 7237
		// (get) Token: 0x06005A6D RID: 23149 RVA: 0x000AC270 File Offset: 0x000AA470
		// (set) Token: 0x06005A6E RID: 23150 RVA: 0x000AC290 File Offset: 0x000AA490
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

		// Token: 0x06005A6F RID: 23151 RVA: 0x000AC2D4 File Offset: 0x000AA4D4
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06005A70 RID: 23152 RVA: 0x000AC2EC File Offset: 0x000AA4EC
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001C46 RID: 7238
		// (get) Token: 0x06005A71 RID: 23153 RVA: 0x000AC2F8 File Offset: 0x000AA4F8
		// (set) Token: 0x06005A72 RID: 23154 RVA: 0x000AC324 File Offset: 0x000AA524
		[ProtoMember(2, IsRequired = false, Name = "diff", DataFormat = DataFormat.TwosComplement)]
		public uint diff
		{
			get
			{
				return this._diff ?? 0U;
			}
			set
			{
				this._diff = new uint?(value);
			}
		}

		// Token: 0x17001C47 RID: 7239
		// (get) Token: 0x06005A73 RID: 23155 RVA: 0x000AC334 File Offset: 0x000AA534
		// (set) Token: 0x06005A74 RID: 23156 RVA: 0x000AC354 File Offset: 0x000AA554
		[XmlIgnore]
		[Browsable(false)]
		public bool diffSpecified
		{
			get
			{
				return this._diff != null;
			}
			set
			{
				bool flag = value == (this._diff == null);
				if (flag)
				{
					this._diff = (value ? new uint?(this.diff) : null);
				}
			}
		}

		// Token: 0x06005A75 RID: 23157 RVA: 0x000AC398 File Offset: 0x000AA598
		private bool ShouldSerializediff()
		{
			return this.diffSpecified;
		}

		// Token: 0x06005A76 RID: 23158 RVA: 0x000AC3B0 File Offset: 0x000AA5B0
		private void Resetdiff()
		{
			this.diffSpecified = false;
		}

		// Token: 0x06005A77 RID: 23159 RVA: 0x000AC3BC File Offset: 0x000AA5BC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001601 RID: 5633
		private uint? _type;

		// Token: 0x04001602 RID: 5634
		private uint? _diff;

		// Token: 0x04001603 RID: 5635
		private IExtension extensionObject;
	}
}
