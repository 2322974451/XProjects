using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000633 RID: 1587
	[ProtoContract(Name = "RiskMapInfos")]
	[Serializable]
	public class RiskMapInfos : IExtensible
	{
		// Token: 0x17001EB1 RID: 7857
		// (get) Token: 0x06006184 RID: 24964 RVA: 0x000BA05C File Offset: 0x000B825C
		[ProtoMember(1, Name = "infos", DataFormat = DataFormat.Default)]
		public List<RiskOneMapInfo> infos
		{
			get
			{
				return this._infos;
			}
		}

		// Token: 0x17001EB2 RID: 7858
		// (get) Token: 0x06006185 RID: 24965 RVA: 0x000BA074 File Offset: 0x000B8274
		// (set) Token: 0x06006186 RID: 24966 RVA: 0x000BA0A0 File Offset: 0x000B82A0
		[ProtoMember(2, IsRequired = false, Name = "diceNum", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001EB3 RID: 7859
		// (get) Token: 0x06006187 RID: 24967 RVA: 0x000BA0B0 File Offset: 0x000B82B0
		// (set) Token: 0x06006188 RID: 24968 RVA: 0x000BA0D0 File Offset: 0x000B82D0
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

		// Token: 0x06006189 RID: 24969 RVA: 0x000BA114 File Offset: 0x000B8314
		private bool ShouldSerializediceNum()
		{
			return this.diceNumSpecified;
		}

		// Token: 0x0600618A RID: 24970 RVA: 0x000BA12C File Offset: 0x000B832C
		private void ResetdiceNum()
		{
			this.diceNumSpecified = false;
		}

		// Token: 0x17001EB4 RID: 7860
		// (get) Token: 0x0600618B RID: 24971 RVA: 0x000BA138 File Offset: 0x000B8338
		// (set) Token: 0x0600618C RID: 24972 RVA: 0x000BA164 File Offset: 0x000B8364
		[ProtoMember(3, IsRequired = false, Name = "leftDiceTime", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001EB5 RID: 7861
		// (get) Token: 0x0600618D RID: 24973 RVA: 0x000BA174 File Offset: 0x000B8374
		// (set) Token: 0x0600618E RID: 24974 RVA: 0x000BA194 File Offset: 0x000B8394
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

		// Token: 0x0600618F RID: 24975 RVA: 0x000BA1D8 File Offset: 0x000B83D8
		private bool ShouldSerializeleftDiceTime()
		{
			return this.leftDiceTimeSpecified;
		}

		// Token: 0x06006190 RID: 24976 RVA: 0x000BA1F0 File Offset: 0x000B83F0
		private void ResetleftDiceTime()
		{
			this.leftDiceTimeSpecified = false;
		}

		// Token: 0x17001EB6 RID: 7862
		// (get) Token: 0x06006191 RID: 24977 RVA: 0x000BA1FC File Offset: 0x000B83FC
		[ProtoMember(4, Name = "boxInfos", DataFormat = DataFormat.Default)]
		public List<RiskBoxInfo> boxInfos
		{
			get
			{
				return this._boxInfos;
			}
		}

		// Token: 0x06006192 RID: 24978 RVA: 0x000BA214 File Offset: 0x000B8414
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040017AB RID: 6059
		private readonly List<RiskOneMapInfo> _infos = new List<RiskOneMapInfo>();

		// Token: 0x040017AC RID: 6060
		private int? _diceNum;

		// Token: 0x040017AD RID: 6061
		private int? _leftDiceTime;

		// Token: 0x040017AE RID: 6062
		private readonly List<RiskBoxInfo> _boxInfos = new List<RiskBoxInfo>();

		// Token: 0x040017AF RID: 6063
		private IExtension extensionObject;
	}
}
