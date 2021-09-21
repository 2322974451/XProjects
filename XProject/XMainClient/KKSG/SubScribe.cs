using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006F6 RID: 1782
	[ProtoContract(Name = "SubScribe")]
	[Serializable]
	public class SubScribe : IExtensible
	{
		// Token: 0x170025FD RID: 9725
		// (get) Token: 0x060077F2 RID: 30706 RVA: 0x000E5738 File Offset: 0x000E3938
		// (set) Token: 0x060077F3 RID: 30707 RVA: 0x000E5764 File Offset: 0x000E3964
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x170025FE RID: 9726
		// (get) Token: 0x060077F4 RID: 30708 RVA: 0x000E5774 File Offset: 0x000E3974
		// (set) Token: 0x060077F5 RID: 30709 RVA: 0x000E5794 File Offset: 0x000E3994
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x060077F6 RID: 30710 RVA: 0x000E57D8 File Offset: 0x000E39D8
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x060077F7 RID: 30711 RVA: 0x000E57F0 File Offset: 0x000E39F0
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x170025FF RID: 9727
		// (get) Token: 0x060077F8 RID: 30712 RVA: 0x000E57FC File Offset: 0x000E39FC
		// (set) Token: 0x060077F9 RID: 30713 RVA: 0x000E581D File Offset: 0x000E3A1D
		[ProtoMember(2, IsRequired = false, Name = "title", DataFormat = DataFormat.Default)]
		public string title
		{
			get
			{
				return this._title ?? "";
			}
			set
			{
				this._title = value;
			}
		}

		// Token: 0x17002600 RID: 9728
		// (get) Token: 0x060077FA RID: 30714 RVA: 0x000E5828 File Offset: 0x000E3A28
		// (set) Token: 0x060077FB RID: 30715 RVA: 0x000E5844 File Offset: 0x000E3A44
		[XmlIgnore]
		[Browsable(false)]
		public bool titleSpecified
		{
			get
			{
				return this._title != null;
			}
			set
			{
				bool flag = value == (this._title == null);
				if (flag)
				{
					this._title = (value ? this.title : null);
				}
			}
		}

		// Token: 0x060077FC RID: 30716 RVA: 0x000E5874 File Offset: 0x000E3A74
		private bool ShouldSerializetitle()
		{
			return this.titleSpecified;
		}

		// Token: 0x060077FD RID: 30717 RVA: 0x000E588C File Offset: 0x000E3A8C
		private void Resettitle()
		{
			this.titleSpecified = false;
		}

		// Token: 0x17002601 RID: 9729
		// (get) Token: 0x060077FE RID: 30718 RVA: 0x000E5898 File Offset: 0x000E3A98
		// (set) Token: 0x060077FF RID: 30719 RVA: 0x000E58C4 File Offset: 0x000E3AC4
		[ProtoMember(3, IsRequired = false, Name = "status", DataFormat = DataFormat.Default)]
		public bool status
		{
			get
			{
				return this._status ?? false;
			}
			set
			{
				this._status = new bool?(value);
			}
		}

		// Token: 0x17002602 RID: 9730
		// (get) Token: 0x06007800 RID: 30720 RVA: 0x000E58D4 File Offset: 0x000E3AD4
		// (set) Token: 0x06007801 RID: 30721 RVA: 0x000E58F4 File Offset: 0x000E3AF4
		[XmlIgnore]
		[Browsable(false)]
		public bool statusSpecified
		{
			get
			{
				return this._status != null;
			}
			set
			{
				bool flag = value == (this._status == null);
				if (flag)
				{
					this._status = (value ? new bool?(this.status) : null);
				}
			}
		}

		// Token: 0x06007802 RID: 30722 RVA: 0x000E5938 File Offset: 0x000E3B38
		private bool ShouldSerializestatus()
		{
			return this.statusSpecified;
		}

		// Token: 0x06007803 RID: 30723 RVA: 0x000E5950 File Offset: 0x000E3B50
		private void Resetstatus()
		{
			this.statusSpecified = false;
		}

		// Token: 0x06007804 RID: 30724 RVA: 0x000E595C File Offset: 0x000E3B5C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C60 RID: 7264
		private uint? _id;

		// Token: 0x04001C61 RID: 7265
		private string _title;

		// Token: 0x04001C62 RID: 7266
		private bool? _status;

		// Token: 0x04001C63 RID: 7267
		private IExtension extensionObject;
	}
}
