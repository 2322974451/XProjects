using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200025E RID: 606
	[ProtoContract(Name = "GuildBindGroupRes")]
	[Serializable]
	public class GuildBindGroupRes : IExtensible
	{
		// Token: 0x17000A95 RID: 2709
		// (get) Token: 0x060021F8 RID: 8696 RVA: 0x00042728 File Offset: 0x00040928
		// (set) Token: 0x060021F9 RID: 8697 RVA: 0x00042754 File Offset: 0x00040954
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

		// Token: 0x17000A96 RID: 2710
		// (get) Token: 0x060021FA RID: 8698 RVA: 0x00042764 File Offset: 0x00040964
		// (set) Token: 0x060021FB RID: 8699 RVA: 0x00042784 File Offset: 0x00040984
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

		// Token: 0x060021FC RID: 8700 RVA: 0x000427C8 File Offset: 0x000409C8
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060021FD RID: 8701 RVA: 0x000427E0 File Offset: 0x000409E0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000A97 RID: 2711
		// (get) Token: 0x060021FE RID: 8702 RVA: 0x000427EC File Offset: 0x000409EC
		// (set) Token: 0x060021FF RID: 8703 RVA: 0x0004280D File Offset: 0x00040A0D
		[ProtoMember(2, IsRequired = false, Name = "group_name", DataFormat = DataFormat.Default)]
		public string group_name
		{
			get
			{
				return this._group_name ?? "";
			}
			set
			{
				this._group_name = value;
			}
		}

		// Token: 0x17000A98 RID: 2712
		// (get) Token: 0x06002200 RID: 8704 RVA: 0x00042818 File Offset: 0x00040A18
		// (set) Token: 0x06002201 RID: 8705 RVA: 0x00042834 File Offset: 0x00040A34
		[XmlIgnore]
		[Browsable(false)]
		public bool group_nameSpecified
		{
			get
			{
				return this._group_name != null;
			}
			set
			{
				bool flag = value == (this._group_name == null);
				if (flag)
				{
					this._group_name = (value ? this.group_name : null);
				}
			}
		}

		// Token: 0x06002202 RID: 8706 RVA: 0x00042864 File Offset: 0x00040A64
		private bool ShouldSerializegroup_name()
		{
			return this.group_nameSpecified;
		}

		// Token: 0x06002203 RID: 8707 RVA: 0x0004287C File Offset: 0x00040A7C
		private void Resetgroup_name()
		{
			this.group_nameSpecified = false;
		}

		// Token: 0x06002204 RID: 8708 RVA: 0x00042888 File Offset: 0x00040A88
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400086E RID: 2158
		private ErrorCode? _result;

		// Token: 0x0400086F RID: 2159
		private string _group_name;

		// Token: 0x04000870 RID: 2160
		private IExtension extensionObject;
	}
}
