using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000375 RID: 885
	[ProtoContract(Name = "GetLeagueTeamInfoRes")]
	[Serializable]
	public class GetLeagueTeamInfoRes : IExtensible
	{
		// Token: 0x17000EFA RID: 3834
		// (get) Token: 0x0600305E RID: 12382 RVA: 0x0005D568 File Offset: 0x0005B768
		// (set) Token: 0x0600305F RID: 12383 RVA: 0x0005D594 File Offset: 0x0005B794
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

		// Token: 0x17000EFB RID: 3835
		// (get) Token: 0x06003060 RID: 12384 RVA: 0x0005D5A4 File Offset: 0x0005B7A4
		// (set) Token: 0x06003061 RID: 12385 RVA: 0x0005D5C4 File Offset: 0x0005B7C4
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

		// Token: 0x06003062 RID: 12386 RVA: 0x0005D608 File Offset: 0x0005B808
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003063 RID: 12387 RVA: 0x0005D620 File Offset: 0x0005B820
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000EFC RID: 3836
		// (get) Token: 0x06003064 RID: 12388 RVA: 0x0005D62C File Offset: 0x0005B82C
		// (set) Token: 0x06003065 RID: 12389 RVA: 0x0005D644 File Offset: 0x0005B844
		[ProtoMember(2, IsRequired = false, Name = "team", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueTeamDetail team
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

		// Token: 0x06003066 RID: 12390 RVA: 0x0005D650 File Offset: 0x0005B850
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BFC RID: 3068
		private ErrorCode? _result;

		// Token: 0x04000BFD RID: 3069
		private LeagueTeamDetail _team = null;

		// Token: 0x04000BFE RID: 3070
		private IExtension extensionObject;
	}
}
