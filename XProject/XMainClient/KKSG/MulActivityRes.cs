using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000173 RID: 371
	[ProtoContract(Name = "MulActivityRes")]
	[Serializable]
	public class MulActivityRes : IExtensible
	{
		// Token: 0x17000709 RID: 1801
		// (get) Token: 0x06001638 RID: 5688 RVA: 0x0002C834 File Offset: 0x0002AA34
		[ProtoMember(1, Name = "actinfo", DataFormat = DataFormat.Default)]
		public List<MulActivitInfo> actinfo
		{
			get
			{
				return this._actinfo;
			}
		}

		// Token: 0x1700070A RID: 1802
		// (get) Token: 0x06001639 RID: 5689 RVA: 0x0002C84C File Offset: 0x0002AA4C
		// (set) Token: 0x0600163A RID: 5690 RVA: 0x0002C878 File Offset: 0x0002AA78
		[ProtoMember(2, IsRequired = false, Name = "myguildlevel", DataFormat = DataFormat.TwosComplement)]
		public int myguildlevel
		{
			get
			{
				return this._myguildlevel ?? 0;
			}
			set
			{
				this._myguildlevel = new int?(value);
			}
		}

		// Token: 0x1700070B RID: 1803
		// (get) Token: 0x0600163B RID: 5691 RVA: 0x0002C888 File Offset: 0x0002AA88
		// (set) Token: 0x0600163C RID: 5692 RVA: 0x0002C8A8 File Offset: 0x0002AAA8
		[XmlIgnore]
		[Browsable(false)]
		public bool myguildlevelSpecified
		{
			get
			{
				return this._myguildlevel != null;
			}
			set
			{
				bool flag = value == (this._myguildlevel == null);
				if (flag)
				{
					this._myguildlevel = (value ? new int?(this.myguildlevel) : null);
				}
			}
		}

		// Token: 0x0600163D RID: 5693 RVA: 0x0002C8EC File Offset: 0x0002AAEC
		private bool ShouldSerializemyguildlevel()
		{
			return this.myguildlevelSpecified;
		}

		// Token: 0x0600163E RID: 5694 RVA: 0x0002C904 File Offset: 0x0002AB04
		private void Resetmyguildlevel()
		{
			this.myguildlevelSpecified = false;
		}

		// Token: 0x1700070C RID: 1804
		// (get) Token: 0x0600163F RID: 5695 RVA: 0x0002C910 File Offset: 0x0002AB10
		// (set) Token: 0x06001640 RID: 5696 RVA: 0x0002C93C File Offset: 0x0002AB3C
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

		// Token: 0x1700070D RID: 1805
		// (get) Token: 0x06001641 RID: 5697 RVA: 0x0002C94C File Offset: 0x0002AB4C
		// (set) Token: 0x06001642 RID: 5698 RVA: 0x0002C96C File Offset: 0x0002AB6C
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

		// Token: 0x06001643 RID: 5699 RVA: 0x0002C9B0 File Offset: 0x0002ABB0
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x06001644 RID: 5700 RVA: 0x0002C9C8 File Offset: 0x0002ABC8
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x06001645 RID: 5701 RVA: 0x0002C9D4 File Offset: 0x0002ABD4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000585 RID: 1413
		private readonly List<MulActivitInfo> _actinfo = new List<MulActivitInfo>();

		// Token: 0x04000586 RID: 1414
		private int? _myguildlevel;

		// Token: 0x04000587 RID: 1415
		private ErrorCode? _errcode;

		// Token: 0x04000588 RID: 1416
		private IExtension extensionObject;
	}
}
