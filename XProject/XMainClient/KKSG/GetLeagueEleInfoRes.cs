using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003A0 RID: 928
	[ProtoContract(Name = "GetLeagueEleInfoRes")]
	[Serializable]
	public class GetLeagueEleInfoRes : IExtensible
	{
		// Token: 0x17000F76 RID: 3958
		// (get) Token: 0x06003211 RID: 12817 RVA: 0x00060670 File Offset: 0x0005E870
		// (set) Token: 0x06003212 RID: 12818 RVA: 0x0006069C File Offset: 0x0005E89C
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

		// Token: 0x17000F77 RID: 3959
		// (get) Token: 0x06003213 RID: 12819 RVA: 0x000606AC File Offset: 0x0005E8AC
		// (set) Token: 0x06003214 RID: 12820 RVA: 0x000606CC File Offset: 0x0005E8CC
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

		// Token: 0x06003215 RID: 12821 RVA: 0x00060710 File Offset: 0x0005E910
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003216 RID: 12822 RVA: 0x00060728 File Offset: 0x0005E928
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000F78 RID: 3960
		// (get) Token: 0x06003217 RID: 12823 RVA: 0x00060734 File Offset: 0x0005E934
		[ProtoMember(2, Name = "rounds", DataFormat = DataFormat.Default)]
		public List<LBEleRoundInfo> rounds
		{
			get
			{
				return this._rounds;
			}
		}

		// Token: 0x17000F79 RID: 3961
		// (get) Token: 0x06003218 RID: 12824 RVA: 0x0006074C File Offset: 0x0005E94C
		// (set) Token: 0x06003219 RID: 12825 RVA: 0x00060764 File Offset: 0x0005E964
		[ProtoMember(3, IsRequired = false, Name = "chamption", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueTeamDetail chamption
		{
			get
			{
				return this._chamption;
			}
			set
			{
				this._chamption = value;
			}
		}

		// Token: 0x0600321A RID: 12826 RVA: 0x00060770 File Offset: 0x0005E970
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C6D RID: 3181
		private ErrorCode? _result;

		// Token: 0x04000C6E RID: 3182
		private readonly List<LBEleRoundInfo> _rounds = new List<LBEleRoundInfo>();

		// Token: 0x04000C6F RID: 3183
		private LeagueTeamDetail _chamption = null;

		// Token: 0x04000C70 RID: 3184
		private IExtension extensionObject;
	}
}
