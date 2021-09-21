using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200021F RID: 543
	[ProtoContract(Name = "RiskRecoverDiceData")]
	[Serializable]
	public class RiskRecoverDiceData : IExtensible
	{
		// Token: 0x17000974 RID: 2420
		// (get) Token: 0x06001E42 RID: 7746 RVA: 0x0003B69C File Offset: 0x0003989C
		// (set) Token: 0x06001E43 RID: 7747 RVA: 0x0003B6C8 File Offset: 0x000398C8
		[ProtoMember(1, IsRequired = false, Name = "diceNum", DataFormat = DataFormat.TwosComplement)]
		public int diceNum
		{
			get
			{
				return this._diceNum ?? 0;
			}
			set
			{
				this._diceNum = new int?(value);
			}
		}

		// Token: 0x17000975 RID: 2421
		// (get) Token: 0x06001E44 RID: 7748 RVA: 0x0003B6D8 File Offset: 0x000398D8
		// (set) Token: 0x06001E45 RID: 7749 RVA: 0x0003B6F8 File Offset: 0x000398F8
		[XmlIgnore]
		[Browsable(false)]
		public bool diceNumSpecified
		{
			get
			{
				return this._diceNum != null;
			}
			set
			{
				bool flag = value == (this._diceNum == null);
				if (flag)
				{
					this._diceNum = (value ? new int?(this.diceNum) : null);
				}
			}
		}

		// Token: 0x06001E46 RID: 7750 RVA: 0x0003B73C File Offset: 0x0003993C
		private bool ShouldSerializediceNum()
		{
			return this.diceNumSpecified;
		}

		// Token: 0x06001E47 RID: 7751 RVA: 0x0003B754 File Offset: 0x00039954
		private void ResetdiceNum()
		{
			this.diceNumSpecified = false;
		}

		// Token: 0x17000976 RID: 2422
		// (get) Token: 0x06001E48 RID: 7752 RVA: 0x0003B760 File Offset: 0x00039960
		// (set) Token: 0x06001E49 RID: 7753 RVA: 0x0003B78C File Offset: 0x0003998C
		[ProtoMember(2, IsRequired = false, Name = "leftDiceTime", DataFormat = DataFormat.TwosComplement)]
		public int leftDiceTime
		{
			get
			{
				return this._leftDiceTime ?? 0;
			}
			set
			{
				this._leftDiceTime = new int?(value);
			}
		}

		// Token: 0x17000977 RID: 2423
		// (get) Token: 0x06001E4A RID: 7754 RVA: 0x0003B79C File Offset: 0x0003999C
		// (set) Token: 0x06001E4B RID: 7755 RVA: 0x0003B7BC File Offset: 0x000399BC
		[XmlIgnore]
		[Browsable(false)]
		public bool leftDiceTimeSpecified
		{
			get
			{
				return this._leftDiceTime != null;
			}
			set
			{
				bool flag = value == (this._leftDiceTime == null);
				if (flag)
				{
					this._leftDiceTime = (value ? new int?(this.leftDiceTime) : null);
				}
			}
		}

		// Token: 0x06001E4C RID: 7756 RVA: 0x0003B800 File Offset: 0x00039A00
		private bool ShouldSerializeleftDiceTime()
		{
			return this.leftDiceTimeSpecified;
		}

		// Token: 0x06001E4D RID: 7757 RVA: 0x0003B818 File Offset: 0x00039A18
		private void ResetleftDiceTime()
		{
			this.leftDiceTimeSpecified = false;
		}

		// Token: 0x06001E4E RID: 7758 RVA: 0x0003B824 File Offset: 0x00039A24
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000793 RID: 1939
		private int? _diceNum;

		// Token: 0x04000794 RID: 1940
		private int? _leftDiceTime;

		// Token: 0x04000795 RID: 1941
		private IExtension extensionObject;
	}
}
