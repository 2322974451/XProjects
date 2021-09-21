using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000AB RID: 171
	[ProtoContract(Name = "GuildFatigueArg")]
	[Serializable]
	public class GuildFatigueArg : IExtensible
	{
		// Token: 0x170003DE RID: 990
		// (get) Token: 0x06000BDA RID: 3034 RVA: 0x0001925C File Offset: 0x0001745C
		// (set) Token: 0x06000BDB RID: 3035 RVA: 0x00019288 File Offset: 0x00017488
		[ProtoMember(1, IsRequired = false, Name = "optype", DataFormat = DataFormat.TwosComplement)]
		public int optype
		{
			get
			{
				return this._optype ?? 0;
			}
			set
			{
				this._optype = new int?(value);
			}
		}

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x06000BDC RID: 3036 RVA: 0x00019298 File Offset: 0x00017498
		// (set) Token: 0x06000BDD RID: 3037 RVA: 0x000192B8 File Offset: 0x000174B8
		[XmlIgnore]
		[Browsable(false)]
		public bool optypeSpecified
		{
			get
			{
				return this._optype != null;
			}
			set
			{
				bool flag = value == (this._optype == null);
				if (flag)
				{
					this._optype = (value ? new int?(this.optype) : null);
				}
			}
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x000192FC File Offset: 0x000174FC
		private bool ShouldSerializeoptype()
		{
			return this.optypeSpecified;
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x00019314 File Offset: 0x00017514
		private void Resetoptype()
		{
			this.optypeSpecified = false;
		}

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x06000BE0 RID: 3040 RVA: 0x00019320 File Offset: 0x00017520
		// (set) Token: 0x06000BE1 RID: 3041 RVA: 0x0001934D File Offset: 0x0001754D
		[ProtoMember(2, IsRequired = false, Name = "targetID", DataFormat = DataFormat.TwosComplement)]
		public ulong targetID
		{
			get
			{
				return this._targetID ?? 0UL;
			}
			set
			{
				this._targetID = new ulong?(value);
			}
		}

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x06000BE2 RID: 3042 RVA: 0x0001935C File Offset: 0x0001755C
		// (set) Token: 0x06000BE3 RID: 3043 RVA: 0x0001937C File Offset: 0x0001757C
		[XmlIgnore]
		[Browsable(false)]
		public bool targetIDSpecified
		{
			get
			{
				return this._targetID != null;
			}
			set
			{
				bool flag = value == (this._targetID == null);
				if (flag)
				{
					this._targetID = (value ? new ulong?(this.targetID) : null);
				}
			}
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x000193C0 File Offset: 0x000175C0
		private bool ShouldSerializetargetID()
		{
			return this.targetIDSpecified;
		}

		// Token: 0x06000BE5 RID: 3045 RVA: 0x000193D8 File Offset: 0x000175D8
		private void ResettargetID()
		{
			this.targetIDSpecified = false;
		}

		// Token: 0x06000BE6 RID: 3046 RVA: 0x000193E4 File Offset: 0x000175E4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002F3 RID: 755
		private int? _optype;

		// Token: 0x040002F4 RID: 756
		private ulong? _targetID;

		// Token: 0x040002F5 RID: 757
		private IExtension extensionObject;
	}
}
