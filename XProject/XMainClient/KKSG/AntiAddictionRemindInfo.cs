using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002FD RID: 765
	[ProtoContract(Name = "AntiAddictionRemindInfo")]
	[Serializable]
	public class AntiAddictionRemindInfo : IExtensible
	{
		// Token: 0x17000CFF RID: 3327
		// (get) Token: 0x060029E9 RID: 10729 RVA: 0x00051488 File Offset: 0x0004F688
		// (set) Token: 0x060029EA RID: 10730 RVA: 0x000514B4 File Offset: 0x0004F6B4
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public AntiAddictionReportType type
		{
			get
			{
				return this._type ?? AntiAddictionReportType.ReportTypeSingle;
			}
			set
			{
				this._type = new AntiAddictionReportType?(value);
			}
		}

		// Token: 0x17000D00 RID: 3328
		// (get) Token: 0x060029EB RID: 10731 RVA: 0x000514C4 File Offset: 0x0004F6C4
		// (set) Token: 0x060029EC RID: 10732 RVA: 0x000514E4 File Offset: 0x0004F6E4
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new AntiAddictionReportType?(this.type) : null);
				}
			}
		}

		// Token: 0x060029ED RID: 10733 RVA: 0x00051528 File Offset: 0x0004F728
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060029EE RID: 10734 RVA: 0x00051540 File Offset: 0x0004F740
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000D01 RID: 3329
		// (get) Token: 0x060029EF RID: 10735 RVA: 0x0005154C File Offset: 0x0004F74C
		// (set) Token: 0x060029F0 RID: 10736 RVA: 0x0005156D File Offset: 0x0004F76D
		[ProtoMember(2, IsRequired = false, Name = "remindmsg", DataFormat = DataFormat.Default)]
		public string remindmsg
		{
			get
			{
				return this._remindmsg ?? "";
			}
			set
			{
				this._remindmsg = value;
			}
		}

		// Token: 0x17000D02 RID: 3330
		// (get) Token: 0x060029F1 RID: 10737 RVA: 0x00051578 File Offset: 0x0004F778
		// (set) Token: 0x060029F2 RID: 10738 RVA: 0x00051594 File Offset: 0x0004F794
		[XmlIgnore]
		[Browsable(false)]
		public bool remindmsgSpecified
		{
			get
			{
				return this._remindmsg != null;
			}
			set
			{
				bool flag = value == (this._remindmsg == null);
				if (flag)
				{
					this._remindmsg = (value ? this.remindmsg : null);
				}
			}
		}

		// Token: 0x060029F3 RID: 10739 RVA: 0x000515C4 File Offset: 0x0004F7C4
		private bool ShouldSerializeremindmsg()
		{
			return this.remindmsgSpecified;
		}

		// Token: 0x060029F4 RID: 10740 RVA: 0x000515DC File Offset: 0x0004F7DC
		private void Resetremindmsg()
		{
			this.remindmsgSpecified = false;
		}

		// Token: 0x060029F5 RID: 10741 RVA: 0x000515E8 File Offset: 0x0004F7E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A69 RID: 2665
		private AntiAddictionReportType? _type;

		// Token: 0x04000A6A RID: 2666
		private string _remindmsg;

		// Token: 0x04000A6B RID: 2667
		private IExtension extensionObject;
	}
}
