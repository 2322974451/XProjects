using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003A6 RID: 934
	[ProtoContract(Name = "PersonalCareerRes")]
	[Serializable]
	public class PersonalCareerRes : IExtensible
	{
		// Token: 0x17000F81 RID: 3969
		// (get) Token: 0x0600323A RID: 12858 RVA: 0x00060AD8 File Offset: 0x0005ECD8
		// (set) Token: 0x0600323B RID: 12859 RVA: 0x00060B04 File Offset: 0x0005ED04
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

		// Token: 0x17000F82 RID: 3970
		// (get) Token: 0x0600323C RID: 12860 RVA: 0x00060B14 File Offset: 0x0005ED14
		// (set) Token: 0x0600323D RID: 12861 RVA: 0x00060B34 File Offset: 0x0005ED34
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

		// Token: 0x0600323E RID: 12862 RVA: 0x00060B78 File Offset: 0x0005ED78
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600323F RID: 12863 RVA: 0x00060B90 File Offset: 0x0005ED90
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000F83 RID: 3971
		// (get) Token: 0x06003240 RID: 12864 RVA: 0x00060B9C File Offset: 0x0005ED9C
		// (set) Token: 0x06003241 RID: 12865 RVA: 0x00060BB4 File Offset: 0x0005EDB4
		[ProtoMember(2, IsRequired = false, Name = "home_page", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PersonalHomePage home_page
		{
			get
			{
				return this._home_page;
			}
			set
			{
				this._home_page = value;
			}
		}

		// Token: 0x17000F84 RID: 3972
		// (get) Token: 0x06003242 RID: 12866 RVA: 0x00060BC0 File Offset: 0x0005EDC0
		// (set) Token: 0x06003243 RID: 12867 RVA: 0x00060BD8 File Offset: 0x0005EDD8
		[ProtoMember(3, IsRequired = false, Name = "pvp_info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PVPInformation pvp_info
		{
			get
			{
				return this._pvp_info;
			}
			set
			{
				this._pvp_info = value;
			}
		}

		// Token: 0x17000F85 RID: 3973
		// (get) Token: 0x06003244 RID: 12868 RVA: 0x00060BE4 File Offset: 0x0005EDE4
		[ProtoMember(4, Name = "system_status", DataFormat = DataFormat.Default)]
		public List<bool> system_status
		{
			get
			{
				return this._system_status;
			}
		}

		// Token: 0x17000F86 RID: 3974
		// (get) Token: 0x06003245 RID: 12869 RVA: 0x00060BFC File Offset: 0x0005EDFC
		// (set) Token: 0x06003246 RID: 12870 RVA: 0x00060C14 File Offset: 0x0005EE14
		[ProtoMember(5, IsRequired = false, Name = "trophy_data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public StageTrophy trophy_data
		{
			get
			{
				return this._trophy_data;
			}
			set
			{
				this._trophy_data = value;
			}
		}

		// Token: 0x06003247 RID: 12871 RVA: 0x00060C20 File Offset: 0x0005EE20
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C7A RID: 3194
		private ErrorCode? _result;

		// Token: 0x04000C7B RID: 3195
		private PersonalHomePage _home_page = null;

		// Token: 0x04000C7C RID: 3196
		private PVPInformation _pvp_info = null;

		// Token: 0x04000C7D RID: 3197
		private readonly List<bool> _system_status = new List<bool>();

		// Token: 0x04000C7E RID: 3198
		private StageTrophy _trophy_data = null;

		// Token: 0x04000C7F RID: 3199
		private IExtension extensionObject;
	}
}
