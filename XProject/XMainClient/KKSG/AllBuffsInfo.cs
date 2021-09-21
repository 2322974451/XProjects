using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200057B RID: 1403
	[ProtoContract(Name = "AllBuffsInfo")]
	[Serializable]
	public class AllBuffsInfo : IExtensible
	{
		// Token: 0x1700162B RID: 5675
		// (get) Token: 0x06004858 RID: 18520 RVA: 0x000896D0 File Offset: 0x000878D0
		// (set) Token: 0x06004859 RID: 18521 RVA: 0x000896FC File Offset: 0x000878FC
		[ProtoMember(1, IsRequired = false, Name = "BuffState", DataFormat = DataFormat.TwosComplement)]
		public uint BuffState
		{
			get
			{
				return this._BuffState ?? 0U;
			}
			set
			{
				this._BuffState = new uint?(value);
			}
		}

		// Token: 0x1700162C RID: 5676
		// (get) Token: 0x0600485A RID: 18522 RVA: 0x0008970C File Offset: 0x0008790C
		// (set) Token: 0x0600485B RID: 18523 RVA: 0x0008972C File Offset: 0x0008792C
		[XmlIgnore]
		[Browsable(false)]
		public bool BuffStateSpecified
		{
			get
			{
				return this._BuffState != null;
			}
			set
			{
				bool flag = value == (this._BuffState == null);
				if (flag)
				{
					this._BuffState = (value ? new uint?(this.BuffState) : null);
				}
			}
		}

		// Token: 0x0600485C RID: 18524 RVA: 0x00089770 File Offset: 0x00087970
		private bool ShouldSerializeBuffState()
		{
			return this.BuffStateSpecified;
		}

		// Token: 0x0600485D RID: 18525 RVA: 0x00089788 File Offset: 0x00087988
		private void ResetBuffState()
		{
			this.BuffStateSpecified = false;
		}

		// Token: 0x1700162D RID: 5677
		// (get) Token: 0x0600485E RID: 18526 RVA: 0x00089794 File Offset: 0x00087994
		[ProtoMember(2, Name = "StateParamIndex", DataFormat = DataFormat.TwosComplement)]
		public List<int> StateParamIndex
		{
			get
			{
				return this._StateParamIndex;
			}
		}

		// Token: 0x1700162E RID: 5678
		// (get) Token: 0x0600485F RID: 18527 RVA: 0x000897AC File Offset: 0x000879AC
		[ProtoMember(3, Name = "StateParamValues", DataFormat = DataFormat.TwosComplement)]
		public List<int> StateParamValues
		{
			get
			{
				return this._StateParamValues;
			}
		}

		// Token: 0x06004860 RID: 18528 RVA: 0x000897C4 File Offset: 0x000879C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001217 RID: 4631
		private uint? _BuffState;

		// Token: 0x04001218 RID: 4632
		private readonly List<int> _StateParamIndex = new List<int>();

		// Token: 0x04001219 RID: 4633
		private readonly List<int> _StateParamValues = new List<int>();

		// Token: 0x0400121A RID: 4634
		private IExtension extensionObject;
	}
}
