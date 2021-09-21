using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200005E RID: 94
	[ProtoContract(Name = "FetchTeamListRes")]
	[Serializable]
	public class FetchTeamListRes : IExtensible
	{
		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000628 RID: 1576 RVA: 0x0000E76C File Offset: 0x0000C96C
		[ProtoMember(1, Name = "teams", DataFormat = DataFormat.Default)]
		public List<TeamBrief> teams
		{
			get
			{
				return this._teams;
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000629 RID: 1577 RVA: 0x0000E784 File Offset: 0x0000C984
		[ProtoMember(2, Name = "TheTeams", DataFormat = DataFormat.Default)]
		public List<TeamFullDataNtf> TheTeams
		{
			get
			{
				return this._TheTeams;
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x0600062A RID: 1578 RVA: 0x0000E79C File Offset: 0x0000C99C
		// (set) Token: 0x0600062B RID: 1579 RVA: 0x0000E7C8 File Offset: 0x0000C9C8
		[ProtoMember(3, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x0600062C RID: 1580 RVA: 0x0000E7D8 File Offset: 0x0000C9D8
		// (set) Token: 0x0600062D RID: 1581 RVA: 0x0000E7F8 File Offset: 0x0000C9F8
		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0000E83C File Offset: 0x0000CA3C
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x0000E854 File Offset: 0x0000CA54
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0000E860 File Offset: 0x0000CA60
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000191 RID: 401
		private readonly List<TeamBrief> _teams = new List<TeamBrief>();

		// Token: 0x04000192 RID: 402
		private readonly List<TeamFullDataNtf> _TheTeams = new List<TeamFullDataNtf>();

		// Token: 0x04000193 RID: 403
		private ErrorCode? _errcode;

		// Token: 0x04000194 RID: 404
		private IExtension extensionObject;
	}
}
