using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200066B RID: 1643
	[ProtoContract(Name = "WeekReportData")]
	[Serializable]
	public class WeekReportData : IExtensible
	{
		// Token: 0x170020FB RID: 8443
		// (get) Token: 0x06006850 RID: 26704 RVA: 0x000C7638 File Offset: 0x000C5838
		// (set) Token: 0x06006851 RID: 26705 RVA: 0x000C7664 File Offset: 0x000C5864
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public WeekReportDataType type
		{
			get
			{
				return this._type ?? WeekReportDataType.WeekReportData_GuildSign;
			}
			set
			{
				this._type = new WeekReportDataType?(value);
			}
		}

		// Token: 0x170020FC RID: 8444
		// (get) Token: 0x06006852 RID: 26706 RVA: 0x000C7674 File Offset: 0x000C5874
		// (set) Token: 0x06006853 RID: 26707 RVA: 0x000C7694 File Offset: 0x000C5894
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
					this._type = (value ? new WeekReportDataType?(this.type) : null);
				}
			}
		}

		// Token: 0x06006854 RID: 26708 RVA: 0x000C76D8 File Offset: 0x000C58D8
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06006855 RID: 26709 RVA: 0x000C76F0 File Offset: 0x000C58F0
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170020FD RID: 8445
		// (get) Token: 0x06006856 RID: 26710 RVA: 0x000C76FC File Offset: 0x000C58FC
		// (set) Token: 0x06006857 RID: 26711 RVA: 0x000C7728 File Offset: 0x000C5928
		[ProtoMember(2, IsRequired = false, Name = "joincount", DataFormat = DataFormat.TwosComplement)]
		public int joincount
		{
			get
			{
				return this._joincount ?? 0;
			}
			set
			{
				this._joincount = new int?(value);
			}
		}

		// Token: 0x170020FE RID: 8446
		// (get) Token: 0x06006858 RID: 26712 RVA: 0x000C7738 File Offset: 0x000C5938
		// (set) Token: 0x06006859 RID: 26713 RVA: 0x000C7758 File Offset: 0x000C5958
		[XmlIgnore]
		[Browsable(false)]
		public bool joincountSpecified
		{
			get
			{
				return this._joincount != null;
			}
			set
			{
				bool flag = value == (this._joincount == null);
				if (flag)
				{
					this._joincount = (value ? new int?(this.joincount) : null);
				}
			}
		}

		// Token: 0x0600685A RID: 26714 RVA: 0x000C779C File Offset: 0x000C599C
		private bool ShouldSerializejoincount()
		{
			return this.joincountSpecified;
		}

		// Token: 0x0600685B RID: 26715 RVA: 0x000C77B4 File Offset: 0x000C59B4
		private void Resetjoincount()
		{
			this.joincountSpecified = false;
		}

		// Token: 0x170020FF RID: 8447
		// (get) Token: 0x0600685C RID: 26716 RVA: 0x000C77C0 File Offset: 0x000C59C0
		// (set) Token: 0x0600685D RID: 26717 RVA: 0x000C77EC File Offset: 0x000C59EC
		[ProtoMember(3, IsRequired = false, Name = "lastjointime", DataFormat = DataFormat.TwosComplement)]
		public uint lastjointime
		{
			get
			{
				return this._lastjointime ?? 0U;
			}
			set
			{
				this._lastjointime = new uint?(value);
			}
		}

		// Token: 0x17002100 RID: 8448
		// (get) Token: 0x0600685E RID: 26718 RVA: 0x000C77FC File Offset: 0x000C59FC
		// (set) Token: 0x0600685F RID: 26719 RVA: 0x000C781C File Offset: 0x000C5A1C
		[XmlIgnore]
		[Browsable(false)]
		public bool lastjointimeSpecified
		{
			get
			{
				return this._lastjointime != null;
			}
			set
			{
				bool flag = value == (this._lastjointime == null);
				if (flag)
				{
					this._lastjointime = (value ? new uint?(this.lastjointime) : null);
				}
			}
		}

		// Token: 0x06006860 RID: 26720 RVA: 0x000C7860 File Offset: 0x000C5A60
		private bool ShouldSerializelastjointime()
		{
			return this.lastjointimeSpecified;
		}

		// Token: 0x06006861 RID: 26721 RVA: 0x000C7878 File Offset: 0x000C5A78
		private void Resetlastjointime()
		{
			this.lastjointimeSpecified = false;
		}

		// Token: 0x06006862 RID: 26722 RVA: 0x000C7884 File Offset: 0x000C5A84
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400192E RID: 6446
		private WeekReportDataType? _type;

		// Token: 0x0400192F RID: 6447
		private int? _joincount;

		// Token: 0x04001930 RID: 6448
		private uint? _lastjointime;

		// Token: 0x04001931 RID: 6449
		private IExtension extensionObject;
	}
}
