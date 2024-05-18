using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Stores
{
    public class CategoryStore
    {
		private Category _category;
		public Category Category
		{
			get { return _category; }
			set { _category = value; }
		}

	}
}
