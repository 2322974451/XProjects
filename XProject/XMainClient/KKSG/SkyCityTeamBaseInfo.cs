using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006AF RID: 1711
	[ProtoContract(Name = "SkyCityTeamBaseInfo")]
	[Serializable]
	public class SkyCityTeamBaseInfo : IExtensible
	{
		// Token: 0x1700235C RID: 9052
		// (get) Token: 0x06006FB6 RID: 28598 RVA: 0x000D5C0C File Offset: 0x000D3E0C
		// (set) Token: 0x06006FB7 RID: 28599 RVA: 0x000D5C38 File Offset: 0x000D3E38
		[ProtoMember(1, IsRequired = false, Name = "teamid", DataFormat = DataFormat.TwosComplement)]
		public int teamid
		{
			get
			{
				return this._teamid ?? 0;
			}
			set
			{
				this._teamid = new int?(value);
			}
		}

		// Token: 0x1700235D RID: 9053
		// (get) Token: 0x06006FB8 RID: 28600 RVA: 0x000D5C48 File Offset: 0x000D3E48
		// (set) Token: 0x06006FB9 RID: 28601 RVA: 0x000D5C68 File Offset: 0x000D3E68
		[XmlIgnore]
		[Browsable(false)]
		public bool teamidSpecified
		{
			get
			{
				return this._teamid != null;
			}
			set
			{
				bool flag = value == (this._teamid == null);
				if (flag)
				{
					this._teamid = (value ? new int?(this.teamid) : null);
				}
			}
		}

		// Token: 0x06006FBA RID: 28602 RVA: 0x000D5CAC File Offset: 0x000D3EAC
		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		// Token: 0x06006FBB RID: 28603 RVA: 0x000D5CC4 File Offset: 0x000D3EC4
		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		// Token: 0x1700235E RID: 9054
		// (get) Token: 0x06006FBC RID: 28604 RVA: 0x000D5CD0 File Offset: 0x000D3ED0
		// (set) Token: 0x06006FBD RID: 28605 RVA: 0x000D5CFD File Offset: 0x000D3EFD
		[ProtoMember(2, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x1700235F RID: 9055
		// (get) Token: 0x06006FBE RID: 28606 RVA: 0x000D5D0C File Offset: 0x000D3F0C
		// (set) Token: 0x06006FBF RID: 28607 RVA: 0x000D5D2C File Offset: 0x000D3F2C
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x06006FC0 RID: 28608 RVA: 0x000D5D70 File Offset: 0x000D3F70
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06006FC1 RID: 28609 RVA: 0x000D5D88 File Offset: 0x000D3F88
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17002360 RID: 9056
		// (get) Token: 0x06006FC2 RID: 28610 RVA: 0x000D5D94 File Offset: 0x000D3F94
		// (set) Token: 0x06006FC3 RID: 28611 RVA: 0x000D5DB5 File Offset: 0x000D3FB5
		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17002361 RID: 9057
		// (get) Token: 0x06006FC4 RID: 28612 RVA: 0x000D5DC0 File Offset: 0x000D3FC0
		// (set) Token: 0x06006FC5 RID: 28613 RVA: 0x000D5DDC File Offset: 0x000D3FDC
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06006FC6 RID: 28614 RVA: 0x000D5E0C File Offset: 0x000D400C
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06006FC7 RID: 28615 RVA: 0x000D5E24 File Offset: 0x000D4024
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17002362 RID: 9058
		// (get) Token: 0x06006FC8 RID: 28616 RVA: 0x000D5E30 File Offset: 0x000D4030
		// (set) Token: 0x06006FC9 RID: 28617 RVA: 0x000D5E5C File Offset: 0x000D405C
		[ProtoMember(4, IsRequired = false, Name = "lv", DataFormat = DataFormat.TwosComplement)]
		public uint lv
		{
			get
			{
				return this._lv ?? 0U;
			}
			set
			{
				this._lv = new uint?(value);
			}
		}

		// Token: 0x17002363 RID: 9059
		// (get) Token: 0x06006FCA RID: 28618 RVA: 0x000D5E6C File Offset: 0x000D406C
		// (set) Token: 0x06006FCB RID: 28619 RVA: 0x000D5E8C File Offset: 0x000D408C
		[XmlIgnore]
		[Browsable(false)]
		public bool lvSpecified
		{
			get
			{
				return this._lv != null;
			}
			set
			{
				bool flag = value == (this._lv == null);
				if (flag)
				{
					this._lv = (value ? new uint?(this.lv) : null);
				}
			}
		}

		// Token: 0x06006FCC RID: 28620 RVA: 0x000D5ED0 File Offset: 0x000D40D0
		private bool ShouldSerializelv()
		{
			return this.lvSpecified;
		}

		// Token: 0x06006FCD RID: 28621 RVA: 0x000D5EE8 File Offset: 0x000D40E8
		private void Resetlv()
		{
			this.lvSpecified = false;
		}

		// Token: 0x17002364 RID: 9060
		// (get) Token: 0x06006FCE RID: 28622 RVA: 0x000D5EF4 File Offset: 0x000D40F4
		// (set) Token: 0x06006FCF RID: 28623 RVA: 0x000D5F20 File Offset: 0x000D4120
		[ProtoMember(5, IsRequired = false, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public uint ppt
		{
			get
			{
				return this._ppt ?? 0U;
			}
			set
			{
				this._ppt = new uint?(value);
			}
		}

		// Token: 0x17002365 RID: 9061
		// (get) Token: 0x06006FD0 RID: 28624 RVA: 0x000D5F30 File Offset: 0x000D4130
		// (set) Token: 0x06006FD1 RID: 28625 RVA: 0x000D5F50 File Offset: 0x000D4150
		[XmlIgnore]
		[Browsable(false)]
		public bool pptSpecified
		{
			get
			{
				return this._ppt != null;
			}
			set
			{
				bool flag = value == (this._ppt == null);
				if (flag)
				{
					this._ppt = (value ? new uint?(this.ppt) : null);
				}
			}
		}

		// Token: 0x06006FD2 RID: 28626 RVA: 0x000D5F94 File Offset: 0x000D4194
		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		// Token: 0x06006FD3 RID: 28627 RVA: 0x000D5FAC File Offset: 0x000D41AC
		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		// Token: 0x17002366 RID: 9062
		// (get) Token: 0x06006FD4 RID: 28628 RVA: 0x000D5FB8 File Offset: 0x000D41B8
		// (set) Token: 0x06006FD5 RID: 28629 RVA: 0x000D5FE4 File Offset: 0x000D41E4
		[ProtoMember(6, IsRequired = false, Name = "job", DataFormat = DataFormat.TwosComplement)]
		public uint job
		{
			get
			{
				return this._job ?? 0U;
			}
			set
			{
				this._job = new uint?(value);
			}
		}

		// Token: 0x17002367 RID: 9063
		// (get) Token: 0x06006FD6 RID: 28630 RVA: 0x000D5FF4 File Offset: 0x000D41F4
		// (set) Token: 0x06006FD7 RID: 28631 RVA: 0x000D6014 File Offset: 0x000D4214
		[XmlIgnore]
		[Browsable(false)]
		public bool jobSpecified
		{
			get
			{
				return this._job != null;
			}
			set
			{
				bool flag = value == (this._job == null);
				if (flag)
				{
					this._job = (value ? new uint?(this.job) : null);
				}
			}
		}

		// Token: 0x06006FD8 RID: 28632 RVA: 0x000D6058 File Offset: 0x000D4258
		private bool ShouldSerializejob()
		{
			return this.jobSpecified;
		}

		// Token: 0x06006FD9 RID: 28633 RVA: 0x000D6070 File Offset: 0x000D4270
		private void Resetjob()
		{
			this.jobSpecified = false;
		}

		// Token: 0x17002368 RID: 9064
		// (get) Token: 0x06006FDA RID: 28634 RVA: 0x000D607C File Offset: 0x000D427C
		// (set) Token: 0x06006FDB RID: 28635 RVA: 0x000D60A8 File Offset: 0x000D42A8
		[ProtoMember(7, IsRequired = false, Name = "online", DataFormat = DataFormat.Default)]
		public bool online
		{
			get
			{
				return this._online ?? false;
			}
			set
			{
				this._online = new bool?(value);
			}
		}

		// Token: 0x17002369 RID: 9065
		// (get) Token: 0x06006FDC RID: 28636 RVA: 0x000D60B8 File Offset: 0x000D42B8
		// (set) Token: 0x06006FDD RID: 28637 RVA: 0x000D60D8 File Offset: 0x000D42D8
		[XmlIgnore]
		[Browsable(false)]
		public bool onlineSpecified
		{
			get
			{
				return this._online != null;
			}
			set
			{
				bool flag = value == (this._online == null);
				if (flag)
				{
					this._online = (value ? new bool?(this.online) : null);
				}
			}
		}

		// Token: 0x06006FDE RID: 28638 RVA: 0x000D611C File Offset: 0x000D431C
		private bool ShouldSerializeonline()
		{
			return this.onlineSpecified;
		}

		// Token: 0x06006FDF RID: 28639 RVA: 0x000D6134 File Offset: 0x000D4334
		private void Resetonline()
		{
			this.onlineSpecified = false;
		}

		// Token: 0x06006FE0 RID: 28640 RVA: 0x000D6140 File Offset: 0x000D4340
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001AB7 RID: 6839
		private int? _teamid;

		// Token: 0x04001AB8 RID: 6840
		private ulong? _uid;

		// Token: 0x04001AB9 RID: 6841
		private string _name;

		// Token: 0x04001ABA RID: 6842
		private uint? _lv;

		// Token: 0x04001ABB RID: 6843
		private uint? _ppt;

		// Token: 0x04001ABC RID: 6844
		private uint? _job;

		// Token: 0x04001ABD RID: 6845
		private bool? _online;

		// Token: 0x04001ABE RID: 6846
		private IExtension extensionObject;
	}
}
