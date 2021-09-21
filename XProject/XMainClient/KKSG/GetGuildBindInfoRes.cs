using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200025C RID: 604
	[ProtoContract(Name = "GetGuildBindInfoRes")]
	[Serializable]
	public class GetGuildBindInfoRes : IExtensible
	{
		// Token: 0x17000A88 RID: 2696
		// (get) Token: 0x060021CF RID: 8655 RVA: 0x0004224C File Offset: 0x0004044C
		// (set) Token: 0x060021D0 RID: 8656 RVA: 0x00042278 File Offset: 0x00040478
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

		// Token: 0x17000A89 RID: 2697
		// (get) Token: 0x060021D1 RID: 8657 RVA: 0x00042288 File Offset: 0x00040488
		// (set) Token: 0x060021D2 RID: 8658 RVA: 0x000422A8 File Offset: 0x000404A8
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

		// Token: 0x060021D3 RID: 8659 RVA: 0x000422EC File Offset: 0x000404EC
		private bool ShouldSerializebind_status()
		{
			return this.bind_statusSpecified;
		}

		// Token: 0x060021D4 RID: 8660 RVA: 0x00042304 File Offset: 0x00040504
		private void Resetbind_status()
		{
			this.bind_statusSpecified = false;
		}

		// Token: 0x17000A8A RID: 2698
		// (get) Token: 0x060021D5 RID: 8661 RVA: 0x00042310 File Offset: 0x00040510
		// (set) Token: 0x060021D6 RID: 8662 RVA: 0x00042331 File Offset: 0x00040531
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

		// Token: 0x17000A8B RID: 2699
		// (get) Token: 0x060021D7 RID: 8663 RVA: 0x0004233C File Offset: 0x0004053C
		// (set) Token: 0x060021D8 RID: 8664 RVA: 0x00042358 File Offset: 0x00040558
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

		// Token: 0x060021D9 RID: 8665 RVA: 0x00042388 File Offset: 0x00040588
		private bool ShouldSerializegroup_name()
		{
			return this.group_nameSpecified;
		}

		// Token: 0x060021DA RID: 8666 RVA: 0x000423A0 File Offset: 0x000405A0
		private void Resetgroup_name()
		{
			this.group_nameSpecified = false;
		}

		// Token: 0x17000A8C RID: 2700
		// (get) Token: 0x060021DB RID: 8667 RVA: 0x000423AC File Offset: 0x000405AC
		// (set) Token: 0x060021DC RID: 8668 RVA: 0x000423D8 File Offset: 0x000405D8
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

		// Token: 0x17000A8D RID: 2701
		// (get) Token: 0x060021DD RID: 8669 RVA: 0x000423E8 File Offset: 0x000405E8
		// (set) Token: 0x060021DE RID: 8670 RVA: 0x00042408 File Offset: 0x00040608
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

		// Token: 0x060021DF RID: 8671 RVA: 0x0004244C File Offset: 0x0004064C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060021E0 RID: 8672 RVA: 0x00042464 File Offset: 0x00040664
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x060021E1 RID: 8673 RVA: 0x00042470 File Offset: 0x00040670
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000865 RID: 2149
		private GuildBindStatus? _bind_status;

		// Token: 0x04000866 RID: 2150
		private string _group_name;

		// Token: 0x04000867 RID: 2151
		private ErrorCode? _result;

		// Token: 0x04000868 RID: 2152
		private IExtension extensionObject;
	}
}
