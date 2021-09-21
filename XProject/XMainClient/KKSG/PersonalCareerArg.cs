using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003A5 RID: 933
	[ProtoContract(Name = "PersonalCareerArg")]
	[Serializable]
	public class PersonalCareerArg : IExtensible
	{
		// Token: 0x17000F7D RID: 3965
		// (get) Token: 0x0600322C RID: 12844 RVA: 0x00060908 File Offset: 0x0005EB08
		// (set) Token: 0x0600322D RID: 12845 RVA: 0x00060934 File Offset: 0x0005EB34
		[ProtoMember(1, IsRequired = false, Name = "quest_type", DataFormat = DataFormat.TwosComplement)]
		public PersonalCarrerReqType quest_type
		{
			get
			{
				return this._quest_type ?? PersonalCarrerReqType.PCRT_HOME_PAGE;
			}
			set
			{
				this._quest_type = new PersonalCarrerReqType?(value);
			}
		}

		// Token: 0x17000F7E RID: 3966
		// (get) Token: 0x0600322E RID: 12846 RVA: 0x00060944 File Offset: 0x0005EB44
		// (set) Token: 0x0600322F RID: 12847 RVA: 0x00060964 File Offset: 0x0005EB64
		[XmlIgnore]
		[Browsable(false)]
		public bool quest_typeSpecified
		{
			get
			{
				return this._quest_type != null;
			}
			set
			{
				bool flag = value == (this._quest_type == null);
				if (flag)
				{
					this._quest_type = (value ? new PersonalCarrerReqType?(this.quest_type) : null);
				}
			}
		}

		// Token: 0x06003230 RID: 12848 RVA: 0x000609A8 File Offset: 0x0005EBA8
		private bool ShouldSerializequest_type()
		{
			return this.quest_typeSpecified;
		}

		// Token: 0x06003231 RID: 12849 RVA: 0x000609C0 File Offset: 0x0005EBC0
		private void Resetquest_type()
		{
			this.quest_typeSpecified = false;
		}

		// Token: 0x17000F7F RID: 3967
		// (get) Token: 0x06003232 RID: 12850 RVA: 0x000609CC File Offset: 0x0005EBCC
		// (set) Token: 0x06003233 RID: 12851 RVA: 0x000609F9 File Offset: 0x0005EBF9
		[ProtoMember(2, IsRequired = false, Name = "role_id", DataFormat = DataFormat.TwosComplement)]
		public ulong role_id
		{
			get
			{
				return this._role_id ?? 0UL;
			}
			set
			{
				this._role_id = new ulong?(value);
			}
		}

		// Token: 0x17000F80 RID: 3968
		// (get) Token: 0x06003234 RID: 12852 RVA: 0x00060A08 File Offset: 0x0005EC08
		// (set) Token: 0x06003235 RID: 12853 RVA: 0x00060A28 File Offset: 0x0005EC28
		[XmlIgnore]
		[Browsable(false)]
		public bool role_idSpecified
		{
			get
			{
				return this._role_id != null;
			}
			set
			{
				bool flag = value == (this._role_id == null);
				if (flag)
				{
					this._role_id = (value ? new ulong?(this.role_id) : null);
				}
			}
		}

		// Token: 0x06003236 RID: 12854 RVA: 0x00060A6C File Offset: 0x0005EC6C
		private bool ShouldSerializerole_id()
		{
			return this.role_idSpecified;
		}

		// Token: 0x06003237 RID: 12855 RVA: 0x00060A84 File Offset: 0x0005EC84
		private void Resetrole_id()
		{
			this.role_idSpecified = false;
		}

		// Token: 0x06003238 RID: 12856 RVA: 0x00060A90 File Offset: 0x0005EC90
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C77 RID: 3191
		private PersonalCarrerReqType? _quest_type;

		// Token: 0x04000C78 RID: 3192
		private ulong? _role_id;

		// Token: 0x04000C79 RID: 3193
		private IExtension extensionObject;
	}
}
