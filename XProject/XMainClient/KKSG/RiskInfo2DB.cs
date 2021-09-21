using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000632 RID: 1586
	[ProtoContract(Name = "RiskInfo2DB")]
	[Serializable]
	public class RiskInfo2DB : IExtensible
	{
		// Token: 0x17001EA9 RID: 7849
		// (get) Token: 0x0600616C RID: 24940 RVA: 0x000B9D88 File Offset: 0x000B7F88
		// (set) Token: 0x0600616D RID: 24941 RVA: 0x000B9DA0 File Offset: 0x000B7FA0
		[ProtoMember(1, IsRequired = false, Name = "infos", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RiskMapInfos infos
		{
			get
			{
				return this._infos;
			}
			set
			{
				this._infos = value;
			}
		}

		// Token: 0x17001EAA RID: 7850
		// (get) Token: 0x0600616E RID: 24942 RVA: 0x000B9DAC File Offset: 0x000B7FAC
		// (set) Token: 0x0600616F RID: 24943 RVA: 0x000B9DD8 File Offset: 0x000B7FD8
		[ProtoMember(2, IsRequired = false, Name = "updatetime", DataFormat = DataFormat.TwosComplement)]
		public int updatetime
		{
			get
			{
				return this._updatetime ?? 0;
			}
			set
			{
				this._updatetime = new int?(value);
			}
		}

		// Token: 0x17001EAB RID: 7851
		// (get) Token: 0x06006170 RID: 24944 RVA: 0x000B9DE8 File Offset: 0x000B7FE8
		// (set) Token: 0x06006171 RID: 24945 RVA: 0x000B9E08 File Offset: 0x000B8008
		[XmlIgnore]
		[Browsable(false)]
		public bool updatetimeSpecified
		{
			get
			{
				return this._updatetime != null;
			}
			set
			{
				bool flag = value == (this._updatetime == null);
				if (flag)
				{
					this._updatetime = (value ? new int?(this.updatetime) : null);
				}
			}
		}

		// Token: 0x06006172 RID: 24946 RVA: 0x000B9E4C File Offset: 0x000B804C
		private bool ShouldSerializeupdatetime()
		{
			return this.updatetimeSpecified;
		}

		// Token: 0x06006173 RID: 24947 RVA: 0x000B9E64 File Offset: 0x000B8064
		private void Resetupdatetime()
		{
			this.updatetimeSpecified = false;
		}

		// Token: 0x17001EAC RID: 7852
		// (get) Token: 0x06006174 RID: 24948 RVA: 0x000B9E70 File Offset: 0x000B8070
		// (set) Token: 0x06006175 RID: 24949 RVA: 0x000B9E9C File Offset: 0x000B809C
		[ProtoMember(3, IsRequired = false, Name = "getDiceTime", DataFormat = DataFormat.TwosComplement)]
		public int getDiceTime
		{
			get
			{
				return this._getDiceTime ?? 0;
			}
			set
			{
				this._getDiceTime = new int?(value);
			}
		}

		// Token: 0x17001EAD RID: 7853
		// (get) Token: 0x06006176 RID: 24950 RVA: 0x000B9EAC File Offset: 0x000B80AC
		// (set) Token: 0x06006177 RID: 24951 RVA: 0x000B9ECC File Offset: 0x000B80CC
		[XmlIgnore]
		[Browsable(false)]
		public bool getDiceTimeSpecified
		{
			get
			{
				return this._getDiceTime != null;
			}
			set
			{
				bool flag = value == (this._getDiceTime == null);
				if (flag)
				{
					this._getDiceTime = (value ? new int?(this.getDiceTime) : null);
				}
			}
		}

		// Token: 0x06006178 RID: 24952 RVA: 0x000B9F10 File Offset: 0x000B8110
		private bool ShouldSerializegetDiceTime()
		{
			return this.getDiceTimeSpecified;
		}

		// Token: 0x06006179 RID: 24953 RVA: 0x000B9F28 File Offset: 0x000B8128
		private void ResetgetDiceTime()
		{
			this.getDiceTimeSpecified = false;
		}

		// Token: 0x17001EAE RID: 7854
		// (get) Token: 0x0600617A RID: 24954 RVA: 0x000B9F34 File Offset: 0x000B8134
		// (set) Token: 0x0600617B RID: 24955 RVA: 0x000B9F60 File Offset: 0x000B8160
		[ProtoMember(4, IsRequired = false, Name = "getDiceNum", DataFormat = DataFormat.TwosComplement)]
		public int getDiceNum
		{
			get
			{
				return this._getDiceNum ?? 0;
			}
			set
			{
				this._getDiceNum = new int?(value);
			}
		}

		// Token: 0x17001EAF RID: 7855
		// (get) Token: 0x0600617C RID: 24956 RVA: 0x000B9F70 File Offset: 0x000B8170
		// (set) Token: 0x0600617D RID: 24957 RVA: 0x000B9F90 File Offset: 0x000B8190
		[XmlIgnore]
		[Browsable(false)]
		public bool getDiceNumSpecified
		{
			get
			{
				return this._getDiceNum != null;
			}
			set
			{
				bool flag = value == (this._getDiceNum == null);
				if (flag)
				{
					this._getDiceNum = (value ? new int?(this.getDiceNum) : null);
				}
			}
		}

		// Token: 0x0600617E RID: 24958 RVA: 0x000B9FD4 File Offset: 0x000B81D4
		private bool ShouldSerializegetDiceNum()
		{
			return this.getDiceNumSpecified;
		}

		// Token: 0x0600617F RID: 24959 RVA: 0x000B9FEC File Offset: 0x000B81EC
		private void ResetgetDiceNum()
		{
			this.getDiceNumSpecified = false;
		}

		// Token: 0x17001EB0 RID: 7856
		// (get) Token: 0x06006180 RID: 24960 RVA: 0x000B9FF8 File Offset: 0x000B81F8
		// (set) Token: 0x06006181 RID: 24961 RVA: 0x000BA010 File Offset: 0x000B8210
		[ProtoMember(5, IsRequired = false, Name = "riskInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleRiskInfo riskInfo
		{
			get
			{
				return this._riskInfo;
			}
			set
			{
				this._riskInfo = value;
			}
		}

		// Token: 0x06006182 RID: 24962 RVA: 0x000BA01C File Offset: 0x000B821C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040017A5 RID: 6053
		private RiskMapInfos _infos = null;

		// Token: 0x040017A6 RID: 6054
		private int? _updatetime;

		// Token: 0x040017A7 RID: 6055
		private int? _getDiceTime;

		// Token: 0x040017A8 RID: 6056
		private int? _getDiceNum;

		// Token: 0x040017A9 RID: 6057
		private RoleRiskInfo _riskInfo = null;

		// Token: 0x040017AA RID: 6058
		private IExtension extensionObject;
	}
}
