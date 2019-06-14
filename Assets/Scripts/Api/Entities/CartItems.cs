﻿using System;

namespace Xsolla
{
	[Serializable]
	public class CartItems
	{
		public string cart_id;
		public bool is_free;
		public CartPrice price;
		public CartItem[] items;
	}
}