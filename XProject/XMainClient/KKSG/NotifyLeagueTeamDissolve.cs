using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000378 RID: 888
	[ProtoContract(Name = "NotifyLeagueTeamDissolve")]
	[Serializable]
	public class NotifyLeagueTeamDissolve : IExtensible
	{
		// Token: 0x17000F02 RID: 3842
		// (get) Token: 0x06003079 RID: 12409 RVA: 0x0005D83C File Offset: 0x0005BA3C
		// (set) Token: 0x0600307A RID: 12410 RVA: 0x0005D869 File Offset: 0x0005BA69
		[ProtoMember(1, IsRequired = false, Name = "leave_roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong leave_roleid
		{
			get
			{
				return this._leave_roleid ?? 0UL;
			}
			set
			{
				this._leave_roleid = new ulong?(value);
			}
		}

		// Token: 0x17000F03 RID: 3843
		// (get) Token: 0x0600307B RID: 12411 RVA: 0x0005D878 File Offset: 0x0005BA78
		// (set) Token: 0x0600307C RID: 12412 RVA: 0x0005D898 File Offset: 0x0005BA98
		[XmlIgnore]
		[Browsable(false)]
		public bool leave_roleidSpecified
		{
			get
			{
				return this._leave_roleid != null;
			}
			set
			{
				bool flag = value == (this._leave_roleid == null);
				if (flag)
				{
					this._leave_roleid = (value ? new ulong?(this.leave_roleid) : null);
				}
			}
		}

		// Token: 0x0600307D RID: 12413 RVA: 0x0005D8DC File Offset: 0x0005BADC
		private bool ShouldSerializeleave_roleid()
		{
			return this.leave_roleidSpecified;
		}

		// Token: 0x0600307E RID: 12414 RVA: 0x0005D8F4 File Offset: 0x0005BAF4
		private void Resetleave_roleid()
		{
			this.leave_roleidSpecified = false;
		}

		// Token: 0x17000F04 RID: 3844
		// (get) Token: 0x0600307F RID: 12415 RVA: 0x0005D900 File Offset: 0x0005BB00
		// (set) Token: 0x06003080 RID: 12416 RVA: 0x0005D921 File Offset: 0x0005BB21
		[ProtoMember(2, IsRequired = false, Name = "leave_rolename", DataFormat = DataFormat.Default)]
		public string leave_rolename
		{
			get
			{
				return this._leave_rolename ?? "";
			}
			set
			{
				this._leave_rolename = value;
			}
		}

		// Token: 0x17000F05 RID: 3845
		// (get) Token: 0x06003081 RID: 12417 RVA: 0x0005D92C File Offset: 0x0005BB2C
		// (set) Token: 0x06003082 RID: 12418 RVA: 0x0005D948 File Offset: 0x0005BB48
		[XmlIgnore]
		[Browsable(false)]
		public bool leave_rolenameSpecified
		{
			get
			{
				return this._leave_rolename != null;
			}
			set
			{
				bool flag = value == (this._leave_rolename == null);
				if (flag)
				{
					this._leave_rolename = (value ? this.leave_rolename : null);
				}
			}
		}

		// Token: 0x06003083 RID: 12419 RVA: 0x0005D978 File Offset: 0x0005BB78
		private bool ShouldSerializeleave_rolename()
		{
			return this.leave_rolenameSpecified;
		}

		// Token: 0x06003084 RID: 12420 RVA: 0x0005D990 File Offset: 0x0005BB90
		private void Resetleave_rolename()
		{
			this.leave_rolenameSpecified = false;
		}

		// Token: 0x06003085 RID: 12421 RVA: 0x0005D99C File Offset: 0x0005BB9C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C04 RID: 3076
		private ulong? _leave_roleid;

		// Token: 0x04000C05 RID: 3077
		private string _leave_rolename;

		// Token: 0x04000C06 RID: 3078
		private IExtension extensionObject;
	}
}
