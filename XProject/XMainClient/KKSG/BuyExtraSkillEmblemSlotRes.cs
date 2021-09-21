using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000406 RID: 1030
	[ProtoContract(Name = "BuyExtraSkillEmblemSlotRes")]
	[Serializable]
	public class BuyExtraSkillEmblemSlotRes : IExtensible
	{
		// Token: 0x170010E0 RID: 4320
		// (get) Token: 0x060036DF RID: 14047 RVA: 0x000691D8 File Offset: 0x000673D8
		// (set) Token: 0x060036E0 RID: 14048 RVA: 0x00069204 File Offset: 0x00067404
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x170010E1 RID: 4321
		// (get) Token: 0x060036E1 RID: 14049 RVA: 0x00069214 File Offset: 0x00067414
		// (set) Token: 0x060036E2 RID: 14050 RVA: 0x00069234 File Offset: 0x00067434
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x060036E3 RID: 14051 RVA: 0x00069278 File Offset: 0x00067478
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060036E4 RID: 14052 RVA: 0x00069290 File Offset: 0x00067490
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x170010E2 RID: 4322
		// (get) Token: 0x060036E5 RID: 14053 RVA: 0x0006929C File Offset: 0x0006749C
		// (set) Token: 0x060036E6 RID: 14054 RVA: 0x000692C8 File Offset: 0x000674C8
		[ProtoMember(2, IsRequired = false, Name = "extraSkillEmblemSlot", DataFormat = DataFormat.TwosComplement)]
		public uint extraSkillEmblemSlot
		{
			get
			{
				return this._extraSkillEmblemSlot ?? 0U;
			}
			set
			{
				this._extraSkillEmblemSlot = new uint?(value);
			}
		}

		// Token: 0x170010E3 RID: 4323
		// (get) Token: 0x060036E7 RID: 14055 RVA: 0x000692D8 File Offset: 0x000674D8
		// (set) Token: 0x060036E8 RID: 14056 RVA: 0x000692F8 File Offset: 0x000674F8
		[XmlIgnore]
		[Browsable(false)]
		public bool extraSkillEmblemSlotSpecified
		{
			get
			{
				return this._extraSkillEmblemSlot != null;
			}
			set
			{
				bool flag = value == (this._extraSkillEmblemSlot == null);
				if (flag)
				{
					this._extraSkillEmblemSlot = (value ? new uint?(this.extraSkillEmblemSlot) : null);
				}
			}
		}

		// Token: 0x060036E9 RID: 14057 RVA: 0x0006933C File Offset: 0x0006753C
		private bool ShouldSerializeextraSkillEmblemSlot()
		{
			return this.extraSkillEmblemSlotSpecified;
		}

		// Token: 0x060036EA RID: 14058 RVA: 0x00069354 File Offset: 0x00067554
		private void ResetextraSkillEmblemSlot()
		{
			this.extraSkillEmblemSlotSpecified = false;
		}

		// Token: 0x060036EB RID: 14059 RVA: 0x00069360 File Offset: 0x00067560
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D9B RID: 3483
		private ErrorCode? _result;

		// Token: 0x04000D9C RID: 3484
		private uint? _extraSkillEmblemSlot;

		// Token: 0x04000D9D RID: 3485
		private IExtension extensionObject;
	}
}
