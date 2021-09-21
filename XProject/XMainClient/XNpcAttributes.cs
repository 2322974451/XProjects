using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F3D RID: 3901
	internal class XNpcAttributes : XAttributes
	{
		// Token: 0x17003660 RID: 13920
		// (get) Token: 0x0600CF99 RID: 53145 RVA: 0x0030313C File Offset: 0x0030133C
		public override uint ID
		{
			get
			{
				return XNpcAttributes.uuID;
			}
		}

		// Token: 0x17003661 RID: 13921
		// (get) Token: 0x0600CF9A RID: 53146 RVA: 0x00303154 File Offset: 0x00301354
		public string Icon
		{
			get
			{
				return this._icon;
			}
		}

		// Token: 0x17003662 RID: 13922
		// (get) Token: 0x0600CF9B RID: 53147 RVA: 0x0030316C File Offset: 0x0030136C
		public string Portrait
		{
			get
			{
				return this._portrait;
			}
		}

		// Token: 0x17003663 RID: 13923
		// (get) Token: 0x0600CF9C RID: 53148 RVA: 0x00303184 File Offset: 0x00301384
		public uint SceneId
		{
			get
			{
				return this._scene_id;
			}
		}

		// Token: 0x17003664 RID: 13924
		// (get) Token: 0x0600CF9D RID: 53149 RVA: 0x0030319C File Offset: 0x0030139C
		public Vector3 Position
		{
			get
			{
				return this._position;
			}
		}

		// Token: 0x17003665 RID: 13925
		// (get) Token: 0x0600CF9E RID: 53150 RVA: 0x003031B4 File Offset: 0x003013B4
		public Vector3 Rotation
		{
			get
			{
				return this._rotation;
			}
		}

		// Token: 0x17003666 RID: 13926
		// (get) Token: 0x0600CF9F RID: 53151 RVA: 0x003031CC File Offset: 0x003013CC
		public string[] Content
		{
			get
			{
				return this._content;
			}
		}

		// Token: 0x17003667 RID: 13927
		// (get) Token: 0x0600CFA0 RID: 53152 RVA: 0x003031E4 File Offset: 0x003013E4
		public string[] Voice
		{
			get
			{
				return this._voice;
			}
		}

		// Token: 0x17003668 RID: 13928
		// (get) Token: 0x0600CFA1 RID: 53153 RVA: 0x003031FC File Offset: 0x003013FC
		public int[] FunctionList
		{
			get
			{
				return this._functionList;
			}
		}

		// Token: 0x0600CFA2 RID: 53154 RVA: 0x00303214 File Offset: 0x00301414
		public void InitAttribute(XNpcInfo.RowData data)
		{
			this._icon = data.Icon;
			this._portrait = data.Portrait;
			this._scene_id = data.SceneID;
			this._position.Set(data.Position[0], data.Position[1], data.Position[2]);
			this._rotation.Set(data.Rotation[0], data.Rotation[1], data.Rotation[2]);
			this._content = data.Content;
			this._voice = data.Voice;
			this._functionList = data.FunctionList;
		}

		// Token: 0x04005D4F RID: 23887
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Npc_Attributes");

		// Token: 0x04005D50 RID: 23888
		private string _icon = null;

		// Token: 0x04005D51 RID: 23889
		private string _portrait = null;

		// Token: 0x04005D52 RID: 23890
		private uint _scene_id = 0U;

		// Token: 0x04005D53 RID: 23891
		private Vector3 _position = Vector3.zero;

		// Token: 0x04005D54 RID: 23892
		private Vector3 _rotation = Vector3.zero;

		// Token: 0x04005D55 RID: 23893
		private string[] _content = null;

		// Token: 0x04005D56 RID: 23894
		private string[] _voice = null;

		// Token: 0x04005D57 RID: 23895
		private int[] _functionList = null;
	}
}
