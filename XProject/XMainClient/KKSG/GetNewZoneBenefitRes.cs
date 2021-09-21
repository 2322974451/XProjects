using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000520 RID: 1312
	[ProtoContract(Name = "GetNewZoneBenefitRes")]
	[Serializable]
	public class GetNewZoneBenefitRes : IExtensible
	{
		// Token: 0x1700149D RID: 5277
		// (get) Token: 0x06004374 RID: 17268 RVA: 0x00080544 File Offset: 0x0007E744
		// (set) Token: 0x06004375 RID: 17269 RVA: 0x00080570 File Offset: 0x0007E770
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

		// Token: 0x1700149E RID: 5278
		// (get) Token: 0x06004376 RID: 17270 RVA: 0x00080580 File Offset: 0x0007E780
		// (set) Token: 0x06004377 RID: 17271 RVA: 0x000805A0 File Offset: 0x0007E7A0
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

		// Token: 0x06004378 RID: 17272 RVA: 0x000805E4 File Offset: 0x0007E7E4
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06004379 RID: 17273 RVA: 0x000805FC File Offset: 0x0007E7FC
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700149F RID: 5279
		// (get) Token: 0x0600437A RID: 17274 RVA: 0x00080608 File Offset: 0x0007E808
		// (set) Token: 0x0600437B RID: 17275 RVA: 0x00080634 File Offset: 0x0007E834
		[ProtoMember(2, IsRequired = false, Name = "is_open", DataFormat = DataFormat.Default)]
		public bool is_open
		{
			get
			{
				return this._is_open ?? false;
			}
			set
			{
				this._is_open = new bool?(value);
			}
		}

		// Token: 0x170014A0 RID: 5280
		// (get) Token: 0x0600437C RID: 17276 RVA: 0x00080644 File Offset: 0x0007E844
		// (set) Token: 0x0600437D RID: 17277 RVA: 0x00080664 File Offset: 0x0007E864
		[XmlIgnore]
		[Browsable(false)]
		public bool is_openSpecified
		{
			get
			{
				return this._is_open != null;
			}
			set
			{
				bool flag = value == (this._is_open == null);
				if (flag)
				{
					this._is_open = (value ? new bool?(this.is_open) : null);
				}
			}
		}

		// Token: 0x0600437E RID: 17278 RVA: 0x000806A8 File Offset: 0x0007E8A8
		private bool ShouldSerializeis_open()
		{
			return this.is_openSpecified;
		}

		// Token: 0x0600437F RID: 17279 RVA: 0x000806C0 File Offset: 0x0007E8C0
		private void Resetis_open()
		{
			this.is_openSpecified = false;
		}

		// Token: 0x170014A1 RID: 5281
		// (get) Token: 0x06004380 RID: 17280 RVA: 0x000806CC File Offset: 0x0007E8CC
		// (set) Token: 0x06004381 RID: 17281 RVA: 0x000806F8 File Offset: 0x0007E8F8
		[ProtoMember(3, IsRequired = false, Name = "has_select", DataFormat = DataFormat.Default)]
		public bool has_select
		{
			get
			{
				return this._has_select ?? false;
			}
			set
			{
				this._has_select = new bool?(value);
			}
		}

		// Token: 0x170014A2 RID: 5282
		// (get) Token: 0x06004382 RID: 17282 RVA: 0x00080708 File Offset: 0x0007E908
		// (set) Token: 0x06004383 RID: 17283 RVA: 0x00080728 File Offset: 0x0007E928
		[XmlIgnore]
		[Browsable(false)]
		public bool has_selectSpecified
		{
			get
			{
				return this._has_select != null;
			}
			set
			{
				bool flag = value == (this._has_select == null);
				if (flag)
				{
					this._has_select = (value ? new bool?(this.has_select) : null);
				}
			}
		}

		// Token: 0x06004384 RID: 17284 RVA: 0x0008076C File Offset: 0x0007E96C
		private bool ShouldSerializehas_select()
		{
			return this.has_selectSpecified;
		}

		// Token: 0x06004385 RID: 17285 RVA: 0x00080784 File Offset: 0x0007E984
		private void Resethas_select()
		{
			this.has_selectSpecified = false;
		}

		// Token: 0x170014A3 RID: 5283
		// (get) Token: 0x06004386 RID: 17286 RVA: 0x00080790 File Offset: 0x0007E990
		[ProtoMember(4, Name = "roles", DataFormat = DataFormat.Default)]
		public List<ZoneRoleInfo> roles
		{
			get
			{
				return this._roles;
			}
		}

		// Token: 0x170014A4 RID: 5284
		// (get) Token: 0x06004387 RID: 17287 RVA: 0x000807A8 File Offset: 0x0007E9A8
		// (set) Token: 0x06004388 RID: 17288 RVA: 0x000807D5 File Offset: 0x0007E9D5
		[ProtoMember(5, IsRequired = false, Name = "select_roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong select_roleid
		{
			get
			{
				return this._select_roleid ?? 0UL;
			}
			set
			{
				this._select_roleid = new ulong?(value);
			}
		}

		// Token: 0x170014A5 RID: 5285
		// (get) Token: 0x06004389 RID: 17289 RVA: 0x000807E4 File Offset: 0x0007E9E4
		// (set) Token: 0x0600438A RID: 17290 RVA: 0x00080804 File Offset: 0x0007EA04
		[XmlIgnore]
		[Browsable(false)]
		public bool select_roleidSpecified
		{
			get
			{
				return this._select_roleid != null;
			}
			set
			{
				bool flag = value == (this._select_roleid == null);
				if (flag)
				{
					this._select_roleid = (value ? new ulong?(this.select_roleid) : null);
				}
			}
		}

		// Token: 0x0600438B RID: 17291 RVA: 0x00080848 File Offset: 0x0007EA48
		private bool ShouldSerializeselect_roleid()
		{
			return this.select_roleidSpecified;
		}

		// Token: 0x0600438C RID: 17292 RVA: 0x00080860 File Offset: 0x0007EA60
		private void Resetselect_roleid()
		{
			this.select_roleidSpecified = false;
		}

		// Token: 0x170014A6 RID: 5286
		// (get) Token: 0x0600438D RID: 17293 RVA: 0x0008086C File Offset: 0x0007EA6C
		// (set) Token: 0x0600438E RID: 17294 RVA: 0x00080898 File Offset: 0x0007EA98
		[ProtoMember(6, IsRequired = false, Name = "total_paycnt", DataFormat = DataFormat.TwosComplement)]
		public uint total_paycnt
		{
			get
			{
				return this._total_paycnt ?? 0U;
			}
			set
			{
				this._total_paycnt = new uint?(value);
			}
		}

		// Token: 0x170014A7 RID: 5287
		// (get) Token: 0x0600438F RID: 17295 RVA: 0x000808A8 File Offset: 0x0007EAA8
		// (set) Token: 0x06004390 RID: 17296 RVA: 0x000808C8 File Offset: 0x0007EAC8
		[XmlIgnore]
		[Browsable(false)]
		public bool total_paycntSpecified
		{
			get
			{
				return this._total_paycnt != null;
			}
			set
			{
				bool flag = value == (this._total_paycnt == null);
				if (flag)
				{
					this._total_paycnt = (value ? new uint?(this.total_paycnt) : null);
				}
			}
		}

		// Token: 0x06004391 RID: 17297 RVA: 0x0008090C File Offset: 0x0007EB0C
		private bool ShouldSerializetotal_paycnt()
		{
			return this.total_paycntSpecified;
		}

		// Token: 0x06004392 RID: 17298 RVA: 0x00080924 File Offset: 0x0007EB24
		private void Resettotal_paycnt()
		{
			this.total_paycntSpecified = false;
		}

		// Token: 0x06004393 RID: 17299 RVA: 0x00080930 File Offset: 0x0007EB30
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010D0 RID: 4304
		private ErrorCode? _result;

		// Token: 0x040010D1 RID: 4305
		private bool? _is_open;

		// Token: 0x040010D2 RID: 4306
		private bool? _has_select;

		// Token: 0x040010D3 RID: 4307
		private readonly List<ZoneRoleInfo> _roles = new List<ZoneRoleInfo>();

		// Token: 0x040010D4 RID: 4308
		private ulong? _select_roleid;

		// Token: 0x040010D5 RID: 4309
		private uint? _total_paycnt;

		// Token: 0x040010D6 RID: 4310
		private IExtension extensionObject;
	}
}
