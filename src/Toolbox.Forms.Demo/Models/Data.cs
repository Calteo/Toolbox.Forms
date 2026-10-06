using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Toolbox.ComponentModel;

namespace Toolbox.Forms.Demo.Models
{
	internal class Data : NotifyObject
	{

		#region Id
		private int _id;
		public int Id
		{
			get => _id;
			set => SetField(ref _id, value);
		}
		#endregion

		#region Name
		private string _name = "";
		public string Name
		{
			get => _name;
			set => SetField(ref _name, value);
		}
		#endregion


	}
}
