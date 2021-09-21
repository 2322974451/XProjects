using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003E7 RID: 999
	[ProtoContract(Name = "GetSkyCraftTeamInfoRes")]
	[Serializable]
	public class GetSkyCraftTeamInfoRes : IExtensible
	{
		// Token: 0x1700105B RID: 4187
		// (get) Token: 0x06003529 RID: 13609 RVA: 0x00065E7C File Offset: 0x0006407C
		// (set) Token: 0x0600352A RID: 13610 RVA: 0x00065EA8 File Offset: 0x000640A8
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

		// Token: 0x1700105C RID: 4188
		// (get) Token: 0x0600352B RID: 13611 RVA: 0x00065EB8 File Offset: 0x000640B8
		// (set) Token: 0x0600352C RID: 13612 RVA: 0x00065ED8 File Offset: 0x000640D8
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

		// Token: 0x0600352D RID: 13613 RVA: 0x00065F1C File Offset: 0x0006411C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600352E RID: 13614 RVA: 0x00065F34 File Offset: 0x00064134
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700105D RID: 4189
		// (get) Token: 0x0600352F RID: 13615 RVA: 0x00065F40 File Offset: 0x00064140
		// (set) Token: 0x06003530 RID: 13616 RVA: 0x00065F58 File Offset: 0x00064158
		[ProtoMember(2, IsRequired = false, Name = "team", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SkyTeamDetail team
		{
			get
			{
				return this._team;
			}
			set
			{
				this._team = value;
			}
		}

		// Token: 0x06003531 RID: 13617 RVA: 0x00065F64 File Offset: 0x00064164
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D33 RID: 3379
		private ErrorCode? _result;

		// Token: 0x04000D34 RID: 3380
		private SkyTeamDetail _team = null;

		// Token: 0x04000D35 RID: 3381
		private IExtension extensionObject;
	}
}
