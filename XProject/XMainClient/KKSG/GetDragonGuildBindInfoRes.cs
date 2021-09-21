using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004CB RID: 1227
	[ProtoContract(Name = "GetDragonGuildBindInfoRes")]
	[Serializable]
	public class GetDragonGuildBindInfoRes : IExtensible
	{
		// Token: 0x17001387 RID: 4999
		// (get) Token: 0x06003FC0 RID: 16320 RVA: 0x0007980C File Offset: 0x00077A0C
		// (set) Token: 0x06003FC1 RID: 16321 RVA: 0x00079838 File Offset: 0x00077A38
		[ProtoMember(1, IsRequired = false, Name = "bind_status", DataFormat = DataFormat.TwosComplement)]
		public GuildBindStatus bind_status
		{
			get
			{
				return this._bind_status ?? GuildBindStatus.GBS_NotBind;
			}
			set
			{
				this._bind_status = new GuildBindStatus?(value);
			}
		}

		// Token: 0x17001388 RID: 5000
		// (get) Token: 0x06003FC2 RID: 16322 RVA: 0x00079848 File Offset: 0x00077A48
		// (set) Token: 0x06003FC3 RID: 16323 RVA: 0x00079868 File Offset: 0x00077A68
		[XmlIgnore]
		[Browsable(false)]
		public bool bind_statusSpecified
		{
			get
			{
				return this._bind_status != null;
			}
			set
			{
				bool flag = value == (this._bind_status == null);
				if (flag)
				{
					this._bind_status = (value ? new GuildBindStatus?(this.bind_status) : null);
				}
			}
		}

		// Token: 0x06003FC4 RID: 16324 RVA: 0x000798AC File Offset: 0x00077AAC
		private bool ShouldSerializebind_status()
		{
			return this.bind_statusSpecified;
		}

		// Token: 0x06003FC5 RID: 16325 RVA: 0x000798C4 File Offset: 0x00077AC4
		private void Resetbind_status()
		{
			this.bind_statusSpecified = false;
		}

		// Token: 0x17001389 RID: 5001
		// (get) Token: 0x06003FC6 RID: 16326 RVA: 0x000798D0 File Offset: 0x00077AD0
		// (set) Token: 0x06003FC7 RID: 16327 RVA: 0x000798F1 File Offset: 0x00077AF1
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

		// Token: 0x1700138A RID: 5002
		// (get) Token: 0x06003FC8 RID: 16328 RVA: 0x000798FC File Offset: 0x00077AFC
		// (set) Token: 0x06003FC9 RID: 16329 RVA: 0x00079918 File Offset: 0x00077B18
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

		// Token: 0x06003FCA RID: 16330 RVA: 0x00079948 File Offset: 0x00077B48
		private bool ShouldSerializegroup_name()
		{
			return this.group_nameSpecified;
		}

		// Token: 0x06003FCB RID: 16331 RVA: 0x00079960 File Offset: 0x00077B60
		private void Resetgroup_name()
		{
			this.group_nameSpecified = false;
		}

		// Token: 0x1700138B RID: 5003
		// (get) Token: 0x06003FCC RID: 16332 RVA: 0x0007996C File Offset: 0x00077B6C
		// (set) Token: 0x06003FCD RID: 16333 RVA: 0x00079998 File Offset: 0x00077B98
		[ProtoMember(3, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700138C RID: 5004
		// (get) Token: 0x06003FCE RID: 16334 RVA: 0x000799A8 File Offset: 0x00077BA8
		// (set) Token: 0x06003FCF RID: 16335 RVA: 0x000799C8 File Offset: 0x00077BC8
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

		// Token: 0x06003FD0 RID: 16336 RVA: 0x00079A0C File Offset: 0x00077C0C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003FD1 RID: 16337 RVA: 0x00079A24 File Offset: 0x00077C24
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003FD2 RID: 16338 RVA: 0x00079A30 File Offset: 0x00077C30
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FE0 RID: 4064
		private GuildBindStatus? _bind_status;

		// Token: 0x04000FE1 RID: 4065
		private string _group_name;

		// Token: 0x04000FE2 RID: 4066
		private ErrorCode? _result;

		// Token: 0x04000FE3 RID: 4067
		private IExtension extensionObject;
	}
}
