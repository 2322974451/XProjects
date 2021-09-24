using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XNpcAttributes : XAttributes
	{

		public override uint ID
		{
			get
			{
				return XNpcAttributes.uuID;
			}
		}

		public string Icon
		{
			get
			{
				return this._icon;
			}
		}

		public string Portrait
		{
			get
			{
				return this._portrait;
			}
		}

		public uint SceneId
		{
			get
			{
				return this._scene_id;
			}
		}

		public Vector3 Position
		{
			get
			{
				return this._position;
			}
		}

		public Vector3 Rotation
		{
			get
			{
				return this._rotation;
			}
		}

		public string[] Content
		{
			get
			{
				return this._content;
			}
		}

		public string[] Voice
		{
			get
			{
				return this._voice;
			}
		}

		public int[] FunctionList
		{
			get
			{
				return this._functionList;
			}
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Npc_Attributes");

		private string _icon = null;

		private string _portrait = null;

		private uint _scene_id = 0U;

		private Vector3 _position = Vector3.zero;

		private Vector3 _rotation = Vector3.zero;

		private string[] _content = null;

		private string[] _voice = null;

		private int[] _functionList = null;
	}
}
