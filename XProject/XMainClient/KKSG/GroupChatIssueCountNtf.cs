using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200048B RID: 1163
	[ProtoContract(Name = "GroupChatIssueCountNtf")]
	[Serializable]
	public class GroupChatIssueCountNtf : IExtensible
	{
		// Token: 0x170012A2 RID: 4770
		// (get) Token: 0x06003CC3 RID: 15555 RVA: 0x00074058 File Offset: 0x00072258
		// (set) Token: 0x06003CC4 RID: 15556 RVA: 0x00074084 File Offset: 0x00072284
		[ProtoMember(1, IsRequired = false, Name = "rolecount", DataFormat = DataFormat.TwosComplement)]
		public uint rolecount
		{
			get
			{
				return this._rolecount ?? 0U;
			}
			set
			{
				this._rolecount = new uint?(value);
			}
		}

		// Token: 0x170012A3 RID: 4771
		// (get) Token: 0x06003CC5 RID: 15557 RVA: 0x00074094 File Offset: 0x00072294
		// (set) Token: 0x06003CC6 RID: 15558 RVA: 0x000740B4 File Offset: 0x000722B4
		[XmlIgnore]
		[Browsable(false)]
		public bool rolecountSpecified
		{
			get
			{
				return this._rolecount != null;
			}
			set
			{
				bool flag = value == (this._rolecount == null);
				if (flag)
				{
					this._rolecount = (value ? new uint?(this.rolecount) : null);
				}
			}
		}

		// Token: 0x06003CC7 RID: 15559 RVA: 0x000740F8 File Offset: 0x000722F8
		private bool ShouldSerializerolecount()
		{
			return this.rolecountSpecified;
		}

		// Token: 0x06003CC8 RID: 15560 RVA: 0x00074110 File Offset: 0x00072310
		private void Resetrolecount()
		{
			this.rolecountSpecified = false;
		}

		// Token: 0x170012A4 RID: 4772
		// (get) Token: 0x06003CC9 RID: 15561 RVA: 0x0007411C File Offset: 0x0007231C
		// (set) Token: 0x06003CCA RID: 15562 RVA: 0x00074148 File Offset: 0x00072348
		[ProtoMember(2, IsRequired = false, Name = "groupcount", DataFormat = DataFormat.TwosComplement)]
		public uint groupcount
		{
			get
			{
				return this._groupcount ?? 0U;
			}
			set
			{
				this._groupcount = new uint?(value);
			}
		}

		// Token: 0x170012A5 RID: 4773
		// (get) Token: 0x06003CCB RID: 15563 RVA: 0x00074158 File Offset: 0x00072358
		// (set) Token: 0x06003CCC RID: 15564 RVA: 0x00074178 File Offset: 0x00072378
		[XmlIgnore]
		[Browsable(false)]
		public bool groupcountSpecified
		{
			get
			{
				return this._groupcount != null;
			}
			set
			{
				bool flag = value == (this._groupcount == null);
				if (flag)
				{
					this._groupcount = (value ? new uint?(this.groupcount) : null);
				}
			}
		}

		// Token: 0x06003CCD RID: 15565 RVA: 0x000741BC File Offset: 0x000723BC
		private bool ShouldSerializegroupcount()
		{
			return this.groupcountSpecified;
		}

		// Token: 0x06003CCE RID: 15566 RVA: 0x000741D4 File Offset: 0x000723D4
		private void Resetgroupcount()
		{
			this.groupcountSpecified = false;
		}

		// Token: 0x06003CCF RID: 15567 RVA: 0x000741E0 File Offset: 0x000723E0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F20 RID: 3872
		private uint? _rolecount;

		// Token: 0x04000F21 RID: 3873
		private uint? _groupcount;

		// Token: 0x04000F22 RID: 3874
		private IExtension extensionObject;
	}
}
