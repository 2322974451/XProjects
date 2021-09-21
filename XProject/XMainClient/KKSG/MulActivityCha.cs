using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001A7 RID: 423
	[ProtoContract(Name = "MulActivityCha")]
	[Serializable]
	public class MulActivityCha : IExtensible
	{
		// Token: 0x170007E3 RID: 2019
		// (get) Token: 0x06001904 RID: 6404 RVA: 0x00031B84 File Offset: 0x0002FD84
		// (set) Token: 0x06001905 RID: 6405 RVA: 0x00031BB0 File Offset: 0x0002FDB0
		[ProtoMember(1, IsRequired = false, Name = "opencount", DataFormat = DataFormat.TwosComplement)]
		public int opencount
		{
			get
			{
				return this._opencount ?? 0;
			}
			set
			{
				this._opencount = new int?(value);
			}
		}

		// Token: 0x170007E4 RID: 2020
		// (get) Token: 0x06001906 RID: 6406 RVA: 0x00031BC0 File Offset: 0x0002FDC0
		// (set) Token: 0x06001907 RID: 6407 RVA: 0x00031BE0 File Offset: 0x0002FDE0
		[XmlIgnore]
		[Browsable(false)]
		public bool opencountSpecified
		{
			get
			{
				return this._opencount != null;
			}
			set
			{
				bool flag = value == (this._opencount == null);
				if (flag)
				{
					this._opencount = (value ? new int?(this.opencount) : null);
				}
			}
		}

		// Token: 0x06001908 RID: 6408 RVA: 0x00031C24 File Offset: 0x0002FE24
		private bool ShouldSerializeopencount()
		{
			return this.opencountSpecified;
		}

		// Token: 0x06001909 RID: 6409 RVA: 0x00031C3C File Offset: 0x0002FE3C
		private void Resetopencount()
		{
			this.opencountSpecified = false;
		}

		// Token: 0x170007E5 RID: 2021
		// (get) Token: 0x0600190A RID: 6410 RVA: 0x00031C48 File Offset: 0x0002FE48
		[ProtoMember(2, Name = "changeInfo", DataFormat = DataFormat.Default)]
		public List<MulActivitInfo> changeInfo
		{
			get
			{
				return this._changeInfo;
			}
		}

		// Token: 0x0600190B RID: 6411 RVA: 0x00031C60 File Offset: 0x0002FE60
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000635 RID: 1589
		private int? _opencount;

		// Token: 0x04000636 RID: 1590
		private readonly List<MulActivitInfo> _changeInfo = new List<MulActivitInfo>();

		// Token: 0x04000637 RID: 1591
		private IExtension extensionObject;
	}
}
