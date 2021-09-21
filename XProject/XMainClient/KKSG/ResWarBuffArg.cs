using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002F1 RID: 753
	[ProtoContract(Name = "ResWarBuffArg")]
	[Serializable]
	public class ResWarBuffArg : IExtensible
	{
		// Token: 0x17000CDB RID: 3291
		// (get) Token: 0x06002969 RID: 10601 RVA: 0x000505FC File Offset: 0x0004E7FC
		// (set) Token: 0x0600296A RID: 10602 RVA: 0x00050628 File Offset: 0x0004E828
		[ProtoMember(1, IsRequired = false, Name = "nParam", DataFormat = DataFormat.TwosComplement)]
		public uint nParam
		{
			get
			{
				return this._nParam ?? 0U;
			}
			set
			{
				this._nParam = new uint?(value);
			}
		}

		// Token: 0x17000CDC RID: 3292
		// (get) Token: 0x0600296B RID: 10603 RVA: 0x00050638 File Offset: 0x0004E838
		// (set) Token: 0x0600296C RID: 10604 RVA: 0x00050658 File Offset: 0x0004E858
		[XmlIgnore]
		[Browsable(false)]
		public bool nParamSpecified
		{
			get
			{
				return this._nParam != null;
			}
			set
			{
				bool flag = value == (this._nParam == null);
				if (flag)
				{
					this._nParam = (value ? new uint?(this.nParam) : null);
				}
			}
		}

		// Token: 0x0600296D RID: 10605 RVA: 0x0005069C File Offset: 0x0004E89C
		private bool ShouldSerializenParam()
		{
			return this.nParamSpecified;
		}

		// Token: 0x0600296E RID: 10606 RVA: 0x000506B4 File Offset: 0x0004E8B4
		private void ResetnParam()
		{
			this.nParamSpecified = false;
		}

		// Token: 0x0600296F RID: 10607 RVA: 0x000506C0 File Offset: 0x0004E8C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A4A RID: 2634
		private uint? _nParam;

		// Token: 0x04000A4B RID: 2635
		private IExtension extensionObject;
	}
}
